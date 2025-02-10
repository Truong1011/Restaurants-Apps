using Microsoft.EntityFrameworkCore;

using RestaurantsManagerApp.Models;

namespace RestaurantsManagerApp.Database
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Dishes> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Đảm bảo CreatedAt mặc định
            modelBuilder.Entity<Dishes>()
                .Property(d => d.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            // Quan hệ giữa OrderDetail và Order
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)  // Correct this to reference the OrderDetails collection
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.NoAction);


            // Quan hệ giữa OrderDetail và Dish
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Dish)
                .WithMany()
                .HasForeignKey(od => od.DishId)
                .OnDelete(DeleteBehavior.NoAction);

        }
        public DbSet<RestaurantsManagerApp.Models.Tables> Tables { get; set; } = default!;
    }
    
    }

