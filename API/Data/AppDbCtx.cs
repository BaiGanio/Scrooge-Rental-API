using Microsoft.EntityFrameworkCore;

namespace API
{
    public class AppDbCtx : DbContext
    {
        public AppDbCtx(DbContextOptions<AppDbCtx> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            modelBuilder
                .Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(u => u.UserId);

            modelBuilder
               .Entity<Order>()
               .HasOne(o => o.Car)
               .WithMany(c => c.Orders)
               .HasForeignKey(c => c.CarId);

            modelBuilder
             .Entity<Car>()
             .HasMany(car => car.Orders)
             .WithOne(order => order.Car)
             .HasForeignKey(order => order.CarId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
