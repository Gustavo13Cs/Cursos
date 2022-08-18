using MiniCursos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult Create(string descricao,int iDCurso,int Carga)
        {
            Disciplinas novadisciplina = new Disciplinas();
            novadisciplina.DISDESCRIACAO = descricao;
            novadisciplina.CURSOID = iDCurso;
            novadisciplina.DISCH = Carga;

            bd.Disciplinas.Add(novadisciplina);
            bd.SaveChanges();

            return RedirectToAction("index");
        }


        [HttpGet]
        public ActionResult Detalhes(int? id)
        {
            Disciplinas exibirdisciplinas = bd.Disciplinas.ToList().Where(x => x.DISID == id).First();

            return View(exibirdisciplinas);
        }

        [HttpPost]
        public ActionResult DetalhesExibir(int? id)
        {
            Disciplinas exibirdisciplinas = bd.Disciplinas.ToList().Where(x => x.DISID == id).First();
            bd.Disciplinas.Remove(exibirdisciplinas);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Excluir(int? id)
        {
            Disciplinas excluirdisciplina = bd.Disciplinas.ToList().Where(x => x.DISID == id).First();
            return View(excluirdisciplina);
        }


        [HttpPost]
        public ActionResult ExcluirConfirma(int? id)
        {
            Disciplinas excluirdisciplina = bd.Disciplinas.ToList().Where(x => x.DISID == id).First();
            bd.Disciplinas.Remove(excluirdisciplina);
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

        [HttpGet]
        public ActionResult Editar(int? id)
        {
            Disciplinas disciplinaLocalizar = bd.Disciplinas.ToList().Where(x => x.DISID == id).First();
            return View(disciplinaLocalizar);
        }

        [HttpPost]
        public ActionResult Editar(int? id, string descricao, int IdCurso , int Carga)
        {
            Disciplinas atualizarDisciplinas = bd.Disciplinas.ToList().Where(x => x.DISID == id).First();
            atualizarDisciplinas.DISDESCRIACAO = descricao;
            atualizarDisciplinas.CURSOID = Convert.ToInt32(IdCurso);
            atualizarDisciplinas.DISCH = Convert.ToInt32(Carga);

            bd.Entry(atualizarDisciplinas).State = EntityState.Modified;
            bd.SaveChanges();
            return RedirectToAction("index");
        }

    }
}