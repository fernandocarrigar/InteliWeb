using System.ComponentModel.DataAnnotations;

namespace InteliWeb2.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Correo del Usuario")]
        public string LoginCorreo { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string LoginContraseña { get; set; }

    }
}
