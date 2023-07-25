using System;
using System.Collections.Generic;

namespace InteliWeb2.Models;

public partial class TipoPublicacione
{
    public int IdTipoPublicacion { get; set; }

    public string TipoPublicacion { get; set; } = null!;

    public virtual ICollection<Publicacione> Publicaciones { get; set; } = new List<Publicacione>();
}
