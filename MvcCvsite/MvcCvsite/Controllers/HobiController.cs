using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvsite.Models.Entity;
using MvcCvsite.Repositories;

namespace MvcCvsite.Controllers
{
    public class HobiController : Controller
    {
        HobilerRepository repo = new HobilerRepository();
        // GET: Hobi
        [HttpGet]
        public ActionResult Index()
        {
            var hobi = repo.List();
            return View(hobi);
        }
        [HttpPost]
        public ActionResult Index(TblHobilerim p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Aciklama1 = p.Aciklama1;
            t.Aciklama2 = p.Aciklama2;
            repo.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}