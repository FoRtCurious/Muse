using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IUserLeave
    {
        IEnumerable<UserLeave> GetUserLeaveById(int id);
    }
}
