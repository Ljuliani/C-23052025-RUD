using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using C_23052025_RUD.Models;
using C_23052025_RUD.Helpers;
using C_23052025_RUD.Servicios;
using C_23052025_RUD.AccesoDatos;
using C_23052025_RUD.Repositorio;

namespace C_23052025_RUD.Pages.Carreras
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Carrera Carrera { get; set; }
        public List<string> Modalidades { get; set; } = new();
        private readonly ServicioCarrera Servicios;
        public CreateModel()
        {
            iAccesoDatos<Carrera> acceso = new AccesoDatos<Carrera>("carreras");
            iRepositorio<Carrera> repo = new RepositorioCrudJson<Carrera>(acceso);
            Servicios = new ServicioCarrera(repo);
        }
        public void OnGet()
        {
            Modalidades = OpcionesModalidad.Lista;
        }


        public IActionResult OnPost()
        {
            Modalidades = OpcionesModalidad.Lista;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Servicios.ServicioCarrera.AgregarCarrera(Carrera);
            Servicios.Agregar(Carrera);
            return RedirectToPage("Index");
            
        }

    }
}
