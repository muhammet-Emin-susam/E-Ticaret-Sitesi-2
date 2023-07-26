using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using E_TicaretOtomasyonu.Models;
namespace E_TicaretOtomasyonu.Controllers
{
    public class MagazaLoginController : Controller
    {
        // GET: MagazaLogin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GirisYap(string MagazaSifre, string MagazaEmail)
        {
            using (Entities2 db = new Entities2())
            {
                string md5pass = Crypto.Hash(MagazaSifre, "MD5").ToString();
                if (MagazaEmail != string.Empty && MagazaSifre != string.Empty)
                {
                    //string sifre = Sifre.MD5Olustur(yourPassword);
                    var p = db.TBLMAGAZA.Where(x => x.MagazaEmail == MagazaEmail && x.MagazaSifre == md5pass).FirstOrDefault();
                    if (p != null)
                    {
                        Session["ID"] = p.ID;
                        Session["KullaniciMail"] = p.MagazaEmail;
                        Session["KullaniciAdi"] = p.MagazaAdi;
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
    }
}