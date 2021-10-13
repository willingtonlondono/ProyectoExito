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

        private readonly Persistencia.Conexion _context;

        public IndexModel(Persistencia.Conexion context)
        {
            _context = context;
        }

        public IList<Consola> Consola { get;set; }

        public void OnGet(string sortOrder)
        {
            NombreSort = String.IsNullOrEmpty(sortOrder) ? "nombre_sort": "";
            var consoleOrder = _context.Consolas.ToList();
            if(NombreSort != null || NombreSort.Equals("")){
                consoleOrder.OrderBy(c => c.Nombre);
            }
            Consola =  consoleOrder.ToList();
        }
    }
}
