using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using C_23052025_RUD.Models;
using C_23052025_RUD.Data;

namespace C_23052025_RUD.Pages.Carreras
{
    public class DelateModel : PageModel
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
            Carrera carreraAEliminar = null;
            foreach(var c in DatosCompartidos.Carreras)
            {
                if(c.Id == Carrera.Id)
                {
                    carreraAEliminar = c;
                    break;
                }
            }
            if(carreraAEliminar !=null)
            {
                DatosCompartidos.Carreras.Remove(carreraAEliminar);
            }
            return RedirectToPage("index");
        }
    }
}