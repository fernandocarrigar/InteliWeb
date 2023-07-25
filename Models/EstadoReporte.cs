using System;
using System.Collections.Generic;

namespace InteliWeb2.Models;

public partial class EstadoReporte
{
    public int IdEstadoReporte { get; set; }

    public string EstadoReporte1 { get; set; } = null!;

    public virtual ICollection<Reporte> Reportes { get; set; } = new List<Reporte>();
}
