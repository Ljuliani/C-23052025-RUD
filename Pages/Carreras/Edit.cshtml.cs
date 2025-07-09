using C_23052025_RUD.AccesoDatos;
using C_23052025_RUD.Helpers;
using C_23052025_RUD.Models;
using C_23052025_RUD.Repositorio;
using C_23052025_RUD.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace C_23052025_RUD.Pages.Carreras
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Carrera? Carrera { get; set; }
        public List<string> Modalidades { get; set; } = new();
        private readonly ServicioCarrera Servicio;
        public EditModel()
        {
            iAccesoDatos<Carrera> acceso = new AccesoDatos<Carrera>("carreras");
            iRepositorio<Carrera> repo = new RepositorioCrudJson<Carrera>(acceso);
            Servicio = new ServicioCarrera(repo);
        }   

        public void OnGet(int id)
        {

            Modalidades = OpcionesModalidad.Lista;
            Carrera? carrera = Servicio.BuscarPorId(id);
         if (carrera != null)
         {
          Carrera = carrera;
         }


        }
        public IActionResult OnPost() 
        {
            Modalidades = OpcionesModalidad.Lista;
            if (!ModelState.IsValid)
            { 
             return Page();
            }
            Servicio.Editar(Carrera);
            return RedirectToPage("Index");
        }
    }
}