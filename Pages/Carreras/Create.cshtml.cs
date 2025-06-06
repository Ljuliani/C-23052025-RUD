using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using C_23052025_RUD.Models;
using C_23052025_RUD.Data;
using C_23052025_RUD.Helpers;

namespace C_23052025_RUD.Pages.Carreras
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Carrera Carrera { get; set; }
        public List<string> Modalidades { get; set; } = new();
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
                Carrera.Id = DatosCompartidos.ObtenerNuevoId();
                DatosCompartidos.Carreras.Add(Carrera);
                return RedirectToPage("Index");
            
        }
    }
}
