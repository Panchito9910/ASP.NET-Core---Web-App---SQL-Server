using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ModeloDualWeb.Models;

public partial class ModelDualContext : DbContext
{
    public ModelDualContext()
    {
    }

    public ModelDualContext(DbContextOptions<ModelDualContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-7GIPTUE;Database=ModelDual;Trusted_Connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.IdAlumno);

            entity.ToTable("alumnos");

            entity.HasIndex(e => e.Matricula, "IX_alumnos").IsUnique();

            entity.Property(e => e.IdAlumno).HasColumnName("id_alumno");
            entity.Property(e => e.ApellidoAlumno)
                .HasMaxLength(25)
                .HasColumnName("apellido_alumno");
            entity.Property(e => e.CorreoAlumno)
                .HasMaxLength(26)
                .HasColumnName("correo_alumno");
            entity.Property(e => e.Matricula)
                .HasMaxLength(9)
                .HasColumnName("matricula");
            entity.Property(e => e.NombreAlumno)
                .HasMaxLength(25)
                .HasColumnName("nombre_alumno");
            entity.Property(e => e.SemestreActual).HasColumnName("semestre_actual");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa);

            entity.ToTable("empresas");

            entity.HasIndex(e => e.CodigoEmpresa, "IX_empresas").IsUnique();

            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.CodigoEmpresa)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("codigo_empresa");
            entity.Property(e => e.CorreoEmpresa)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("correo_empresa");
            entity.Property(e => e.NombreEmpresa)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre_empresa");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.IdProyecto);

            entity.ToTable("proyectos");

            entity.HasIndex(e => e.CodigoProyecto, "IX_proyectos").IsUnique();

            entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");
            entity.Property(e => e.CodigoEmpresa)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("codigo_empresa");
            entity.Property(e => e.CodigoProyecto)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("codigo_proyecto");
            entity.Property(e => e.Matricula)
                .HasMaxLength(9)
                .HasColumnName("matricula");
            entity.Property(e => e.NombreProyecto)
                .HasMaxLength(50)
                .HasColumnName("nombre_proyecto");

            entity.HasOne(d => d.CodigoEmpresaNavigation).WithMany(p => p.Proyectos)
                .HasPrincipalKey(p => p.CodigoEmpresa)
                .HasForeignKey(d => d.CodigoEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_proyectos_empresas");

            entity.HasOne(d => d.MatriculaNavigation).WithMany(p => p.Proyectos)
                .HasPrincipalKey(p => p.Matricula)
                .HasForeignKey(d => d.Matricula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_proyectos_alumnos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
