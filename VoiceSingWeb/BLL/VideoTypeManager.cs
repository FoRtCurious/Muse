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
    public class VideoTypeManager
    {
        IVideoType ivideotype = DataAccess.CreateVideoType();
        public IEnumerable<VideoType> GetVideoType()
        {
            var videotype = ivideotype.GetVideoType();
            return videotype;
        }
    }
}
