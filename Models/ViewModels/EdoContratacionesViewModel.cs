using System.ComponentModel.DataAnnotations;

namespace InteliWeb2.Models.ViewModels
{
    public class EdoContratacionesViewModel
    {
        [Required]
        [Display(Name = "Id del Estado de Contratacion")]
        public int idEdoContrat { get; set; }

        [Required]
        [Display(Name = "Estado de Contratacion")]
        public string EdoContratacion { get; set; }
    }
}
