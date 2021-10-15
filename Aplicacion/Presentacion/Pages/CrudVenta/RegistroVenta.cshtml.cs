using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;
using Microsoft.AspNetCore.Http;

namespace presentacion.Pages
{
    public class RegistroVentaModel : PageModel
    {

        [BindProperty]
        public List<Producto> Producto {get; set;}

        public Producto ProductoID {get; set;}
        Conexion conexion = new Conexion();


        public void OnGet()
        {
            Producto = conexion.Productos.ToList();
        }

        public void OnPost(int id){
            Console.WriteLine(id);
            //string username =  HttpContext.Session.GetString("username");
            //Empleado e = conexion.Empleados.FirstOrDefault(e => e.usuario == username);
            //var productoVendido = conexion.Productos.FirstOrDefault(p => p.Id == id);
            //productoVendido.vendido = true;
            //productoVendido.Empleado = e;
            //conexion.SaveChanges();
        }
    }
}
