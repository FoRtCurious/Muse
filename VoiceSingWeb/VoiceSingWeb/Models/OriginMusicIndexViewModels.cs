using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace VoiceSingWeb.Models
{
    public class OriginMusicIndexViewModels
    {
        public IEnumerable<UserMusics> BestOriginMusic { get; set; }
        public IEnumerable<UserMusics> rankMusic { get; set; }
        public IEnumerable<Users> Singers { get; set; }
        public IEnumerable<UserMusics> ToDayRecommendMusic { get; set; }
        public IEnumerable<UserMusics> newUpMusic { get; set; }
    }
}