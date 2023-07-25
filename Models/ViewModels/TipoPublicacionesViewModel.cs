using System.ComponentModel.DataAnnotations;

namespace InteliWeb2.Models.ViewModels
{
    public class TipoPublicacionesViewModel
    {
        [Required]
        [Display(Name = "Id Tipo de Publicacion")]
        public int idTpPub { get; set; }

        [Required]
        [Display(Name = "Tipo de Publicacion")]
        public string TpPub { get; set; }
    }
}
