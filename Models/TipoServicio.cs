using System;
using System.Collections.Generic;

namespace InteliWeb2.Models;

public partial class TipoServicio
{
    public int IdTipoServicio { get; set; }

    public string TipoServicio1 { get; set; } = null!;

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
