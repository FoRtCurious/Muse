using System.Collections.Generic;
using Models;

namespace VoiceSingWeb.Models
{
    public class CollectViewModel
    {
        public Users user { get; set; }
        public IEnumerable<MusicCollectRecord> musicCollect { get; set; }

        public IEnumerable<VideoCollectRecord> videoCollect { get; set; }
    }
}