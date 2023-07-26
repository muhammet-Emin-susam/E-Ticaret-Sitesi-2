using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using E_TicaretOtomasyonu.Models;
namespace E_TicaretOtomasyonu.Controllers
{
    public class MagazaKayitOlController : Controller
    {
        // GET: MagazaKayitOl
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult KayitOl(string MagazaMail, string MagazaSifre,string MagazaAdi)
        {
            using (Entities2 db = new Entities2())
            {
                var count = db.TBLMAGAZA.Where(x => x.MagazaEmail == MagazaMail).FirstOrDefault();
                if (count != null)
                {
                    return Json("ZatenVar");
                }
                else
                {
                    db.TBLMAGAZA.Add(new TBLMAGAZA()
                    {
                        MagazaEmail = MagazaMail,
                        MagazaAdi = MagazaAdi,
                        MagazaSifre = Crypto.Hash(MagazaSifre, "MD5")
                    });
                    try
                    {
                        db.SaveChanges();
                        return Json("Başarılı");
                    }
                    catch (Exception e)
                    {
                        return Json(e.Message);
                    }
                }
            }
        }
    }
}