using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dominio;
using Persistencia;

namespace Presentacion.Pages.CrudConsola
{
    public class IndexModel : PageModel
    {

        public String NombreSort {get; set;}

        public String VersionSort {get; set;}

        public String Busqueda {get; set;}

        private readonly Persistencia.Conexion _context;

        public IndexModel(Persistencia.Conexion context)
        {
            _context = context;
        }

        public IList<Consola> Consola { get;set; }

        public void OnGet(string sortOrder, string Busqueda)
        {
            NombreSort = String.IsNullOrEmpty(sortOrder) ? "nombre_sort": "";
            VersionSort = String.IsNullOrEmpty(sortOrder) ? "version_sort": "";
            List<Consola> consoleOrder = _context.Consolas.ToList();

            if(!String.IsNullOrEmpty(Busqueda)){
                consoleOrder = _context.Consolas.Where(c => c.Nombre == Busqueda).ToList();
            }
            
            if(NombreSort != null && NombreSort.Equals("nombre_sort")){
                consoleOrder =  consoleOrder.OrderBy(c => c.Nombre).ToList();
            }else if(VersionSort != null && VersionSort.Equals("version_sort")){
                consoleOrder =  consoleOrder.OrderBy(c => c.Version).ToList();
            }else{
                consoleOrder =  consoleOrder.ToList();
            } 
            Consola = consoleOrder.ToList();    
           
        }
    }
}
