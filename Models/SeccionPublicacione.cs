using System;
using System.Collections.Generic;

namespace InteliWeb2.Models;

public partial class SeccionPublicacione
{
    public int IdSeccionPublicacion { get; set; }

    public string SeccionPublicacion { get; set; } = null!;

    public virtual ICollection<Publicacione> Publicaciones { get; set; } = new List<Publicacione>();
}
