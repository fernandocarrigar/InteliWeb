using System;
using System.Collections.Generic;

namespace InteliWeb2.Models;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public string NombreServicio { get; set; } = null!;

    public int PrecioServicio { get; set; }

    public string? Ubicacion { get; set; }

    public DateTime? FechaRealizacion { get; set; }

    public DateTime? FechaTerminacion { get; set; }

    public int IdUsuario { get; set; }

    public int IdTipoServicio { get; set; }

    public virtual ICollection<Contratacione> Contrataciones { get; set; } = new List<Contratacione>();

    public virtual TipoServicio IdTipoServicioNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Publicacione> Publicaciones { get; set; } = new List<Publicacione>();

    public virtual ICollection<Reporte> Reportes { get; set; } = new List<Reporte>();
}
