using MiniCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniCursos.Controllers
{
    public class DisciplinasController : Controller
    {
        BDCursosEntities bd = new BDCursosEntities();
        // GET: Disciplinas
        public ActionResult Index()
        {
            ViewBag.qtdDisciplinas = bd.Disciplinas.ToList().Count();
            return View(bd.Disciplinas.ToList());
        }
    }
}