using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace VoiceSingWeb.Models
{
    public class VideoIndexViewModels
    {
        public IEnumerable<Videos> videos { get; set; }
        public IEnumerable<VideoType> videotype { get; set; }        
    }
}