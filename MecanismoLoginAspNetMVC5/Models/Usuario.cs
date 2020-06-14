using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MecanismoLoginAspNetMVC5.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public char TipoUsuario { get; set; }
        public char SituacaoUsuario { get; set; }

        public Usuario(){}

        public Usuario(string emailUsuario, string senhaUsuario)
        {
            this.EmailUsuario = emailUsuario;
            this.SenhaUsuario = senhaUsuario;
        }
    }
}