using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using C_23052025_RUD.Models;
using C_23052025_RUD.Data;


namespace C_23052025_RUD.Pages.Alumnos
{
  public class EditModel : PageModel
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
            if(!ModelState.IsValid)
            {
                return Page();
            }
            foreach(var c in DatosCompartidos.Alumnos)
            {
                if(c.Id == Alumno.Id)
                {
                    c.Nombre = Alumno.Nombre;
                    c.Apellido = Alumno.Apellido;
                    c.Dni = Alumno.Dni;
                    c.Ce = Alumno.Ce;
                    c.Fn = Alumno.Fn;

                    break;
                }
            }
            return RedirectToPage("index");
        }
    }
}
