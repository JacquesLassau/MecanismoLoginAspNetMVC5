using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MecanismoLoginAspNetMVC5.Models;

namespace MecanismoLoginAspNetMVC5.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (ValidarUsuario.UsuarioValido())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }            
        }
    }
}