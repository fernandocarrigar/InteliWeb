using System;
using System.Collections.Generic;

namespace InteliWeb.Entity;

public partial class Contrataciones
{
    public int IdContratacione { get; set; }

    public DateTime FechaInicialContratacion { get; set; }

    public DateTime FechaFinalContratacion { get; set; }

    public int IdUsuario { get; set; }

    public int IdServicio { get; set; }

    public int IdEstadoServicio { get; set; }

    public virtual EstadoServicios IdEstadoServicioNavigation { get; set; } = null!;

    public virtual Servicios IdServicioNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
