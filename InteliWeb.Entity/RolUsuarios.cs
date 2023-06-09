using System;
using System.Collections.Generic;

namespace InteliWeb.Entity;

public partial class RolUsuarios
{
    public int IdRolUsuario { get; set; }

    public string RolUsuario1 { get; set; } = null!;

    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
}
