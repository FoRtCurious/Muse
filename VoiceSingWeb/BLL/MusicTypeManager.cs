using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using IDAL;
using Models;

namespace BLL
{
    public class MusicTypeManager
    {
        IMusicType imusictype = DataAccess.CreateMusicType();
        public IEnumerable<MusicType> GetMusicType()
        {
            var musictype = imusictype.GetMusicType();
            return musictype;
        }
    }
}
