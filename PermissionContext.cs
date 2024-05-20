using Microsoft.EntityFrameworkCore;
using PermissionApi.Models;

namespace PermissionApi
{
    public class PermissionDbContext : DbContext
    {
        public PermissionDbContext(DbContextOptions<PermissionDbContext> options) : base(options) { }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionType>(type =>
            {
                type.ToTable("PermissionTypes");
                type.HasKey(t => t.Id);
                type.Property(t => t.Description).IsRequired();

                type.HasData(
                  new PermissionType { Id = 1, Description = "Enfermedad" },
                  new PermissionType { Id = 2, Description = "Vacaciones" },
                  new PermissionType { Id = 3, Description = "Situacion Personal" },
                  new PermissionType { Id = 4, Description = "Tramites Legales" },
                  new PermissionType { Id = 5, Description = "Examen univesitario" }
              );
            });

            modelBuilder.Entity<Permission>(p =>
            {
                p.ToTable("Permissions");
                p.HasKey(p => p.Id);
                p.Property(p => p.Id).IsRequired();
                p.Property(p => p.Name).HasMaxLength(150).IsRequired();
                p.Property(p => p.LastName).HasMaxLength(150).IsRequired();
                p.Property(p => p.DatePermission).IsRequired();
                p.HasOne(p => p.PermissionType)
                 .WithMany()
                 .HasForeignKey(p => p.PermissionTypeId)
                 .IsRequired();
            });
        }
    }
}
