using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoiceSingWeb.Models
{
    public class CoverMusicIndexViewModels
    {
        public IEnumerable<UserMusics> BestCoverMusic { get; set; }
        public IEnumerable<UserMusics> DayHotMusic { get; set; }
        public IEnumerable<Videos> HotVideo { get; set; }
        public IEnumerable<UserMusics> MusicHappy { get; set; }
        public IEnumerable<UserMusics> SelfRecommend { get; set; }
        public IEnumerable<UserMusics> newUpMusic { get; set; }
    }
}