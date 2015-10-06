using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeguimientoProyectosASP.NET.Controllers
{
    public class HomeController : Controller
    {
        private string[] opcion_menu = new string[] { "active", "", "", "", "" };

        public ActionResult Index()
        {
            ViewBag.opcionMenu[0] = "active";
            ViewBag.Title = "Inicio";

            return View();
        }
    }
}