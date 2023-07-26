using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretOtomasyonu.Models;
namespace E_TicaretOtomasyonu.Controllers
{
    public class AdminKategorilerController : Controller
    {
        // GET: AdminKategoriler
        Entities2 db = new Entities2();
        public ActionResult Index()
        {
            var model = db.TBLKATEGORILER.ToList();
            return View(model);
        }
        public ActionResult KategoriDuzenle(int ID)
        {
            var model = db.TBLKATEGORILER.Where(x => x.ID == ID).FirstOrDefault();
            return View(model);
        }
        public ActionResult KategoriSil(int ID)
        {
            db.TBLKATEGORILER.Remove(db.TBLKATEGORILER.Where(x => x.ID == ID).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index", "AdminKategoriler");
        }
        public ActionResult EditKategori(TBLKATEGORILER p)
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0 && p.ResimURL != null)
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
                        p.ResimURL = "/Resimler/Kategoriler/" + fname;
                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("~/Resimler/Kategoriler/"), fname);
                        file.SaveAs(fname);

                    }
                    // Returns message that successfully uploaded  

                    var save = db.TBLKATEGORILER.Where(xa => xa.ID == p.ID).FirstOrDefault();
                    save.KategoriAD = p.KategoriAD;
                    save.KategoriAciklama = p.KategoriAciklama;
                    save.ResimURL = p.ResimURL;
                    try
                    {
                        db.SaveChanges();
                        //return Json("Başarılı");
                        return RedirectToAction("Index", "AdminKategoriler");

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
                var edit = db.TBLKATEGORILER.Where(xa => xa.ID == p.ID).FirstOrDefault();
                edit.KategoriAD = p.KategoriAD;
                edit.KategoriAciklama = p.KategoriAciklama;
                try
                {
                    db.SaveChanges();
                    //return Json("Başarılı");
                    return RedirectToAction("Index", "AdminKategoriler");

                }
                catch (Exception e)
                {
                    return Json("Hata " + e.Message);

                    //return RedirectToAction("/Index");
                }
            }
        }
        public ActionResult KategoriEkle()
        {
            return View();
        }
        public ActionResult AddKategoeri(TBLKATEGORILER p)
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
                        p.ResimURL = "/Resimler/Kategoriler/" + fname;
                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("~/Resimler/Kategoriler/"), fname);
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
                    db.TBLKATEGORILER.Add(new TBLKATEGORILER()
                    {
                        KategoriAD = p.KategoriAD,
                        KategoriAciklama = p.KategoriAciklama,
                        EklenmeTarihi = DateTime.Now,
                        ResimURL = p.ResimURL,
                    }); ;
                    try
                    {
                        db.SaveChanges();
                        //return Json("Başarılı");
                        return RedirectToAction("Index", "AdminKategoriler");

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
                db.TBLKATEGORILER.Add(new TBLKATEGORILER()
                {
                    KategoriAD = p.KategoriAD,
                    KategoriAciklama = p.KategoriAciklama,
                    EklenmeTarihi = DateTime.Now
                });
                try
                {
                    db.SaveChanges();
                    //return Json("Başarılı");
                    return RedirectToAction("Index", "AdminKategoriler");

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