using System;
using System.Collections.Generic;

namespace InteliWeb2.Models;

public partial class Contratacione
{
    public int IdContratacion { get; set; }

    public DateTime? FechaSolicitud { get; set; }

    public DateTime? FechaInicialContratacion { get; set; }

    public DateTime? FechaFinalContratacion { get; set; }

    public string? MontoCotizacion { get; set; }

    public string? MontoFinal { get; set; }

    public string? Coomentarios { get; set; }

    public int IdUsuario { get; set; }

    public int IdServicio { get; set; }

    public int IdEstadoContratacion { get; set; }

    public virtual EstadoContratacione IdEstadoContratacionNavigation { get; set; } = null!;

    public virtual Servicio IdServicioNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
