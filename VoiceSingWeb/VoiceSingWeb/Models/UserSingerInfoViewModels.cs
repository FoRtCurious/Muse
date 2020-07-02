using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace VoiceSingWeb.Models
{
    public class UserSingerInfoViewModels
    {
        public Users user { get; set; }
        public IEnumerable<UserMusics> musics { get; set; }
    }
}