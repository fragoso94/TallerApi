using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TallerApiBasica.Models
{
    public partial class TallerDbContext : DbContext
    {
        public TallerDbContext()
        {
        }

        public TallerDbContext(DbContextOptions<TallerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleados> Empleados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // verifica que no exista una conexión y lo vuelve a reconectar.
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Helpers.ContextConfigurations.ConexionString, builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            }
            /*if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-U5D8Q1N5;Database=DBTaller;Trusted_Connection=True;Integrated Security=True;");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Correo).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Rfc).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
