using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvsite.Models.Entity;
using MvcCvsite.Repositories;

namespace MvcCvsite.Controllers
{
    public class SosyalMedyaController : Controller
    {
        GenericRepository<TblSosyalMedyalar> repo = new GenericRepository<TblSosyalMedyalar>();
        // GET: SosyalMedya
   
        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TblSosyalMedyalar p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var sosyalsayfa = repo.Find(x => x.ID == id);
            return View(sosyalsayfa);
        }
        [HttpPost]
        public ActionResult SayfaGetir(TblSosyalMedyalar p)
        {
            var s = repo.Find(x => x.ID == p.ID);
            s.Ad = p.Ad;
            s.Durum = true;
            s.Link = p.Link;
            s.ikon = p.ikon;
            repo.TUpdate(s);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            hesap.Durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");

        }
    }
}