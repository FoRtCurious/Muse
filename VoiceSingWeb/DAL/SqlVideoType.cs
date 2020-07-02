using System.Collections.Generic;
using System.Linq;
using IDAL;
using Models;

namespace DAL
{
    class SqlVideoType:IVideoType
    {
        SingMusicDataBaseEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<VideoType> GetVideoType()
        {
            var videotype = db.VideoType.ToList();
            return videotype;
        }
    }
}
