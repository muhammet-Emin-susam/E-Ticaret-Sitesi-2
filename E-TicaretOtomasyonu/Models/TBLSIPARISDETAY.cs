//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E_TicaretOtomasyonu.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLSIPARISDETAY
    {
        public int ID { get; set; }
        public Nullable<int> UrunID { get; set; }
        public Nullable<decimal> Tutar { get; set; }
        public Nullable<int> Adet { get; set; }
        public Nullable<int> SiparisID { get; set; }
        public Nullable<System.DateTime> VerilisTarihi { get; set; }
    
        public virtual TBLSIPARIS TBLSIPARIS { get; set; }
        public virtual TBLURUNLER TBLURUNLER { get; set; }
    }
}
