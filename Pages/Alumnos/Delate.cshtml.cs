using C_23052025_RUD.Data;
using C_23052025_RUD.Models;
using C_23052025_RUD.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace C_23052025_RUD.Pages.Alumnos
{
    public class DelateModel : PageModel
    {
        [BindProperty]
        public Alumno Alumno { get; set; }
        public IActionResult OnGet(int id)
        {
            var alumno = ServicioAlumno.BuscarPorId(id);
            if (alumno == null)
            {
                return RedirectToPage("Index");
            }
            Alumno = alumno;
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            ServicioAlumno.EliminarPorId(id);
            return RedirectToPage("Index");
        }

    }
}
