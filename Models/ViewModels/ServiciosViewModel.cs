using System.ComponentModel.DataAnnotations;

namespace InteliWeb2.Models.ViewModels
{
    public class ServiciosViewModel
    {
        public int IdServ { get; set; }
        
        [Required]
        [Display(Name = "Nombre")]
        public string NameServ { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public int PrecioServ { get; set; }

        [Required]
        [Display(Name = "Ubicacion del Servicio (Opcional)")]
        public string? UbiServ { get; set; }

        [Required]
        [Display(Name = "Fecha de Realizacion (Opcional)")]
        public DateTime? FecRealizar { get; set; }

        [Required]
        [Display(Name = "Fecha de Terminacion(Opcional)")]
        public DateTime? FecTerm { get; set; }

        [Required]
        [Display(Name = "Usuario Encargado")]
        public int idUser { get; set; }

        [Required]
        [Display(Name = "Tipo de Servicio")]
        public int IdTipoServ { get; set; }
    }
}
