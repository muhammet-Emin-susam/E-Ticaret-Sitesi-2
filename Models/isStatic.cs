using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_TicaretOtomasyonu.Models
{
    public class isStatic
    {
        public static List<TBLKATEGORILER> getKategori()
        {
            using (Entities2 db = new Entities2())
            {
                return db.TBLKATEGORILER.ToList();
            }
        }
        
    }
}