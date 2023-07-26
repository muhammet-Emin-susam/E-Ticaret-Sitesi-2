using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretOtomasyonu.Models;
namespace E_TicaretOtomasyonu.Controllers
{
    public class ProfilController : Controller
    {
        Entities2 db = new Entities2();
        // GET: Profil
        public ActionResult Index(int ID)
        {
            var partial = db.TBLKULLANICILAR.Where(x => x.ID == ID).FirstOrDefault();
            ViewBag.Adreslerim = db.TBLADRESLER.Where(x => x.KullaniciID == ID).ToList();
            return View(partial);
        }
        public ActionResult KullaniciDuzenleme(int ID)
        {
            var partialView = db.TBLKULLANICILAR.Where(x => x.ID == ID).FirstOrDefault();
            return PartialView("ProfilDuzenleme", partialView);
        }
        public ActionResult AdresDuzenleme(int ID)
        {
            var partialView = db.TBLADRESLER.Where(x => x.KullaniciID == ID).FirstOrDefault();
            return PartialView("AdresDuzenle", partialView);
        }
        public ActionResult KullaniciGuncelle(int ID,string KullaniciAdi,string KullaniciMail,string KullaniciTel)
        {
            var kullanici = db.TBLKULLANICILAR.Where(x => x.ID == ID).FirstOrDefault();
            kullanici.KullaniciAdi = KullaniciAdi;
            kullanici.KullaniciMail = KullaniciMail;
            kullanici.KullaniciTel = KullaniciTel;
            try
            {
                db.SaveChanges();
                return Json("Başarılı");
            }
            catch (Exception)
            {
                return Json("Hata");
            }
        }
        public ActionResult AdresEkle(int KullaniciID, string AdresAdi, string Adres, int ApartNo, int EvNo, string Sehir, string Ulke)
        {

            db.TBLADRESLER.Add(new TBLADRESLER()
            {
                KullaniciID = KullaniciID,
                AdresAdi = AdresAdi,
                AdresAciklama = Adres,
                ApartmanNo = ApartNo,
                EvNo = EvNo,
                Sehir = Sehir,
                Ulke = Ulke
            });

            try
            {
                db.SaveChanges();
                return Json("Başarılı");

            }
            catch (Exception e)
            {
                return Json("Hata " + e.Message);
            }
        }
        public JsonResult AdresSil(int ID)
        {
            db.TBLADRESLER.Remove(db.TBLADRESLER.Where(x => x.ID == ID).FirstOrDefault());
            db.SaveChanges();
            return Json("Başarılı");
        }
        public ActionResult AdresGuncelle(int ID,string AdresAdi, string Adres, string ApartNo, string EvNo, string Sehir, string Ulke)
        {
            var kullanici = db.TBLADRESLER.Where(x => x.KullaniciID == ID).FirstOrDefault();
            kullanici.AdresAdi = AdresAdi;
            kullanici.AdresAciklama = Adres;
            kullanici.ApartmanNo = int.Parse(ApartNo);
            kullanici.EvNo = int.Parse(EvNo);
            kullanici.Sehir = Sehir;
            kullanici.Ulke = Ulke;
            try
            {
                db.SaveChanges();
                return Json("Başarılı");
            }
            catch (Exception)
            {
                return Json("Hata");
            }
        }
    }
}