using System;
using System.Collections.Generic;

namespace InteliWeb2.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string ApPatUsuario { get; set; } = null!;

    public string ApMatUsuario { get; set; } = null!;

    public string CorreUsuario { get; set; } = null!;

    public string TelefonoUsuario { get; set; } = null!;

    public string ContraUsuario { get; set; } = null!;

    public string? EmpresaUsuario { get; set; }

    public int? IdRolUsuario { get; set; }

    public virtual ICollection<Archivo> Archivos { get; set; } = new List<Archivo>();

    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();

    public virtual ICollection<Contratacione> Contrataciones { get; set; } = new List<Contratacione>();

    public virtual RolUsuario IdRolUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Publicacione> Publicaciones { get; set; } = new List<Publicacione>();

    public virtual ICollection<Reporte> Reportes { get; set; } = new List<Reporte>();

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
