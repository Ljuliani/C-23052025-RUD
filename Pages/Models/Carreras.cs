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
        [StringLength(20, MinimumLength = 5, ErrorMessage = "The Title awarded must be at most 20 characters long and 5 short.")]
        public string? Titulootorgado { get; set; }

        [Required(ErrorMessage = "The field of Modality is empty.")]
        public string? Modalidad { get; set; } 
    }
}
