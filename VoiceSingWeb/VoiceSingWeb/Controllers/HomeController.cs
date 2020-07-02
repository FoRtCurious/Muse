using System;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using BLL;
using VoiceSingWeb.Models;

namespace VoiceSingWeb.Controllers
{
    public class HomeController : Controller
    {
        MusicManager musicmanager = new MusicManager();

        #region 主页主视图
        public ActionResult Index()
        {
            HomeIndexViewModels homeViewModel = new HomeIndexViewModels();

            //根据用户收藏次数降序选择前8首原创歌曲
            homeViewModel.MusicRecommend = musicmanager.GetMusic().Where(o => o.UpType.typeName == "原创").OrderByDescending(o => o.music_like).Take(8);

            //根据4种歌曲类型选择前5首原创歌曲
            homeViewModel.GuFenMusic = musicmanager.GetMusic().Where(o => o.UpType.typeName == "原创").Where(o => o.MusicType.typeName == "古风").Take(5);
            homeViewModel.LiuXingMusic = musicmanager.GetMusic().Where(o => o.UpType.typeName == "原创").Where(o => o.MusicType.typeName == "流行").Take(5);
            homeViewModel.DianZiMusic = musicmanager.GetMusic().Where(o => o.UpType.typeName == "原创").Where(o => o.MusicType.typeName == "电子").Take(5);
            homeViewModel.MinYaoMusic = musicmanager.GetMusic().Where(o => o.UpType.typeName == "原创").Where(o => o.MusicType.typeName == "民谣").Take(5);

            //根据上传时间降序选择前5首原创歌曲
            homeViewModel.NewMusic = musicmanager.GetMusic().Where(o => o.UpType.typeName == "原创").OrderByDescending(o => o.upTime).Take(5);

            //根据播放次数降序选择前7首原创歌曲
            homeViewModel.HotMusic = musicmanager.GetMusic().Where(o => o.UpType.typeName == "原创").OrderByDescending(o => o.listen_times).Take(7);
            return View(homeViewModel);
        }
        #endregion

        #region 查找歌曲
        public ActionResult Search(string searchString)   
        {
            ViewBag.keyword = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                var musics = musicmanager.SearchMusic(searchString);
                ViewBag.sum = musics.Count();      //统计查询出歌曲的数量
                return View(musics);
            }
            else
            {
                ViewBag.sum = 0;
                return View();
            }

        }
        #endregion

    }
}