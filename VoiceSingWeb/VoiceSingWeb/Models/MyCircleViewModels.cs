using System.Collections.Generic;
using Models;

namespace VoiceSingWeb.Models
{
    public class MyCircleViewModels
    {
        public IEnumerable<Circle> circles { get; set; }
        public IEnumerable<User_friends> myattention { get; set; }
    }
}