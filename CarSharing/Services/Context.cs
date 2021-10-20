using CarSharing.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarSharing.Services
{
    public class Context : IdentityDbContext<User>
    {
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<CarModel> CarModel { get; set; }
        public virtual DbSet<Make> Make { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Statement> Statement { get; set; }

        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("AspNetUsers");
            builder.Entity<Car>().ToTable("Car");
            builder.Entity<CarModel>().ToTable("CarModel");
            builder.Entity<Make>().ToTable("Make");
            builder.Entity<Order>().ToTable("Order");
            builder.Entity<Statement>().ToTable("Statement");
        }

    }
}
