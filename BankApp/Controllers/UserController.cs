using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HicFarketmezBank.Models;


namespace HicFarketmezBank.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public ActionResult exit()
        {
            Session["kAdı"] = null;
            return RedirectToAction("Login", "User");
        }


        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            Kullanici müst = new Kullanici();
            return View(müst);
        }
        
        [HttpPost]
        
        public ActionResult AddOrEdit(Kullanici müst)
        {
            using(dbHostEntities2 entities = new dbHostEntities2())
            {
                entities.Kullanici.Add(müst);
                entities.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Succesfull.";
            return View("AddOrEdit", new Kullanici());
        }
        
        dbHostEntities2 entities1 = new dbHostEntities2();

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["kAdı"] != null)
            {
                return RedirectToAction("Anasayfa", "Home", new { session = Session["kAdı"].ToString() });
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(Kullanici login)
        {
            var myUser = entities1.Kullanici
    .FirstOrDefault(u => u.kullanıcıadı == login.kullanıcıadı
                 && u.parola == login.parola);

            if (myUser != null)    //User was found
            {
                Session["kAdı"] =  myUser.kullanıcıadı;
                return RedirectToAction("Anasayfa","Home",new { session = myUser.kullanıcıadı });
            }
            else    //User was not found
            {
                var yanıt = "Kullanıcı Adı veya Parola Hatalı";
                    ViewBag.NotValidUser = yanıt;
                return View();
            }
        }
        


        [HttpGet]

        public ActionResult Arama()
        {
            if (Session["kAdı"]==null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            { 
            return View(entities1.host.ToList());
        }
        }



        [HttpGet]

        public ActionResult HesapEkle()
        {
            return View();
        }
/**
        [HttpPost]

        public ActionResult HesapEkle(Hesap hsp)
        {
            using (dbHostEntities2 entities = new dbHostEntities2())
            {
                hsp.müsteriNo = Session["kAdı"].ToString();
                hsp.hesapDurumu = 1.ToString();
                hsp.bakiye = 0.ToString();
                hsp.hesapNo=(100+Butter.hesapsayisi).ToString();
                entities.Hesap.Add(hsp);
                entities.SaveChanges();
                Butter.hesapsayisi++;       
            }
            ModelState.Clear();
            return RedirectToAction("Hesap", "User", new { session = Session["kAdı"].ToString() });
        }
    **/
    }
}