using MiniCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniCursos.Controllers
{
    
    public class HomeController : Controller
    {
        BDCursosEntities bd = new BDCursosEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult DashboadCursos()
        {
            if (Session["MyCurso"] != null)
            {
                return View(bd.GrupoCursoQuantidadeDisciplina.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerificarLogin(string login, string senha)
        {
            bool validado = true;
            if (validado == true)
            {
                Session["MyCurso"] = "MyCurso";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.textoErro = "Login ou senha incorreto";
                return RedirectToAction("Login");
            }

        }
    }
 }
