using System;
using System.Collections.Generic;
using InteliWeb.Entity;
using Microsoft.EntityFrameworkCore;

namespace InteliWeb.DAL.InteliWebContext
{

    public partial class InteliWebContext : DbContext
    {
        public InteliWebContext()
        {
        }

        public InteliWebContext(DbContextOptions<InteliWebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Archivos> Archivos { get; set; }

        public virtual DbSet<Contrataciones> Contrataciones { get; set; }

        public virtual DbSet<EstadoServicios> EstadoServicios { get; set; }

        public virtual DbSet<RolUsuarios> RolUsuarios { get; set; }

        public virtual DbSet<Servicios> Servicios { get; set; }

        public virtual DbSet<TextoPosts> TextoPosts { get; set; }

        public virtual DbSet<TipoArchivos> TipoArchivos { get; set; }

        public virtual DbSet<TipoServicios> TipoServicios { get; set; }

        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Archivos>(entity =>
            {
                entity.HasKey(e => e.IdArchivo).HasName("PK__Archivos__DF161F50C212F25A");

                entity.Property(e => e.IdArchivo).HasColumnName("idArchivo");
                entity.Property(e => e.ContenidoArchivo).HasColumnName("contenidoArchivo");
                entity.Property(e => e.FechaArchivo)
                    .HasColumnType("date")
                    .HasColumnName("fechaArchivo");
                entity.Property(e => e.IdTipoArchivo).HasColumnName("idTipoArchivo");
                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdTipoArchivoNavigation).WithMany(p => p.Archivos)
                    .HasForeignKey(d => d.IdTipoArchivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TipoArchivos_Archivos");

                entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Archivos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuarios_Archivos");
            });

            modelBuilder.Entity<Contrataciones>(entity =>
            {
                entity.HasKey(e => e.IdContratacione).HasName("PK__Contrata__AF7F3659CAD4E8E1");

                entity.Property(e => e.IdContratacione).HasColumnName("idContratacione");
                entity.Property(e => e.FechaFinalContratacion)
                    .HasColumnType("date")
                    .HasColumnName("fechaFinalContratacion");
                entity.Property(e => e.FechaInicialContratacion)
                    .HasColumnType("date")
                    .HasColumnName("fechaInicialContratacion");
                entity.Property(e => e.IdEstadoServicio).HasColumnName("idEstadoServicio");
                entity.Property(e => e.IdServicio).HasColumnName("idServicio");
                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdEstadoServicioNavigation).WithMany(p => p.Contrataciones)
                    .HasForeignKey(d => d.IdEstadoServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_EstadoServicios_Contrataciones");

                entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Contrataciones)
                    .HasForeignKey(d => d.IdServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Servicios_Contrataciones");

                entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Contrataciones)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuarios_Contrataciones");
            });

            modelBuilder.Entity<EstadoServicios>(entity =>
            {
                entity.HasKey(e => e.IdEstadoServicio).HasName("PK__EstadoSe__69076D2A1AA52B95");

                entity.Property(e => e.IdEstadoServicio).HasColumnName("idEstadoServicio");
                entity.Property(e => e.EstadoServicio1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EstadoServicio");
            });

            modelBuilder.Entity<RolUsuarios>(entity =>
            {
                entity.HasKey(e => e.IdRolUsuario).HasName("PK__RolUsuar__B6AD5CB5E7A7EDE6");

                entity.Property(e => e.IdRolUsuario).HasColumnName("idRolUsuario");
                entity.Property(e => e.RolUsuario1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RolUsuario");
            });

            modelBuilder.Entity<Servicios>(entity =>
            {
                entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__CEB981190B6082B6");

                entity.Property(e => e.IdServicio).HasColumnName("idServicio");
                entity.Property(e => e.IdTipoServicio).HasColumnName("idTipoServicio");
                entity.Property(e => e.NombreServicio)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.PrecioServicio).HasColumnName("precioServicio");

                entity.HasOne(d => d.IdTipoServicioNavigation).WithMany(p => p.Servicios)
                    .HasForeignKey(d => d.IdTipoServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TipoServicios_Servicios");
            });

            modelBuilder.Entity<TextoPosts>(entity =>
            {
                entity.HasKey(e => e.IdTextoPost).HasName("PK__TextoPos__D5CD8954B8206A4F");

                entity.Property(e => e.IdTextoPost).HasColumnName("idTextoPost");
                entity.Property(e => e.ContenidoTextoPost)
                    .HasColumnType("text")
                    .HasColumnName("contenidoTextoPost");
                entity.Property(e => e.FechaTextoPost)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaTextoPost");
                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TextoPosts)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuarios_TextoPosts");
            });

            modelBuilder.Entity<TipoArchivos>(entity =>
            {
                entity.HasKey(e => e.IdTipoArchivo).HasName("PK__TipoArch__8B9D3ED5941A4179");

                entity.Property(e => e.IdTipoArchivo).HasColumnName("idTipoArchivo");
                entity.Property(e => e.TipoArchivo1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tipoArchivo");
            });

            modelBuilder.Entity<TipoServicios>(entity =>
            {
                entity.HasKey(e => e.IdTipoServicio).HasName("PK__TipoServ__278616766E099ACE");

                entity.Property(e => e.IdTipoServicio).HasColumnName("idTipoServicio");
                entity.Property(e => e.TipoServicio1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TipoServicio");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__645723A65CEDF675");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
                entity.Property(e => e.ApMatUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apMatUsuario");
                entity.Property(e => e.ApPatUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apPatUsuario");
                entity.Property(e => e.CorreUsuario)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correUsuario");
                entity.Property(e => e.IdRolUsuario).HasColumnName("idRolUsuario");
                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreUsuario");
                entity.Property(e => e.TelefonoUsuario)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("telefonoUsuario");

                entity.HasOne(d => d.IdRolUsuarioNavigation).WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRolUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RolUsuarios_Usuarios");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}