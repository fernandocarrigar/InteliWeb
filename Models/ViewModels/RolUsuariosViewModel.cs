using System.ComponentModel.DataAnnotations;

namespace InteliWeb2.Models.ViewModels
{
    public class RolUsuariosViewModel
    {
        [Display(Name = "Id del Rol")]
        public int IdRol { get; set; }
        [Required]
        [Display(Name = "Rol de Usuario")]
        public string Rol { get; set; }
    }
}
