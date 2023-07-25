using System;
using System.Collections.Generic;

namespace InteliWeb2.Models;

public partial class Publicacione
{
    public int IdPublicacion { get; set; }

    public DateTime? FechaPublicacion { get; set; }

    public string TextoPublicado { get; set; } = null!;

    public int IdArchivo { get; set; }

    public int IdTipoPublicacion { get; set; }

    public int IdSeccionPublicacion { get; set; }

    public int IdUsuario { get; set; }

    public int IdServicio { get; set; }

    public virtual Archivo IdArchivoNavigation { get; set; } = null!;

    public virtual SeccionPublicacione IdSeccionPublicacionNavigation { get; set; } = null!;

    public virtual Servicio IdServicioNavigation { get; set; } = null!;

    public virtual TipoPublicacione IdTipoPublicacionNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
