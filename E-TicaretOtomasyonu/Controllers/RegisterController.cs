using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using E_TicaretOtomasyonu.Models;
namespace E_TicaretOtomasyonu.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Register(string KullaniciAdi, string KullaniciMail, string KullaniciKayitSifresi, string KullaniciTel)
        {
            using (Entities2 db = new Entities2())
            {
                var count = db.TBLKULLANICILAR.Where(x => x.KullaniciMail == KullaniciMail).FirstOrDefault();
                if (count != null)
                {
                    return Json("ZatenVar");
                }
                else
                {
                    db.TBLKULLANICILAR.Add(new TBLKULLANICILAR()
                    {
                        KullaniciAdi = KullaniciAdi,
                        KullaniciMail = KullaniciMail,
                        KullaniciKatilimTarihi = DateTime.Now,
                        KullaniciTel = KullaniciTel,
                        KullaniciRol = "Musteri",
                        KullaniciSifre = Crypto.Hash(KullaniciKayitSifresi, "MD5")
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