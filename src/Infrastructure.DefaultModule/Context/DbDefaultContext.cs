using Domain.DefaultModule.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DefaultModule.Models
{
    public partial class DbDefaultContext : DbContext
    {
        public DbDefaultContext()
        {
        }

        public DbDefaultContext(DbContextOptions<DbDefaultContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<TableDefault> TableDefaults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=localhost;Database=dbDefault;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer("name=DefaultDatabase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<TableDefault>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("TABLEDEFAULT");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(100);
            });

        }
    }
}
