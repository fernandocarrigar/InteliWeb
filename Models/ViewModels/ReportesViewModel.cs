using System.ComponentModel.DataAnnotations;

namespace InteliWeb2.Models.ViewModels
{
    public class ReportesViewModel
    {
        [Display(Name = "Codigo del Reporte")]
        public int IdReport { get; set; }
        
        [Required]
        [Display(Name = "Detalles de Reporte")]
        public string DetReporte { get; set; }

        [Required]
        [Display(Name = "Pruebas del Error sucedido")]
        public byte[]? PruebReport { get; set; }

        [Required]
        [Display(Name = "Prueba de la Solucion")]
        public byte[] SoluctReport { get; set; }

        [Required]
        [Display(Name = "Comentarios de la solucion")]
        public string ComentSolucion { get; set; }

        [Required]
        [Display(Name = "Fecha del Reporte")]
        public DateTime? FecReporte { get; set; }
        
        [Required]
        [Display(Name = "Tipo de Reporte")]
        public int TpReporte { get; set; }
        
        [Required]
        [Display(Name = "Usuario")]
        public int idUser { get; set; }

        [Required]
        [Display(Name = "Estado del Reporte")]
        public int idEdoReport { get; set; }

        [Required]
        [Display(Name = "Servicio Reportado")]
        public int idServ { get; set; }

    }
}
