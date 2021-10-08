using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistencia;
using Microsoft.AspNetCore.Http;
using Dominio;

namespace Presentacion.Pages
{
    public class CambiarContrasenaModel : PageModel
    {

         [BindProperty]
        public string Password { get; set; }


        [BindProperty]
        public string RepeatPassword { get; set; }

        [BindProperty]
        public string MensajePassword { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            Conexion conn = new Conexion();
            var Username = HttpContext.Session.GetString("username");
            HttpContext.Session.Remove("username");
            Empleado empleado = conn.Empleados.FirstOrDefault(e => e.usuario == Username);
            if(!Password.Equals(RepeatPassword)){
                MensajePassword = "Las contraseñas no coinciden";
            }else{
                empleado.password = Password;
                empleado.PrimerIngreso = false;
                conn.SaveChanges();
            }
        }
    }
}
