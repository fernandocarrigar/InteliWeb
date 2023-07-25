using System;
using System.Collections.Generic;

namespace InteliWeb2.Models;

public partial class TipoArchivo
{
    public int IdTipoArchivo { get; set; }

    public string TipoArchivo1 { get; set; } = null!;

    public virtual ICollection<Archivo> Archivos { get; set; } = new List<Archivo>();
}
