using C_23052025_RUD.Data;
using C_23052025_RUD.Helpers;
using C_23052025_RUD.Models;
using C_23052025_RUD.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace C_23052025_RUD.Pages.Alumnos
{
  public class EditModel : PageModel
    {
        [BindProperty]
        public Alumno Alumno { get; set; }

        public void OnGet(int id)
        {
            Alumno? alumno = ServicioAlumno.BuscarPorId(id);
            if (alumno != null)
            {
              Alumno = alumno;
            }
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }
            ServicioAlumno.EditarAlumno(Alumno);
            return RedirectToPage("Index");
        }

    }
}
