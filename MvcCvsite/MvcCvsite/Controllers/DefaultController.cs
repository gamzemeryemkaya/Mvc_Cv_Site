using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvsite.Models.Entity;
namespace MvcCvsite.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvsiteEntities1 db = new DbCvsiteEntities1();
        public ActionResult Index()
        {
            var degerler = db.TablHakkimda.ToList();
            return View(degerler);
        }
        public PartialViewResult Deneyimlerim()
        {
            var deneyimler = db.TblDeneyimler.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult SosyalMedyalar()
        {
            var sosyalmedya = db.TblSosyalMedyalar.Where(x=>x.Durum==true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.TblEgitim.ToList();
            return PartialView(egitimler);
        }
        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.TblYeteneklerim.ToList();
            return PartialView(yetenekler);
        }
        public PartialViewResult Hobilerim()
        {
            var hobiler = db.TblHobilerim.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult Sertifikalarim()
        {
            var sertifikalarim = db.TblSertifikalar.ToList();
            return PartialView(sertifikalarim);
        }
        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletisim( Tbliletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbliletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}