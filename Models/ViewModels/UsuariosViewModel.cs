using System.ComponentModel.DataAnnotations;

namespace InteliWeb2.Models.ViewModels
{
    public class UsuariosViewModel
    {
        [Display(Name = "Id de Usuario")]
        public int IdUsuario { get; set; }
        [Required]
        [Display(Name = "Nombre del Usuario")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Apellido Paterno")]
        public string ApName { get; set; }
        [Required]
        [Display(Name = "Apellido Materno")]
        public string AmName { get; set; }
        [Required]
        [Display(Name = "Correo")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Numero telefonico")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Empresa a la que pertenece (Opcional)")]
        public string? Empresa { get; set; }

        [Display(Name = "Rol de usuario")]
        public int? IdRol { get; set; }
    }
}
