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
    
    public partial class TBLSIPARIS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLSIPARIS()
        {
            this.TBLSIPARISDETAY = new HashSet<TBLSIPARISDETAY>();
        }
    
        public int ID { get; set; }
        public Nullable<int> KullaniciID { get; set; }
        public Nullable<int> AdresID { get; set; }
        public Nullable<System.DateTime> VerilisTarihi { get; set; }
        public string Aciklama { get; set; }
        public Nullable<decimal> ToplamTutar { get; set; }
    
        public virtual TBLADRESLER TBLADRESLER { get; set; }
        public virtual TBLKULLANICILAR TBLKULLANICILAR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLSIPARISDETAY> TBLSIPARISDETAY { get; set; }
    }
}
