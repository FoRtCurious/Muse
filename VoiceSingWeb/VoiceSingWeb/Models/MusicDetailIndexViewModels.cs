using System.Collections.Generic;
using Models;

namespace VoiceSingWeb.Models
{
    public class MusicDetailIndexViewModels
    {
        public UserMusics music { get; set; }
        public IEnumerable<UserMusics> GuessYouLike { get; set; }
        public IEnumerable<UserMusics> TodayHotMusic { get; set; }
        public IEnumerable<MusicComment> Comment { get; set; }
    }
}