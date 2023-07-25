using System;
using System.Collections.Generic;

namespace InteliWeb2.Models;

public partial class Archivo
{
    public int IdArchivo { get; set; }

    public byte[]? ContenidoArchivo { get; set; }

    public string? MimeArchivo { get; set; } = null!;

    public string? NombreArchivo { get; set; } = null!;

    public DateTime? FechaSubido { get; set; }

    public int IdTipoArchivo { get; set; }

    public int IdUsuario { get; set; }

    public virtual TipoArchivo IdTipoArchivoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Publicacione> Publicaciones { get; set; } = new List<Publicacione>();
}
