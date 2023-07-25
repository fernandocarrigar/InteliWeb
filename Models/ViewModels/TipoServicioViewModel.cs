using System.ComponentModel.DataAnnotations;

namespace InteliWeb2.Models.ViewModels
{
    public class TipoServicioViewModel
    {
        [Display(Name = "Id del Tipo de Servicio")]
        public int IdTpServ { get; set; }
        [Required]
        [Display(Name = "Tipo de Servicio")]
        public string TipoServ { get; set; }
    }
}
