using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretOtomasyonu.Models;
namespace E_TicaretOtomasyonu.Controllers
{
    public class AdminIletisimController : Controller
    {
        // GET: AdminIletisim
        Entities2 db = new Entities2();
        public ActionResult Index()
        {
            var model = db.TBLBILGILER.FirstOrDefault();
            return View(model);
        }
        public ActionResult BilgilerimGuncelle(string Email,string Adres, string Telno)
        {
            using (Entities2 db = new Entities2())
            {
                var edit = db.TBLBILGILER.FirstOrDefault();
                edit.Adres = Adres;
                edit.Email = Email;
                edit.TelNo = Telno;
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