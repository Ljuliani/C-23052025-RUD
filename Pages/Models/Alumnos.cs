using System.ComponentModel.DataAnnotations;

namespace C_23052025_RUD.Models
{
    public class Alumno
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field of Name is empty.")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "The field of Surname is empty.")]
        public string? Apellido { get; set; }
        [Required(ErrorMessage = "The field of N° ID is empty.")]
        public int? Dni { get; set; } //Documento nacional de identidad.
        [Required(ErrorMessage = "The field of E-mail is empty.")]
        public string? Ce { get; set; } //Correo eléctronico
        [Required(ErrorMessage = "The field of Date of brithday is empty.")]
        public DateTime? Fn { get; set; } //Fecha de nacimiento
    }
}
