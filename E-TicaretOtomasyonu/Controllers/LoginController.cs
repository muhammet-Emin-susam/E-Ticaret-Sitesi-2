using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using E_TicaretOtomasyonu.Models;
namespace E_TicaretOtomasyonu.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GirisYap(string KullaniciSifre, string KullaniciEmail)
        {
            using (Entities2 db = new Entities2())
            {
                string md5pass = Crypto.Hash(KullaniciSifre, "MD5").ToString();
                if (KullaniciEmail != string.Empty && KullaniciSifre != string.Empty)
                {
                    //string sifre = Sifre.MD5Olustur(yourPassword);
                    var p = db.TBLKULLANICILAR.Where(x => x.KullaniciMail == KullaniciEmail && x.KullaniciSifre == md5pass).FirstOrDefault();
                    if (p != null)
                    {
                        Session["ID"] = p.ID;
                        Session["KullaniciMail"] = p.KullaniciMail;
                        Session["KullaniciAdi"] = p.KullaniciAdi;
                        Session["KullaniciRol"] = p.KullaniciRol;
                        //Session["UserImage"] = p.UserImage;
                        //return RedirectToAction("Index", "Admin");
                        return Json("Başarılı");
                    }
                    else
                    {
                        return Json("Hata");
                    }

                }
                else
                {
                    return Json("Bos");
                }
            }
        }
        public ActionResult CikisYap()
        {
            Session.Clear();
            return RedirectToAction("Index","Login");
        }
    }
}