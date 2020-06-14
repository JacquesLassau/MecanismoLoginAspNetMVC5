using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MecanismoLoginAspNetMVC5.Models;
using MecanismoLoginAspNetMVC5.DAL;

namespace MecanismoLoginAspNetMVC5.Controllers
{
    public class AreaRestritaController : Controller
    {        
        public ActionResult Login()
        {
            string btnClick = Request["btnLogin"];

            if (btnClick == "Login")
            {
                string sessaoEmail = Request["txtEmailUsuario"];
                string sessaoSenha = Request["txtSenhaUsuario"];

                UsuarioDAL usuarioDAL = new UsuarioDAL();
                Usuario usuario = new Usuario(sessaoEmail, sessaoSenha);
                
                var login = usuarioDAL.AcessoUsuario(usuario);

                if(login != null)
                {
                    Session["sessaoEmail"] = usuario.EmailUsuario;
                    Session["sessaoId"] = usuario.IdUsuario;
                    return RedirectToAction("index", "Admin");
                }
                else
                {
                    return View();
                }

            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "AreaRestrita");
        }

    }
}