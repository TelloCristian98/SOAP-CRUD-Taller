using Microsoft.EntityFrameworkCore; // Asegura que este espacio de nombres está presente
using MiProyectoEntities; // Ensure this namespace contains the Category class

namespace MiProyectoVDL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");
                entity.HasKey(c => c.categoryid);
                entity.Property(c => c.categoryname)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(c => c.description)
                      .HasMaxLength(255);
            });

            // Configuración de Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");
                entity.HasKey(p => p.productid);
                entity.Property(p => p.productname)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(p => p.unitprice)
                      .HasColumnType("decimal(10, 2)");
                entity.HasOne(p => p.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(p => p.categoryid)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}