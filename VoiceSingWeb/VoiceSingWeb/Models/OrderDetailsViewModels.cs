using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace VoiceSingWeb.Models
{
    public class OrderDetailsViewModels
    {
        public IEnumerable<Orderdetails> orderdetails { get; set; }
        public Orders order { get; set; }
    }
}