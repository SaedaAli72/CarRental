using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRentalDAL.Migrations
{
    /// <inheritdoc />
    public partial class car : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Categories",
                keyColumn: "Id",
                keyValue: "55676524-a76c-40d5-9bff-6841aef0e57d");

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
                table: "Categories",
                keyColumn: "Id",
                keyValue: "d1fd691b-fc71-4c7b-8fba-8d4c5a64fe8d");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "e0b6d5ec-7810-465d-a9a6-43ff649a623f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4b4fddfa-56b9-4304-9e42-975d2742d427", null, "AppRole", "Admin", "ADMIN" },
                    { "4fc7a5c2-d937-468c-898f-9c0947ab5e84", null, "AppRole", "Customer", "CUSTOMER" },
                    { "673736a1-629e-4f4e-bf64-3925da9db1b4", null, "AppRole", "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "bc0bfb10-e1ef-4342-a148-d330040a76dc", "Sedan" },
                    { "eeb7eb13-3409-4e84-af49-68b79c039c1d", "SUV" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "09975295-832f-46fd-a9cb-31a1c2c0c377", 0, "b99445e6-fd43-4f2a-a6d2-424095206d37", "customer@system.com", true, false, null, "CUSTOMER@SYSTEM.COM", "CUSTOMER@SYSTEM.COM", "AQAAAAIAAYagAAAAED1KbdZLmwSCrWXe0NBpdMKEmCwH506fO73JpIAvyOHI+VSVXxSM9lx36BXKdj+8Ig==", null, false, "3b21c891-0010-4c7a-8553-2fc8f9aa1a63", false, "customer@system.com" },
                    { "7cf13b3a-78a8-481b-8122-ddba91b49088", 0, "51469f7b-2e9f-4dfd-abfb-c329699f5386", "owner@system.com", true, false, null, "OWNER@SYSTEM.COM", "OWNER@SYSTEM.COM", "AQAAAAIAAYagAAAAECKalDP5JHyG2GhvCswePMdtZvpBX8uAxvmZwvntF6VdnDn33tnvquuoKyw3ZJGFsQ==", null, false, "b8bbcbaf-c038-4301-9ed1-a7c6886d874f", false, "owner@system.com" },
                    { "c1203171-e3e9-491f-89e0-6aec11e957fc", 0, "9e8e55b4-36b2-45e6-abcc-b9223542021c", "admin@system.com", true, false, null, "ADMIN@SYSTEM.COM", "ADMIN@SYSTEM.COM", "AQAAAAIAAYagAAAAEHCNpTxIOu6tqGAZDoT21Jdl3qO/2PCs+2zaGZELtrkZ6afoZhANBP3+ChS3lyrMcg==", null, false, "f92ae652-fd95-4fda-bf6c-6d0a3b1d9ac3", false, "admin@system.com" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Capacity", "CategoryId", "Color", "ModelYear", "Name", "OwnerUserId", "PlateNumber", "PricePerDay", "Rate", "Status" },
                values: new object[,]
                {
                    { "0b64407f-8140-4fa1-98ae-0f0786ed07cf", "Honda", 5, "eeb7eb13-3409-4e84-af49-68b79c039c1d", "Black", 2022, "Honda Civic", "7cf13b3a-78a8-481b-8122-ddba91b49088", "XYZ-456", 0m, 60m, "Available" },
                    { "fcf41895-17a5-456f-98b6-735d450c872c", "Toyota", 5, "bc0bfb10-e1ef-4342-a148-d330040a76dc", "White", 2021, "Toyota Corolla", "7cf13b3a-78a8-481b-8122-ddba91b49088", "ABC-123", 0m, 50m, "Available" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4fc7a5c2-d937-468c-898f-9c0947ab5e84", "09975295-832f-46fd-a9cb-31a1c2c0c377" },
                    { "673736a1-629e-4f4e-bf64-3925da9db1b4", "7cf13b3a-78a8-481b-8122-ddba91b49088" },
                    { "4b4fddfa-56b9-4304-9e42-975d2742d427", "c1203171-e3e9-491f-89e0-6aec11e957fc" }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "ActualDate", "CarId", "CustomerUserId", "OwnerUserId", "RentalDate", "ReturnDate", "Status" },
                values: new object[] { "85d1c997-4623-427e-a965-fcd6f8e0fad4", null, "fcf41895-17a5-456f-98b6-735d450c872c", "09975295-832f-46fd-a9cb-31a1c2c0c377", "7cf13b3a-78a8-481b-8122-ddba91b49088", new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CarId", "CustomerUserId", "Date", "Score", "Text", "Title" },
                values: new object[] { "85d1c997-4623-427e-a965-fcd6f8e0fad4", "fcf41895-17a5-456f-98b6-735d450c872c", "09975295-832f-46fd-a9cb-31a1c2c0c377", new DateTime(2026, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, "Great car!" });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "AppUserId", "PaymentDate", "PaymentType", "RentalId" },
                values: new object[] { "db324d05-59d5-4ec1-91d8-09d0f8843103", 150m, null, new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deposit", "85d1c997-4623-427e-a965-fcd6f8e0fad4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: "0b64407f-8140-4fa1-98ae-0f0786ed07cf");

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: "db324d05-59d5-4ec1-91d8-09d0f8843103");

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: "85d1c997-4623-427e-a965-fcd6f8e0fad4");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4fc7a5c2-d937-468c-898f-9c0947ab5e84", "09975295-832f-46fd-a9cb-31a1c2c0c377" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "673736a1-629e-4f4e-bf64-3925da9db1b4", "7cf13b3a-78a8-481b-8122-ddba91b49088" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4b4fddfa-56b9-4304-9e42-975d2742d427", "c1203171-e3e9-491f-89e0-6aec11e957fc" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b4fddfa-56b9-4304-9e42-975d2742d427");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fc7a5c2-d937-468c-898f-9c0947ab5e84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "673736a1-629e-4f4e-bf64-3925da9db1b4");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "eeb7eb13-3409-4e84-af49-68b79c039c1d");

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: "85d1c997-4623-427e-a965-fcd6f8e0fad4");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "c1203171-e3e9-491f-89e0-6aec11e957fc");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: "fcf41895-17a5-456f-98b6-735d450c872c");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "09975295-832f-46fd-a9cb-31a1c2c0c377");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "bc0bfb10-e1ef-4342-a148-d330040a76dc");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7cf13b3a-78a8-481b-8122-ddba91b49088");

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
        }
    }
}
