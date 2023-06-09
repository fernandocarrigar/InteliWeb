using System;
using System.Collections.Generic;

namespace InteliWeb.Entity;

public partial class Archivos
{
    public int IdArchivo { get; set; }

    public byte[] ContenidoArchivo { get; set; } = null!;

    public DateTime FechaArchivo { get; set; }

    public int IdTipoArchivo { get; set; }

    public int IdUsuario { get; set; }

    public virtual TipoArchivos IdTipoArchivoNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
