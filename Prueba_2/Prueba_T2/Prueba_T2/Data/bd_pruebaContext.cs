using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data.SqlClient;
using System.Linq;
using Prueba_T2.Models;

namespace Prueba_T2.Data
{
    public partial class bd_pruebaContext : DbContext
    {
        public bd_pruebaContext()
        {
        }

        public bd_pruebaContext(DbContextOptions<bd_pruebaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Consulta1> Consulta1s { get; set; } = null!;
        public virtual DbSet<Consulta2> Consulta2s { get; set; } = null!;
        public virtual DbSet<ConsultaUsuario> ConsultaUsuarios { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        public IQueryable<Usuario> TopTen()
        {
            return this.Usuarios.FromSqlRaw("EXEC selectTop10");
        }

        public IQueryable<Empleado> ConsultaEmpleadoUnico(int iduser)
        {
            return this.Empleados.FromSqlRaw("SELECT * FROM empleado where userId = {0}", iduser);
        }

        public void EditSalario(double sueldo, int id)
        {
            this.Usuarios.FromSqlRaw("EXEC updateSalario @newSalario = {0}, @userId = {1};", sueldo, id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER04;Database=bd_prueba;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consulta1>(entity =>
            {
                entity.ToView("consulta1");
            });

            modelBuilder.Entity<Consulta2>(entity =>
            {
                entity.ToView("consulta2");
            });

            modelBuilder.Entity<ConsultaUsuario>(entity =>
            {
                entity.ToView("consultaUsuarios");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.Property(e => e.EmpleadoId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_empleados_usuarios");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
