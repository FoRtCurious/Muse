using System.Collections.Generic;
using Models;

namespace VoiceSingWeb.Models
{
    public class AccompanyMusicIndexViewModels
    {
        public IEnumerable<CompanyMusics> HotAccompanyMusic { get; set; }
        public IEnumerable<Users> Singers { get; set; }
        public IEnumerable<CompanyMusics> NewUpAccompanyMusic { get; set; }
        public IEnumerable<CompanyMusics> RankAccompanyMusic { get; set; }
    }
}