using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretOtomasyonu.Models;
namespace E_TicaretOtomasyonu.Controllers
{
    public class SepetController : Controller
    {
        Entities2 db = new Entities2();
        // GET: Sepet
        public ActionResult Index(int ID)
        {
            var partialView = db.TBLADRESLER.Where(x => x.KullaniciID == ID).ToList();
            ViewBag.adress = partialView;
            return View(getSepet());
        }

        public JsonResult SepeteEkle(int ID)
        {
            var urunler = db.TBLURUNLER.Where(i => i.ID == ID).FirstOrDefault();
            if (urunler != null)
            {
                getSepet().UrunEkle(urunler, 1);
            }
            return Json("Başarılı");
        }
        public JsonResult SepettenSil(int ID)
        {
            var urunler = db.TBLURUNLER.Where(i => i.ID == ID).FirstOrDefault();
            if (urunler != null)
            {
                getSepet().UrunSil(urunler);
            }
            return Json("Başarılı");
        }
        public Sepet getSepet()
        {
            var sepet = (Sepet)Session["Sepet"];
            if (sepet == null)
            {
                sepet = new Sepet();
                Session["Sepet"] = sepet;
            }

            return sepet;
        }
        public ActionResult SepetMenusu()
        {
            return PartialView(getSepet());
        }
        public ActionResult AdresSec(int ID)
        {
            var partialView = db.TBLADRESLER.Where(x => x.KullaniciID == ID).ToList();
            return PartialView("getAdres", partialView);
        }
        public ActionResult SatinAl(int KullaniciID, int AdresID)
        {
            Sepet crt = new Sepet();
            var cart = getSepet();
            List<SepetDetay> _cardLines = new List<SepetDetay>();
            //var order = new Order();
            //db.Orders.Add(new Orders()
            //{
            //    UserID = UserID,
            //    AddressID = AddressID,
            //    AddedDate = DateTime.Now,
            //    Status = "SA",
            //});
            var siparis = new TBLSIPARIS()
            {
                KullaniciID = KullaniciID,
                AdresID = AdresID,
                VerilisTarihi = DateTime.Now,
                ToplamTutar = cart.Sepetdetay.Sum(x => x.Urunler.Fiyat * x.Adet)
            };
            db.TBLSIPARIS.Add(siparis);
            db.SaveChanges();
            //SaveOrder(crt);
            foreach (var pr in cart.Sepetdetay)
            {
                db.TBLSIPARISDETAY.Add(new TBLSIPARISDETAY()
                {
                    Adet = pr.Adet,
                    Tutar = pr.Urunler.Fiyat,
                    UrunID = pr.Urunler.ID,
                    VerilisTarihi = DateTime.Now,
                    SiparisID = siparis.ID
                });
                var _product = db.TBLURUNLER.Where(x => x.ID == pr.Urunler.ID).FirstOrDefault();
                _product.StokAdeti= _product.StokAdeti - pr.Adet;
            }


            try
            {
                db.SaveChanges();
                ViewBag.Msg = "Kayıt Başarıyla Oluşturuldu.";
                cart.Temizle();
                return Json("Başarılı");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}