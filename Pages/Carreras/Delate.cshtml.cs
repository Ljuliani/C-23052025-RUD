using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using C_23052025_RUD.Models;
using C_23052025_RUD.Servicios;

namespace C_23052025_RUD.Pages.Carreras
{
    public class DelateModel : PageModel
    {
        [BindProperty]
        public Carrera Carrera { get; set; }
        private readonly ServicioCarrera Servicio;
        public DelateModel()
        {
            Servicio = new ServicioCarrera();
        }
        public IActionResult OnGet(int id)
        {
           var carrera = Servicio.BuscarPorId(id);
            if (Servicio == null)
            {
                return RedirectToPage("Index");
            }
            Carrera = carrera;
            return Page();
        }
        public IActionResult OnPost(int id) 
        {
         Servicio.EliminarPorId(id);
         return RedirectToPage("Index");
        }
    }
}