using System.ComponentModel.DataAnnotations;

namespace InteliWeb2.Models.ViewModels
{
    public class ContactosViewModel
    {
        [Required]
        [Display(Name = "Id de Contacto")]
        public int idContact { get; set; }

        [Required]
        [Display(Name = "Telefono de Contacto Auxiliar")]
        public string? TelContact { get; set; }

        [Required]
        [Display(Name = "Correo de Contacto Auxiliar")]
        public string? EmailContact { get; set; }

        [Required]
        [Display(Name = "Ubicacion de contacto Auxiliar")]
        public string? UbiContact { get; set; }

        [Required]
        [Display(Name = "Id del Usuario de Contacto")]
        public int idUser { get; set; }
    }
}
