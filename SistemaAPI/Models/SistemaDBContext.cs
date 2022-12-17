using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SistemaAPI.Models
{
    public partial class SistemaDBContext : DbContext
    {
        public SistemaDBContext()
        {
        }

        public SistemaDBContext(DbContextOptions<SistemaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActividadDiarium> ActividadDiaria { get; set; } = null!;
        public virtual DbSet<Bitacora> Bitacoras { get; set; } = null!;
        public virtual DbSet<Equipo> Equipos { get; set; } = null!;
        public virtual DbSet<GastoDiario> GastoDiarios { get; set; } = null!;
        public virtual DbSet<TipoActividad> TipoActividads { get; set; } = null!;
        public virtual DbSet<TipoGasto> TipoGastos { get; set; } = null!;
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("SERVER=DESKTOP-7U6LGFC;DATABASE=SistemaDB;User Id=SistemaActividades; Password=12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActividadDiarium>(entity =>
            {
                entity.HasKey(e => e.Idactividad)
                    .HasName("PK__Activida__7E2A8B752A9E0FA6");

                entity.Property(e => e.Idactividad).HasColumnName("IDActividad");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.GastoDiarioIdgasto).HasColumnName("GastoDiarioIDGasto");

                entity.Property(e => e.HoraEntrada).HasColumnName("horaEntrada");

                entity.Property(e => e.HoraSalida).HasColumnName("horaSalida");

                entity.Property(e => e.Lugar)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("lugar");

                entity.Property(e => e.TipoActividadIdtipo).HasColumnName("TipoActividadIDTipo");

                entity.Property(e => e.VehiculoIdvehiculo).HasColumnName("VehiculoIDVehiculo");

                entity.HasOne(d => d.GastoDiarioIdgastoNavigation)
                    .WithMany(p => p.ActividadDiaria)
                    .HasForeignKey(d => d.GastoDiarioIdgasto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKActividadD109905");

                entity.HasOne(d => d.TipoActividadIdtipoNavigation)
                    .WithMany(p => p.ActividadDiaria)
                    .HasForeignKey(d => d.TipoActividadIdtipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKActividadD855292");

                entity.HasOne(d => d.VehiculoIdvehiculoNavigation)
                    .WithMany(p => p.ActividadDiaria)
                    .HasForeignKey(d => d.VehiculoIdvehiculo)
                    .HasConstraintName("FKActividadD142629");

                entity.HasMany(d => d.UsuarioidUsuarios)
                    .WithMany(p => p.ActividadDiariaIdactividads)
                    .UsingEntity<Dictionary<string, object>>(
                        "ActividadDiariaUsuario",
                        l => l.HasOne<Usuario>().WithMany().HasForeignKey("UsuarioidUsuario").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKActividadD852793"),
                        r => r.HasOne<ActividadDiarium>().WithMany().HasForeignKey("ActividadDiariaIdactividad").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKActividadD483793"),
                        j =>
                        {
                            j.HasKey("ActividadDiariaIdactividad", "UsuarioidUsuario").HasName("PK__Activida__A63952874AA05217");

                            j.ToTable("ActividadDiaria_Usuario");

                            j.IndexerProperty<int>("ActividadDiariaIdactividad").HasColumnName("ActividadDiariaIDActividad");
                        });
            });

            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.HasKey(e => e.Idreporte)
                    .HasName("PK__Bitacora__F69C2DECEFD891AD");

                entity.ToTable("Bitacora");

                entity.Property(e => e.Idreporte).HasColumnName("IDReporte");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fechaInicio");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Bitacoras)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FKBitacora710172");
            });

            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.HasKey(e => e.Idequipo)
                    .HasName("PK__Equipo__034DC40FAEC36947");

                entity.ToTable("Equipo");

                entity.Property(e => e.Idequipo).HasColumnName("IDEquipo");

                entity.Property(e => e.Marca)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroSerie)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("numeroSerie");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsuarioidUsuarioNavigation)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey(d => d.UsuarioidUsuario)
                    .HasConstraintName("FKEquipo826731");
            });

            modelBuilder.Entity<GastoDiario>(entity =>
            {
                entity.HasKey(e => e.Idgasto)
                    .HasName("PK__GastoDia__D41CA026FAB10F51");

                entity.ToTable("GastoDiario");

                entity.Property(e => e.Idgasto).HasColumnName("IDGasto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Foto)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("foto");

                entity.Property(e => e.TipoGastoIdtipoGasto).HasColumnName("tipoGastoIDTipoGasto");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.TipoGastoIdtipoGastoNavigation)
                    .WithMany(p => p.GastoDiarios)
                    .HasForeignKey(d => d.TipoGastoIdtipoGasto)
                    .HasConstraintName("FKGastoDiari622898");
            });

            modelBuilder.Entity<TipoActividad>(entity =>
            {
                entity.HasKey(e => e.Idtipo)
                    .HasName("PK__TipoActi__BEB088A67EBA6ACA");

                entity.ToTable("TipoActividad");

                entity.Property(e => e.Idtipo).HasColumnName("IDTipo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<TipoGasto>(entity =>
            {
                entity.HasKey(e => e.IdtipoGasto)
                    .HasName("PK__TipoGast__63CAEA1FC9F346B4");

                entity.ToTable("TipoGasto");

                entity.Property(e => e.IdtipoGasto).HasColumnName("IDTipoGasto");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__03006BFF90861D25");

                entity.ToTable("TipoUsuario");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasDefaultValueSql("('1')");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("PK__Usuario__52311169C7AB46BD");

                entity.ToTable("Usuario");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cedula");

                entity.Property(e => e.Clave)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.CodigoRecuperacion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("codigoRecuperacion");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombreCompleto");

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroTelefono)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("numeroTelefono");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FKUsuario557876");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.Idvehiculo)
                    .HasName("PK__Vehiculo__CA7F86878B85DED6");

                entity.ToTable("Vehiculo");

                entity.Property(e => e.Idvehiculo).HasColumnName("IDVehiculo");

                entity.Property(e => e.Marca)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.Placa)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("placa");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
