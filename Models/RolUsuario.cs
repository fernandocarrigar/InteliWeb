using System;
using System.Collections.Generic;

namespace InteliWeb2.Models;

public partial class RolUsuario
{
    public int IdRolUsuario { get; set; }

    public string RolUsuario1 { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
