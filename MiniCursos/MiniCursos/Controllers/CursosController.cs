using MiniCursos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniCursos.Controllers
{
    public class CursosController : Controller
    {
        BDCursosEntities bd = new BDCursosEntities();
        // GET: Cursos
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.qtdCursos = bd.Cursos.ToList().Count();

            return View(bd.Cursos.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string descricao, string habilidade,string modalidade)
        {
            Cursos novocurso = new Cursos();
            novocurso.CURSODESCRICAO = descricao;
            novocurso.CURSOCODHABILIDADE = habilidade;
            novocurso.CURSOMODALIDADE = modalidade;
         
            bd.Cursos.Add(novocurso);
            bd.SaveChanges();

            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Editar(int ?id)
        {
            Cursos cursosLocalizar = bd.Cursos.ToList().Where(x => x.CURSOID == id).First();
            return View(cursosLocalizar);
        }

        [HttpPost]
        public ActionResult Editar(int? id,string descricao, string habilidade, string modalidade)
        {
            Cursos atualizarCursos = bd.Cursos.ToList().Where(x => x.CURSOID == id).First();
            atualizarCursos.CURSODESCRICAO = descricao;
            atualizarCursos.CURSOCODHABILIDADE = habilidade;
            atualizarCursos.CURSOMODALIDADE = modalidade;

            bd.Entry(atualizarCursos).State = EntityState.Modified;
            bd.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Detalhes(int? id)
        {
            Cursos exibircursos = bd.Cursos.ToList().Where(x => x.CURSOID == id).First();

            return View(exibircursos);
        }

        [HttpPost]
        public ActionResult DetalhesExibir(int? id)
        {
            Cursos exibircursos = bd.Cursos.ToList().Where(x => x.CURSOID == id).First();
            bd.Cursos.Remove(exibircursos);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Excluir(int? id)
        {
            Cursos excluircurso = bd.Cursos.ToList().Where(x => x.CURSOID== id).First();
            return View(excluircurso);
        }


        [HttpPost]
        public ActionResult ExcluirConfirma(int? id)
        {
            Cursos excluircurso = bd.Cursos.ToList().Where(x => x.CURSOID == id).First();
            bd.Cursos.Remove(excluircurso);
            try
            {
                bd.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("index");
            }

            return RedirectToAction("index");
        }

        public ActionResult DisciplinaPorCurso (int? id)
        {
            return View(bd.Disciplinas.ToList().Where(x=>x.CURSOID==id));
        }

    }
}