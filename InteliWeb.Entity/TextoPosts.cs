using System;
using System.Collections.Generic;

namespace InteliWeb.Entity;

public partial class TextoPosts
{
    public int IdTextoPost { get; set; }

    public string ContenidoTextoPost { get; set; } = null!;

    public DateTime FechaTextoPost { get; set; }

    public int IdUsuario { get; set; }

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
