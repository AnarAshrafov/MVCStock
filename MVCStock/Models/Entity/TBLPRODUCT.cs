//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCStock.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLPRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLPRODUCT()
        {
            this.TBLSALES = new HashSet<TBLSALE>();
        }
    
        public int PRODUCTID { get; set; }
        public string PRODUCTNAME { get; set; }
        public string BRAND { get; set; }
        public Nullable<short> PRODUCTCATEGORY { get; set; }
        public Nullable<decimal> PRICE { get; set; }
        public Nullable<byte> STOCK { get; set; }
    
        public virtual TBLCATEGORy TBLCATEGORy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLSALE> TBLSALES { get; set; }
    }
}