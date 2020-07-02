using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using VoiceSingWeb.Models;

namespace VoiceSingWeb.Controllers
{
    public class AccompanyMusicController : Controller
    {
        AccompanyMusicManager acmmanager = new AccompanyMusicManager();
        UserManager usmaneger = new UserManager();

        #region 伴奏页主视图
        public ActionResult Index()
        {
            AccompanyMusicIndexViewModels Am = new AccompanyMusicIndexViewModels();
            //热门伴奏,根据下载量选择前18首
            Am.HotAccompanyMusic = acmmanager.GetAccompanyMusic().OrderByDescending(o => o.music_down).Take(18);

            //名人堂,根据用户点赞量选择前8位
            Am.Singers = usmaneger.GetUser().OrderByDescending(o => o.user_fans).Take(8);

            //最新更新，根据更新时间选择前12首
            Am.NewUpAccompanyMusic = acmmanager.GetAccompanyMusic().OrderByDescending(o => o.music_upTime).Take(12);

            //下载排行，根据下载次数选择前20首
            Am.RankAccompanyMusic = acmmanager.GetAccompanyMusic().OrderByDescending(o => o.music_down).Take(20);

            return View(Am);
        }
        #endregion

        #region 伴奏查询
        public ActionResult SearchAccompany(string search)
        {
            ViewBag.keyword = search;
            if (!String.IsNullOrEmpty(search))
            {
                var cmmusic = acmmanager.SearchAccompanyMusic(search);
                ViewBag.sum = cmmusic.Count();                                                                               //统计查询出歌曲的数量
                return View(cmmusic);
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