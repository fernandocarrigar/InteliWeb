using System;
using System.Collections.Generic;

namespace InteliWeb2.Models;

public partial class Reporte
{
    public int IdReporte { get; set; }

    public string Reporte1 { get; set; } = null!;

    public byte[]? PruebaReporte { get; set; }

    public byte[] PruebaSolucion { get; set; } = null!;

    public string? ComentariosSolucion { get; set; }

    public DateTime? FechaReporte { get; set; }

    public int IdTipoReporte { get; set; }

    public int IdUsuario { get; set; }

    public int IdEstadoReporte { get; set; }

    public int IdServicio { get; set; }

    public virtual EstadoReporte IdEstadoReporteNavigation { get; set; } = null!;

    public virtual Servicio IdServicioNavigation { get; set; } = null!;

    public virtual TipoReporte IdTipoReporteNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
