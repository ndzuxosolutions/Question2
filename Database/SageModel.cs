using Microsoft.EntityFrameworkCore;

namespace Question2.Database;

public partial class SageModel : DbContext
{
    public SageModel()
    {
    }

    public SageModel(DbContextOptions<SageModel> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerID).HasName("PK__Customer__A4AE64B807BADCE9");

            entity.Property(e => e.CustomerID).ValueGeneratedNever();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderID).HasName("PK__Orders__C3905BAF1A22FBE7");

            entity.Property(e => e.OrderID).ValueGeneratedNever();

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__Customer__3B75D760");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderID, e.ProductID }).HasName("PK__OrderDet__08D097C19DBE8480");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Order__3E52440B");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Produ__3F466844");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductID).HasName("PK__Products__B40CC6ED37E659C8");

            entity.Property(e => e.ProductID).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
