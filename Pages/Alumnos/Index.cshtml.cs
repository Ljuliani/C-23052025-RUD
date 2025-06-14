using C_23052025_RUD.Data;
using C_23052025_RUD.Models;
using C_23052025_RUD.Servicios;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace C_23052025_RUD.Pages.Alumnos
{
    public class IndexModel : PageModel
    {
        public List<Alumno> Alumnos { get; set; }
        public void OnGet()
        {
          Alumnos = ServicioAlumno.ObtenerAlumnos();
        }
    }
}
