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
    
    public partial class Reply
    {
        public int Rno { get; set; }
        public int Responder_id { get; set; }
        public int RTLocation_id { get; set; }
        public int RBLocation_id { get; set; }
        public string RContent { get; set; }
        public System.DateTime Rtime { get; set; }
        public Nullable<int> Likesum { get; set; }
    
        public virtual Block Block { get; set; }
        public virtual Users Users { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
