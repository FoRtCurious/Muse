using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoiceSingWeb.Models
{
    public class UpdateAddressModel
    {
        //修改地址所需展示
        public int Addressid { get; set; }
        public string Name { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
    }
}