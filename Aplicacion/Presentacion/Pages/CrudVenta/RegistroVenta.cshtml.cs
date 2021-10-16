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

        [BindProperty]
        public int Cantidad {get; set;}
      
        Conexion conexion = new Conexion();


        public void OnGet()
        {
            Producto = conexion.Productos.ToList();
        }

        public RedirectToPageResult OnPostVender(int id){
            string username =  HttpContext.Session.GetString("username");
            Empleado e = conexion.Empleados.FirstOrDefault(e => e.usuario == username);
            var productoVendido = conexion.Productos.FirstOrDefault(p => p.Id == id);
            productoVendido.vendido = true;
            productoVendido.Empleado = e;
            conexion.SaveChanges();
            Venta venta = new Venta();
            venta.Producto = productoVendido;
            venta.CantidadProducto = Cantidad;
            venta.TotalVenta = productoVendido.PrecioVenta * Cantidad;
            venta.Empleado = e;
            conexion.SaveChanges();
            return RedirectToPage("./RegistroVenta");
        }
    }
}
