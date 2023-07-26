using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using E_TicaretOtomasyonu.Models;
namespace E_TicaretOtomasyonu.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GirisYap(string AdminSifre, string AdminEmail)
        {
            using (Entities2 db = new Entities2())
            {
                
                if (AdminEmail != string.Empty && AdminSifre != string.Empty)
                {
                    //string sifre = Sifre.MD5Olustur(yourPassword);
                    var p = db.TBLADMINLER.Where(x => x.Email == AdminEmail && x.Sifre== AdminEmail).FirstOrDefault();
                    if (p != null)
                    {
                        Session["ID"] = p.ID;
                        Session["KullaniciMail"] = p.Email;
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