using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoiceSingWeb.Models;
using System.IO;
using System.Data.Entity.Validation;
using BLL;
using Models;

namespace VoiceSingWeb.Controllers
{
    public class UserManageController: Controller
    {
        UserManager usermanager = new UserManager();
        User_friendsManager userfriendsma = new User_friendsManager();
        MusicManager musicma = new MusicManager();
        MusicTypeManager mtypemusic = new MusicTypeManager();
        MusicCommentManager musiccommentma = new MusicCommentManager();
        VideoManager videoma = new VideoManager();
        VideoTypeManager videotypemanager = new VideoTypeManager();
        VideoCommentManager videocommentma = new VideoCommentManager();
        CircleManager circlemanager = new CircleManager();
        MusicCollectRecordManager musiccolrecordma = new MusicCollectRecordManager();
        VideoCollectRecordManager videocolrecordma = new VideoCollectRecordManager();

        #region 登录
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string userId,string password)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string data;
                    var user = usermanager.Login(userId,password);
                    if (user != null)
                    {
                        Session["UserId"] = user.userId;               //保存用户id
                        Session["Username"] = user.name;               //保存用户名
                        Session["Userphoto"] = user.photo;             //保存用户头像路径
                        data = "success";
                        return Content(data);
                    }
                    else
                    {
                        data = "fault";
                        return Content(data);
                    }
                }
                catch (Exception ex)
                {
                    return Content(ex.Message);
                }
            }
            else
            {
                return Content("<script>alert('页面验证失败！');</script>");
            }

        }
        #endregion

        #region 注销登录
        public string LoginOut()   
        {
            Session["UserId"] = null;
            Session["Username"] = null;
            Session["Userphoto"] = null;
            string data = "已注销登录！";
            return data;
        }
        #endregion

        #region 注册
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(FormCollection forms)
        {
            if (ModelState.IsValid)
            {
                if (forms["phone"]!="" && forms["password"] != "")
                {
                    string msg = usermanager.Register(forms["phone"], forms["password"]);
                    if (msg == "exist")
                    {
                        return Content("exist");
                    }
                    else if (msg == "success")
                    {
                        return Content("success");
                    }
                    else
                    {
                        return Content("fail");
                    }
                }
                else
                {
                    return Content("fail");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion

        #region 找回密码
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FindPassword()  //找回密码
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FindPassword(string phone)  //找回密码
        {
            return View();
        }
        #endregion

        #region 个人中心
        public ActionResult UserCenter()
        {
            if (Session["UserId"] != null)
            {
                var id = Convert.ToInt32(Session["UserId"]);
                UserCenterViewModels centermodel = new UserCenterViewModels();
                centermodel.user = usermanager.GetUserById(id);
                centermodel.recentplay = musicma.GetPlayRecordByUserId(id).OrderByDescending(o=>o.play_time).Take(6);
                centermodel.collectmusic = musiccolrecordma.GetRecordByUserId(id);
                centermodel.collectvideo = videocolrecordma.GetRecordByUserId(id);
                centermodel.upmusic = musicma.GetMusicByUserId(id);
                centermodel.upvideo = videoma.GetVideoByUserId(id);
                return View(centermodel);
            }
            else
            {
                return Content("<script>alert('请先登录！');</script>");
            }
        } 
        #endregion

        #region 修改用户信息页
        public ActionResult UpdateInfo(int userid)
        {
            var user = usermanager.GetUserById(userid);
            return View(user);
        }
        #endregion

        #region 保存信息修改
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEditInfo(FormCollection form)
        {
            int id = Convert.ToInt32(Session["UserId"]);
            var user = usermanager.GetUserById(id);
            user.name = form["nickname"];
            user.user_sex = form["gender"];
            user.birthday = Convert.ToDateTime(form["date"]);
            user.area = form["area"];
            user.user_info = form["introduce"];
            string msg = usermanager.EditUser(id, user);
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

        #region 保存头像
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SavePhoto(FormCollection forms)
        {
            var id = Convert.ToInt32(Session["UserId"]);
            var user = usermanager.GetUserById(id);
            var picName = Path.GetFileName(user.photo);
            var delphoto = Server.MapPath("~/Content/images/user_photo/" + picName);
            //获取用户新头像
            HttpPostedFileBase userPhoto = Request.Files["photo"];
            string dbimg_url = "";
            string savefilePath = "";
            //判断文件是否为空
            if (userPhoto != null && userPhoto.FileName != "")
            {
                //获取文件类型
                string fileExtension = Path.GetExtension(userPhoto.FileName) ;
                //自定义文件名（时间+唯一标识符+后缀）
                string fileName = DateTime.Now.ToString("yyyy-MM-dd") + Guid.NewGuid() + fileExtension;
                //判断是否存在需要的目录，不存在则创建 
                if (!Directory.Exists(Server.MapPath("~/Content/images/user_photo")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Content/images/user_photo"));
                }
                //拼接保存文件的详细路径
                savefilePath = Server.MapPath("~/Content/images/user_photo/") + fileName;
                //若扩展名不为空则判断文件是否是指定图片类型
                if (fileExtension != null)
                {
                    if ("(.bmp)|(.png)|(.jpg)|(.gif)|(.jpeg)".Contains(fileExtension))
                    {
                        if(picName != "default.jpg")
                        {
                            System.IO.File.Delete(delphoto);   //删除原有头像
                        }                        
                        userPhoto.SaveAs(savefilePath);    //保存新头像
                        //拼接返回的Img标签
                        dbimg_url = "../../Content/images/user_photo/" + fileName;
                    }
                }
                else
                {
                    dbimg_url = "";
                }
                user.photo = dbimg_url;              //更新用户头像地址
                Session["UserPhoto"] = user.photo;
            }
            else
            {
                return Content("unfound");
            }
            string msg = usermanager.EditUser(id, user);
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

        #region 音悦人申请页
        UserSingerApplyManager singerapply = new UserSingerApplyManager();
        public ActionResult UserSingerApply(int userid)
        {
            SingerApplyViewModels applymodel = new SingerApplyViewModels();
            applymodel.user = usermanager.GetUserById(userid);
            applymodel.apply = singerapply.GetSingerApplyByUserId(userid);
            return View(applymodel);
        }
        #endregion

        #region 提交音悦人申请        
        public ActionResult SingerApply()
        {
            UserSingerApply apply = new UserSingerApply();
            apply.userId = Convert.ToInt32(Session["UserId"]);
            apply.applytime = DateTime.Now;
            apply.deal_state = 0;
            int msg = singerapply.AddSingerApply(apply);
            if (msg == 1)
            {
                return Content("suc");
            }
            else
            {
                return Content("fail");
            }
        }
        #endregion

        #region 我的动态
        public ActionResult MyCircle()
        {
            var id = Convert.ToInt32(Session["UserId"]);
            MyCircleViewModels CircirModel = new MyCircleViewModels();
            CircirModel.circles = circlemanager.GetCircleById(id);
            CircirModel.myattention = userfriendsma.GetUserFriendsById(id).ToList(); 
            return View(CircirModel);
        } 
        #endregion

        #region 我的关注
        public ActionResult MyAddtion()
        {
            var id = Convert.ToInt32(Session["UserId"]);
            var addtion = userfriendsma.GetUserFriendsById(id).ToList();
            return View(addtion);
        }
        #endregion

        #region 我的粉丝
        public ActionResult MyFans()
        {
            var id = Convert.ToInt32(Session["UserId"]);
            var Fans = userfriendsma.GetUserFansById(id);
            return View(Fans);
        }
        #endregion

        #region 上传原创
        // GET: UpOrigin
        public ActionResult UpOrigin()
        {
            if (Session["UserId"] != null && Session["Username"] != null)
            {
                ViewBag.musicType_id = new SelectList(mtypemusic.GetMusicType(), "typeId", "typeName");
                return View();
            }
            else
            {
                return Content("<script>alert('请先登录！');history.go(-1);</script>");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpOrigin(FormCollection forms, UserMusics music)
        {

            if (Session["UserId"] != null && Session["UserName"] != null)    //用户功能，需要登录
            {
                try
                {
                    //获取音乐文件
                    HttpPostedFileBase musicfile = Request.Files["musicfile"];
                    string dbsrc = "";
                    string savefilePath = "";
                    //判断文件是否为空
                    if (musicfile != null)
                    {
                        //获取文件类型
                        string fileExtension = Path.GetExtension(musicfile.FileName);
                        //自定义文件名（时间+唯一标识符+后缀）
                        string fileName = DateTime.Now.ToString("yyyy-MM-dd") + Guid.NewGuid() + fileExtension;
                        //判断是否存在需要的目录，不存在则创建 
                        if (!Directory.Exists(Server.MapPath("~/Content/source/music-source")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/Content/source/music-source"));
                        }
                        //拼接保存文件的详细路径
                        savefilePath = Server.MapPath("~/Content/source/music-source/") + fileName;
                        //若扩展名不为空则判断文件是否是指定音频类型
                        if (fileExtension != null)
                        {
                            if ("(.mp3)|(.wma)|(.wav)".Contains(fileExtension))
                            {
                                //拼接返回的Img标签
                                dbsrc = "../../Content/source/music-source/" + fileName;
                            }
                        }
                        else
                        {
                            dbsrc = "上传失败！";
                        }
                        music.music_url = dbsrc;
                    }
                    else
                    {
                        return Content("没有找到该文件！");
                    }
                    //获取歌曲封面
                    HttpPostedFileBase musicImg = Request.Files["musicImg"];
                    string dbimg_url = "";
                    string savefilePath2 = "";
                    //判断文件是否为空
                    if (musicImg != null)
                    {
                        //获取文件类型
                        string fileExtension = Path.GetExtension(musicImg.FileName);
                        //自定义文件名（时间+唯一标识符+后缀）
                        string fileName = DateTime.Now.ToString("yyyy-MM-dd") + Guid.NewGuid() + fileExtension;
                        //判断是否存在需要的目录，不存在则创建 
                        if (!Directory.Exists(Server.MapPath("~/Content/images/musics")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/Content/images/musics"));
                        }
                        //拼接保存文件的详细路径
                        savefilePath2 = Server.MapPath("~/Content/images/musics/") + fileName;
                        //若扩展名不为空则判断文件是否是指定视频类型
                        if (fileExtension != null)
                        {
                            if ("(.bmp)|(.png)|(.jpg)|(.gif)|(.jpeg)|(.BMP)|(.PNG)|(.JPG)|(.GIF)|(.JPEG)".Contains(fileExtension))
                            {
                                //拼接返回的Img标签
                                dbimg_url = "../../Content/images/musics/" + fileName;
                            }
                        }
                        else
                        {
                            dbimg_url = "没有找到该文件！";
                        }
                        music.imgage_url = dbimg_url;
                    }
                    else
                    {
                        return Content("没有找到该文件！");
                    }

                    //获取歌名，上传用户id,歌曲类型id,歌曲描述
                    music.music_name = forms["musicname"];
                    music.user_id = Convert.ToInt32(Session["UserId"]);
                    music.music_info = forms["musicInfo"];
                    music.upType_id = 1;   //原创id
                    music.music_like = 0;
                    music.listen_times = 0;
                    music.upTime = DateTime.Now;
                    music.music_state = 0;
                    music.music_check = 0;
                    string msg = musicma.AddMusic(music);
                    if (msg == "success")
                    {
                        //保存音乐文件
                        musicfile.SaveAs(savefilePath);
                        //保存海报图片
                        musicImg.SaveAs(savefilePath2);
                        return Content("<script>alert('上传成功！');history.go(-1)</script>");
                    }
                    else
                    {
                        return Content("<script>alert('上传失败！');history.go(-1);;</script>");
                    }
                }
                catch (DbEntityValidationException dbEx)
                {
                    return Content(dbEx.Message);
                }
            }
            else
            {
                return Content("<script>alert('请先登录！');history.go(-1);</script>");
            }
        }
        #endregion

        #region 上传翻唱
        // GET: UpCover
        public ActionResult UpCover()
        {
            if (Session["UserId"] != null && Session["Username"] != null)
            {
                ViewBag.musicType_id = new SelectList(mtypemusic.GetMusicType(), "typeId", "typeName");
                return View();
            }
            else
            {
                return Content("<script>alert('请先登录！');history.go(-1);</script>");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpCover(FormCollection forms, UserMusics usermusic)
        {

            if (Session["UserId"] != null && Session["UserName"] != null)   //用户功能，需要登录
            {
                try
                {
                    //获取音乐文件
                    HttpPostedFileBase musicfile = Request.Files["musicfile"];
                    string dbsrc = "";
                    string savefilePath = "";
                    //判断文件是否为空
                    if (musicfile != null)
                    {
                        //获取文件类型
                        string fileExtension = Path.GetExtension(musicfile.FileName);
                        //自定义文件名（时间+唯一标识符+后缀）
                        string fileName = DateTime.Now.ToString("yyyy-MM-dd") + Guid.NewGuid() + fileExtension;
                        //判断是否存在需要的目录，不存在则创建 
                        if (!Directory.Exists(Server.MapPath("~/Content/source/music-source")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/Content/source/music-source"));
                        }
                        //拼接保存文件的详细路径
                        savefilePath = Server.MapPath("~/Content/source/music-source/") + fileName;
                        //若扩展名不为空则判断文件是否是指定视频类型
                        if (fileExtension != null)
                        {
                            if ("(.mp3)|(.wma)|(.wav)".Contains(fileExtension))
                            {
                                //拼接返回的Img标签
                                dbsrc = "../../Content/source/music-source/" + fileName;
                            }
                        }
                        else
                        {
                            dbsrc = "上传失败！";
                        }
                        usermusic.music_url = dbsrc;
                    }
                    else
                    {
                        return Content("没有找到该文件！");
                    }


                    //获取歌曲封面
                    HttpPostedFileBase musicImg = Request.Files["musicImg"];
                    string dbimg_url = "";
                    string saveImgPath = "";
                    //判断文件是否为空
                    if (musicImg != null)
                    {
                        //获取文件类型
                        string fileExtension = Path.GetExtension(musicImg.FileName);
                        //自定义文件名（时间+唯一标识符+后缀）
                        string fileName = DateTime.Now.ToString("yyyy-MM-dd") + Guid.NewGuid() + fileExtension;
                        //判断是否存在需要的目录，不存在则创建 
                        if (!Directory.Exists(Server.MapPath("~/Content/images/musics")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/Content/images/musics"));
                        }
                        //拼接保存文件的详细路径
                        saveImgPath = Server.MapPath("~/Content/images/musics/") + fileName;
                        //若扩展名不为空则判断文件是否是指定图片类型
                        if (fileExtension != null)
                        {
                            if ("(.bmp)|(.png)|(.jpg)|(.gif)|(.jpeg)|(.BMP)|(.PNG)|(.JPG)|(.GIF)|(.JPEG)".Contains(fileExtension))
                            {
                                //拼接返回的Img标签
                                dbimg_url = "../../Content/images/musics/" + fileName;
                            }
                        }
                        else
                        {
                            dbimg_url = "没有找到该文件！";
                        }
                        usermusic.imgage_url = dbimg_url;
                    }
                    else
                    {
                        return Content("没有找到该文件！");
                    }

                    //获取歌名，上传用户id,歌曲类型id,歌曲描述
                    usermusic.music_name = forms["musicname"];
                    usermusic.user_id = Convert.ToInt32(Session["UserId"]);
                    usermusic.music_info = forms["musicInfo"];
                    usermusic.upType_id = 2;            //翻唱id
                    usermusic.music_like = 0;
                    usermusic.upTime = DateTime.Now;
                    usermusic.listen_times = 0;
                    usermusic.music_state = 0;
                    usermusic.music_check = 0;
                    string msg = musicma.AddMusic(usermusic);                     
                    if (msg == "success")
                    {
                        //保存音乐文件
                        musicfile.SaveAs(savefilePath);
                        //保存海报图片
                        musicImg.SaveAs(saveImgPath);
                        return Content("<script>alert('上传成功！');history.go(-1);</script>");
                    }
                    else
                    {
                        return Content("<script>alert('上传失败！');history.go(-1);</script>");
                    }
                }
                catch (DbEntityValidationException dbEx)
                {
                    return Content(dbEx.Message);
                }
            }
            else
            {
                return Content("<script>alert('请先登录！');history.go(-1);</script>");
            }
        }
        #endregion

        #region 上传视频
        // GET: UpVideo
        public ActionResult UpVideo()
        {
            if (Session["UserId"] != null && Session["Username"] != null)
            {
                ViewBag.videoType_id = new SelectList(videotypemanager.GetVideoType(), "typeId", "typeName");
                return View();
            }
            else
            {
                return Content("<script>alert('请先登录！');history.go(-1);</script>");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpVideo(FormCollection forms, Videos video)
        {
            if (Session["UserId"] != null && Session["UserName"] != null)      //用户功能，需要登录
            {
                try
                {
                    //获取视频文件
                    HttpPostedFileBase videofile = Request.Files["videofile"];
                    string video_src = "";
                    string filePath = "";
                    //判断文件是否为空
                    if (videofile != null)
                    {
                        //获取文件类型
                        string fileExtension = Path.GetExtension(videofile.FileName);
                        //自定义文件名（时间+唯一标识符+后缀）
                        string fileName = DateTime.Now.ToString("yyyy-MM-dd") + Guid.NewGuid() + fileExtension;
                        //判断是否存在需要的目录，不存在则创建 
                        if (!Directory.Exists(Server.MapPath("~/Content/source/video-source")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/Content/source/video-source"));
                        }
                        //拼接保存文件的详细路径
                        filePath = Server.MapPath("~/Content/source/video-source/") + fileName;
                        //若扩展名不为空则判断文件是否是指定视频类型
                        if (fileExtension != null)
                        {
                            if ("(.mp4)|(.avi)|(.flv)|(.rmvb)|(.wmv)".Contains(fileExtension))
                            {

                                //拼接返回的Img标签
                                video_src = "../../Content/source/video-source/" + fileName;
                            }
                        }
                        else
                        {
                            video_src = "上传失败！";
                        }
                    }
                    else
                    {
                        video_src = "没有找到该文件！";
                    }
                    video.video_url = video_src;    //获取视频文件存储路径

                    //获取视频封面
                    HttpPostedFileBase videoImg = Request.Files["videoImg"];
                    string dbimg_url = "";
                    string saveImgPath = "";
                    //判断文件是否为空
                    if (videoImg != null)
                    {
                        //获取文件类型
                        string fileExtension = Path.GetExtension(videoImg.FileName);
                        //自定义文件名（时间+唯一标识符+后缀）
                        string fileName = DateTime.Now.ToString("yyyy-MM-dd") + Guid.NewGuid() + fileExtension;
                        //判断是否存在需要的目录，不存在则创建 
                        if (!Directory.Exists(Server.MapPath("~/Content/images/videos/videos-post")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/Content/images/videos/videos-post"));
                        }
                        //拼接保存文件的详细路径
                        saveImgPath = Server.MapPath("~/Content/images/videos/videos-post/") + fileName;
                        //若扩展名不为空则判断文件是否是指定图片类型
                        if (fileExtension != null)
                        {
                            if ("(.bmp)|(.png)|(.jpg)|(.gif)|(.jpeg)|(.BMP)|(.PNG)|(.JPG)|(.GIF)|(.JPEG)".Contains(fileExtension))
                            {
                                //拼接返回的Img标签
                                dbimg_url = "../../Content/images/videos/videos-post/" + fileName;
                            }
                        }
                        else
                        {
                            dbimg_url = "没有找到该文件！";
                        }
                        video.video_photo = dbimg_url;    //获取图片路径
                    }
                    else
                    {
                        return Content("没有找到该文件！");
                    }

                    //获取视频名，上传用户id,视频描述,初始播放量，视频简介上传时间，关联歌曲
                    video.user_id = Convert.ToInt32(Session["UserId"]);
                    video.video_name = forms["videoname"];
                    video.video_look = 0;
                    video.video_info = forms["video_info"];
                    video.video_upTime = DateTime.Now;
                    video.relate_music = forms["relate_music"];
                    video.video_state = 0;
                    video.video_check = 0;
                    string msg = videoma.AddVideo(video);
                    if (msg == "success")
                    {
                        //保存视频文件
                        videofile.SaveAs(filePath);
                        //保存视频封面
                        videoImg.SaveAs(saveImgPath);
                        return Content("<script>alert('上传成功！');history.go(-1)</script>");
                    }
                    else
                    {
                        return Content("<script>alert('上传失败！');history.go(-1);</script>");
                    }

                }
                catch (DbEntityValidationException dbEx)
                {
                    return Content(dbEx.Message);
                }
            }
            else
            {
                return Content("<script>alert('请先登录！');history.go(-1);</script>");
            }
        }
        #endregion

        #region 点赞歌曲
        public ActionResult GiveLike(int id)        //用户功能，需要登录
        {
            if (Session["UserId"] != null)
            {
                var music = musicma.GetMusicById(id);
                string msg = musicma.AddLike(music);
                if (msg == "success")
                    return Content("<script>alert('点赞成功！');history.go(-1);</script>");
                else
                    return Content("<script>alert('点赞失败！');history.go(-1);</script>");
            }
            else
            {
                return Content("<script>alert('请先登录！');history.go(-1);</script>");
            }
        }
        #endregion

        #region 收藏歌曲
        public ActionResult MusicCollect(int id)      //用户功能，需要登录
        {
            if (Session["UserId"] != null)
            {
                MusicCollectRecord usercollect = new MusicCollectRecord();
                MusicCollectRecord usercollect1 = new MusicCollectRecord();
                int userid = Convert.ToInt32(Session["UserId"]);
                usercollect = musiccolrecordma.GetRecordByUserIdAndMusicId(userid,id);
                if (usercollect == null)
                {
                    usercollect1.user_id = userid;
                    usercollect1.music_id = id;
                    usercollect1.collect_time = DateTime.Now;
                    string msg = musiccolrecordma.AddMusicCollect(usercollect1);
                    if (msg == "success")
                    {
                        return Content("<script>alert('收藏成功！');history.go(-1);</script>");
                    }
                    else
                    {
                        return Content("<script>alert('收藏失败！');history.go(-1);</script>");
                    }
                }
                else
                {
                    return Content("<script>alert('您已经收藏过该歌曲！');history.go(-1);</script>");
                }
            }
            else
            {
                return Content("<script>alert('请先登录！');history.go(-1);</script>");
            }
        }
        #endregion

        #region 取消收藏歌曲
        public ActionResult deleteMusicCollect(int deleteId)
        {
            var userid = Convert.ToInt32(Session["UserId"]);
            var deletemusic = musiccolrecordma.GetRecordByUserIdAndMusicId(userid, deleteId);
            string msg = musiccolrecordma.RemoveMusicCollect(deletemusic);
            if (msg == "success")
            {
                return Content("<script>alert('取消成功！');window.location='../../UserManage/MyCollect';</script>");
            }
            else
            {
                return Content("<script>alert('取消失败！');history.go(-1);</script>");
            }
        }
        #endregion

        #region 收藏视频
        public ActionResult videoCollect(int id)      //用户功能，需要登录
        {
            if (Session["UserId"] != null)
            {
                VideoCollectRecord usercollect = new VideoCollectRecord();
                VideoCollectRecord usercollect1 = new VideoCollectRecord();
                int userid = Convert.ToInt32(Session["UserId"]);
                usercollect = videocolrecordma.GetVideoRecordByUserIdAndVideoId(userid,id);
                if (usercollect == null)
                {
                    usercollect1.user_id = userid;
                    usercollect1.video_id = id;
                    usercollect1.collect_time = DateTime.Now;
                    string msg = videocolrecordma.AddVideoRecord(usercollect1);
                    if (msg == "success")
                    {
                        return Content("<script>alert('收藏成功！');history.go(-1);</script>");
                    }
                    else
                    {
                        return Content("<script>alert('收藏失败！');history.go(-1);</script>");
                    }
                }
                else
                {
                    return Content("<script>alert('您已经收藏过该视频！');history.go(-1);</script>");
                }
            }
            else
            {
                return Content("<script>alert('请先登录！');history.go(-1);</script>");
            }
        }
        #endregion

        #region 取消收藏视频
        public ActionResult deleteVideoCollect(int deleteId)
        {
            var userid = Convert.ToInt32(Session["UserId"]);
            var deletevideo = videocolrecordma.GetVideoRecordByUserIdAndVideoId(userid,deleteId);
            string msg = videocolrecordma.RemoveVideoRecord(deletevideo);
            if (msg == "success")
            {
                return Content("<script>alert('取消成功！');window.location='../../UserManage/MyCollect';</script>");
            }
            else
            {
                return Content("<script>alert('取消失败！');history.go(-1);</script>");
            }
        }
        #endregion

        #region 删除上传歌曲(原创/翻唱)
        public ActionResult deleteUpMusic(int deleteId)
        {
            var deletemusic = musicma.GetMusicById(deleteId);
            var picName = Path.GetFileName(deletemusic.imgage_url);
            var sourceName = Path.GetFileName(deletemusic.music_url);
            var deletemusicPic = Server.MapPath("~/Content/images/Musics/" + picName);
            var deletemusicSource = Server.MapPath("~/Content/source/Music-source/" + sourceName);
            if (System.IO.File.Exists(deletemusicPic))
            {
                System.IO.File.Delete(deletemusicPic);   //删除歌曲图片
            }
            else
            {
                return Content("<script>alert('图片删除失败！');window.reload();</script>");
            }
            if (System.IO.File.Exists(deletemusicSource))
            {
                System.IO.File.Delete(deletemusicSource);    //删除歌曲资源
            }
            else
            {
                return Content("<script>alert('资源删除失败！');window.reload();</script>");
            }
            string msg = musicma.RemoveMusic(deletemusic);
            if (msg == "success")
            {
                return Content("<script>alert('删除成功！');window.reload();</script>");
            }
            else
            {
                return Content("<script>alert('删除失败！');history.go(-1);</script>");
            }
        }
        #endregion

        #region 删除上传视频
        public ActionResult deleteVideo(int deleteId)
        {
            var deletevideo = videoma.GetVideoById(deleteId);
            var picName = Path.GetFileName(deletevideo.video_photo);
            var sourceName = Path.GetFileName(deletevideo.video_url);
            var deletevideoPic = Server.MapPath("~/Content/images/videos/videos-post/" + picName);
            var deletevideoSource = Server.MapPath("~/Content/source/video-source/" + sourceName);
            if (System.IO.File.Exists(deletevideoPic))
            {
                System.IO.File.Delete(deletevideoPic);   //删除视频封面
            }
            else
            {
                return Content("<script>alert('图片删除失败！');window.reload();</script>");
            }
            if (System.IO.File.Exists(deletevideoSource))
            {
                System.IO.File.Delete(deletevideoSource);    //删除歌曲资源
            }
            else
            {
                return Content("<script>alert('资源删除失败！');window.reload();</script>");
            }
            string msg = videoma.RemoveVideo(deletevideo);
            if (msg == "success")
            {
                return Content("<script>alert('删除成功！');window.reload();</script>");
            }
            else
            {
                return Content("<script>alert('删除失败！');history.go(-1);</script>");
            }
        }
        #endregion

        #region 评论歌曲
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MusicComment(int id, string content)
        {
            if (Session["UserId"] != null)
            {
                MusicComment comment = new MusicComment();
                comment.music_id = id;
                comment.user_id = Convert.ToInt32(Session["UserId"]);
                comment.Comment_time = DateTime.Now;
                comment.Comment_content = content;
                comment.Users = usermanager.GetUserById(comment.user_id);
                string msg = musiccommentma.AddComment(comment);
                if (msg == "success")
                {
                    return View(comment);
                }
                else
                {
                    return Content("Fault");
                }
            }
            else
            {
                return Content("Login");
            }

        }
        #endregion

        #region 评论视频
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult VideoComment(int id, string content)
        {
            if (Session["UserId"] != null)
            {
                VideoComment comment = new VideoComment();
                comment.video_id = id;
                comment.user_id = Convert.ToInt32(Session["UserId"]);
                comment.Comment_time = DateTime.Now;
                comment.Comment_content = content;
                comment.Users = usermanager.GetUserById(comment.user_id);
                string msg = videocommentma.AddComment(comment);
                if (msg == "success")
                {                                        
                    return View(comment);
                }
                else
                {
                    return Content("Fault");
                }
            }
            else
            {
                return Content("Login");
            }

        }
        #endregion


        #region            // //关注用户    已三层
        public ActionResult Adduser(int id)
        {
            if (Session["UserId"] != null)
            {
                //var adduser = new User_friends();
                //var adduser1 = new User_friends();
                //var userid = Convert.ToInt32(Session["UserId"]);
                //adduser = db.user_friends.Where(o => o.userId == userid).Where(o => o.adduserId == id).SingleOrDefault();
                //if (adduser == null)
                //{
                //    adduser1.userId = userid;
                //    adduser1.adduserId = id;
                //    adduser1.add_date = DateTime.Now;
                //    db.user_friends.Add(adduser1);
                //    //修改用户的关注量属性和粉丝量属性
                //    var user = db.users.Where(o => o.userId == userid).SingleOrDefault();                 //获取当前用户
                //    user.user_add = user.user_add + 1;    //当前用户关注量+1

                //    var user1 = db.users.Where(o => o.userId == id).SingleOrDefault();                 //获取被关注用户
                //    user1.user_fans = user1.user_fans + 1;    //被关注用户粉丝量+1

                //    if (db.SaveChanges() > 0)
                //    {
                //        return Content("<script>alert('关注成功！');history.go(-1);</script>");
                //    }
                //    else
                //    {
                //        return Content("<script>alert('关注失败！');history.go(-1);</script>");
                //    }
                //}
                //else
                //{
                //    return Content("<script>alert('你已经关注过该用户！');history.go(-1);</script>");
                //}
                var userid = Convert.ToInt32(Session["UserId"]);
                var add = circlemanager.AdduserLike(id, userid);
                if (add == "success")
                {
                    return Content("<script>alert('关注成功！');history.go(-1);</script>");
                    //return Content("success");
                }
                else if (add  == "fail")
                {
                    return Content("<script>alert('关注失败！');history.go(-1);</script>");
                }
                else
                {
                    return Content("<script>alert('你已经关注过该用户！');history.go(-1);</script>");
                }
            }
            else
            {
                return Content("<script>alert('请先登录！');history.go(-1);</script>");
            }
        }
        #endregion

        #region    // //取消关注用户       已三层
        public ActionResult delUser(int deleteId)
        {
            if (Session["UserId"] != null)
            {
                //var userid = Convert.ToInt32(Session["UserId"]);
                //var deluser = db.user_friends.Where(o => o.userId == userid).Where(o => o.adduserId == deleteId).SingleOrDefault();
                //if (deluser != null)
                //{
                //    db.user_friends.Remove(deluser);
                //    //修改用户的关注量属性和粉丝量属性
                //    var user = db.users.Where(o => o.userId == userid).SingleOrDefault();                 //获取当前用户
                //    user.user_add = user.user_add - 1;    //当前用户关注量-1

                //    var user1 = db.users.Where(o => o.userId == deleteId).SingleOrDefault();                 //获取被关注用户
                //    user1.user_fans = user1.user_fans - 1;    //被关注用户粉丝量-1
                //    if (db.SaveChanges() > 0)
                //    {
                //        return Content("<script>alert('取消关注成功！');location ='../../UserManage/MyAddition';</script>");
                //    }
                //    else
                //    {
                //        return Content("<script>alert('取消关注失败！');history.go(-1);</script>");
                //    }
                //}
                //else
                //{
                //    return Content("<script>alert('取消关注失败！');history.go(-1);</script>");
                //}
                var userid = Convert.ToInt32(Session["UserId"]);
                var delete = circlemanager.RemoveUserLike(deleteId, userid);
                if (delete == "success")
                {
                    return Content("<script>alert('取消关注成功！');history.go(-1);</script>");
                    //return Content("success");
                }
                else if (delete == "fail")
                {
                    return Content("<script>alert('取消关注失败！');history.go(-1);</script>");
                }
                else
                {
                    return Content("<script>alert('取消关注失败！');history.go(-1);</script>");
                }

            }
            else
            {
                return RedirectToAction("Login", "UserManage");
            }
        }
        #endregion

        #region           // //用户留言   三层 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult userLeave(int id, string message)
        {
            if (Session["UserId"] != null)
            {
                //UserLeave leave = new UserLeave();
                //leave.user_id = id;
                //leave.Leaveuser_id = Convert.ToInt32(Session["UserId"]);
                //leave.Leave_time = DateTime.Now;
                //leave.Leave_content = message;
                //db.userLeave.Add(leave);
                var Leaveuser_id = Convert.ToInt32(Session["UserId"]);
                var leave = circlemanager.UserLeave(id, Leaveuser_id, message);
                if (leave == "success")
                {
                    return Content("success");
                }
                else
                {
                    return Content("fail");
                }

                //if (db.SaveChanges() > 0)
                //{
                //    leave.Users = db.users.Where(o => o.userId == leave.Leaveuser_id).FirstOrDefault();   //指明为当前用户留言
                //    return View(leave);
                //}
                //else
                //{
                //    return Content("Fault");
                //}
            }
            else
            {
                return Content("Login");
            }

        }
        #endregion

        #region   //发布圈子动态  postMessage     已三层
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult PostMessage(string content)
        {
            SingMusicDataBaseEntities db = new SingMusicDataBaseEntities();
            if (Session["UserId"] != null)
            {
                //Circle addcircle = new Circle();
                //addcircle.userid = Convert.ToInt32(Session["UserId"]);//
                //addcircle.uptime = DateTime.Now;
                //addcircle.content = content;
                //addcircle.thumbs = 1;
                //addcircle.replysum = 0;
                //addcircle.c_state = 0;
                //db.Circle.Add(addcircle);

                var userid = Convert.ToInt32(Session["UserId"]);
                var post = circlemanager.PostMessage(userid, content);
                if (post == "success")
                {
                    return Content("success");
                }
                else
                {
                    return Content("fail");
                }

                //if (db.SaveChanges() > 0)
                //{
                //    addcircle.Users = db.Users.Where(o => o.userId == addcircle.userid).FirstOrDefault();
                //    // return View(addcircle);
                //    return Content("success");
                //    //return Content("<script>alert('发布成功！');history.go(-1); </script>; ");
                //}
                //else
                //{
                //    return Content("fail");
                //    // return Content("<script>alert('发布失败！');history.go(-1); </script>; ");
                //}
            }
            else
            {
                return Content("<script>alert('请先登录！');history.go(-1); </script>; ");
            }
        }
        #endregion

    }
}