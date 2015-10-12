using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeguimientoProyectosASP.NET.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.opcionMenu[0] = "active";
            ViewBag.Title = "Inicio";

            return View();
        }
    }
}