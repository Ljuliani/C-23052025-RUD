using Microsoft.AspNetCore.Mvc.RazorPages;
using C_23052025_RUD.Models;
using C_23052025_RUD.Servicios;

namespace C_23052025_RUD.Pages.Carreras
{
    public class IndexModel : PageModel
    {
        public List<Carrera> Carreras { get; set; }
        public void OnGet()
        {
            //Carreras = ServicioCarrera.ObtenerCarreras();
            var RepoCarrera = new RepositorioCrudJson<Carrera>("carreras");
            Carreras = RepoCarrera.ObtenerTodos();
        }
    }
}
