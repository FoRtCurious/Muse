using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using Models;
using IDAL;

namespace BLL
{
    public class CircleManager
    {
        ICircle icircle = DataAccess.CreateCircle();
        public IEnumerable<Circle> GetCircleById(int id)
        {
            var circle = icircle.GetCircleById(id);
            return circle;
        }

        public Circle CircleById(int id)
        {
            var circle = icircle.CircleById(id);
            return circle;
        }


        public string ComplainCircle(int userid, int cirid, string content)
        {
            string msg = icircle.ComplainCircle(userid, cirid, content);
            if (msg == "success")
            {
                return msg;
            }
            else { return msg; }
        }

        public string ComplainUser(int userid, int id, string content)
        {
            string msg = icircle.ComplainUser(userid, id, content);
            if (msg == "success")
            {
                return msg;
            }
            else { return msg; }
        }

        public IEnumerable<Circle> GetCircleByUptime()
        {
            var circle = icircle.GetCircleByUptime();
            return circle;
        }

        public IEnumerable<Users> GetUserForCircleByFans()
        {
            var user = icircle.GetUserForCircleByFans();
            return user;
        }

        public IEnumerable<Circle> GetCircleByUserType()
        {
            var circle = icircle.GetCircleByUserType();
            return circle;
        }

        public string PostMessage(int userid, string content)
        {
            string msg = icircle.PostMessage(userid, content);
            if (msg == "success")
            {
                return msg;
            }
            else { return msg; }
        }

        public string UserLeave(int id, int Leaveuser_id, string message)
        {
            string msg = icircle.UserLeave(id, Leaveuser_id, message);
            if (msg == "success")
            {
                return msg;
            }
            else { return msg; }
        }

        public string AdduserLike(int id, int userid)
        {
            string msg = icircle.AdduserLike(id, userid);
            if (msg == "success")
            {
                return msg;
            }
            else if (msg == "fail")
            {
                return msg;
            }
            else { return msg; }
        }

        public string RemoveUserLike(int deleteId, int userid)
        {
            string msg = icircle.RemoveUserLike(deleteId, userid);
            if (msg == "success")
            {
                return msg;
            }
            else if (msg == "fail")
            {
                return msg;
            }
            else { return msg; }
        }
        public string PostAlbumLeave(int userid, int albumid, string content)       //new 
        {
            string msg = icircle.PostAlbumLeave(userid, albumid, content);
            if (msg == "success")
            {
                return msg;
            }
            else { return msg; }
        }

        public string PostActiveLeave(int userid, int activeid, string content)      //new 
        {
            string msg = icircle.PostActiveLeave(userid, activeid, content);
            if (msg == "success")
            {
                return msg;
            }
            else { return msg; }
        }
        public IEnumerable<SingerAlbumLeave> GetAllLeaveById(int id)      //new 
        {
            var leave = icircle.GetAllLeaveById(id);
            return leave;
        }

        public IEnumerable<ActiveAlbumLeave> GetAllLeaveByIdForActive(int id)
        {
            var leave = icircle.GetAllLeaveByIdForActive(id);
            return leave;
        }
        public string AddReply(int userid, int cno, string content)
        {
            string msg = icircle.AddReply(userid, cno, content);
            if (msg == "success")
            {
                return msg;
            }
            else { return msg; }
        }

        public string AddUserReply(int userid, int replyid, string content)
        {
            string msg = icircle.AddUserReply(userid, replyid, content);
            if (msg == "success")
            {
                return msg;
            }
            else { return msg; }
        }

        public  IEnumerable<Circlereply> GetAllReplyByCno(int cno)
        {
            var reply = icircle.GetAllReplyByCno(cno);
            return reply;
        }

        public IEnumerable<CircleUserReply> GetAllReplyById(int id)
        {
            var reply = icircle.GetAllReplyById(id);
            return reply;
        }



    }
}
