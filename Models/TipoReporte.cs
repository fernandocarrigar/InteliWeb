using System;
using System.Collections.Generic;

namespace InteliWeb2.Models;

public partial class TipoReporte
{
    public int IdTipoReporte { get; set; }

    public string TipoReporte1 { get; set; } = null!;

    public virtual ICollection<Reporte> Reportes { get; set; } = new List<Reporte>();
}
