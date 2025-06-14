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
        public IActionResult OnGet(int id)
        {
            var carrera = ServicioCarrera.BuscarPorId(id);
            if (carrera == null)
            {
                return RedirectToPage("Index");
            }
            Carrera = carrera;
            return Page();
        }
        public IActionResult OnPost(int id) 
        {
         ServicioCarrera.EliminarPorId(id);
         return RedirectToPage("Index");
        }
    }
}