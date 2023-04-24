using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvsite.Models.Entity;
using MvcCvsite.Repositories;

namespace MvcCvsite.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim

        iletisimrepository repo = new iletisimrepository();
        public ActionResult Index()
        {
            var iletisim = repo.List();
            return View(iletisim);

        }
    }
}