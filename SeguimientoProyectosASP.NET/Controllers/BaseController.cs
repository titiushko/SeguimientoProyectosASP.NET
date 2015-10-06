using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeguimientoProyectosASP.NET.Models;

namespace SeguimientoProyectosASP.NET.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            /*
             * Sidebar Options:
             * 0 = Inicio
             * 1 = Proyectos
             * 2 = Tareas
             * 3 = Responsables
             * 4 = Usuarios
             */
            ViewBag.opcionMenu = new string[] { "", "", "", "", "" };
        }
    }
}