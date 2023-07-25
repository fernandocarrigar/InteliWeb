using System;
using System.Collections.Generic;

namespace InteliWeb2.Models;

public partial class EstadoContratacione
{
    public int IdEstadoContratacion { get; set; }

    public string EstadoContratacion { get; set; } = null!;

    public virtual ICollection<Contratacione> Contrataciones { get; set; } = new List<Contratacione>();
}
