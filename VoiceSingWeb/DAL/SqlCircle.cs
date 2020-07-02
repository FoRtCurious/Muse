using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
    public class SqlCircle : ICircle 
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();

       // 通过id获取圈子内容
        public IEnumerable<Circle> GetCircleById(int id)
        {
            var circle = db.Circle.Where(o => o.userid  == id);
            return circle;

        }

        public Circle CircleById (int id)
        {
            var circle = db.Circle.Where(o => o.cno == id).SingleOrDefault();
            return circle;
        }

        public string ComplainCircle(int userid, int cirid, string content)
        {
            string msg;
            var circle = db.Circle.Find(cirid);
            circle.c_state = 1;
            //初始化一个投诉事件
            CircleComplain  complain = new CircleComplain();
            complain.userid = userid;
            complain.circleid = cirid;
            complain.content = content;
            complain.complain_time = DateTime.Now;
            complain.complain_state = 1;
            db.CircleComplain.Add(complain);

            if (db.SaveChanges() > 0)
            {
                msg = "success";
                return msg;
            }
            else
            {
                msg = "fail";
                return msg;
            }
        }

        public string ComplainUser(int userid, int id, string content)
        {
            string msg;
            var user = db.Users.Find(id);
            user.user_state = 1;
            //初始化一个投诉事件 
            UserComplain complain = new UserComplain();
            complain.userid = userid;
            complain.complainid = id;
            complain.content = content;
            complain.complain_time = DateTime.Now;
            complain.complain_state = 1;
            db.UserComplain.Add(complain);

            if (db.SaveChanges() > 0)
            {
                msg = "success";
                return msg;
            }
            else
            {
                msg = "fail";
                return msg;
            }

        }

        public IEnumerable<Circle> GetCircleByUptime()
        {
            var circle = db.Circle.OrderByDescending(o => o.uptime).Where(o => o.c_state == 0);
            return circle;
        }

        public IEnumerable<Users> GetUserForCircleByFans()
        {
            var user = db.Users.OrderByDescending(o => o.user_fans).Take(5);
            return user;
        }

        public IEnumerable<Circle> GetCircleByUserType()
        {
            var circle = db.Circle.Where(o => o.Users.userType_id == 2).Where(o => o.c_state == 0);
            return circle;
        }

        public string PostMessage(int userid, string content)        //圈子发布动态    mew 
        {
            string msg;
            //初始化一个圈子动态内容 
            Circle circle = new Circle();
            circle.userid = userid;
            circle.uptime = DateTime.Now;
            circle.content = content;
            circle.thumbs = 1;
            circle.replysum = 0;
            circle.c_state = 0;
            db.Circle.Add(circle);

            if (db.SaveChanges() > 0)
            {
                msg = "success";
                return msg;
            }
            else
            {
                msg = "fail";
                return msg;
            }
        }      

        public string UserLeave(int id, int Leaveuser_id, string message)       //发布用户留言    new 
        {
            string msg;
            //初始化一条留言内容
            UserLeave leave = new UserLeave();
            leave.user_id = id;
            leave.Leaveuser_id = Leaveuser_id;
            leave.Leave_time = DateTime.Now;
            leave.Leave_content = message;
            db.UserLeave.Add(leave);

            if (db.SaveChanges() > 0)
            {
                msg = "success";
                return msg;
            }
            else
            {
                msg = "fail";
                return msg;
            }
        }

        public string AdduserLike(int id, int userid)          //关注用户
        {
            string msg;
            var adduser = new User_friends();
            var adduser1 = new User_friends();
            //var userid = Convert.ToInt32(Session["UserId"]);
            adduser = db.User_friends.Where(o => o.userId == userid).Where(o => o.adduserId == id).SingleOrDefault();
            if (adduser == null)
            {
                adduser1.userId = userid;
                adduser1.adduserId = id;
                adduser1.add_date = DateTime.Now;
                db.User_friends.Add(adduser1);
                //修改用户的关注量属性和粉丝量属性
                var user = db.Users.Where(o => o.userId == userid).SingleOrDefault();                 //获取当前用户
                user.user_add = user.user_add + 1;    //当前用户关注量+1

                var user1 = db.Users.Where(o => o.userId == id).SingleOrDefault();                 //获取被关注用户
                user1.user_fans = user1.user_fans + 1;    //被关注用户粉丝量+1

                if (db.SaveChanges() > 0)
                {
                    msg = "success";
                    return msg;
                    //return Content("<script>alert('关注成功！');history.go(-1);</script>");
                }
                else
                {
                    msg = "fail";
                    return msg;
                    //return Content("<script>alert('关注失败！');history.go(-1);</script>");
                }
            }
            else
            {
                msg = "exist";
                return msg;
               // return Content("<script>alert('你已经关注过该用户！');history.go(-1);</script>");
            }
        }

        public string RemoveUserLike(int deleteId, int userid)            //移除关注 
        {
            string msg;
           // var userid = userid;
            var deluser = db.User_friends.Where(o => o.userId == userid).Where(o => o.adduserId == deleteId).SingleOrDefault();
            if (deluser != null)
            {
                db.User_friends.Remove(deluser);
                //修改用户的关注量属性和粉丝量属性
                var user = db.Users.Where(o => o.userId == userid).SingleOrDefault();                 //获取当前用户
                user.user_add = user.user_add - 1;    //当前用户关注量-1

                var user1 = db.Users.Where(o => o.userId == deleteId).SingleOrDefault();                 //获取被关注用户
                user1.user_fans = user1.user_fans - 1;    //被关注用户粉丝量-1
                if (db.SaveChanges() > 0)
                {
                    msg = "success";
                    return msg;
                    //return Content("<script>alert('取消关注成功！');location ='../../UserManage/MyAddition';</script>");
                }
                else
                {
                    msg = "fail";
                    return msg;
                    //return Content("<script>alert('取消关注失败！');history.go(-1);</script>");
                }
            }
            else
            {
                msg = "exist";
                return msg;
               // return Content("<script>alert('取消关注失败！');history.go(-1);</script>");
            }
        }


        public string PostAlbumLeave(int userid, int albumid, string content)          // 发布音乐专辑留言     new 
        {
            string msg;
            //初始化一个歌单留言内容
            SingerAlbumLeave leave = new SingerAlbumLeave();
            leave.userid = userid;
            leave.leaveid = albumid;        //歌单持有者id 
            leave.content = content;
            leave.leave_time = DateTime.Now;
            leave.reply_state = 0;
            db.SingerAlbumLeave.Add(leave);

            if (db.SaveChanges() > 0)
            {
                msg = "success";
                return msg;
            }
            else
            {
                msg = "fail";
                return msg;
            }
        }

        public string PostActiveLeave(int userid, int activeid, string content)    //发布活动歌单留言      new 
        {
            string msg;
            //初始化一个歌单留言内容
            ActiveAlbumLeave leave = new ActiveAlbumLeave();
            leave.userid = userid;
            leave.leaveid = activeid;        //活动编号id 
            leave.content = content;
            leave.leave_time = DateTime.Now;
            leave.reply_state = 0;
            db.ActiveAlbumLeave.Add(leave);

            if (db.SaveChanges() > 0)
            {
                msg = "success";
                return msg;
            }
            else
            {
                msg = "fail";
                return msg;
            }
        }

        public IEnumerable<SingerAlbumLeave> GetAllLeaveById(int id)            //new
        {
            var leave = db.SingerAlbumLeave.Where (o => o.leaveid == id).OrderByDescending( o => o.leave_time );
            return leave;
        }

        public IEnumerable<ActiveAlbumLeave> GetAllLeaveByIdForActive(int id)         //new 
        {
            var leave = db.ActiveAlbumLeave.Where(o => o.leaveid == id).OrderByDescending(o => o.leave_time);
            return leave;
        }

        public string AddReply(int userid, int cno, string content)
        {
            string msg;
            //初始化一个回复内容 
            Circlereply reply = new Circlereply();
            reply.userid = userid;
            reply.at_cno = cno;
            reply.content = content;
            reply.reply_time = DateTime.Now;
            reply.reply_state = 0;
            db.Circlereply.Add(reply);

            if (db.SaveChanges() > 0)
            {
                msg = "success";
                return msg;
            }
            else
            {
                msg = "fail";
                return msg;
            }

        }

        public string AddUserReply(int userid, int replyid, string content)
        {
            string msg;
            //初始化一个回复内容 
            CircleUserReply  reply = new CircleUserReply();
            reply.userid = userid;
            reply.replyid = replyid;
            reply.content = content;
            reply.reply_time = DateTime.Now;
            reply.reply_state = 0;
            db.CircleUserReply.Add(reply);

            if (db.SaveChanges() > 0)
            {
                msg = "success";
                return msg;
            }
            else
            {
                msg = "fail";
                return msg;
            }
        }

        public IEnumerable<Circlereply> GetAllReplyByCno(int cno)
        {
            var reply = db.Circlereply.Where(o => o.at_cno == cno);
            return reply;
        }

        public IEnumerable<CircleUserReply> GetAllReplyById(int id)
        {
            var reply = db.CircleUserReply.Where(o => o.replyid == id);
            return reply;
        }







    }
}
