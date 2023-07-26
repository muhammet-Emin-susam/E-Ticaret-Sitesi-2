using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretOtomasyonu.Models;
namespace E_TicaretOtomasyonu.Controllers
{
    public class HomeController : Controller
    {
        Entities2 db = new Entities2();
        public ActionResult Index()
        {
            ViewBag.Kategoriler = db.TBLKATEGORILER.ToList();
            ViewBag.Kampanyalar = db.TBLKAMPANYALAR.ToList();
            return View();
        }
        public ActionResult getKategori()
        {
            
            var partial = db.TBLKATEGORILER;

            return PartialView("Menuler", partial);
        }
        public ActionResult KategoriBazliUrunler(int ID)
        {
            var model = db.TBLURUNLER.Where(x => x.KategoriID == ID).ToList();
            var KategoriAd = db.TBLKATEGORILER.Where(x => x.ID == ID).FirstOrDefault();
            var FarkliUrunler = db.TBLURUNLER.ToList();
            ViewBag.FarkUrunler = FarkliUrunler;
            ViewBag.KategoriAd = KategoriAd.KategoriAD;
            ViewBag.KategoriAciklama = KategoriAd.KategoriAciklama;
            return View(model);
        }
        
        
        
    }
}