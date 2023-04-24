using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvsite.Models.Entity;
using MvcCvsite.Repositories;

namespace MvcCvsite.Controllers
{
    
    public class SertifikaController : Controller
    { 
        // GET: Sertifika
        SertifikalarRepository repo = new SertifikalarRepository();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifikalar p)
        {
          
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.ID ==id);
            repo.Tdelete(sertifika);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifikalar p)
        {

            var s = repo.Find(x => x.ID == p.ID);
            s.Tarih = p.Tarih;
            s.Aciklama = p.Aciklama;
            repo.TUpdate(s);
            return RedirectToAction("Index");


        }


    }
}