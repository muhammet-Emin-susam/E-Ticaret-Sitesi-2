using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretOtomasyonu.Models;
namespace E_TicaretOtomasyonu.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Entities2 db = new Entities2();
        public ActionResult Index(int ID)
        {
            var pr = db.TBLURUNLER.Where(x => x.ID == ID).FirstOrDefault();
            return View(pr);
        }

    }
}