using System;
using System.Collections.Generic;

namespace InteliWeb2.Models;

public partial class Contacto
{
    public int IdContacto { get; set; }

    public string? TelefonoContacto { get; set; }

    public string? CorreoContacto { get; set; }

    public string? UbicacionContacto { get; set; } = null!;

    public int IdUsuario { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
