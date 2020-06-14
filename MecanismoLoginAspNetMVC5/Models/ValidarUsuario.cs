using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MecanismoLoginAspNetMVC5.Models
{
    public class ValidarUsuario
    {
        public static bool UsuarioValido()
        {
            HttpContext contexto = HttpContext.Current;
            if (contexto.Session["sessaoId"] != null)
            {
                return true;                
            }
            else
            {
                return false;
            }
            
        }
    }
}