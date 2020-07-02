using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using System.Text.RegularExpressions;
using VoiceSingWeb.Models;
using PagedList;

namespace VoiceSingWeb.Controllers
{
    public class VideoController : Controller
    {
        VideoManager videomanager = new VideoManager();
        VideoCommentManager videocommentma = new VideoCommentManager();
        VideoTypeManager videotypema = new VideoTypeManager();

        #region 视频页底部视频分类
        public ActionResult Index()
        {
            var videotype = videotypema.GetVideoType();
            return View(videotype);
        }
        #endregion

        #region 按选中类分页展示视频
        public ActionResult VideoTypePageShow(string typeName, string currentFilter, int? page)
        {
            IEnumerable<Videos> videos = videomanager.GetVideo().Where(o => o.video_state == 1).OrderBy(o => o.VideoType.typeName);
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
                videos = videos.Where(x => x.VideoType.typeName == typeName);

            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return PartialView(videos.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region 搜索视频
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchVideo(FormCollection form)
        {
            string searchstr = form["searchtxt"];
            var videos = videomanager.SearchVideo(searchstr).Where(o => o.video_state == 1);
            return View(videos);
        } 
        #endregion

        #region 视频详情页视图
        public ActionResult Details(int id)
        {
            VideoDetailsIndexViewModels Vd = new VideoDetailsIndexViewModels();
            Vd.video = videomanager.GetVideo().Where(o => o.video_id == id).SingleOrDefault();
            //视频播放详情页右侧精品推荐
            Vd.VideoRecommd = videomanager.GetVideo().OrderByDescending(o => o.video_look).Take(6);
            //视频评论
            Vd.comment = videocommentma.GetVideoComment().Where(o => o.video_id == id).OrderByDescending(o => o.Comment_time);
            //播放次数加1
            videomanager.AddLookTime(Vd.video);     
            return View(Vd);
        }
        #endregion

        #region 视频播放详情页评论内容添加图片
        public ActionResult VideoUploadPic()
        {
            HttpPostedFileBase imageName = Request.Files[0];
            string file = null;
            try
            {
                file = imageName.FileName;
            }
            catch (Exception)
            {
                return Content("<script>alert('图片未能正常上传！');history.go(-1);</script>");
            }
            string fileFormat = file.Split('.')[file.Split('.').Length - 1]; // 以“.”截取，获取“.”后面的文件后缀
            Regex imageFormat = new Regex(@"^(bmp)|(png)|(gif)|(jpg)|(jpeg)"); // 验证文件后缀的正则表达式
            // 验证后缀不合格
            if (string.IsNullOrEmpty(file) || !imageFormat.IsMatch(fileFormat))
            {
                return Content("<script>alert('请上传正确格式照片！');history.go(-1);</script>");
            }
            // 验证后缀合格
            else
            {
                string timeStamp = DateTime.Now.Ticks.ToString(); // 获取当前时间的string类型
                string firstFileName = timeStamp.Substring(0, timeStamp.Length - 4); // 通过截取获得文件名
                string imageStr = "Content/images/videos/CommentImg/"; // 获取保存图片的项目文件夹
                string uploadPath = Server.MapPath("~/" + imageStr); // 将项目路径与文件夹合并

                string pictureFormat = file.Split('.')[file.Split('.').Length - 1];// 设置文件格式
                string fileName = firstFileName + "." + fileFormat;// 设置完整（文件名+文件格式） 
                string saveFile = uploadPath + fileName;//保存文件路径
                imageName.SaveAs(saveFile);// 保存文件
                var imageUrl = "../../Content/images/videos/CommentImg/" + fileName;// 设置数据库保存的路径
                var CkeditorFuncNum = System.Web.HttpContext.Current.Request["CKEditorFuncNum"];
                return Content("<script>window.parent.CKEDITOR.tools.callFunction(" + CkeditorFuncNum + ", \"" + imageUrl + "\");</script>");
            }
        }
        #endregion
        
    }
}