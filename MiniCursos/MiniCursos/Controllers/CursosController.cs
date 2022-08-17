using MiniCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniCursos.Controllers
{
    public class CursosController : Controller
    {
        BDCursosEntities bd = new BDCursosEntities();
        // GET: Cursos
        public ActionResult Index()
        {
            ViewBag.qtdCursos = bd.Cursos.ToList().Count();

            return View(bd.Cursos.ToList());
        }
    }
}