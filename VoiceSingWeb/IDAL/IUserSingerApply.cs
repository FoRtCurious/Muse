using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IUserSingerApply
    {
        List<UserSingerApply> GetUserSingerApply();
        IEnumerable<UserSingerApply> GetSingerApplyByUserId(int id);
        int AddSingerApply(UserSingerApply apply);
        int AgreeApply(int id);
        int DealResult(int id);
    }
}
