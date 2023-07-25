using System.ComponentModel.DataAnnotations;

namespace InteliWeb2.Models.ViewModels
{
    public class SeccionPublicacionesViewModel
    {
        [Required]
        [Display(Name = "Id Seccion de la Publicacion")]
        public int idSeccPub { get; set; }

        [Required]
        [Display(Name = "Seccion de la Publicacion")]
        public string SeccPub { get; set; }
    }
}
