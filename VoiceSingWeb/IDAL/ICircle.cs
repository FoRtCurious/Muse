using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace IDAL
{
    public interface ICircle
    {
        IEnumerable<Circle> GetCircleById(int id);
        Circle CircleById(int id);     //获取动态详情
        string ComplainCircle(int userid, int cirid, string content);     //投诉圈子
        string ComplainUser(int userid, int id, string content);    //投诉用户       new 
        IEnumerable<Circle> GetCircleByUptime();     //所有动态
        IEnumerable<Users> GetUserForCircleByFans();     //圈子推荐关注
        IEnumerable<Circle> GetCircleByUserType();        // 依据用户类型获取音乐人动态
        string PostMessage(int userid, string content);     // 发布圈子内容       new
        string UserLeave(int id, int Leaveuser_id, string message);      //添加用户留言  new 
        string AdduserLike(int id, int userid);                     // 关注用户     new 
        string RemoveUserLike(int deleteId, int userid);                 //移除用户关注   new  
        string PostAlbumLeave(int userid,int albumid, string content);     //发布音乐人歌单留言       new 
        string PostActiveLeave(int userid, int activeid, string content);    //发布活动歌单留言      new 
        IEnumerable<SingerAlbumLeave> GetAllLeaveById(int id);            //获取音乐人歌单留言     new
        IEnumerable<ActiveAlbumLeave> GetAllLeaveByIdForActive(int id);    //获取活动歌单留言       new 
      //  string PostMessage(int userid, string content);
        string AddReply(int userid, int cno, string content);    //添加圈子回复
        string AddUserReply(int userid, int replyid, string content);   //添加圈子中对用户评论的回复
        IEnumerable<Circlereply> GetAllReplyByCno(int cno);    //获取一个动态的所有回复 
        IEnumerable<CircleUserReply> GetAllReplyById(int id);     //获取一个回复的所有回复

    }
}
