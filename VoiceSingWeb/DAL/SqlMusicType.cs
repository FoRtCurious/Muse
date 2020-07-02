using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
    public class SqlMusicType:IMusicType
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<MusicType> GetMusicType()
        {
            var musictype = db.MusicType.ToList();
            return musictype;
        }
    }
}
