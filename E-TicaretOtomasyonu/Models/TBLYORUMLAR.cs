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
    
    public partial class TBLYORUMLAR
    {
        public int ID { get; set; }
        public string Yorum { get; set; }
        public Nullable<int> KullaniciID { get; set; }
        public Nullable<int> UrunID { get; set; }
        public Nullable<System.DateTime> EklenmeTarihi { get; set; }
    
        public virtual TBLKULLANICILAR TBLKULLANICILAR { get; set; }
        public virtual TBLURUNLER TBLURUNLER { get; set; }
    }
}
