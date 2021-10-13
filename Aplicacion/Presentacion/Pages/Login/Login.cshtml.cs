using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;
using Microsoft.AspNetCore.Http;

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

        [BindProperty]
        public bool UsuarioAutenticado {get; set;}


        public void OnGet()
        {
            var usuarioAutenticado = HttpContext.Session.GetString("usuarioAutenticado");
            if(usuarioAutenticado != null){
                UsuarioAutenticado = true;
            }else{
                UsuarioAutenticado = false;
            }

        }

        public IActionResult OnPost(){
            Conexion conexion = new Conexion();
            Empleado empleado = conexion.Empleados.FirstOrDefault(e => e.usuario == Usuario);
            if(empleado != null){
                if(empleado.PrimerIngreso && empleado.password.Equals(empleado.Cedula)){
                    HttpContext.Session.SetString("username", Usuario);
                    Console.WriteLine(empleado.PrimerIngreso);
                    return RedirectToPage("../CambiarContrasena/CambiarContrasena");
                }
                if(empleado.password.Equals(Contrasena)){
                    HttpContext.Session.SetString("usuarioAutenticado", empleado.NombreRol.ToString());
                    switch(empleado.NombreRol){
                        case NombreRol.ADMINISTRADOR_COMPRAS:
                            return RedirectToPage("../CrudConsola/Index");
                        case NombreRol.ADMINISTRADOR_VENTAS:
                            return RedirectToPage("../CrudConsola/Index");
                        case NombreRol.ADMINISTRADOR_SISTEMA:
                            return RedirectToPage("../CrudEmpleado/Index");
                        case NombreRol.VENDEDOR:
                            return RedirectToPage("../CrudConsola/Index");
                        case NombreRol.USUARIO:
                            return RedirectToPage("../CrudConsola/Index");
                        default:
                        return RedirectToPage("../Index");
                    }       
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
