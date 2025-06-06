using C_23052025_RUD.Data;
using C_23052025_RUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace C_23052025_RUD.Pages.Alumnos
{
    public class CreateModel : PageModel
    {
        public void OnGet()
        {
        }
        [BindProperty]
        public Alumno Alumno { get; set; }

        public IActionResult OnPost()
        {
            if(DatosCompartidos.Alumnos.Any(a=> a.Ce == Alumno.Ce))
            {
                ModelState.AddModelError("Alumno.Ce", "Currently the E-Mail it's exists");
            }
            if(DatosCompartidos.Alumnos.Any(a=> a.Dni == Alumno.Dni))
            {
                ModelState.AddModelError("Alumno.Dni", "Currently this ID it's exists");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            Alumno.Id = DatosCompartidos.ObtenerNuevoId();
            DatosCompartidos.Alumnos.Add(Alumno);
            return RedirectToPage("Index");

        }
    }
}