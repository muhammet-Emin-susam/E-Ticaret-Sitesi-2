using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretOtomasyonu.Models;
namespace E_TicaretOtomasyonu.Controllers
{
    public class MagazaAnasayfaController : Controller
    {
        // GET: MagazaAnasayfa
        Entities2 db = new Entities2();
        public ActionResult Index()
        {
            var model = db.TBLURUNLER.ToList();
            ViewBag.UrunSayisi = model.Count;


            return View();
        }
    }
}