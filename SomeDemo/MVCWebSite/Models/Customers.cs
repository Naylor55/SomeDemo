//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCWebSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customers()
        {
            this.Orders = new HashSet<Orders>();
        }
    
        public string c_ID { get; set; }
        public string c_Name { get; set; }
        public string c_TrueName { get; set; }
        public string c_Gender { get; set; }
        public System.DateTime c_Birth { get; set; }
        public string c_CardID { get; set; }
        public string c_Address { get; set; }
        public string c_Postcode { get; set; }
        public string c_Mobile { get; set; }
        public string c_Phone { get; set; }
        public string c_Email { get; set; }
        public string c_Password { get; set; }
        public string c_SafeCode { get; set; }
        public string c_Question { get; set; }
        public string c_Answer { get; set; }
        public string c_Type { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
