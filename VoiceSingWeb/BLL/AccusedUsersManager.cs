using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;
using DALFactory;

namespace BLL
{
    public class AccusedUsersManager
    {
        IAccusedUsers iaccusedusers = DataAccess.CreateAccusedUsers();
        public List<AccusedUsers> GetAccusedUsers()
        {
            var accusedusers = iaccusedusers.GetAccusedUsers();
            return accusedusers;
        }
        public AccusedUsers GetAccusedById(int accusedid)
        {
            var accused = iaccusedusers.GetAccusedById(accusedid);
            return accused;
        }
        public int DealResult(int accusedid)
        {
            return iaccusedusers.DealResult(accusedid);
        }
    }
}
