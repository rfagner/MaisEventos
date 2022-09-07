using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MaisEventos.API.Models;

#nullable disable

namespace MaisEventos.API.Data
{
    public partial class MaisEventosDBContext : DbContext
    {
        public MaisEventosDBContext()
        {
        }

        public MaisEventosDBContext(DbContextOptions<MaisEventosDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioEvento> UsuarioEventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=MaisEventosDB;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.NomeCategoria).HasColumnName("Categoria");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.Property(e => e.DataHora).HasColumnType("datetime");

                entity.Property(e => e.Preco).HasColumnType("decimal(6, 2)");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("FK__Eventos__Categor__286302EC");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Senha).IsRequired();
            });

            modelBuilder.Entity<UsuarioEvento>(entity =>
            {
                entity.ToTable("UsuarioEvento");

                entity.HasOne(d => d.Evento)
                    .WithMany(p => p.UsuarioEventos)
                    .HasForeignKey(d => d.EventoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UsuarioEv__Event__2C3393D0");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.UsuarioEventos)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UsuarioEv__Usuar__2B3F6F97");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
