using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using VoiceSingWeb.Models;
using PagedList;
using Models;

namespace VoiceSingWeb.Controllers
{
    public class MusicController : Controller
    {
        MusicManager musicmanager = new MusicManager();
        MusicTypeManager mtm = new MusicTypeManager();
        UserManager usermanage = new UserManager();
        VideoManager videomanager = new VideoManager();
        MusicCommentManager commentma = new MusicCommentManager();

        #region 原创页视图
        public ActionResult OriginMusic()
        {
            OriginMusicIndexViewModels Om = new OriginMusicIndexViewModels();
            //优质原创,根据点赞数选择前6首
            Om.BestOriginMusic = musicmanager.GetOriginMusic().Where(o => o.music_check == 1 && o.music_state == 1).OrderByDescending(o => o.music_like).Take(6);
            //排行榜,根据点赞数选择前14首
            Om.rankMusic = musicmanager.GetOriginMusic().Where(o => o.music_check == 1 && o.music_state == 1).OrderByDescending(o => o.music_like).Take(14);
            //热门音乐人,根据用户关注量选择前6人
            Om.Singers = usermanage.GetUser().OrderByDescending(o => o.user_fans).Take(6);
            //今日推荐,根据播放次数选择前16首
            Om.ToDayRecommendMusic = musicmanager.GetOriginMusic().Where(o => o.music_check == 1 && o.music_state == 1).OrderByDescending(o => o.listen_times).Take(16);
            //最新上传,根据原创上传时间排序，选择前13首
            Om.newUpMusic = musicmanager.GetOriginMusic().Where(o => o.music_check == 1 && o.music_state == 1).OrderByDescending(o => o.upTime).Take(13);
            return View(Om);
        }
        #endregion

        #region 原创音乐子页音乐随心听
        public ActionResult OriginOptionMusic(int? page)
        {
            var musics = musicmanager.GetMusic().Where(o => o.music_check == 1 && o.music_state == 1).OrderBy(o => Guid.NewGuid()).Take(40);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return PartialView(musics.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region 翻唱页视图
        public ActionResult CoverMusic()
        {
            CoverMusicIndexViewModels Cm = new CoverMusicIndexViewModels();

            //优质翻唱,根据点赞量选择前6首
            Cm.BestCoverMusic = musicmanager.GetCoverMusic().OrderByDescending(o => o.music_like).Take(6);

            //音乐嗨翻天，根据歌曲播放量选择前14首
            Cm.MusicHappy = musicmanager.GetCoverMusic().OrderByDescending(o => o.listen_times).Take(14);

            //热播视频,根据视频播放量选择前4个
            Cm.HotVideo = videomanager.GetVideo().OrderByDescending(o => o.video_look).Take(4);

            //网友自荐，musics表前11首
            Cm.SelfRecommend = musicmanager.GetCoverMusic().Take(11);

            //24小时最热,根据点赞量选择前10首
            Cm.DayHotMusic = musicmanager.GetCoverMusic().OrderByDescending(o => o.music_like).Skip(1).Take(10);

            //最新上传翻唱，按上传时间排序，选择前12首
            Cm.newUpMusic = musicmanager.GetCoverMusic().OrderByDescending(o => o.upTime).Take(15);

            return View(Cm);
        }
        #endregion

        #region 音乐播放详情页视图
        public ActionResult Details(int id)
        {
            MusicDetailIndexViewModels Md = new MusicDetailIndexViewModels();
            Md.music = musicmanager.GetMusic().Where(o => o.music_id == id).SingleOrDefault();
            musicmanager.AddListenTime(Md.music);
            //随机选出5首作为猜你喜欢
            Md.GuessYouLike = musicmanager.GetMusic().OrderBy(o => Guid.NewGuid()).Take(5);
            //今日热门，根据歌曲点赞量选择前5首
            Md.TodayHotMusic = musicmanager.GetMusic().OrderByDescending(o => o.music_like).Take(6);
            //歌曲评论
            Md.Comment = commentma.GetMusicCommentByMusicId(id).OrderByDescending(o => o.Comment_time);
            return View(Md);
        }
        #endregion

        #region 更多歌曲类型
        public ActionResult MoreMusicType()
        {
            var type = mtm.GetMusicType();
            return View(type);
        }
        #endregion

        #region 按选中类分页展示歌曲
        public ActionResult MusicTypePageShow(string typeName, string currentFilter, int? page)
        {
            IEnumerable<UserMusics> music = musicmanager.GetMusic().OrderBy(o => o.MusicType.typeName);
            if (typeName != null)
            {
                page = 1;
            }
            else
            {
                typeName = currentFilter;
            }
            ViewBag.CurrentFilter = typeName;
            if (!String.IsNullOrEmpty(typeName))
            {
                music = music.Where(x => x.MusicType.typeName == typeName);

            }
            int pageSize = 18;
            int pageNumber = (page ?? 1);

            return PartialView(music.ToPagedList(pageNumber, pageSize));
        }
        #endregion
    }
}