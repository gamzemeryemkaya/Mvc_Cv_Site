using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvsite.Models.Entity;
using MvcCvsite.Repositories;

namespace MvcCvsite.Controllers
{
    public class Yetenek1Controller : Controller
    {
        // GET: Yetenek1
      
        YetenekRepository repo = new YetenekRepository();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
         
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TblYeteneklerim p)
        {
          repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            var yetenekler = repo.Find(x => x.ID == id);
            repo.Tdelete(yetenekler);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDüzenle(int id)
        {
          var yetenek = repo.Find(x => x.ID == id);
            return View(yetenek);
        }
        [HttpPost]
        public ActionResult YetenekDüzenle(TblYeteneklerim p)
        {
            var yetenekler = repo.Find(x => x.ID == p.ID);
            yetenekler.Yetenek = p.Yetenek;
            yetenekler.Oran = p.Oran;

            repo.TUpdate(yetenekler);
            return RedirectToAction("Index");
        }
    }
}