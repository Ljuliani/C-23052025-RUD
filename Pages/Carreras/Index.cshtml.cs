using C_23052025_RUD.AccesoDatos;
using C_23052025_RUD.Models;
using C_23052025_RUD.Repositorio;
using C_23052025_RUD.Servicios;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace C_23052025_RUD.Pages.Carreras
{
    public class IndexModel : PageModel
    {
        public List<Carrera> Carreras { get; set; }
        private readonly ServicioCarrera Servicio;
        public IndexModel()
        {
            iAccesoDatos<Carrera> acceso = new AccesoDatos<Carrera>("Carreras");
            iRepositorio<Carrera> repo = new RepositorioCrudJson<Carrera>(acceso);
            Servicio = new ServicioCarrera(repo);
        }
        public void OnGet()
        {

            Carreras = Servicio.Obtenertodos();
        }
    }
}
