using C_23052025_RUD.AccesoDatos;
using C_23052025_RUD.Models;
using C_23052025_RUD.Repositorio;
using C_23052025_RUD.Servicios;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace C_23052025_RUD.Pages.Alumnos
{
    public class IndexModel : PageModel
    {
        public List<Alumno> Alumnos { get; set; }
        private readonly ServicioAlumno Servicio;
        public IndexModel()
        {
            iAccesoDatos<Alumno> acceso = new AccesoDatos<Alumno>("Alumnos");
            iRepositorio<Alumno> repo = new RepositorioCrudJson<Alumno>(acceso);
            Servicio = new ServicioAlumno(repo);
        }
        public void OnGet()
        {
            Alumnos = Servicio.Obtenertodos();
        }
    }
}
