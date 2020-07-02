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
    public class UserSingerApplyManager
    {
        IUserSingerApply iuserapply = DataAccess.CreateUserSingerApply();
        public List<UserSingerApply> GetUserSingerApply()
        {
            var apply = iuserapply.GetUserSingerApply();
            return apply;
        }
        public IEnumerable<UserSingerApply> GetSingerApplyByUserId(int id)
        {
            var apply = iuserapply.GetSingerApplyByUserId(id);
            return apply;
        }
        public int AddSingerApply(UserSingerApply apply)
        {
            return iuserapply.AddSingerApply(apply);
        }
        public int AgreeApply(int id)
        {
            return iuserapply.AgreeApply(id);
        }
        public int DealResult(int id)
        {
            return iuserapply.DealResult(id);
        }
    }
}
