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
    
    public partial class Addcomment
    {
        public int Addcommentid { get; set; }
        public int userId { get; set; }
        public int goodsid { get; set; }
        public int goodscommentid { get; set; }
        public System.DateTime addcommmenttime { get; set; }
        public string addcontent { get; set; }
    
        public virtual Goods Goods { get; set; }
        public virtual GoodsComment GoodsComment { get; set; }
        public virtual Users Users { get; set; }
    }
}