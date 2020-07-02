using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoiceSingWeb.Models
{
    public class VideoDetailsIndexViewModels
    {
        public Videos video { get; set; }
        public IEnumerable<Videos> VideoRecommd { get; set; }
        public IEnumerable<VideoComment> comment { get; set; }
    }
}