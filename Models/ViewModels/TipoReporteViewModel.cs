using System.ComponentModel.DataAnnotations;

namespace InteliWeb2.Models.ViewModels
{
    public class TipoReporteViewModel
    {
        [Display(Name = "Codigo del Tipo de Reporte")]
        public int IdTpReporte { get; set; }
        [Required]
        [Display(Name = "Tipo de Reporte")]
        public string TpReporte { get; set; }

    }
}
