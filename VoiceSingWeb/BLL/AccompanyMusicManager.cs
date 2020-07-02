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
    public class AccompanyMusicManager
    {
        IAccompanyMusic iaccompanymusic = DataAccess.CreateAccompanyMusic();
        public IEnumerable<CompanyMusics> GetAccompanyMusic()
        {
            var acm = iaccompanymusic.GetAccompanyMusic();
            return acm;
        }
        public IEnumerable<CompanyMusics> SearchAccompanyMusic(string search)
        {
            var acm = iaccompanymusic.SearchAccompanyMusic(search);
            return acm;
        }
    }
}
