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
        private readonly ServicioAlumno Servicio;
        public DelateModel()
        {
            Servicio = new ServicioAlumno();
        }
        public IActionResult OnGet(int id)
        {
            var alumno = Servicio.BuscarPorId(id);
            if (alumno == null)
            {
                return RedirectToPage("Index");
            }
            Alumno = alumno;
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            Servicio.EliminarPorId(id);
            return RedirectToPage("Index");
        }

    }
}
