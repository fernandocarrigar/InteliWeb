using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InteliWeb2.Models;

public partial class InteliWebContext : DbContext
{
    public InteliWebContext()
    {
    }

    public InteliWebContext(DbContextOptions<InteliWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Archivo> Archivos { get; set; }

    public virtual DbSet<Contacto> Contactos { get; set; }

    public virtual DbSet<Contratacione> Contrataciones { get; set; }

    public virtual DbSet<EstadoContratacione> EstadoContrataciones { get; set; }

    public virtual DbSet<EstadoReporte> EstadoReportes { get; set; }

    public virtual DbSet<Publicacione> Publicaciones { get; set; }

    public virtual DbSet<Reporte> Reportes { get; set; }

    public virtual DbSet<RolUsuario> RolUsuarios { get; set; }

    public virtual DbSet<SeccionPublicacione> SeccionPublicaciones { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<TipoArchivo> TipoArchivos { get; set; }

    public virtual DbSet<TipoPublicacione> TipoPublicaciones { get; set; }

    public virtual DbSet<TipoReporte> TipoReportes { get; set; }

    public virtual DbSet<TipoServicio> TipoServicios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-HEQPAUL\\MSSQLSERVER01; DataBase=InteliWeb;Integrated Security=true; Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Archivo>(entity =>
        {
            entity.HasKey(e => e.IdArchivo).HasName("PK__Archivos__DF161F50E9E62CC3");

            entity.Property(e => e.IdArchivo).HasColumnName("idArchivo");
            entity.Property(e => e.ContenidoArchivo).HasMaxLength(1);
            entity.Property(e => e.FechaSubido).HasColumnType("datetime");
            entity.Property(e => e.IdTipoArchivo).HasColumnName("idTipoArchivo");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.MimeArchivo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NombreArchivo)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoArchivoNavigation).WithMany(p => p.Archivos)
                .HasForeignKey(d => d.IdTipoArchivo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_TipoArchivos_Archivos");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Archivos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Usuarios_Archivos");
        });

        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.IdContacto).HasName("PK__Contacto__4B1329C7290B2C9C");

            entity.Property(e => e.IdContacto).HasColumnName("idContacto");
            entity.Property(e => e.CorreoContacto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.TelefonoContacto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UbicacionContacto)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Usuarios_Contactos");
        });

        modelBuilder.Entity<Contratacione>(entity =>
        {
            entity.HasKey(e => e.IdContratacion).HasName("PK__Contrata__577E4B104E0E787C");

            entity.Property(e => e.IdContratacion).HasColumnName("idContratacion");
            entity.Property(e => e.Coomentarios).HasColumnType("text");
            entity.Property(e => e.FechaFinalContratacion).HasColumnType("date");
            entity.Property(e => e.FechaInicialContratacion).HasColumnType("date");
            entity.Property(e => e.FechaSolicitud).HasColumnType("date");
            entity.Property(e => e.IdEstadoContratacion).HasColumnName("idEstadoContratacion");
            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.MontoCotizacion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MontoFinal)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoContratacionNavigation).WithMany(p => p.Contrataciones)
                .HasForeignKey(d => d.IdEstadoContratacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_EstadoContratacion_Contrataciones");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Contrataciones)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Servicios_Contrataciones");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Contrataciones)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Usuarios_Contrataciones");
        });

        modelBuilder.Entity<EstadoContratacione>(entity =>
        {
            entity.HasKey(e => e.IdEstadoContratacion).HasName("PK__EstadoCo__3D9334DA9505F637");

            entity.Property(e => e.IdEstadoContratacion).HasColumnName("idEstadoContratacion");
            entity.Property(e => e.EstadoContratacion)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstadoReporte>(entity =>
        {
            entity.HasKey(e => e.IdEstadoReporte).HasName("PK__EstadoRe__E46292CF8F35B2F3");

            entity.Property(e => e.IdEstadoReporte).HasColumnName("idEstadoReporte");
            entity.Property(e => e.EstadoReporte1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EstadoReporte");
        });

        modelBuilder.Entity<Publicacione>(entity =>
        {
            entity.HasKey(e => e.IdPublicacion).HasName("PK__Publicac__BF9D9890201511B0");

            entity.Property(e => e.IdPublicacion).HasColumnName("idPublicacion");
            entity.Property(e => e.FechaPublicacion).HasColumnType("datetime");
            entity.Property(e => e.IdArchivo).HasColumnName("idArchivo");
            entity.Property(e => e.IdSeccionPublicacion).HasColumnName("idSeccionPublicacion");
            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.IdTipoPublicacion).HasColumnName("idTipoPublicacion");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.TextoPublicado).HasColumnType("text");

            entity.HasOne(d => d.IdArchivoNavigation).WithMany(p => p.Publicaciones)
                .HasForeignKey(d => d.IdArchivo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Archivos_Publicaciones");

            entity.HasOne(d => d.IdSeccionPublicacionNavigation).WithMany(p => p.Publicaciones)
                .HasForeignKey(d => d.IdSeccionPublicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_SeccionPublicaciones_Publicaciones");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Publicaciones)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Servicio_Publicaciones");

            entity.HasOne(d => d.IdTipoPublicacionNavigation).WithMany(p => p.Publicaciones)
                .HasForeignKey(d => d.IdTipoPublicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_TipoPublicaciones_Publicaciones");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Publicaciones)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Usuario_Publicaciones");
        });

        modelBuilder.Entity<Reporte>(entity =>
        {
            entity.HasKey(e => e.IdReporte).HasName("PK__Reportes__40D65D3C893DD36A");

            entity.Property(e => e.IdReporte).HasColumnName("idReporte");
            entity.Property(e => e.ComentariosSolucion).HasColumnType("text");
            entity.Property(e => e.FechaReporte).HasColumnType("datetime");
            entity.Property(e => e.IdEstadoReporte).HasColumnName("idEstadoReporte");
            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.IdTipoReporte).HasColumnName("idTipoReporte");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Reporte1)
                .HasColumnType("text")
                .HasColumnName("Reporte");

            entity.HasOne(d => d.IdEstadoReporteNavigation).WithMany(p => p.Reportes)
                .HasForeignKey(d => d.IdEstadoReporte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_EstadoReportes_Reportes");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Reportes)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Servicios_Reportes");

            entity.HasOne(d => d.IdTipoReporteNavigation).WithMany(p => p.Reportes)
                .HasForeignKey(d => d.IdTipoReporte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_TipoReportes_Reportes");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reportes)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Usuarios_Reportes");
        });

        modelBuilder.Entity<RolUsuario>(entity =>
        {
            entity.HasKey(e => e.IdRolUsuario).HasName("PK__RolUsuar__B6AD5CB5D5AC7630");

            entity.Property(e => e.IdRolUsuario).HasColumnName("idRolUsuario");
            entity.Property(e => e.RolUsuario1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RolUsuario");
        });

        modelBuilder.Entity<SeccionPublicacione>(entity =>
        {
            entity.HasKey(e => e.IdSeccionPublicacion).HasName("PK__SeccionP__0310F403A27E36B6");

            entity.Property(e => e.IdSeccionPublicacion).HasColumnName("idSeccionPublicacion");
            entity.Property(e => e.SeccionPublicacion)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__CEB98119BF438BEF");

            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.FechaRealizacion).HasColumnType("date");
            entity.Property(e => e.FechaTerminacion).HasColumnType("date");
            entity.Property(e => e.IdTipoServicio).HasColumnName("idTipoServicio");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.NombreServicio)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoServicioNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdTipoServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_TipoServicios_Servicios");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Usuarios_Servicios");
        });

        modelBuilder.Entity<TipoArchivo>(entity =>
        {
            entity.HasKey(e => e.IdTipoArchivo).HasName("PK__TipoArch__8B9D3ED5A12CE817");

            entity.Property(e => e.IdTipoArchivo).HasColumnName("idTipoArchivo");
            entity.Property(e => e.TipoArchivo1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("TipoArchivo");
        });

        modelBuilder.Entity<TipoPublicacione>(entity =>
        {
            entity.HasKey(e => e.IdTipoPublicacion).HasName("PK__TipoPubl__C3E0309321AD2B3D");

            entity.Property(e => e.IdTipoPublicacion).HasColumnName("idTipoPublicacion");
            entity.Property(e => e.TipoPublicacion)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoReporte>(entity =>
        {
            entity.HasKey(e => e.IdTipoReporte).HasName("PK__TipoRepo__5692713AEA155E5B");

            entity.Property(e => e.IdTipoReporte).HasColumnName("idTipoReporte");
            entity.Property(e => e.TipoReporte1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("TipoReporte");
        });

        modelBuilder.Entity<TipoServicio>(entity =>
        {
            entity.HasKey(e => e.IdTipoServicio).HasName("PK__TipoServ__2786167632D697C3");

            entity.Property(e => e.IdTipoServicio).HasColumnName("idTipoServicio");
            entity.Property(e => e.TipoServicio1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TipoServicio");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__645723A6349AF17D");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.ApMatUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApPatUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContraUsuario)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CorreUsuario)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmpresaUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdRolUsuario).HasColumnName("idRolUsuario");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoUsuario)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRolUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_RolUsuarios_Usuarios");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
