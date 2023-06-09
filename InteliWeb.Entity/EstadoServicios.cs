using System;
using System.Collections.Generic;

namespace InteliWeb.Entity;

public partial class EstadoServicios
{
    public int IdEstadoServicio { get; set; }

    public string EstadoServicio1 { get; set; } = null!;

    public virtual ICollection<Contrataciones> Contrataciones { get; set; } = new List<Contrataciones>();
}
