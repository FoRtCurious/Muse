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
    
    public partial class Circle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Circle()
        {
            this.CircleComplain = new HashSet<CircleComplain>();
            this.Circlereply = new HashSet<Circlereply>();
        }
    
        public int cno { get; set; }
        public int userid { get; set; }
        public Nullable<System.DateTime> uptime { get; set; }
        public string content { get; set; }
        public string imageurl { get; set; }
        public Nullable<int> thumbs { get; set; }
        public Nullable<int> replysum { get; set; }
        public string varify { get; set; }
        public Nullable<int> c_state { get; set; }
    
        public virtual Users Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CircleComplain> CircleComplain { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Circlereply> Circlereply { get; set; }
    }
}
