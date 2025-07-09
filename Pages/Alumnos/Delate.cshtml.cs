using C_23052025_RUD.AccesoDatos;
using C_23052025_RUD.Data;
using C_23052025_RUD.Models;
using C_23052025_RUD.Repositorio;
using C_23052025_RUD.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace C_23052025_RUD.Pages.Alumnos
{
    public class DelateModel : PageModel
    {
        [BindProperty]
        public Alumno Alumno { get; set; }
        private readonly ServicioAlumno Servicios;
        public DelateModel()
        {
            iAccesoDatos<Alumno> acceso = new AccesoDatos<Alumno>("Alumnos");
            iRepositorio<Alumno> repo = new RepositorioCrudJson<Alumno>(acceso);
            Servicios = new ServicioAlumno(repo);
        }
        public IActionResult OnGet(int id)
        {
            var alumno = Servicios.BuscarPorId(id);
            if (alumno == null)
            {
                return RedirectToPage("Index");
            }
            Alumno = alumno;
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            Servicios.EliminarPorId(id);
            return RedirectToPage("Index");
        }

    }
}
