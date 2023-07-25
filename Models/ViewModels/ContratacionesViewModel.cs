using System.ComponentModel.DataAnnotations;

namespace InteliWeb2.Models.ViewModels
{
    public class ContratacionesViewModel
    {
        [Display(Name = "Codigo de Contratación")]
        public int IdCont { get; set; }

        [Display(Name = "Fecha de solicitud")]
        public DateTime? FecSolicitud { get; set; }

        [Display(Name = "Fecha Inicial de Contratación")]
        public DateTime? FecIniCont { get; set; }

        [Display(Name = "Fecha de Termino")]
        public DateTime? FecFinCont { get; set; }

        [Display(Name = "Monto total cotizado")]
        public string? MontoCotizado { get; set; }

        [Display(Name = "Monto total final")]
        public string? MontoConseguido { get; set; }

        [Display(Name = "Comentarios del usuario")]
        public string? ComUSer { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public int idUser { get; set; }

        [Required]
        [Display(Name = "Servicio")]
        public int idServ { get; set; }

        [Required]
        [Display(Name = "Estado del Servicio")]
        public int idEdoContrat { get; set; }
    }
}
