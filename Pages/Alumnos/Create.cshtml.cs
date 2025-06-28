using C_23052025_RUD.Servicios;
using C_23052025_RUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace C_23052025_RUD.Pages.Alumnos
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Alumno Alumno { get; set; }
        private readonly ServicioAlumno Servicios;
        public CreateModel()
        {
            Servicios = new ServicioAlumno();
        }
        public void OnGet()
        {
        }


        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            Servicios.Agregar(Alumno);
            return RedirectToPage("Index");

        }
    }
}