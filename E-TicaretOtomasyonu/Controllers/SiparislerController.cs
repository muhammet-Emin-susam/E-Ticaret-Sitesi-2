using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_TicaretOtomasyonu.Models;
namespace E_TicaretOtomasyonu.Controllers
{
    public class SiparislerController : Controller
    {
        Entities2 db = new Entities2();
        // GET: Siparisler
        public ActionResult Index()
        {
            //var model = db.TBLSIPARIS.Where(x => x.KullaniciID == ID).FirstOrDefault();
            var username = Convert.ToInt32(Session["ID"]);
            var order = db.TBLSIPARIS.Where(x => x.KullaniciID == username).ToList();
            List<Models.UserOrderModel> model = new List<UserOrderModel>();
            foreach (var item in order)
            {
                var bymodel = new UserOrderModel();
                bymodel.TotalPrice = (decimal)item.TBLSIPARISDETAY.Sum(y => y.Adet * y.Tutar);
                bymodel.OrderName = String.Join(", ", item.TBLSIPARISDETAY.Select(y => y.TBLURUNLER.UrunAdi + "(" + y.Adet + ")"));
                bymodel.AddedDate = (DateTime)item.VerilisTarihi;
                bymodel.OrderID = item.ID;
                model.Add(bymodel);
            }
            return View(model);
        }
    }
}