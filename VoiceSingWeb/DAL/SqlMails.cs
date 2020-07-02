using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
    public class SqlMails : IMail 
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();
        //收件箱
        public IEnumerable<Mails> GetMailsByPhone(int id)
        {
            var mails = db.Mails.Where(o => o.recip_user == id).Where(o => o.mail_state != 2);
            return mails;
        }
        //发件箱
        public IEnumerable<Mails> GetMailsByPhone2(int id)
        {
            var cmails = db.Mails.Where(o => o.sent_user == id);
            return cmails;
        }
        //垃圾箱
        public IEnumerable<Mails> GetMailsByPhone3(int id)
        {
            var cmails = db.Mails.Where(o => o.recip_user == id ).Where(o=>o.mail_state ==2 );
            return cmails;
        }

        #region //写信 Write(string recip, string title , string mail)
        public string Write(int id, int recip, string title, string content) 
        {
            var rp = recip;
            string msg;
       
                //初始化一个新邮件 
                Mails mails = new Mails();
                mails.sent_user = id ;
                mails.recip_user = recip ;
                mails.title = title;
                mails.mail_state = 0 ;
                mails.mail = content;
            
                db.Mails.Add(mails);
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
        #endregion

        #region 通过修改邮件状态实现删除邮件 DeleteMailByChangeState(int id)
        public int DeleteMailByChangeState(int id)
        {
            int sign;
            var mail = db.Mails.Find(id);
            mail.mail_state = 2;
            if (db.SaveChanges() > 0)
            {
                sign = 1;
                return sign;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region 通过修改邮件状态实现从垃圾箱恢复邮件 RenewMail(int id)
        public int RenewMail(int id)
        {
            int sign;
            var mail = db.Mails.Find(id);
            mail.mail_state = 1;
            if (db.SaveChanges() > 0)
            {
                sign = 1;
                return sign;
            }
            else
            {
                return 0;
            }
        }
        #endregion


        #region 通过删除好友表中数据对用户进行取消关注
        public int DislikeUser(int id, int userid)
        {
            int sign;
            var user = db.User_friends.Where(o => o.adduserId == id).Where(o => o.userId == userid).SingleOrDefault();
            db.User_friends.Remove(user);
           // if (user. == userid )
            //{
             //   db.User_friends.Remove(user);
            //}
            if (db.SaveChanges() > 0)
            {
                sign = 1;
                return sign;
            }
            else
            {
                return 0;
            }

        }

        #endregion

        #region 移除粉丝 RemoveLike(int id, int userid)
        public int RemoveLike(int id, int userid)
        {
            int sign;
            var user = db.User_friends.Where(o => o.adduserId == userid ).Where(o => o.userId == id).SingleOrDefault();
            db.User_friends.Remove(user);
            if (db.SaveChanges() > 0)
            {
                sign = 1;
                return sign;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region 获取所有用户的聊天入口
        public IEnumerable<Users> GetAllUser()
        {
            var alluser = db.Users.ToList();
            return alluser;
        }
        #endregion

        #region 最近联系人 
        public IEnumerable<MailChat> GetAllChatByUser(int id)
        {
            var chatuser = db.MailChat.Where(o => o.sentid == id);
            return chatuser;
        }

        #endregion

        #region 添加聊天  AddMailChat(int recipid, int userid)
        public string AddMailChat(int userid, int recipid)
        {
            string msg;
            
            MailChat chat = new MailChat();
            MailChat chat1 = new MailChat();

            chat1 = db.MailChat .Where (o => o.sentid == recipid && o.recipid == userid).SingleOrDefault();
            if (chat1 == null)
            {
                chat.sentid = recipid;
                chat.recipid = userid;
                chat.click_sum = 0;
                chat.create_time = DateTime.Now;
                chat.chat_state = 0;
                db.MailChat.Add(chat);

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
            else
            {
                msg = "exist";
                return msg;
            }
                                 
        }

        #endregion

        #region 添加聊天记录 
        public string AddChatMsg(int id, int recipid, int recordid, string content)
        {
            string msg;
            MailChatRecords record1 = new MailChatRecords();      
                record1.sentid = id;
                record1.recipid = recipid;
                record1.content = content;
                record1.sent_time = DateTime.Now;
                
                record1.record_state = 0;
                record1.otherstate = 0;
                record1.recordid = 1;
                db.MailChatRecords.Add(record1);

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

        #endregion

        #region 获取聊天记录 
        public IEnumerable<MailChatRecords> GetHistoryByUser(int id, int recipid)
        {
            var history = db.MailChatRecords.Where(o => o.sentid == id && o.recipid == recipid || o.sentid == recipid && o.recipid == id);
            return history;
        }
        #endregion

        #region  搜索用户
        public IEnumerable<Users> SearchUsers(string search)
        {
            var user = from o in db.Users
                         where o.name.Contains(search)   //根据用户名搜索
                         select o;
            return user;
        }

        #endregion



    }
}
