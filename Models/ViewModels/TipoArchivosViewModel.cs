using System.ComponentModel.DataAnnotations;

namespace InteliWeb2.Models.ViewModels
{
    public class TipoArchivosViewModel
    {
        [Display(Name = "Id del Tipo de Archivo")]
        public int IdTpArc { get; set; }
        [Required]
        [Display(Name = "Tipo de archivo")]
        public string TpArchivo { get; set; }
    }
}
