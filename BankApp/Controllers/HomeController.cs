using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HicFarketmezBank.Models;

namespace HicFarketmezBank.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Anasayfa()
        {
            return View();
        }
        public ActionResult Arama()
        {
            dbHostEntities2 entities = new dbHostEntities2();
            return View(entities.host.ToList());
        }
        public ActionResult Host(host hst)
        {
            dbHostEntities2 entities = new dbHostEntities2();
            var employee = entities.host.Where(e => e.hesapId == 2).ToList();
            return View(employee);
        }
    }
}