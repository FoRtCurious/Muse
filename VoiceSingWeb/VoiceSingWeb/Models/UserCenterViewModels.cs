using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace VoiceSingWeb.Models
{
    public class UserCenterViewModels
    {
        public Users user { get; set; }
        public IEnumerable<PlayRecord> recentplay { get; set; }
        public IEnumerable<MusicCollectRecord> collectmusic { get; set; }
        public IEnumerable<VideoCollectRecord> collectvideo { get; set; }
        public IEnumerable<UserMusics> upmusic { get; set; }
        public IEnumerable<Videos> upvideo { get; set; }
    }
}