using System.ComponentModel.DataAnnotations;

namespace InteliWeb2.Models.ViewModels
{
    public class PublicacionesViewModel
    {
        [Display(Name = "Id de Publicación")]
        public int IdPub { get; set; }

        [Display(Name = "Fecha de Publicación")]
        public DateTime? FecPub { get; set; }

        [Required]
        [Display(Name = "Texto de la publicacion")]
        public string TxtPub { get; set; }

        [Required]
        [Display(Name = "Archivo Publicado")]
        public int idArch { get; set; }

        [Required]
        [Display(Name = "Tipo de Publicacion")]
        public int idTpPub { get; set; }

        [Required]
        [Display(Name = "Seccion de la Publicacion")]
        public int idSecPub { get; set; }

        [Required]
        [Display(Name = "Usuario que publico")]
        public int idUser { get; set; }

        [Required]
        [Display(Name = "Servicio de la publicacion")]
        public int idServ { get; set; }

    }
}
