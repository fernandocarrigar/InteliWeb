using System;
using System.Collections.Generic;

namespace InteliWeb.Entity;

public partial class TipoArchivos
{
    public int IdTipoArchivo { get; set; }

    public string TipoArchivo1 { get; set; } = null!;

    public virtual ICollection<Archivos> Archivos { get; set; } = new List<Archivos>();
}
