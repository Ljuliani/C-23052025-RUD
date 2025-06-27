using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using C_23052025_RUD.Models;
using C_23052025_RUD.Data;
using C_23052025_RUD.Helpers;
using System.Collections.Generic;
using C_23052025_RUD.Servicios;

namespace C_23052025_RUD.Pages.Carreras
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Carrera Carrera { get; set; }
        public List<string> Modalidades { get; set; } = new();
        private readonly ServicioCarrera Servicio;
        public CreateModel()
        {
            Servicio = new ServicioCarrera();
        }
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
            //Servicios.ServicioCarrera.AgregarCarrera(Carrera);
            Servicio.Agregar(Carrera);
            return RedirectToPage("Index");
            
        }

    }
}
