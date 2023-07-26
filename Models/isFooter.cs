using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_TicaretOtomasyonu.Models
{
    public class isFooter
    {
        public static List<TBLBILGILER> getFooter()
        {
            using (Entities2 db = new Entities2())
            {
                return db.TBLBILGILER.ToList();
            }
        }
    }
}