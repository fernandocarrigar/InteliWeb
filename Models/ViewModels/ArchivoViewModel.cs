using System.ComponentModel.DataAnnotations;

namespace InteliWeb2.Models.ViewModels
{
    public class ArchivoViewModel
    {
        [Display(Name = "Id del Archivo")]
        public int IdArchivo { get; set; }
        
        [Display(Name = "Archivo")]
        public byte[]? ContArchivo { get; set; }
        
        [Display(Name = "Tipo Myme")]
        public string? mimeArc { get; set; }

        [Display(Name = "Nombre del Archivo")]
        public string? NameArchivo { get; set; }

        [Display(Name = "Fecha de carga")]
        public DateTime? FecArchivo { get; set; }
        
        [Required]
        [Display(Name = "Tipo de Archivo")]
        public int TpArchivo { get; set; }
        
        [Required]
        [Display(Name = "Usuario")]
        public int User { get; set; }

    }
}
