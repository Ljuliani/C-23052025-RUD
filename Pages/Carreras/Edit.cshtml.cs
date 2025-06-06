using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using C_23052025_RUD.Models;
using C_23052025_RUD.Data;

namespace C_23052025_RUD.Pages.Carreras
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Carrera Carrera { get; set; }
        public void OnGet(int id)
        {
            foreach (var c in DatosCompartidos.Carreras)
            {
                if (c.Id == id)
                {
                    Carrera = c;
                    break;
                }
            }
        }
        public IActionResult OnPost() 
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            foreach(var c in DatosCompartidos.Carreras)
            {
                if(c.Id == Carrera.Id)
                {
                    c.Nombre = Carrera.Nombre;
                    c.Modalidad = Carrera.Modalidad;
                    c.Duracionaños = Carrera.Duracionaños;
                    c.Titulootorgado = Carrera.Titulootorgado;
                    break;
                }
            }
            return RedirectToPage("index");
        }
    }
}