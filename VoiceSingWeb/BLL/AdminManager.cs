using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using IDAL;
using Models;

namespace BLL
{
    public class AdminManager
    {
        IAdmin iadmin = DataAccess.CreateAdmin();

        public Administrator Login(string id, string pwd)
        {
            var admin = iadmin.Login(id, pwd);
            return admin;
        }
    }
}
