using CarRentalDAL.Entities;
using CarRentalDAL.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Context
{
    public class AppDBContext : IdentityDbContext<AppUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<UserDocument> UserDocuments { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<AppUser>().ToTable("Users");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");


            #region Relations

            #region User-Car
            builder.Entity<AppUser>()
                    .HasMany(u => u.Cars)
                    .WithOne(c => c.OwnerUser)
                    .HasForeignKey(c => c.OwnerUserId)
                    .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region User-Rental-Owner
            builder.Entity<AppUser>()
                    .HasMany(u => u.OwnerRentals)
                    .WithOne(r => r.OwnerUser)
                    .HasForeignKey(r => r.OwnerUserId)
                    .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region User-Rental-Customer
            builder.Entity<AppUser>()
                    .HasMany(u => u.CustomerRentals)
                    .WithOne(r => r.CustomerUser)
                    .HasForeignKey(r => r.CustomerUserId)
                    .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region User-Review
            builder.Entity<AppUser>()
                    .HasMany(u => u.Reviews)
                    .WithOne(r => r.CustomerUser)
                    .HasForeignKey(r => r.CustomerUserId)
                    .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region User-Document
            builder.Entity<AppUser>()
                    .HasMany(u => u.UserDocuments)
                    .WithOne(d => d.AppUser)
                    .HasForeignKey(d => d.AppUserId)
                    .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Car-Category
            builder.Entity<Category>()
                    .HasMany(c => c.Cars)
                    .WithOne(c => c.Category)
                    .HasForeignKey(c => c.CategoryId)
                    .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Car-Rental
            builder.Entity<Car>()
                    .HasMany(c => c.Rentals)
                    .WithOne(r => r.Car)
                    .HasForeignKey(r => r.CarId)
                    .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Car-Review
            builder.Entity<Car>()
                    .HasMany(c => c.Reviews)
                    .WithOne(r => r.Car)
                    .HasForeignKey(r => r.CarId)
                    .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Car-Image
            builder.Entity<Car>()
                    .HasMany(c => c.CarImages)
                    .WithOne(i => i.Car)
                    .HasForeignKey(i => i.CarId)
                    .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Rental-Payment
            builder.Entity<Rental>()
                    .HasMany(r => r.Payments)
                    .WithOne(p => p.Rental)
                    .HasForeignKey(p => p.RentalId)
                    .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #endregion

            // =================== Roles ===================
            var adminRoleId = "11111111-1111-1111-1111-111111111111";
            var ownerRoleId = "22222222-2222-2222-2222-222222222222";
            var customerRoleId = "33333333-3333-3333-3333-333333333333";

            builder.Entity<AppRole>().HasData(
                new AppRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
                new AppRole { Id = ownerRoleId, Name = "Owner", NormalizedName = "OWNER" },
                new AppRole { Id = customerRoleId, Name = "Customer", NormalizedName = "CUSTOMER" }
            );

            // =================== Users ===================
            var adminUserId = "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa";
            var ownerUserId = "bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb";
            var customerUserId = "cccccccc-cccc-cccc-cccc-cccccccccccc";

            builder.Entity<AppUser>().HasData(
    new AppUser
    {
        Id = adminUserId,
        UserName = "admin@system.com",
        NormalizedUserName = "ADMIN@SYSTEM.COM",
        Email = "admin@system.com",
        NormalizedEmail = "ADMIN@SYSTEM.COM",
        EmailConfirmed = true,

        PasswordHash = "AQAAAAIAAYagAAAAEOl6JGZ198pti7st7mJa1W3L0b8KVHVlMGLiiytti9xCL4XI1nRWhe8l4u/QJqLwDQ==",

        SecurityStamp = "11111111-aaaa-aaaa-aaaa-aaaaaaaaaaaa",
        ConcurrencyStamp = "11111111-bbbb-bbbb-bbbb-bbbbbbbbbbbb"
    },

    new AppUser
    {
        Id = ownerUserId,
        UserName = "owner@system.com",
        NormalizedUserName = "OWNER@SYSTEM.COM",
        Email = "owner@system.com",
        NormalizedEmail = "OWNER@SYSTEM.COM",
        EmailConfirmed = true,

        PasswordHash = "AQAAAAIAAYagAAAAEBYwFmzVidPhWNw1v2E8afkWSRpELnVYYU/7vKpa3gaXAR8b7EDvgq79Mz7yFGV0KA==",

        SecurityStamp = "22222222-bbbb-bbbb-bbbb-bbbbbbbbbbbb",
        ConcurrencyStamp = "22222222-cccc-cccc-cccc-cccccccccccc"
    },

    new AppUser
    {
        Id = customerUserId,
        UserName = "customer@system.com",
        NormalizedUserName = "CUSTOMER@SYSTEM.COM",
        Email = "customer@system.com",
        NormalizedEmail = "CUSTOMER@SYSTEM.COM",
        EmailConfirmed = true,

        PasswordHash = "AQAAAAIAAYagAAAAELJ1/UFD9Y1BhqFWI+dbif+nQapSLxpuROK1dx70bO7Qk193rSbwDSdxLMslVVrnEw==",

        SecurityStamp = "33333333-cccc-cccc-cccc-cccccccccccc",
        ConcurrencyStamp = "33333333-dddd-dddd-dddd-dddddddddddd"
    }
);

            // =================== Assign Roles to Users ===================
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = adminUserId, RoleId = adminRoleId },
                new IdentityUserRole<string> { UserId = ownerUserId, RoleId = ownerRoleId },
                new IdentityUserRole<string> { UserId = customerUserId, RoleId = customerRoleId }
            );
            // =================== Categories ===================
            var sedanCategoryId = new Guid("dddddddd-1111-1111-1111-111111111111");
            var suvCategoryId = new Guid("eeeeeeee-2222-2222-2222-222222222222");


            builder.Entity<Category>().HasData(
                new Category
                {
                    Id = sedanCategoryId,
                    Name = "Sedan",
                },
                new Category
                {
                    Id = suvCategoryId,
                    Name = "SUV",
                }

            );


            // =================== Cars ===================

            var car1Id = new Guid("aaaaaaaa-3333-3333-3333-333333333333");
            var car2Id = new Guid("bbbbbbbb-4444-4444-4444-444444444444");
            builder.Entity<Car>().HasData(
                new Car
                {
                    Id = car1Id,
                    Name = "Toyota Corolla",
                    Brand = "Toyota",
                    ModelYear = 2021,
                    PlateNumber = "ABC-123",
                    Color = "White",
                    Capacity = 5,
                    Rate = 50,
                    Status = CarStatus.Available,
                    OwnerUserId = ownerUserId,
                    CategoryId = sedanCategoryId
                },
                new Car
                {
                    Id = car2Id,
                    Name = "Honda Civic",
                    Brand = "Honda",
                    ModelYear = 2022,
                    PlateNumber = "XYZ-456",
                    Color = "Black",
                    Capacity = 5,
                    Rate = 60,
                    Status = CarStatus.Available,
                    OwnerUserId = ownerUserId
                    ,
                    CategoryId = suvCategoryId
                }
            );

            // =================== Rentals ===================
            var rental1Id = new Guid("aaaaaaaa-5555-5555-5555-555555555555");

            builder.Entity<Rental>().HasData(
                new Rental
                {
                    Id = rental1Id,
                    CarId = car1Id,
                    CustomerUserId = customerUserId,
                    OwnerUserId = ownerUserId,
                    RentalDate = new DateTime(2026, 1, 20),
                    ReturnDate = new DateTime(2026, 1, 25),
                    ActualDate = null,
                    Status = RentalStatus.Active
                }
            );

            // =================== Payments ===================
            var payment1Id = new Guid("aaaaaaaa-6666-6666-6666-666666666666");
            builder.Entity<Payment>().HasData(
                new Payment
                {
                    Id = payment1Id,
                    RentalId = rental1Id,
                    Amount = 150,
                    PaymentDate = new DateTime(2026, 1, 20),
                    PaymentType = PaymentType.Deposit,
                }
            );

            // =================== Reviews ===================
            var review1Id = new Guid("aaaaaaaa-7777-7777-7777-777777777777");
            builder.Entity<Review>().HasData(
                new Review
                {
                    Id = review1Id,
                    CarId = car1Id,
                    CustomerUserId = customerUserId,
                    Title = "Great car!",
                    Score = 5,
                    Date = new DateTime(2026, 1, 22)
                }
            );
        }
    }
}
