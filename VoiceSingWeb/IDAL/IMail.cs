using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  IMail
    {
        IEnumerable<Mails> GetMailsByPhone(int id );
        IEnumerable<Mails> GetMailsByPhone2(int id);
        IEnumerable<Mails> GetMailsByPhone3(int id);
        string Write(int id ,int recip, string title , string content);   //写信
        int DeleteMailByChangeState(int id);     //从发件箱删除邮件
        int RenewMail(int id);      //从垃圾箱恢复邮件
        int DislikeUser(int id, int userid);   //取消关注
        int RemoveLike(int id, int userid);   //移除粉丝

        IEnumerable<Users> GetAllUser();    //聊天窗口获取所有用户
        IEnumerable<MailChat> GetAllChatByUser(int id);       //最近联系
        string AddMailChat(int userid,int recipid );     //添加mailchat数据
        string AddChatMsg(int id, int recipid, int recordid, string content);    //添加聊天记录
        IEnumerable<MailChatRecords> GetHistoryByUser(int id, int recipid);       //检索聊天记录
        IEnumerable<Users> SearchUsers(string search);      //搜索用户
    }
}
