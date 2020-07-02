using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Models;
using IDAL;

namespace DAL
{
    /// <summary>
    /// 提供管理员信息操作
    /// </summary>
    public class SqlAdmin:IAdmin
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();
        public Administrator Login(string id, string pwd)
        {
            var admin = db.Administrator.Where(o => o.adminId == id).Where(o => o.password == pwd).SingleOrDefault();
            if(admin != null)
            {
                return admin;
            }
            else
            {
                return null;
            }
        }
    }
}
