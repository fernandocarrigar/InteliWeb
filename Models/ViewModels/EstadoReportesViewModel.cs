using System.ComponentModel.DataAnnotations;

namespace InteliWeb2.Models.ViewModels
{
    public class EstadoReportesViewModel
    {
        [Required]
        [Display(Name = "Id del Estado de Reporte")]
        public int idEdoReport { get; set; }

        [Required]
        [Display(Name = "Estado de Reporte")]
        public string EdoReport { get; set; }
    }
}
