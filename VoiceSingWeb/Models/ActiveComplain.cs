//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ActiveComplain
    {
        public int id { get; set; }
        public Nullable<int> userid { get; set; }
        public Nullable<int> activeid { get; set; }
        public string content { get; set; }
        public Nullable<System.DateTime> complain_time { get; set; }
        public Nullable<int> complain_state { get; set; }
    
        public virtual Active Active { get; set; }
        public virtual Users Users { get; set; }
    }
}
