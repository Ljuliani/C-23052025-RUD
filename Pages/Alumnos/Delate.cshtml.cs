using C_23052025_RUD.Data;
using C_23052025_RUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace C_23052025_RUD.Pages.Alumnos
{
    public class DelateModel : PageModel
    {
        [BindProperty]
        public Alumno Alumno { get; set; }
        public void OnGet(int id)
        {
            foreach (var c in DatosCompartidos.Alumnos)
            {
                if (c.Id == id)
                {
                    Alumno = c;
                    break;
                }
            }
        }
        public IActionResult OnPost()
        {
            Alumno alumnoAEliminar = null;
            foreach (var c in DatosCompartidos.Alumnos)
            {
                if (c.Id == Alumno.Id)
                {
                    alumnoAEliminar = c;
                    break;
                }
            }
            if (alumnoAEliminar != null)
            {
                DatosCompartidos.Alumnos.Remove(alumnoAEliminar);
            }
            return RedirectToPage("index");
        }
    }
}
