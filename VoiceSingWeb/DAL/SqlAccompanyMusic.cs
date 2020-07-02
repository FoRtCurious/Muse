using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
    public class SqlAccompanyMusic : IAccompanyMusic
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<CompanyMusics> GetAccompanyMusic()
        {
            var accompany = db.CompanyMusics.ToList();
            return accompany;
        }
        public IEnumerable<CompanyMusics> SearchAccompanyMusic(string search)
        {
            var accompany = from o in db.CompanyMusics
                            where o.cm_name.Contains(search)  //根据歌名模糊查询伴奏
                            select o;
            return accompany;
        }
    }
}
