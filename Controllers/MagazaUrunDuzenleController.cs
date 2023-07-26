using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretOtomasyonu.Models;
namespace E_TicaretOtomasyonu.Controllers
{
    public class MagazaUrunDuzenleController : Controller
    {
        // GET: MagazaUrunDuzenle
        Entities2 db = new Entities2();
        [HttpGet]
        public ActionResult Index(int ID)
        {
            List<SelectListItem> Categorys = (from i in db.TBLKATEGORILER.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.KategoriAD,
                                                  Value = i.ID.ToString()
                                              }).ToList();
            ViewBag.Categorys = Categorys;
            var model = db.TBLURUNLER.Where(x => x.ID == ID).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult UrunGuncelle(TBLURUNLER p)
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0 && p.ImageURL != null)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname = file.FileName;
                        p.ImageURL = "/Resimler/Urunler/" + fname;
                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("~/Resimler/Urunler/"), fname);
                        file.SaveAs(fname);

                    }
                    // Returns message that successfully uploaded  

                    var save = db.TBLURUNLER.Where(xa => xa.ID == p.ID).FirstOrDefault();
                    save.KategoriID = p.KategoriID;
                    save.UrunAdi = p.UrunAdi;
                    save.ImageURL = p.ImageURL;
                    save.Aciklama = p.Aciklama;
                    save.Fiyat = p.Fiyat;
                    save.Marka = p.Marka;
                    save.StokAdeti = p.StokAdeti;
                    save.KisaAciklama = p.KisaAciklama;
                    try
                    {
                        db.SaveChanges();
                        //return Json("Başarılı");
                        return RedirectToAction("Index", "MagazaUrunlerim/Index/");

                    }
                    catch (Exception e)
                    {
                        return Json("Hata " + e.Message);

                        //return RedirectToAction("/Index");
                    }
                    //return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }

            }
            else
            {
                var edit = db.TBLURUNLER.Where(xa => xa.ID == p.ID).FirstOrDefault();
                edit.KategoriID = p.KategoriID;
                edit.UrunAdi = p.UrunAdi;
                edit.Aciklama = p.Aciklama;
                edit.Fiyat = p.Fiyat;
                edit.Marka = p.Marka;
                edit.StokAdeti = p.StokAdeti;
                edit.KisaAciklama = p.KisaAciklama;
                try
                {
                    db.SaveChanges();
                    //return Json("Başarılı");
                    return RedirectToAction("Index","MagazaUrunlerim/Index/");

                }
                catch (Exception e)
                {
                    return Json("Hata " + e.Message);

                    //return RedirectToAction("/Index");
                }
            }
        }

        public ActionResult DeleteProduct(int ID)
        {
            db.TBLURUNLER.Remove(db.TBLURUNLER.Where(x => x.ID == ID).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index", "MagazaUrunlerim/Index/" + Session["ID"]);
        }
    }
}