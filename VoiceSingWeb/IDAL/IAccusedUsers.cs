using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IAccusedUsers
    {
        List<AccusedUsers> GetAccusedUsers();
        AccusedUsers GetAccusedById(int accusedid);
        int DealResult(int accusedid);
    }
}
