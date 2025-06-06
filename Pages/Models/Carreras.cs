using System.ComponentModel.DataAnnotations;

namespace C_23052025_RUD.Models
{
    public class Carrera
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The field of Name is empty.")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "The field of Duration (In ages) is empty.")]
        [Range(1, 100, ErrorMessage = "Duration must be between 1 and 100.")]

        public int? Duracionaños { get; set; }
        [Required(ErrorMessage = "The field of Title awarded is empty.")]
        public string? Titulootorgado { get; set; }

        [Required(ErrorMessage = "The field of Modality is empty.")]
        public string? Modalidad { get; set; } 
    }
}
