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
    
    public partial class Topic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Topic()
        {
            this.Reply = new HashSet<Reply>();
        }
    
        public int Tno { get; set; }
        public string Tname { get; set; }
        public int Holder { get; set; }
        public int Location { get; set; }
        public string TContent { get; set; }
        public Nullable<int> Readsum { get; set; }
        public Nullable<int> Replysum { get; set; }
        public string Varify { get; set; }
    
        public virtual Block Block { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reply> Reply { get; set; }
        public virtual Users Users { get; set; }
    }
}