using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basic_api.Constants;
using basic_api.Models;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Data
{
  public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : DbContext(options)
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<CarType> CarTypes { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Punishment> Punishments { get; set; }
    public DbSet<CarBrand> CarBrands { get; set; }


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      UpdateTimestamps();
      return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateTimestamps()
    {
      var entries = ChangeTracker.Entries()
          .Where(e => e.Entity is User &&
                 (e.State == EntityState.Added || e.State == EntityState.Modified));

      foreach (var entry in entries)
      {
        if (entry.State == EntityState.Added)
        {
          ((User)entry.Entity).CreatedAt = DateTime.UtcNow;
        }

          ((User)entry.Entity).UpdatedAt = DateTime.UtcNow;
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Order>()
        .HasOne(o => o.User)
        .WithMany(u => u.Orders)
        .HasForeignKey(o => o.UserID)
        .OnDelete(DeleteBehavior.SetNull);

      base.OnModelCreating(modelBuilder);


      modelBuilder.Entity<User>().HasData(
          new User
          {
            Id = 1,
            Phone = "0999999999",
            Email = "admin@gmail.com",
            Password = "AQAAAAIAAYagAAAAEGl3jelov24IEW8Zr037HzEkXVuuOJZCc7t6eVK5/AxxfCNoQANr0rt8kQazCmW0fA==", // 123123123
            Username = "Admin",
            IsActive = true,
            IsVerify = true,
            Role = Roles.Admin,
            DrivingLicense = ""
          }
      );

      modelBuilder.Entity<CarType>().HasData(
          new CarType
          {
            Id = 1,
            Type = "Automatic Car",
            Detail = "An automatic car shifts gears on its own without a manual clutch. It offers a smoother, easier driving experience. Many drivers prefer it for convenience."
          },
          new CarType
          {
            Id = 2,
            Type = "Electric Car",
            Detail = "An electric car runs on electricity instead of fuel. It’s eco-friendly and quieter than traditional cars. Many drivers choose it for sustainability."
          }
    );

      modelBuilder.Entity<CarBrand>().HasData(
           new CarBrand
           {
             Id = 1,
             Brand = "HYUNDAI",
           },
           new CarBrand
           {
             Id = 2,
             Brand = "KIA",
           }
     );

      modelBuilder.Entity<Car>().HasData(
          new Car
          {
            Id = 1,
            Name = "HYUNDAI ACCENT",
            CarTypeID = 1,
            CarBrandID = 1,
            LicensePlate = "92A-12312",
            IsInUse = false,
            Seats = 4,
            PricePerHour = 100000,
            PricePerDay = 800000,
            Fuel = "Gasoline",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
          },
          new Car
          {
            Id = 2,
            Name = "KIA CERATO",
            CarTypeID = 1,
            CarBrandID = 2,
            LicensePlate = "43A-42256",
            IsInUse = false,
            Seats = 4,
            PricePerHour = 120000,
            PricePerDay = 900000,
            Fuel = "Gasoline",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
          }
      );
    }
  }
}
