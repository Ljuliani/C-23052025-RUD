using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using C_23052025_RUD.Models;
using C_23052025_RUD.Data;

namespace C_23052025_RUD.Pages.Carreras
{
    public class IndexModel : PageModel
    {
        public List<Carrera> Carreras { get; set; }
        public void OnGet()
        {
            Carreras = DatosCompartidos.Carreras;
        }
    }
}
