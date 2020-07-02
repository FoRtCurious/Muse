using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace VoiceSingWeb.Models
{
    public class HomeIndexViewModels
    {
        public IEnumerable<UserMusics> MusicRecommend { get; set; }
        public IEnumerable<UserMusics> GuFenMusic { get; set; }
        public IEnumerable<UserMusics> LiuXingMusic { get; set; }
        public IEnumerable<UserMusics> DianZiMusic { get; set; }
        public IEnumerable<UserMusics> MinYaoMusic { get; set; }
        public IEnumerable<UserMusics> NewMusic { get; set; }
        public IEnumerable<UserMusics> HotMusic { get; set; }

    }
}