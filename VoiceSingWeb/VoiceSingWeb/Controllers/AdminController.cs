using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL;
using PagedList;
using Models;
using VoiceSingWeb.Models;
using System.IO;
using System.Web;

namespace VoiceSingWeb.Controllers
{
    public class AdminController : Controller
    {
        AdminManager adminmanager = new AdminManager();
        #region 管理员登录
        //GET:
        public ActionResult Login()
        {
            return View();
        }
        //POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string admin_id, string admin_pwd)
        {
            try
            {
                var admin = adminmanager.Login(admin_id, admin_pwd);
                if (admin != null)
                {
                    Session["admin_id"] = admin.adminId;
                    return Content("success");
                }
                else
                {
                    return Content("fail");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }
        #endregion

        #region 管理员注销登录
        public ActionResult Loginout()
        {
            Session["admin_id"] = null;
            return Redirect("/Home/Index");
        }
        #endregion

        //用户管理
        UserManager usermanager = new UserManager();        
        UserSingerApplyManager userapplyma = new UserSingerApplyManager();
        AccusedUsersManager accusedma = new AccusedUsersManager();
        #region 系统主页
        public ActionResult Index()
        {
            if (Session["admin_id"] != null)
            {
                return View();
            }
            else
            {
                return Content("<script>alert('您还未登录');location='../../Admin/Login'</script>");
            }
        } 
        #endregion

        #region 注册用户库
        public ActionResult Users()
        {
            if (Session["admin_id"] != null)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView();//Ajax.ActionLink
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return Content("<script>alert('您还未登录');location='../../Admin/Login'</script>");
            }
        }
        #endregion       

        #region 系统用户信息分页数据接口
        public JsonResult SystemUsers(int page, int limit)
        {
            List<Users> users = usermanager.GetUserJson();
            var list = users.Skip((page - 1) * limit).Take(limit).ToList();
            int Count = users.Count;
            return Json(new { code = 0, count = Count, data = list, msg = "" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 查询注册用户
        public JsonResult SearchUser(int page, int limit, int search_id)
        {
            Users user = usermanager.SearchUserById(search_id);
            List<Users> list = new List<Users>();
            list.Add(user);
            int Count = list.Count();
            return Json(new { code = 0, count = Count, data = list, msg = "" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 查看用户
        public ActionResult UserDetails(int id)
        {
            var user = usermanager.GetUserById(id);
            return View(user);
        }
        #endregion

        #region 修改用户页
        public ActionResult EditUserInfo(int id)
        {
            var user = usermanager.GetUserById(id);
            return View(user);
        }
        #endregion

        #region 提交用户信息修改
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEditUser(FormCollection form)
        {
            int id = Convert.ToInt32(form["userId"]);
            var user = usermanager.GetUserById(id);
            user.phone_num = form["phone"];
            user.name = form["name"];
            user.password = form["password"];
            user.user_sex = form["sex"];
            user.userType_id = Convert.ToInt32(form["usertype"]);
            user.user_info = form["intruduce"];
            string msg = usermanager.EditUser(id,user);
            if (msg == "success")
            {
                return Content("修改成功");
            }
            else
                return Content("修改失败");
        } 
        #endregion       

        #region 音悦人申请
        public ActionResult UserSingerApply()
        {
            if (Session["admin_id"] != null)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView();//Ajax.ActionLink
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return Content("<script>alert('您还未登录');location='../../Admin/Login'</script>");
            }
        }
        #endregion       

        #region 音悦人申请数据接口        
        public JsonResult GetUserSingerApply(int page,int limit)
        {
            List<UserSingerApply> usersapply = userapplyma.GetUserSingerApply();
            var list = usersapply.Skip((page - 1) * limit).Take(limit).ToList();
            int Count = usersapply.Count;
            return Json(new { code = 0, count = Count, data = list, msg = "" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 申请条件
        public ActionResult ApplyDetails(int id)
        {
            UserSingerInfoViewModels singer = new UserSingerInfoViewModels();
            singer.user = usermanager.GetUserById(id);
            singer.musics = musicmanager.GetMusicByUserId(id);
            return View(singer);
        }
        #endregion

        #region 通过申请
        public JsonResult AgreeApply(int Pno, int userId)
        {
            int suc = userapplyma.AgreeApply(userId);
            int deal = userapplyma.DealResult(Pno);
            if (suc == 1 && deal == 1)
            {
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 驳回申请
        public JsonResult BackApply(int Pno)
        {
            var result = userapplyma.DealResult(Pno);
            if (result == 1)
            {
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 被举报用户
        public ActionResult AccusedUsers()
        {
            if (Session["admin_id"] != null)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView();//Ajax.ActionLink
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return Content("<script>alert('您还未登录');location='../../Admin/Login'</script>");
            }
        }
        #endregion

        #region 被举报用户数据接口        
        public JsonResult AccusedUsersJson(int page, int limit)
        {
            List<AccusedUsers> users = accusedma.GetAccusedUsers();
            var list = users.Skip((page - 1) * limit).Take(limit).ToList();
            int Count = users.Count;
            return Json(new { code = 0, count = Count, data = list, msg = "" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 违规原因
        public ActionResult AccusedReasons(int id)
        {
            var accused = accusedma.GetAccusedById(id);
            return View(accused);
        }
        #endregion

        #region 驳回举报
        public JsonResult BackAccused(int accusedid)
        {
            var result = accusedma.DealResult(accusedid);
            if (result == 1)
            {
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
        } 
        #endregion

        #region 查封用户
        public JsonResult CloseDownUser(int accusedid,int userId)
        {
            int suc = usermanager.CloseDownUser(userId);
            int deal = accusedma.DealResult(accusedid);
            if (suc == 1 && deal == 1 )
            {
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
        }
        #endregion        

        #region 已冻结用户
        public ActionResult BeCloseDownUser()
        {
            if (Session["admin_id"] != null)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView();//Ajax.ActionLink
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return Content("<script>alert('您还未登录');location='../../Admin/Login'</script>");
            }
        }
        #endregion       

        #region 已冻结用户数据接口
        public JsonResult CloseDownUsers(int page, int limit)
        {
            List<Users> closeusers = usermanager.GetCloseDownUserJson();
            var list = closeusers.Skip((page - 1) * limit).Take(limit).ToList();
            int Count = closeusers.Count;
            return Json(new { code = 0, count = Count, data = list, msg = "" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 解封用户
        public JsonResult OpenUser(int id)
        {
            int suc = usermanager.OpenUser(id);
            if (suc == 1)
            {
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //音乐管理
        MusicManager musicmanager = new MusicManager();
        MusicTypeManager musictypema = new MusicTypeManager();
        #region 系统音乐库
        public ActionResult Musics()
        {
            if (Session["admin_id"] != null)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView();//Ajax.ActionLink
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return Content("<script>alert('您还未登录');location='../../Admin/Login'</script>");
            }
        }
        #endregion       

        #region 系统音乐库数据接口
        public JsonResult SystemMusic(int page, int limit)
        {
            List<UserMusics> musics = musicmanager.GetMusicJson();
            var list = musics.Where(o => o.music_check ==1).Skip((page - 1) * limit).Take(limit).ToList();
            int Count = musics.Count;
            return Json(new { code = 0, count = Count, data = list, msg = "" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 查询系统音乐
        public JsonResult SearchMusic(int page, int limit, int search_id)
        {
            UserMusics music = musicmanager.SearchMusicById(search_id);
            List<UserMusics> list = new List<UserMusics>();
            list.Add(music);
            int Count = list.Count();
            return Json(new { code = 0, count = Count, data = list, msg = "" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 查看音乐
        public ActionResult MusicDetails(int id)
        {
            var music = musicmanager.GetMusicById(id);
            return View(music);
        }
        #endregion

        #region 下架音乐
        public JsonResult CloseMusic(int id)
        {
            string msg = musicmanager.CloseMusic(id);
            if(msg == "success")
            {
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { code = 504 }, JsonRequestBehavior.AllowGet);
        } 
        #endregion

        #region 待审核音乐
        public ActionResult CheckMusics()
        {
            if (Session["admin_id"] != null)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView();//Ajax.ActionLink
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return Content("<script>alert('您还未登录');location='../../Admin/Login'</script>");
            }
        }
        #endregion
                
        #region 待审核音乐数据接口
        public JsonResult CheckMusicsJson(int page, int limit)
        {
            List<UserMusics> checkmusics = musicmanager.GetMusicJson();
            var list = checkmusics.Where(o =>o.music_check == 0).Skip((page - 1) * limit).Take(limit).ToList();
            int Count = checkmusics.Count;
            return Json(new { code = 0, count = Count, data = list, msg = "" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 浏览审核音乐
        public ActionResult ScanCheckMusic(int id)
        {
            var music = musicmanager.GetMusicById(id);
            return View(music);
        }
        #endregion

        #region 音乐审核通过
        public JsonResult AgreeCheck(int id)
        {
            string suc = musicmanager.AgreeCheck(id);
            string msg = musicmanager.OpenMusic(id);
            if (suc == "success" && msg =="success")
            {
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 音乐审核不通过
        public JsonResult UnAgreeCheck(int id)
        {
            string suc = musicmanager.UnAgreeCheck(id);
            if (suc == "success")
            {
                int flag;
                var deletemusic = musicmanager.GetMusicById(id);
                var picName = Path.GetFileName(deletemusic.imgage_url);
                var sourceName = Path.GetFileName(deletemusic.music_url);
                var deletemusicPicUrl = Server.MapPath("~/Content/images/musics/" + picName);
                var deletemusicSourceUrl = Server.MapPath("~/Content/source/music-source/" + sourceName);
                if (System.IO.File.Exists(deletemusicPicUrl) && System.IO.File.Exists(deletemusicSourceUrl))
                {
                    System.IO.File.Delete(deletemusicPicUrl);   //删除歌曲图片
                    System.IO.File.Delete(deletemusicSourceUrl);    //删除歌曲资源
                    flag = 200;
                }
                else
                {
                    flag = 500;
                }
                return Json(new { code = flag }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 已下架歌曲
        public ActionResult DownMusics()
        {
            if (Session["admin_id"] != null)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView();//Ajax.ActionLink
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return Content("<script>alert('您还未登录');location='../../Admin/Login'</script>");
            }
        }
        #endregion

        #region 已下架歌曲数据接口
        public JsonResult DownMusicJson(int page,int limit)
        {
            List<UserMusics> downmusics = musicmanager.GetMusicJson();
            var list = downmusics.Where(o => o.music_state == 0 && o.music_check ==1).Skip((page - 1) * limit).Take(limit).ToList();
            int Count = downmusics.Count;
            return Json(new { code = 0, count = Count, data = list, msg = "" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 上架歌曲
        public JsonResult OpenMusic(int id)
        {
            string msg = musicmanager.OpenMusic(id);
            if (msg == "success")
            {
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { code = 504 }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 发布官方音乐页面        
        public ActionResult PublishMusic()
        {
            if (Session["admin_id"] != null)
            {
                if (Request.IsAjaxRequest())
                {
                    ViewBag.MusicType = new SelectList(musictypema.GetMusicType(), "typeId", "typeName");
                    ViewBag.UpType = new SelectList(musicmanager.GetUpType(), "typeId", "typeName");
                    return PartialView();
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return Content("<script>alert('您还未登录');location='../../Admin/Login'</script>");
            }
        }
        #endregion

        #region 上传歌曲海报
        public JsonResult UpMusicImg()
        {
            string src = "";
            HttpPostedFileBase file = Request.Files[0];
            string savefilePath = "";
            //判断文件是否为空
            if (file != null)
            {
                //获取文件类型
                string fileExtension = Path.GetExtension(file.FileName);
                //自定义文件名（时间+唯一标识符+后缀）
                string fileName = DateTime.Now.ToString("yyyy-MM-dd") + Guid.NewGuid() + fileExtension;
                //判断是否存在需要的目录，不存在则创建 
                if (!Directory.Exists(Server.MapPath("~/Content/images/originMusics")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Content/images/originMusics"));
                }
                //拼接保存文件的详细路径
                savefilePath = Server.MapPath("~/Content/images/originMusics/") + fileName;
                //若扩展名不为空则判断文件是否是指定视频类型
                if (fileExtension != null)
                {
                    if ("(.bmp)|(.png)|(.jpg)|(.gif)|(.jpeg)|(.BMP)|(.PNG)|(.JPG)|(.GIF)|(.JPEG)".Contains(fileExtension))
                    {
                        //拼接返回的Img标签
                        src = "../../Content/images/originMusics/" + fileName;
                    }
                    file.SaveAs(savefilePath);
                    return Json(new { code = 200, url = src }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { code = 500, url = src }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                src = null;
                return Json(new { code = 500, url = src }, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region 上传歌曲文件
        public JsonResult UpMusicFile()
        {
            string url = "";
            HttpPostedFileBase file = Request.Files[0];
            string savefilePath = "";
            //判断文件是否为空
            if (file != null)
            {
                //获取文件类型
                string fileExtension = Path.GetExtension(file.FileName);
                //自定义文件名（时间+唯一标识符+后缀）
                string fileName = DateTime.Now.ToString("yyyy-MM-dd") + Guid.NewGuid() + fileExtension;
                //判断是否存在需要的目录，不存在则创建 
                if (!Directory.Exists(Server.MapPath("~/Content/source/originMusic-source")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Content/source/originMusic-source"));
                }
                //拼接保存文件的详细路径
                savefilePath = Server.MapPath("~/Content/source/originMusic-source/") + fileName;
                //若扩展名不为空则判断文件是否是指定视频类型
                if (fileExtension != null)
                {
                    if ("(.mp3)|(.wma)|(.wav))".Contains(fileExtension))
                    {
                        //拼接返回的Img标签
                        url = "../../Content/source/originMusic-source/" + fileName;
                    }
                    file.SaveAs(savefilePath);
                    return Json(new { code = 200, url = url }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { code = 500, url = url }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                url = null;
                return Json(new { code = 500, url = url }, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region 提交发布歌曲
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PublishNewMusic(FormCollection form)
        {
            UserMusics music = new UserMusics();
            music.user_id = 20191165;   //官方指定账号
            music.music_name = form["name"];
            music.imgage_url = form["img"];
            music.music_url = form["music"];
            music.musicType_id = Convert.ToInt32(form["MusicType"]);
            music.upType_id = Convert.ToInt32(form["UpType"]);
            music.music_info = form["intruduce"];
            music.music_state = Convert.ToInt32(form["music_state"]);
            music.music_like = 0;
            music.listen_times = 0;
            music.upTime = DateTime.Now;
            music.music_check = 1;
            string msg = musicmanager.AddMusic(music);
            if(msg == "success")
            {
                return Content("suc");
            }
            else
            {
                return Content("fail");
            }
        } 
        #endregion

        //视频管理
        VideoManager videomanager = new VideoManager();

        #region 系统视频库
        public ActionResult Videos()
        {
            if (Session["admin_id"] != null)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView();//Ajax.ActionLink
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return Content("<script>alert('您还未登录');location='../../Admin/Login'</script>");
            }
        }
        #endregion       

        #region 系统视频库数据接口
        public JsonResult SystemVideo(int page, int limit)
        {
            List<Videos> videos = videomanager.GetVideoJson();
            var list = videos.Where(o => o.video_check == 1).Skip((page - 1) * limit).Take(limit).ToList();
            int Count = videos.Count;
            return Json(new { code = 0, count = Count, data = list, msg = "" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 查询系统视频
        public JsonResult SearchVideo(int page, int limit, int search_id)
        {
            Videos video = videomanager.SearchVideoById(search_id);
            List<Videos> list = new List<Videos>();
            list.Add(video);
            int Count = list.Count();
            return Json(new { code = 0, count = Count, data = list, msg = "" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 查看视频信息
        public ActionResult VideoDetails(int id)
        {
            var video = videomanager.GetVideoById(id);
            return View(video);
        }
        #endregion

        #region 下架视频
        public JsonResult CloseVideo(int id)
        {
            string msg = videomanager.CloseVideo(id);
            if (msg == "success")
            {
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { code = 504 }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 待审核视频
        public ActionResult CheckVideos()
        {
            if (Session["admin_id"] != null)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView();//Ajax.ActionLink
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return Content("<script>alert('您还未登录');location='../../Admin/Login'</script>");
            }
        }
        #endregion

        #region 待审核视频数据接口
        public JsonResult CheckVideosJson(int page, int limit)
        {
            List<Videos> checkmusics = videomanager.GetVideoJson();
            var list = checkmusics.Where(o => o.video_check == 0).Skip((page - 1) * limit).Take(limit).ToList();
            int Count = checkmusics.Count;
            return Json(new { code = 0, count = Count, data = list, msg = "" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 浏览待审核视频
        public ActionResult ScanCheckVideo(int id)
        {
            var video = videomanager.GetVideoById(id);
            return View(video);
        }
        #endregion

        #region 视频审核通过
        public JsonResult AgreeVideoCheck(int id)
        {
            string suc = videomanager.AgreeVideoCheck(id);
            string msg = videomanager.OpenVideo(id);
            if (suc == "success" && msg == "success")
            {
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 视频审核不通过
        public JsonResult UnAgreeVideoCheck(int id)
        {
            string suc = videomanager.UnAgreeVideoCheck(id);
            if (suc == "success")
            {
                int flag;
                var deletevideo = videomanager.GetVideoById(id);
                var picName = Path.GetFileName(deletevideo.video_photo);
                var sourceName = Path.GetFileName(deletevideo.video_url);
                var deletevideoPicUrl = Server.MapPath("~/Content/images/videos/" + picName);
                var deletevideoSourceUrl = Server.MapPath("~/Content/source/video-source/" + sourceName);
                if (System.IO.File.Exists(deletevideoPicUrl) && System.IO.File.Exists(deletevideoSourceUrl))
                {
                    System.IO.File.Delete(deletevideoPicUrl);   //删除视频图片
                    System.IO.File.Delete(deletevideoSourceUrl);    //删除视频资源
                    flag = 200;
                }
                else
                {
                    flag = 500;
                }
                return Json(new { code = flag }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 已下架视频
        public ActionResult DownVideos()
        {
            if (Session["admin_id"] != null)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView();//Ajax.ActionLink
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return Content("<script>alert('您还未登录');location='../../Admin/Login'</script>");
            }
        }
        #endregion

        #region 已下架视频数据接口
        public JsonResult DownVideoJson(int page, int limit)
        {
            List<Videos> downvideos = videomanager.GetVideoJson();
            var list = downvideos.Where(o => o.video_state == 0 && o.video_check == 1).Skip((page - 1) * limit).Take(limit).ToList();
            int Count = downvideos.Count;
            return Json(new { code = 0, count = Count, data = list, msg = "" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 上架视频
        public JsonResult OpenVideo(int id)
        {
            string msg = videomanager.OpenVideo(id);
            if (msg == "success")
            {
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { code = 504 }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 发布官方视频页面
        VideoTypeManager videotypema = new VideoTypeManager();
        public ActionResult PublishVideo()
        {
            if (Session["admin_id"] != null)
            {
                if (Request.IsAjaxRequest())
                {
                    ViewBag.VideoType = new SelectList(videotypema.GetVideoType(), "typeId", "typeName");
                    return PartialView();
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return Content("<script>alert('您还未登录');location='../../Admin/Login'</script>");
            }
        }
        #endregion

        #region 上传视频海报
        public JsonResult UpVideoImg()
        {
            string src = "";
            HttpPostedFileBase file = Request.Files[0];
            string savefilePath = "";
            //判断文件是否为空
            if (file != null)
            {
                //获取文件类型
                string fileExtension = Path.GetExtension(file.FileName);
                //自定义文件名（时间+唯一标识符+后缀）
                string fileName = DateTime.Now.ToString("yyyy-MM-dd") + Guid.NewGuid() + fileExtension;
                //判断是否存在需要的目录，不存在则创建 
                if (!Directory.Exists(Server.MapPath("~/Content/images/videos/videos-post")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Content/images/videos/videos-post"));
                }
                //拼接保存文件的详细路径
                savefilePath = Server.MapPath("~/Content/images/videos/videos-post/") + fileName;
                //若扩展名不为空则判断文件是否是指定视频类型
                if (fileExtension != null)
                {
                    if ("(.bmp)|(.png)|(.jpg)|(.gif)|(.jpeg)|(.BMP)|(.PNG)|(.JPG)|(.GIF)|(.JPEG)".Contains(fileExtension))
                    {
                        //拼接返回的Img标签
                        src = "../../Content/images/videos/videos-post/" + fileName;
                    }
                    file.SaveAs(savefilePath);
                    return Json(new { code = 200, url = src }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { code = 500, url = src }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                src = null;
                return Json(new { code = 500, url = src }, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region 上传视频文件
        public JsonResult UpVideoFile()
        {
            string url = "";
            HttpPostedFileBase file = Request.Files[0];
            string savefilePath = "";
            //判断文件是否为空
            if (file != null)
            {
                //获取文件类型
                string fileExtension = Path.GetExtension(file.FileName);
                //自定义文件名（时间+唯一标识符+后缀）
                string fileName = DateTime.Now.ToString("yyyy-MM-dd") + Guid.NewGuid() + fileExtension;
                //判断是否存在需要的目录，不存在则创建 
                if (!Directory.Exists(Server.MapPath("~/Content/source/video-source")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Content/source/video-source"));
                }
                //拼接保存文件的详细路径
                savefilePath = Server.MapPath("~/Content/source/video-source/") + fileName;
                //若扩展名不为空则判断文件是否是指定视频类型
                if (fileExtension != null)
                {
                    if ("(.mp4)|(.avi)|(.flv)|(.rmvb)|(.wmv)".Contains(fileExtension))
                    {
                        //拼接返回的Img标签
                        url = "../../Content/source/video-source/" + fileName;
                    }
                    file.SaveAs(savefilePath);
                    return Json(new { code = 200, url = url }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { code = 500, url = url }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                url = null;
                return Json(new { code = 500, url = url }, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region 提交发布视频
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PublishNewVideo(FormCollection form)
        {
            Videos video = new Videos();
            video.user_id = 20191165;   //官方指定账号
            video.video_name = form["name"];
            video.video_photo = form["img"];
            video.video_url = form["video"];
            video.videoType_id = Convert.ToInt32(form["VideoType"]);
            video.relate_music = form["relamusic"];
            video.video_info = form["intruduce"];
            video.video_state = Convert.ToInt32(form["video_state"]);
            video.video_look = 0;
            video.video_upTime = DateTime.Now;
            video.video_check = 1;
            string msg = videomanager.AddVideo(video);
            if (msg == "success")
            {
                return Content("suc");
            }
            else
            {
                return Content("fail");
            }
        }
        #endregion

        //活动管理

        //圈子管理

        //商城管理
        GoodsManager goodsmanager = new GoodsManager();
        GoodsTypeManager goodtypemanager = new GoodsTypeManager();
        OrderdetailsManager orderdetailsma = new OrderdetailsManager();
        OrdersManager ordersma = new OrdersManager();
        ReceiptAddressManager addressma = new ReceiptAddressManager();

        #region 搜索商品
        public ActionResult SearchGood(string searchId)
        {
            int id = Convert.ToInt32(searchId);
            var good = goodsmanager.Getgooddetails(id);
            ViewBag.goodType = new SelectList(goodtypemanager.GetGoodsType(), "goodstypeid", "typename");
            return PartialView(good);
        } 
        #endregion

        #region 已上架商品
        public ActionResult Products(int? page)
        {
            if (Session["admin_id"] != null)
            {
                if (Request.IsAjaxRequest())
                {
                    ViewBag.goodType = new SelectList(goodtypemanager.GetGoodsType(), "goodstypeid", "typename");
                    var goods = goodsmanager.GetGoods().Where(o => o.good_state == 1);
                    int pageSize = 16;
                    int pageNumber = (page ?? 1);
                    return PartialView(goods.ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return Content("<script>alert('您还未登录');location='../../Admin/Login'</script>");
            }
        }
        #endregion

        #region 编辑商品
        public ActionResult EditProduct(int goodid)
        {
            if (Session["admin_id"] != null)
            {
                if (Request.IsAjaxRequest())
                {
                    ViewBag.goodType = new SelectList(goodtypemanager.GetGoodsType(), "goodstypeid", "typename");
                    var good = goodsmanager.Getgooddetails(goodid);
                    return PartialView(good);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return Content("<script>alert('您还未登录');location='../../Admin/Login'</script>");
            }            
        }
        #endregion

        #region 提交修改
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitEdit(FormCollection form)
        {
            int id = Convert.ToInt32(form["goodid"]);
            var good = goodsmanager.Getgooddetails(id);
            good.goodsname = form["name"];
            good.goodstypeid = Convert.ToInt32(form["goodType"]);
            good.price = Convert.ToDecimal(form["price"]);
            good.good_store = Convert.ToInt32(form["store"]);
            if (form["comment"] == "on")
            {
                good.comment_state = 1;
            }
            else
            {
                good.comment_state = 0;
            }
            good.good_state = Convert.ToInt32(form["state"]);
            good.img = form["img"];
            string msg = goodsmanager.UpdateGood(id, good);
            if(msg == "success")
            {
                return Content("suc");
            }
            else
                return Content("fail");
        } 
        #endregion

        #region 新增上架商品
        public ActionResult UpNewProduct()
        {
            if (Session["admin_id"] != null)
            {
                if (Request.IsAjaxRequest())
                {
                    ViewBag.goodType = new SelectList(goodtypemanager.GetGoodsType(), "goodstypeid", "typename");
                    return PartialView();
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return Content("<script>alert('您还未登录');location='../../Admin/Login'</script>");
            }
        }
        #endregion

        #region 上传商品图片
        public JsonResult UpGoodImg()
        {
            string src = "";
            HttpPostedFileBase file = Request.Files[0];
            string savefilePath = "";
            //判断文件是否为空
            if (file != null)
            {
                //获取文件类型
                string fileExtension = Path.GetExtension(file.FileName);
                //自定义文件名（时间+唯一标识符+后缀）
                string fileName = DateTime.Now.ToString("yyyy-MM-dd") + Guid.NewGuid() + fileExtension;
                //判断是否存在需要的目录，不存在则创建 
                if (!Directory.Exists(Server.MapPath("~/Content/images/shopping/goods")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Content/images/shopping/goods"));
                }
                //拼接保存文件的详细路径
                savefilePath = Server.MapPath("~/Content/images/shopping/goods/") + fileName;
                //若扩展名不为空则判断文件是否是指定视频类型
                if (fileExtension != null)
                {
                    if ("(.bmp)|(.png)|(.jpg)|(.gif)|(.jpeg)|(.BMP)|(.PNG)|(.JPG)|(.GIF)|(.JPEG)".Contains(fileExtension))
                    {
                        //拼接返回的Img标签
                        src = "../../Content/images/shopping/goods/" + fileName;
                    }
                    file.SaveAs(savefilePath);
                    return Json(new { code = 200, url = src }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { code = 500, url = src }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                src = null;
                return Json(new { code = 500, url = src }, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region 提交新增商品
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitGoods(FormCollection form)
        {
            Goods good = new Goods();
            good.goodsname = form["name"];
            good.goodstypeid = Convert.ToInt32(form["goodType"]);           
            good.price = Convert.ToDecimal(form["price"]);
            good.good_store = Convert.ToInt32(form["store"]);
            if (form["comment"] == "on")
            {
                good.comment_state = 1;
            }
            else
            {
                good.comment_state = 0;
            }           
            good.good_state = Convert.ToInt32(form["state"]);
            good.img = form["img"];
            string msg = goodsmanager.AddGood(good);
            if (msg == "success")
            {
                return Content("suc");
            }
            else
                return Content("fail");
        }
        #endregion

        #region 已下架商品
        public ActionResult DownProducts(int? page)
        {
            if (Session["admin_id"] != null)
            {
                if (Request.IsAjaxRequest())
                {
                    ViewBag.goodType = new SelectList(goodtypemanager.GetGoodsType(), "goodstypeid", "typename");
                    var goods = goodsmanager.GetGoods().Where(o => o.good_state == 0);
                    int pageSize = 16;
                    int pageNumber = (page ?? 1);
                    return PartialView(goods.ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return Content("<script>alert('您还未登录');location='../../Admin/Login'</script>");
            }
        }
        #endregion

        #region 用户订单信息
        public ActionResult UserOrders()
        {
            if (Session["admin_id"] != null)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView();
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return Content("<script>alert('您还未登录');location='../../Admin/Login'</script>");
            }
        }
        #endregion        

        #region 用户订单信息分页数据接口
        public JsonResult Orders(int page, int limit)
        {
            List<Orders> orders = ordersma.GetOrdersJson();
            var list = orders.Skip((page - 1) * limit).Take(limit).ToList();
            int Count = orders.Count;
            return Json(new { code = 0, count = Count, data = list, msg = "" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 获取Json用户集
        public JsonResult GetUsersJson()
        {
            List<Users> users = usermanager.GetUserJson();
            int Count = users.Count;
            return Json(new { code = 0, count = Count, data = users, msg = "" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 用户收货地址数据接口
        public JsonResult ReceiptAddress()
        {
            List<Receipt_address> address = addressma.GetReceiptAddressJson();
            int Count = address.Count;
            return Json(new { code = 0, count = Count, data = address, msg = "" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 订单详情
        public ActionResult OrdersDetails(int id)
        {
            if (Session["admin_id"] != null)
            {
                OrderDetailsViewModels orderdetailsview = new OrderDetailsViewModels();
                orderdetailsview.orderdetails = orderdetailsma.GetOrderdetailsByOrderId(id);
                orderdetailsview.order = ordersma.GetOrderById(id);
                return View(orderdetailsview);
            }
            else
            {
                return Content("<script>alert('您还未登录');location='../../Admin/Login'</script>");
            }
        }
        #endregion

        #region 商城销售数据
        public ActionResult MarketSaleData()
        {
            return View();
        }
        #endregion
    }
}
