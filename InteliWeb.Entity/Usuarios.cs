using System;
using System.Collections.Generic;

namespace InteliWeb.Entity;

public partial class Usuarios
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string ApPatUsuario { get; set; } = null!;

    public string ApMatUsuario { get; set; } = null!;

    public string CorreUsuario { get; set; } = null!;

    public string TelefonoUsuario { get; set; } = null!;

    public int IdRolUsuario { get; set; }

    public virtual ICollection<Archivos> Archivos { get; set; } = new List<Archivos>();

    public virtual ICollection<Contrataciones> Contrataciones { get; set; } = new List<Contrataciones>();

    public virtual RolUsuarios IdRolUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<TextoPosts> TextoPosts { get; set; } = new List<TextoPosts>();
}
