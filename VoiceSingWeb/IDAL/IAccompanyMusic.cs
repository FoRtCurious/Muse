using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IAccompanyMusic
    {
        IEnumerable<CompanyMusics> GetAccompanyMusic();
        IEnumerable<CompanyMusics> SearchAccompanyMusic(string search);
    }
}
