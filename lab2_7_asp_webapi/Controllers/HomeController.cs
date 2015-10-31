using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab2_7_asp_webapi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Афиша";

            return View();
        }
        public ActionResult Cinema()
        {
            ViewBag.Title = "Кинотеатры";
            return View();
        }
        public ActionResult Film()
        {
            ViewBag.Title = "Фильмы";
            return View();
        }
        public ActionResult Seance()
        {
            ViewBag.Title = "Сеансы";
            return View();
        }
    }
}
