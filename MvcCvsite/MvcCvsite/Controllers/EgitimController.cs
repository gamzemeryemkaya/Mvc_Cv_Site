using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvsite.Models.Entity;
using MvcCvsite.Repositories;

namespace MvcCvsite.Controllers
{
    [Authorize]
    public class EgitimController : Controller
    {
        // GET: Egitim
        EgitimRepository repo = new EgitimRepository();
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.Tdelete(egitim);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EgitimDüzenle(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EgitimDüzenle(TblEgitim p)
        {

            if (!ModelState.IsValid)
            {
                return View("EgitimDüzenle");
            }
            var  e = repo.Find(x => x.ID == p.ID);
            e.Baslik = p.Baslik;
            e.AltBaslik = p.AltBaslik;
            e.AltBaslik2 = p.AltBaslik2;
            e.Tarih = p.Tarih;
            e.GNO= p.GNO;
            repo.TUpdate(e);
            return RedirectToAction("Index");
        }
    }
}