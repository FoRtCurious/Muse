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
    
    public partial class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            this.Orderdetails = new HashSet<Orderdetails>();
        }
    
        public int orderid { get; set; }
        public int userid { get; set; }
        public int addressid { get; set; }
        public System.DateTime ordertime { get; set; }
        public decimal Tot_amt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orderdetails> Orderdetails { get; set; }
        public virtual Receipt_address Receipt_address { get; set; }
        public virtual Users Users { get; set; }
    }
}
