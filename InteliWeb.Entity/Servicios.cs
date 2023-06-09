using System;
using System.Collections.Generic;

namespace InteliWeb.Entity;

public partial class Servicios
{
    public int IdServicio { get; set; }

    public string NombreServicio { get; set; } = null!;

    public int PrecioServicio { get; set; }

    public int IdTipoServicio { get; set; }

    public virtual ICollection<Contrataciones> Contrataciones { get; set; } = new List<Contrataciones>();

    public virtual TipoServicios IdTipoServicioNavigation { get; set; } = null!;
}
