using System;
using System.Collections.Generic;

namespace InteliWeb.Entity;

public partial class TipoServicios
{
    public int IdTipoServicio { get; set; }

    public string TipoServicio1 { get; set; } = null!;

    public virtual ICollection<Servicios> Servicios { get; set; } = new List<Servicios>();
}
