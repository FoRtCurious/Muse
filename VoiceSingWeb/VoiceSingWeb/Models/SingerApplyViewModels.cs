using System.Collections.Generic;
using Models;

namespace VoiceSingWeb.Models
{
    public class SingerApplyViewModels
    {
        public Users user { get; set; }
        public IEnumerable<UserSingerApply> apply { get; set; }
    }
}