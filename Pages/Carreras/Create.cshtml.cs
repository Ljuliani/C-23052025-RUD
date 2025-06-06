using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using C_23052025_RUD.Models;
using C_23052025_RUD.Data;

namespace C_23052025_RUD.Pages.Carreras
{
    public class CreateModel : PageModel
    {
        public void OnGet()
        {
        }
        [BindProperty]
        public Carrera Carrera { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
                Carrera.Id = DatosCompartidos.ObtenerNuevoId();
                DatosCompartidos.Carreras.Add(Carrera);
                return RedirectToPage("Index");
            
        }
    }
}
