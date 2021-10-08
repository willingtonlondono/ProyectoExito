using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dominio;
using Persistencia;

namespace Presentacion.Pages.CrudEmpleado
{
    public class CreateModel : PageModel
    {
        private readonly Persistencia.Conexion _context;

        public SelectList SucursalesFront;

        public CreateModel(Persistencia.Conexion context)
        {
            _context = context;
        }

        //Comentario de prueba de clase
        public IActionResult OnGet()
        {
            List<Sucursal> listaSucursales = _context.Sucursal.ToList();
            SucursalesFront = new SelectList(listaSucursales, nameof(Sucursal.Id), nameof(Sucursal.Nombre));
            return Page();
        }

        [BindProperty]
        public Empleado Empleado { get; set; }

        public NombreRol NombreRol { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Empleado.PrimerIngreso = true;
            Empleado.password = Empleado.Cedula;
            _context.Empleados.Add(Empleado);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
