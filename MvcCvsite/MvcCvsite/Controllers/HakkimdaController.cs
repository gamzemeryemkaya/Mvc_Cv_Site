using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvsite.Models.Entity;
using MvcCvsite.Repositories;
namespace MvcCvsite.Controllers
{
    public class HakkimdaController : Controller
    {
        HakkimdaRepository repo = new HakkimdaRepository();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(TablHakkimda p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Adres = p.Adres;
            t.Telefon = p.Telefon;
            t.Mail = p.Mail;
            t.Aciklama = p.Aciklama;
            t.Resim = p.Resim;
            repo.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}