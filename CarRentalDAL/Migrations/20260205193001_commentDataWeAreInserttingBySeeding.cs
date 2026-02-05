using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRentalDAL.Migrations
{
    /// <inheritdoc />
    public partial class commentDataWeAreInserttingBySeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Cars",
            //    keyColumn: "Id",
            //    keyValue: new Guid("bbbbbbbb-4444-4444-4444-444444444444"));

            //migrationBuilder.DeleteData(
            //    table: "Payments",
            //    keyColumn: "Id",
            //    keyValue: new Guid("aaaaaaaa-6666-6666-6666-666666666666"));

            //migrationBuilder.DeleteData(
            //    table: "Reviews",
            //    keyColumn: "Id",
            //    keyValue: new Guid("aaaaaaaa-7777-7777-7777-777777777777"));

            //migrationBuilder.DeleteData(
            //    table: "UserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "11111111-1111-1111-1111-111111111111", "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa" });

            //migrationBuilder.DeleteData(
            //    table: "UserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "22222222-2222-2222-2222-222222222222", "bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb" });

            //migrationBuilder.DeleteData(
            //    table: "UserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "33333333-3333-3333-3333-333333333333", "cccccccc-cccc-cccc-cccc-cccccccccccc" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "11111111-1111-1111-1111-111111111111");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "22222222-2222-2222-2222-222222222222");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "33333333-3333-3333-3333-333333333333");

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"));

            //migrationBuilder.DeleteData(
            //    table: "Rentals",
            //    keyColumn: "Id",
            //    keyValue: new Guid("aaaaaaaa-5555-5555-5555-555555555555"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "Id",
            //    keyValue: "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

            //migrationBuilder.DeleteData(
            //    table: "Cars",
            //    keyColumn: "Id",
            //    keyValue: new Guid("aaaaaaaa-3333-3333-3333-333333333333"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "Id",
            //    keyValue: "cccccccc-cccc-cccc-cccc-cccccccccccc");

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("dddddddd-1111-1111-1111-111111111111"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "Id",
            //    keyValue: "bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "11111111-1111-1111-1111-111111111111", null, "AppRole", "Admin", "ADMIN" },
            //        { "22222222-2222-2222-2222-222222222222", null, "AppRole", "Owner", "OWNER" },
            //        { "33333333-3333-3333-3333-333333333333", null, "AppRole", "Customer", "CUSTOMER" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Categories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("dddddddd-1111-1111-1111-111111111111"), "Sedan" },
            //        { new Guid("eeeeeeee-2222-2222-2222-222222222222"), "SUV" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
            //    values: new object[,]
            //    {
            //        { "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa", 0, "11111111-bbbb-bbbb-bbbb-bbbbbbbbbbbb", "admin@system.com", true, false, null, "ADMIN@SYSTEM.COM", "ADMIN@SYSTEM.COM", "AQAAAAIAAYagAAAAEOl6JGZ198pti7st7mJa1W3L0b8KVHVlMGLiiytti9xCL4XI1nRWhe8l4u/QJqLwDQ==", null, false, "11111111-aaaa-aaaa-aaaa-aaaaaaaaaaaa", false, "admin@system.com" },
            //        { "bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb", 0, "22222222-cccc-cccc-cccc-cccccccccccc", "owner@system.com", true, false, null, "OWNER@SYSTEM.COM", "OWNER@SYSTEM.COM", "AQAAAAIAAYagAAAAEBYwFmzVidPhWNw1v2E8afkWSRpELnVYYU/7vKpa3gaXAR8b7EDvgq79Mz7yFGV0KA==", null, false, "22222222-bbbb-bbbb-bbbb-bbbbbbbbbbbb", false, "owner@system.com" },
            //        { "cccccccc-cccc-cccc-cccc-cccccccccccc", 0, "33333333-dddd-dddd-dddd-dddddddddddd", "customer@system.com", true, false, null, "CUSTOMER@SYSTEM.COM", "CUSTOMER@SYSTEM.COM", "AQAAAAIAAYagAAAAELJ1/UFD9Y1BhqFWI+dbif+nQapSLxpuROK1dx70bO7Qk193rSbwDSdxLMslVVrnEw==", null, false, "33333333-cccc-cccc-cccc-cccccccccccc", false, "customer@system.com" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Cars",
            //    columns: new[] { "Id", "Brand", "Capacity", "CategoryId", "Color", "ModelYear", "Name", "OwnerUserId", "PlateNumber", "PricePerDay", "Rate", "Status" },
            //    values: new object[,]
            //    {
            //        { new Guid("aaaaaaaa-3333-3333-3333-333333333333"), "Toyota", 5, new Guid("dddddddd-1111-1111-1111-111111111111"), "White", 2021, "Toyota Corolla", "bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb", "ABC-123", 0m, 50m, "Available" },
            //        { new Guid("bbbbbbbb-4444-4444-4444-444444444444"), "Honda", 5, new Guid("eeeeeeee-2222-2222-2222-222222222222"), "Black", 2022, "Honda Civic", "bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb", "XYZ-456", 0m, 60m, "Available" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "UserRoles",
            //    columns: new[] { "RoleId", "UserId" },
            //    values: new object[,]
            //    {
            //        { "11111111-1111-1111-1111-111111111111", "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa" },
            //        { "22222222-2222-2222-2222-222222222222", "bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb" },
            //        { "33333333-3333-3333-3333-333333333333", "cccccccc-cccc-cccc-cccc-cccccccccccc" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Rentals",
            //    columns: new[] { "Id", "ActualDate", "CarId", "CustomerUserId", "OwnerUserId", "RentalDate", "ReturnDate", "Status" },
            //    values: new object[] { new Guid("aaaaaaaa-5555-5555-5555-555555555555"), null, new Guid("aaaaaaaa-3333-3333-3333-333333333333"), "cccccccc-cccc-cccc-cccc-cccccccccccc", "bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb", new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" });

            //migrationBuilder.InsertData(
            //    table: "Reviews",
            //    columns: new[] { "Id", "CarId", "CustomerUserId", "Date", "Score", "Text", "Title" },
            //    values: new object[] { new Guid("aaaaaaaa-7777-7777-7777-777777777777"), new Guid("aaaaaaaa-3333-3333-3333-333333333333"), "cccccccc-cccc-cccc-cccc-cccccccccccc", new DateTime(2026, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, "Great car!" });

            //migrationBuilder.InsertData(
            //    table: "Payments",
            //    columns: new[] { "Id", "Amount", "AppUserId", "PaymentDate", "PaymentType", "RentalId" },
            //    values: new object[] { new Guid("aaaaaaaa-6666-6666-6666-666666666666"), 150m, null, new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deposit", new Guid("aaaaaaaa-5555-5555-5555-555555555555") });
        }
    }
}
