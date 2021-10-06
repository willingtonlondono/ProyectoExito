using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Presentacion.Pages
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        public string Usuario { get; set; }


        [BindProperty]
        public string Contrasena { get; set; }


        [BindProperty]
        public string MensajeUsuario { get; set; }

        [BindProperty]
        public string MensajePassword { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost(){
            Conexion conexion = new Conexion();
            Empleado empleado = conexion.Empleados.FirstOrDefault(e => e.usuario == Usuario);
            if(empleado != null){
                if(empleado.password.Equals(Contrasena)){
                    return RedirectToPage("../Index");
                }else{
                    MensajePassword = "El password no coincide";
                    return Page();
                }    
            }else{
                MensajeUsuario = "Usuario no ha sido encontrado";
                return Page();
            }

            
        }
    }
}
