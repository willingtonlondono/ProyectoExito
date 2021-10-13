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

        public int SucursalId {get; set;}

        public string usuarioCreado {get; set;}

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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Empleado verificarUsuario = _context.Empleados.FirstOrDefault(e => e.usuario == Empleado.usuario);
            if(verificarUsuario != null){
                usuarioCreado = "El nombre de usuario ya esta en uso";
                return Page();
            }else{
                Sucursal sucursal = _context.Sucursal.FirstOrDefault(s => s.Id == SucursalId);
                Empleado.Sucursal = sucursal;
                Empleado.PrimerIngreso = true;
                Empleado.password = Empleado.Cedula;
                _context.Empleados.Add(Empleado);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
        }
    }
}
