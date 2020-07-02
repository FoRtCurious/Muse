using System.Linq;
using Models;
using System;
using IDAL;
using System.Collections.Generic;

namespace DAL
{
    public class SqlUser:IUser
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();

        #region 用户登录
        /// <summary>
        /// 用户两种登录方式验证
        /// </summary>
        /// <param name="userId">输入的账户</param>
        /// <param name="pwd">输入的密码</param>
        /// <returns>返回登入成功的用户或者空用户</returns>
        public Users Login(string userId, string pwd)
        {
            try
            {
                long userid = Convert.ToInt64(userId);
                var user1 = db.Users.Where(o => o.userId == userid ).SingleOrDefault();
                if (user1 != null)                           //输入的是账号
                {
                    if (pwd == user1.password)               //账号存在验证密码是否正确
                    {
                        return user1;
                    }
                    else
                        return null;
                }
                else                                             //输入的不是账号
                {
                    string phone = userId;                       //用户手机号登录
                    var user2 = db.Users.Where(o => o.phone_num == phone).SingleOrDefault();
                    if (user2 != null)                           //输入的是手机号
                    {
                        if (pwd == user2.password)               //手机号存在验证密码是否正确
                        {
                            return user2;
                        }
                        else
                            return null;
                    }
                    else                                        //输入的不是账号和手机号
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 用户注册
        public string Register(string phone, string password)
        {
            var ph = phone;
            string msg;
            var User = db.Users.Where(o => o.phone_num == ph).SingleOrDefault();
            if (User != null)
            {
                msg = "exist";
                return msg;
            }
            else
            {
                //初始化一个新注册用户
                Users user = new Users();
                user.phone_num = phone;
                user.name = "用户-" + phone;
                user.password = password;
                user.photo = "../../Content/images/user_photo/default.jpg";  //默认头像
                user.birthday = Convert.ToDateTime("1900/1/1");
                user.userType_id = 1;         //默认普通用户
                user.register_time = DateTime.Now;
                user.area = "南昌市";
                user.user_add = 0;
                user.user_fans = 0;
                user.user_info = "暂无简介~";
                user.user_state = 1;
                db.Users.Add(user);
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
        }
        #endregion

        #region 获取用户
        public IEnumerable<Users> GetUser()
        {
            var Users = db.Users.ToList();
            return Users;
        }
        #endregion

        #region 通过ID获取用户,具有循环引用
        public Users GetUserById(int? id)
        {
            var user = db.Users.Where(o => o.userId == id).SingleOrDefault();
            return user;
        }
        #endregion

        #region 管理员通过Id查找用户不具有循环引用
        public Users SearchUserById(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var user = db.Users.Where(o => o.userId == id).SingleOrDefault();
            return user;
        }
        #endregion

        #region 获取用户数据集
        public List<Users> GetUserJson()
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Users> list = db.Users.ToList();
            return list;
        }
        #endregion

        #region 修改信息
        public string EditUser(int id, Users user)
        {
            var u = db.Users.Find(id);
            u = user;
            if (db.SaveChanges() > 0)
            {
                return "success";
            }
            else
                return "fail";
        } 
        #endregion

        #region 查封用户
        public int CloseDownUser(int id)
        {
            int sign;
            var user = db.Users.Find(id);
            user.user_state = 0;
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

        #region 解封用户
        public int OpenUser(int id)
        {
            int sign;
            var user = db.Users.Find(id);
            user.user_state = 1;
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

    }
}
