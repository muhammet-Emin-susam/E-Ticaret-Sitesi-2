using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretOtomasyonu.Models;
namespace E_TicaretOtomasyonu.Controllers
{
    public class MagazaUrunEkleController : Controller
    {
        // GET: MagazaUrunEkle
        Entities2 db = new Entities2();
        [HttpGet]
        public ActionResult Index()
        {
            List<SelectListItem> Categorys = (from i in db.TBLKATEGORILER.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.KategoriAD,
                                                  Value = i.ID.ToString()
                                              }).ToList();
            var model = db.TBLURUNLER.FirstOrDefault();
            ViewBag.Categorys = Categorys;
            return View(model);
            //return View();
        }
        public ActionResult UrunEkle(TBLURUNLER p)
        {
            if (Request.Files.Count > 0)
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

                    //var save = db.Products.Where(xa => xa.ID == p.ID).FirstOrDefault();
                    //save.CategoryID = 1;
                    //save.Name = p.Name;
                    //save.ImageURL = p.ImageURL;
                    //save.Description = p.Description;
                    //save.Price = p.Price;
                    //save.StoreID = p.ID;
                    //save.TradeMark = p.TradeMark;
                    //save.UnitsInStock = p.UnitsInStock;
                    db.TBLURUNLER.Add(new TBLURUNLER()
                    {
                        KategoriID = p.KategoriID,
                        UrunAdi = p.UrunAdi,
                        ImageURL = p.ImageURL,
                        Aciklama = p.Aciklama,
                        Fiyat = p.Fiyat,
                        Marka = p.Marka,
                        StokAdeti = p.StokAdeti,
                        KisaAciklama = p.KisaAciklama
                    });
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
                db.TBLURUNLER.Add(new TBLURUNLER()
                {
                    ImageURL = "0",
                    KategoriID = p.KategoriID,
                    UrunAdi = p.UrunAdi,
                    Aciklama = p.Aciklama,
                    Fiyat = p.Fiyat,
                    Marka = p.Marka,
                    StokAdeti = p.StokAdeti,
                    KisaAciklama = p.KisaAciklama
                });
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
            }
        }
    }
}