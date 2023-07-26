using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretOtomasyonu.Models;
namespace E_TicaretOtomasyonu.Controllers
{
    public class AdminKampanyalarController : Controller
    {
        // GET: AdminKampanyalar
        Entities2 db = new Entities2();
        public ActionResult Index()
        {
            var model = db.TBLKAMPANYALAR.ToList();
            return View(model);
        }
        public ActionResult KampanyaSil(int ID)
        {
            db.TBLKAMPANYALAR.Remove(db.TBLKAMPANYALAR.Where(x => x.ID == ID).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index", "AdminKampanyalar");
        }
        public ActionResult KampanyaEkle(TBLKAMPANYALAR p)
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
                        p.KampanyaResimURL = "/Resimler/Kampanyalar/" + fname;
                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("~/Resimler/Kampanyalar/"), fname);
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
                    db.TBLKAMPANYALAR.Add(new TBLKAMPANYALAR()
                    {
                       KampanyaResimURL = p.KampanyaResimURL
                    });
                    try
                    {
                        db.SaveChanges();
                        //return Json("Başarılı");
                        return RedirectToAction("Index", "AdminKampanyalar");

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
                db.TBLKAMPANYALAR.Add(new TBLKAMPANYALAR()
                {
                    KampanyaResimURL = p.KampanyaResimURL
                });
                try
                {
                    db.SaveChanges();
                    //return Json("Başarılı");
                    return RedirectToAction("Index", "AdminKampanyalar");

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