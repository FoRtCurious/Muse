using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using DALFactory;

namespace BLL
{

    public class MailsManager
    {
        IMail imail = DataAccess.CreateMails();
        //收件箱
        public IEnumerable<Mails> GetMailsByPhone(int id)
        {
            var mails = imail.GetMailsByPhone(id);
            return mails;
        }
        //发件箱
        public IEnumerable<Mails> GetMailsByPhone2(int id)
        {
            var mails = imail.GetMailsByPhone2(id);
            return mails;
        }
        //垃圾箱
        public IEnumerable<Mails> GetMailsByPhone3(int id)
        {
            var mails = imail.GetMailsByPhone3(id);
            return mails;
        }
        //写信
        public string Write(int id, int recip, string title, string content)
        {
            string msg = imail.Write(id, recip, title , content);
            //if (msg == "exist")
            //{
            //    return msg;
            //}
            if (msg == "success")
            {
                return msg;
            }
            else
            {
                return msg;
            }
        }


        public int DeleteMailByChangeState(int id)
        {
            var delete = imail.DeleteMailByChangeState(id);
            return delete;
        }



        public int RenewMail(int id)
        {
            var delete = imail.RenewMail(id);
            return delete;
        }


        public int DislikeUser(int id, int userid)
        {
            var dislike = imail.DislikeUser(id, userid);
            return dislike;

        }

        public int RemoveLike(int id, int userid)
        {
            var remove = imail.RemoveLike(id, userid);
            return remove;
        }

        public IEnumerable<Users> GetAllUser()
        {
            var alluser = imail.GetAllUser();
            return alluser;
        }

        public IEnumerable<MailChat> GetAllChatByUser(int id)
        {
            var chat = imail.GetAllChatByUser(id);
            return chat;
        }

        public string AddMailChat(int userid, int recipid)
        {
            string msg = imail.AddMailChat(recipid, userid);
            if (msg == "success")
            {
                return msg;
            }
            else
            {
                return msg;
            }
        }

        public string AddChatMsg(int id, int recipid, int recordid, string content)
        {
            string msg = imail.AddChatMsg(id, recipid, recordid, content);
            if (msg == "success")
            {
                return msg;
            }
            else
            {
                return msg;
            }
        }

        public IEnumerable<MailChatRecords> GetHistoryByUser(int id, int recipid)
        {
            var history = imail.GetHistoryByUser(id, recipid);
            return history;
        }

        public IEnumerable<Users> SearchUsers(string search)
        {
            var user = imail.SearchUsers(search);
            return user;
        }





    }
}
