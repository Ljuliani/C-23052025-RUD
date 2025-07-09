using C_23052025_RUD.AccesoDatos;
using C_23052025_RUD.Data;
using C_23052025_RUD.Helpers;
using C_23052025_RUD.Models;
using C_23052025_RUD.Repositorio;
using C_23052025_RUD.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace C_23052025_RUD.Pages.Alumnos
{
  public class EditModel : PageModel
    {
        [BindProperty]
        public Alumno? Alumno { get; set; }
        private readonly ServicioAlumno Servicios;
        public EditModel()
        {
            iAccesoDatos<Alumno> acceso = new AccesoDatos<Alumno>("Alumnos");
            iRepositorio<Alumno> repo = new RepositorioCrudJson<Alumno>(acceso);
            Servicios = new ServicioAlumno(repo);
        }

        public void OnGet(int id)
        {
            Alumno? alumno = Servicios.BuscarPorId(id);
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
            Servicios.Editar(Alumno);
            return RedirectToPage("Index");
        }

    }
}
