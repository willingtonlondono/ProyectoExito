using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentacion.Pages
{
    public class CerrarSesionModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Remove("usuarioAutenticado");
            return RedirectToPage("../Index");
        }
    }
}
