using C_23052025_RUD.AccesoDatos;
using C_23052025_RUD.Models;
using C_23052025_RUD.Repositorio;
using C_23052025_RUD.Servicios;
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
            iAccesoDatos<Alumno> acceso = new AccesoDatos<Alumno>("Alumnos");
            iRepositorio<Alumno> repo = new RepositorioCrudJson<Alumno>(acceso);
            Servicios = new ServicioAlumno(repo);
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
            if(Servicios.CDD(Alumno.Dni))
            {
                 ModelState.AddModelError("Alumno.Dni", "Student id, currently exists");
                return Page();
            }
            Servicios.Agregar(Alumno);
            return RedirectToPage("Index");

        }
    }
}