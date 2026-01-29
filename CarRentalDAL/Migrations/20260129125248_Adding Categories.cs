using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRentalDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddingCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: "3e4030fb-3e05-4a64-887d-fc6698f0276d");

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: "c4958ce0-6ea7-4f0f-8985-08e274e8570c");

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: "8031f399-7e8c-415b-84e6-fae85a703150");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "666a7310-dbcc-42c8-8423-b36a993d59b0", "11fe7915-da52-4c82-83a8-95c5debc4e21" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ede35c35-7f98-4e88-bb00-0b5884196880", "31280881-2ec3-4e44-82bf-c84ecf54e100" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "46e250d8-05c9-44bc-830e-8fdf06180595", "dd7ac551-be9d-4467-a896-edd3841cc505" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46e250d8-05c9-44bc-830e-8fdf06180595");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "666a7310-dbcc-42c8-8423-b36a993d59b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ede35c35-7f98-4e88-bb00-0b5884196880");

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: "8031f399-7e8c-415b-84e6-fae85a703150");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "11fe7915-da52-4c82-83a8-95c5debc4e21");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: "ac50f2e7-19c7-4e41-a71e-324bf5f2fea2");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "dd7ac551-be9d-4467-a896-edd3841cc505");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "31280881-2ec3-4e44-82bf-c84ecf54e100");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerDay",
                table: "Cars",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2430619a-4e22-480b-aee5-ee45251173c2", null, "AppRole", "Customer", "CUSTOMER" },
                    { "24be6338-2814-4435-94ed-a53a642d0f21", null, "AppRole", "Owner", "OWNER" },
                    { "fa3d28ca-f74a-4121-9c88-ae2e8a8a8964", null, "AppRole", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "55676524-a76c-40d5-9bff-6841aef0e57d", "SUV" },
                    { "d1fd691b-fc71-4c7b-8fba-8d4c5a64fe8d", "Sedan" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "97e5f66f-8be0-4760-a9e2-089796214cc1", 0, "186ec5c9-3de4-43d5-80dc-c5e82b1c5bad", "admin@system.com", true, false, null, "ADMIN@SYSTEM.COM", "ADMIN@SYSTEM.COM", "AQAAAAIAAYagAAAAECtO403Y0da623L2qvZ/UpXKhTYtXrW4ZogjDF47etxs1Bame+GZUOsQEC01HQkjmQ==", null, false, "2759e44f-2358-4138-b4f3-5e774d8775a1", false, "admin@system.com" },
                    { "e0b6d5ec-7810-465d-a9a6-43ff649a623f", 0, "2755183b-5caf-46ee-92f5-b5e9ab5ca477", "owner@system.com", true, false, null, "OWNER@SYSTEM.COM", "OWNER@SYSTEM.COM", "AQAAAAIAAYagAAAAENtt+HJU0bXacSXuYYMFPJCWnCcRP6Htun7h3qS07/F+jhXyjkSwPWN/OwrjP7bZdA==", null, false, "51f458be-ea1d-4c69-9e0b-469ffa065b66", false, "owner@system.com" },
                    { "fa40b9ad-4023-4b06-95b9-4de3dc70dab6", 0, "e2d693c8-0647-46d3-9572-bd3d6b6c9651", "customer@system.com", true, false, null, "CUSTOMER@SYSTEM.COM", "CUSTOMER@SYSTEM.COM", "AQAAAAIAAYagAAAAEHl6yFp0dyIh7BpmoR7yqNTDMJ7jjb3rsEafxy+tn3AqKq73/lJ1Ui5tNIYLhlPgcQ==", null, false, "6fd2a31e-9156-48ab-9e50-3a2865e587d9", false, "customer@system.com" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Capacity", "CategoryId", "Color", "ModelYear", "Name", "OwnerUserId", "PlateNumber", "PricePerDay", "Rate", "Status" },
                values: new object[,]
                {
                    { "08d3eae4-4fec-410c-a955-11f6f9eeffd1", "Toyota", 5, "d1fd691b-fc71-4c7b-8fba-8d4c5a64fe8d", "White", 2021, "Toyota Corolla", "e0b6d5ec-7810-465d-a9a6-43ff649a623f", "ABC-123", 0m, 50m, "Available" },
                    { "2bb2cfe6-491e-4f77-8b1f-c65196c32f6e", "Honda", 5, "55676524-a76c-40d5-9bff-6841aef0e57d", "Black", 2022, "Honda Civic", "e0b6d5ec-7810-465d-a9a6-43ff649a623f", "XYZ-456", 0m, 60m, "Available" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "fa3d28ca-f74a-4121-9c88-ae2e8a8a8964", "97e5f66f-8be0-4760-a9e2-089796214cc1" },
                    { "24be6338-2814-4435-94ed-a53a642d0f21", "e0b6d5ec-7810-465d-a9a6-43ff649a623f" },
                    { "2430619a-4e22-480b-aee5-ee45251173c2", "fa40b9ad-4023-4b06-95b9-4de3dc70dab6" }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "ActualDate", "CarId", "CustomerUserId", "OwnerUserId", "RentalDate", "ReturnDate", "Status" },
                values: new object[] { "af9561ed-9266-4d16-b666-851d898525df", null, "08d3eae4-4fec-410c-a955-11f6f9eeffd1", "fa40b9ad-4023-4b06-95b9-4de3dc70dab6", "e0b6d5ec-7810-465d-a9a6-43ff649a623f", new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CarId", "CustomerUserId", "Date", "Score", "Text", "Title" },
                values: new object[] { "af9561ed-9266-4d16-b666-851d898525df", "08d3eae4-4fec-410c-a955-11f6f9eeffd1", "fa40b9ad-4023-4b06-95b9-4de3dc70dab6", new DateTime(2026, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, "Great car!" });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "AppUserId", "PaymentDate", "PaymentType", "RentalId" },
                values: new object[] { "0c0a846d-10ce-4548-aa96-144b70f161b3", 150m, null, new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deposit", "af9561ed-9266-4d16-b666-851d898525df" });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Categories_CategoryId",
                table: "Cars",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Categories_CategoryId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: "2bb2cfe6-491e-4f77-8b1f-c65196c32f6e");

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: "0c0a846d-10ce-4548-aa96-144b70f161b3");

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: "af9561ed-9266-4d16-b666-851d898525df");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fa3d28ca-f74a-4121-9c88-ae2e8a8a8964", "97e5f66f-8be0-4760-a9e2-089796214cc1" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "24be6338-2814-4435-94ed-a53a642d0f21", "e0b6d5ec-7810-465d-a9a6-43ff649a623f" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2430619a-4e22-480b-aee5-ee45251173c2", "fa40b9ad-4023-4b06-95b9-4de3dc70dab6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2430619a-4e22-480b-aee5-ee45251173c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24be6338-2814-4435-94ed-a53a642d0f21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa3d28ca-f74a-4121-9c88-ae2e8a8a8964");

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: "af9561ed-9266-4d16-b666-851d898525df");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "97e5f66f-8be0-4760-a9e2-089796214cc1");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: "08d3eae4-4fec-410c-a955-11f6f9eeffd1");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "fa40b9ad-4023-4b06-95b9-4de3dc70dab6");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "e0b6d5ec-7810-465d-a9a6-43ff649a623f");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PricePerDay",
                table: "Cars");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46e250d8-05c9-44bc-830e-8fdf06180595", null, "AppRole", "Customer", "CUSTOMER" },
                    { "666a7310-dbcc-42c8-8423-b36a993d59b0", null, "AppRole", "Admin", "ADMIN" },
                    { "ede35c35-7f98-4e88-bb00-0b5884196880", null, "AppRole", "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "11fe7915-da52-4c82-83a8-95c5debc4e21", 0, "f9f346c1-1391-41d9-96cb-850e52bd6ce4", "admin@system.com", true, false, null, "ADMIN@SYSTEM.COM", "ADMIN@SYSTEM.COM", "AQAAAAIAAYagAAAAELFQUpUzTkPb2Ft/YJMq2Aql7g4+zwdqi3h3c5+T0JStY6EOZxaF1JgkD1FVQir/YQ==", null, false, "209c8236-91a3-4d1d-b44e-1a0e1a031fb6", false, "admin@system.com" },
                    { "31280881-2ec3-4e44-82bf-c84ecf54e100", 0, "ce3e0b4d-20d3-4d6a-ba9d-fcf52d0c4510", "owner@system.com", true, false, null, "OWNER@SYSTEM.COM", "OWNER@SYSTEM.COM", "AQAAAAIAAYagAAAAEPal0oZIWTuQtnkDWAk4tnjIKkR5srDUPwQ0rh5JeBaSC69qI5FoF4TU+edkq8gYgw==", null, false, "8735926a-ded3-4ea2-b59e-47955887e77e", false, "owner@system.com" },
                    { "dd7ac551-be9d-4467-a896-edd3841cc505", 0, "3dddb528-054c-404d-8333-5b815d0a4f14", "customer@system.com", true, false, null, "CUSTOMER@SYSTEM.COM", "CUSTOMER@SYSTEM.COM", "AQAAAAIAAYagAAAAEASyW4dlsbHX1qawXcziiqoAM4xebGW1+ku5f7wX8ugYDcEeam2x7ujQyjCtcEF/vw==", null, false, "386d116e-424b-481a-860d-facab318c23a", false, "customer@system.com" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Capacity", "Color", "ModelYear", "Name", "OwnerUserId", "PlateNumber", "Rate", "Status" },
                values: new object[,]
                {
                    { "3e4030fb-3e05-4a64-887d-fc6698f0276d", "Honda", 5, "Black", 2022, "Honda Civic", "31280881-2ec3-4e44-82bf-c84ecf54e100", "XYZ-456", 60m, "Available" },
                    { "ac50f2e7-19c7-4e41-a71e-324bf5f2fea2", "Toyota", 5, "White", 2021, "Toyota Corolla", "31280881-2ec3-4e44-82bf-c84ecf54e100", "ABC-123", 50m, "Available" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "666a7310-dbcc-42c8-8423-b36a993d59b0", "11fe7915-da52-4c82-83a8-95c5debc4e21" },
                    { "ede35c35-7f98-4e88-bb00-0b5884196880", "31280881-2ec3-4e44-82bf-c84ecf54e100" },
                    { "46e250d8-05c9-44bc-830e-8fdf06180595", "dd7ac551-be9d-4467-a896-edd3841cc505" }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "ActualDate", "CarId", "CustomerUserId", "OwnerUserId", "RentalDate", "ReturnDate", "Status" },
                values: new object[] { "8031f399-7e8c-415b-84e6-fae85a703150", null, "ac50f2e7-19c7-4e41-a71e-324bf5f2fea2", "dd7ac551-be9d-4467-a896-edd3841cc505", "31280881-2ec3-4e44-82bf-c84ecf54e100", new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CarId", "CustomerUserId", "Date", "Score", "Text", "Title" },
                values: new object[] { "8031f399-7e8c-415b-84e6-fae85a703150", "ac50f2e7-19c7-4e41-a71e-324bf5f2fea2", "dd7ac551-be9d-4467-a896-edd3841cc505", new DateTime(2026, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, "Great car!" });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "AppUserId", "PaymentDate", "PaymentType", "RentalId" },
                values: new object[] { "c4958ce0-6ea7-4f0f-8985-08e274e8570c", 150m, null, new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deposit", "8031f399-7e8c-415b-84e6-fae85a703150" });
        }
    }
}
