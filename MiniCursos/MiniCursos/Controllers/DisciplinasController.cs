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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string descricao, string iDCurso, string CargaHoraria)
        {
            Cursos novocurso = new Cursos();
            novocurso.CURSODESCRICAO = descricao;
            novocurso.CURSOCODHABILIDADE = iDCurso;
            novocurso.CURSOMODALIDADE = CargaHoraria;

            bd.Cursos.Add(novocurso);
            bd.SaveChanges();

            return RedirectToAction("index");
        }
    }
}