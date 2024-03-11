using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FJMA20241103.Models
{
    public partial class FJMA20241103DBContext : DbContext
    {
        public FJMA20241103DBContext()
        {
        }

        public FJMA20241103DBContext(DbContextOptions<FJMA20241103DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auto> Autos { get; set; } = null!;
        public virtual DbSet<ComponenteCarro> ComponenteCarros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=FJMA20241103DB;Integrated Security=True");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auto>(entity =>
            {
                entity.HasKey(e => e.IdAuto)
                    .HasName("PK__Autos__D8600DCF80AA0115");

                entity.Property(e => e.IdAuto).HasColumnName("idAuto");

                entity.Property(e => e.Anio).HasColumnName("anio");

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.Modelo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modelo");
            });

            modelBuilder.Entity<ComponenteCarro>(entity =>
            {
                entity.HasKey(e => e.IdComponente)
                    .HasName("PK__Componen__001F4C930631F843");

                entity.ToTable("ComponenteCarro");

                entity.Property(e => e.IdComponente).HasColumnName("idComponente");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdAuto).HasColumnName("idAuto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdAutoNavigation)
                    .WithMany(p => p.ComponenteCarros)
                    .HasForeignKey(d => d.IdAuto)
                    .HasConstraintName("FK__Component__idAut__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
