using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => new { x.ProductId, x.CartId, x.Size, x.Color });
                    table.ForeignKey(
                        name: "FK_CartProduct_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => new { x.ProductID, x.ImageURL });
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsInfo",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsInfo", x => new { x.ProductID, x.Color, x.Size });
                    table.ForeignKey(
                        name: "FK_ProductsInfo_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WishListID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CartID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NameOnCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumber = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MidName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_WishLists_WishListID",
                        column: x => x.WishListID,
                        principalTable: "WishLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductWishList",
                columns: table => new
                {
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WishListsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWishList", x => new { x.ProductsId, x.WishListsId });
                    table.ForeignKey(
                        name: "FK_ProductWishList_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductWishList_WishLists_WishListsId",
                        column: x => x.WishListsId,
                        principalTable: "WishLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomersReviews",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersReviews", x => new { x.ProductId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_CustomersReviews_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.ProductId, x.OrderId, x.Color, x.Size });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardNumber", "CartID", "City", "ConcurrencyStamp", "Country", "Discriminator", "Email", "EmailConfirmed", "ExpireDate", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MidName", "NameOnCard", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName", "WishListID" },
                values: new object[,]
                {
                    { "07d96ed8-155d-49c7-a77a-615f109d77c3", 0, 1234567890123456m, null, "New York", "a55f79f3-d046-4e00-a97c-3cb9eeb6bb2e", "Ukraine", "Customer", "johndoe@example.com", false, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Doe", false, null, "E", " John E Doe", null, null, null, "123-456-7890", false, "User", "934bf199-d5d7-4779-bda4-ac4e7dbdd88d", "123 Main St", false, null, null },
                    { "0e67a2e5-df53-4a92-9854-8e1ad46a4e61", 0, 5432101234567890m, null, "Paris", "42c922af-7c43-4aac-a338-8ec8378e51f0", "France", "Customer", "oliviabrown@example.com", false, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olivia", "Brown", false, null, "N", "Olivia N Brown", null, null, null, "888-777-6666", false, "User", "28f519a0-c6f7-45d0-8875-37085111e8b1", "123 Cherry St", false, null, null },
                    { "22ac8dc9-4385-48ae-90a3-7d8c898c6d5d", 0, 1234554321098765m, null, "Seoul", "14a3abd1-f451-4a7a-a322-639efa355cb9", "Serbia", "Customer", "sophialee@example.com", false, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sophia", "Lee", false, null, "K", "Sophia K Lee", null, null, null, "222-333-4444", false, "User", "297e0e67-e77b-4395-b3b8-6ca67892dbde", "456 Cedar St", false, null, null },
                    { "23456789-01ab-cdef-0123-456789abcdef", 0, 5432109876543210m, null, "Madrid", "fec8af31-bffe-4afc-b2f6-1eed0ecc434e", "Spain", "Customer", "isabellatmartinez@example.com", false, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isabella", "Martinez", false, null, "T", "Isabella T Martinez", null, null, null, "888-777-6666", false, "User", "657cd449-d340-4912-91d2-cfebd75b7dd4", "123 Cherry St", false, null, null },
                    { "2345cdef-0123-4567-89ab-cdef01234567", 0, 1234554321098765m, null, "Seattle", "c2f7a787-f1d7-41c1-beff-d8f236da146c", "Kiribati", "Customer", "noahajohnson@example.com", false, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Noah", "Johnson", false, null, "A", "Noah A Johnson", null, null, null, "222-333-4444", false, "User", "2346151a-f09a-4c80-a379-6f1392bcadb6", "456 Cedar St", false, null, null },
                    { "234cdf89-12a3-45b6-789c-0123456789de", 0, 9876543298765432m, null, "New York", "8ccdb489-9dcd-4122-8d8c-34f56ea6e000", "Bangladesh", "Customer", "emmajdavis@example.com", false, new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emma", "Davis", false, null, "J", "Emma J Davis", null, null, null, "444-555-6666", false, "User", "f34e7602-6e73-4cb3-b53b-d697f7dc3fb7", "456 Maple Ave", false, null, null },
                    { "456789ab-cdef-0123-4567-89abcdef0123", 0, 5432167890123456m, null, "Rome", "e6594633-f977-417c-a06a-013dabe3c325", "Italy", "Customer", "miasjohnson@example.com", false, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mia", "Johnson", false, null, "S", "Mia S Johnson", null, null, null, "777-888-9999", false, "User", "63de93e3-4b74-47f2-9e4d-0054f180453c", "789 Oak St", false, null, null },
                    { "56789abc-def0-1234-5678-9abcdef01234", 0, 1234987654321098m, null, "Tokyo", "2656372a-51f9-481a-83b9-a589975239f2", "Japan", "Customer", "logantmartinez@example.com", false, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Logan", "Martinez", false, null, "T", "Logan T Martinez", null, null, null, "555-666-7777", false, "User", "5c5b5bd5-0657-44e9-95dd-033492e6f0dd", "123 Walnut Ave", false, null, null },
                    { "6789abcd-ef01-2345-6789-abcd01234567", 0, 1234987654321098m, null, "Los Angeles", "f3bdee5b-8328-4017-9861-cfd15194516a", "Somalia", "Customer", "liammwilson@example.com", false, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liam", "Wilson", false, null, "M", "Liam M Wilson", null, null, null, "777-888-9999", false, "User", "144cbfc4-d7db-4f1e-a25d-167e20537d33", "789 Oak St", false, null, null },
                    { "724587e6-9314-4fe6-9c3e-6fd612f50234", 0, 1234567812345678m, null, "London", "08325e61-dee6-4e59-85d3-a19334692818", "Andorra", "Customer", "williamtaylor@example.com", false, new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "William", "Taylor", false, null, "G", "William G Taylor", null, null, null, "111-222-3333", false, "User", "de07ea27-58bb-48bf-a262-4327381ee0f5", "123 Elm St", false, null, null },
                    { "74f5b2b3-3d10-4a85-93b5-8c6d0c992b58", 0, 5432167890123456m, null, "Chicago", "7f9e8e52-564f-4776-b6dd-ce1ccb9ad7dd", "Zimbabwe", "Customer", "alexjohnson@example.com", false, new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "Johnson", false, null, "S", " Alex S Johnson", null, null, null, "777-888-666", false, "User", "417f696d-2f94-4ac6-a812-e5183711318d", "789 Oak St", false, null, null },
                    { "74f5b2b3-3d10-4a85-93b5-8c6d0c992bb7", 0, 9876543210123456m, null, "San Francisco", "7ba0a8e3-8534-4ad6-98c2-e742f6b72b88", "Australia", "Customer", "emilyanderson@example.com", false, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily", "Anderson", false, null, "R", "Emily R Anderson", null, null, null, "111-222-3333", false, "User", "c07157ee-f856-480f-892d-35280e9a5698", "789 Elm St", false, null, null },
                    { "74f5b2b3-3d10-4a85-93b5-8c6d0c992bb8", 0, 1234987654321098m, null, "London", "604f84a8-f580-4510-a7af-851715bf6f4f", "Albania", "Customer", "michaelwilson@example.com", false, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", "Wilson", false, null, "J", "Michael J Wilson", null, null, null, "444-555-6666", false, "User", "b54d8799-18a1-4665-bffc-2eb19a5d7b0c", "456 Maple Ave", false, null, null },
                    { "8901def0-1234-5678-9abc-def012345678", 0, 9876543298765432m, null, "San Francisco", "bce199d5-b948-48a7-89fa-2a789b7f4431", "Uruguay", "Customer", "avaklee@example.com", false, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ava", "Lee", false, null, "K", "Ava K Lee", null, null, null, "555-666-7777", false, "User", "bbada415-eb3c-4a30-97c2-5d8f1a7a24eb", "789 Walnut Ave", false, null, null },
                    { "b6a76b15-33e5-4d26-98b9-c948c7823b84", 0, 9876543210012345m, null, "Madrid", "31a6d716-121d-4c8e-b78e-0de067b47ad1", "Spain", "Customer", "danielmartinez@example.com", false, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel", "Martinez", false, null, "T", "Daniel T Martinez", null, null, null, "555-666-7777", false, "User", "4538de25-7cfd-436b-938e-2a6fc918ee5c", "789 Walnut Ave", false, null, null },
                    { "bcdef012-3456-789a-bcde-f01234567890", 0, 9876012345678901m, null, "Sydney", "52314635-d512-481b-badb-11ba9697badb", "Australia", "Customer", "olivialthompson@example.com", false, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olivia", "Thompson", false, null, "L", "Olivia L Thompson", null, null, null, "777-777-8888", false, "User", "2a0b54ed-95b4-4973-bfe1-41bbf11136a7", "123 Pine St", false, null, null },
                    { "c7d3e80a-7a4a-4c54-91a6-89c0df051c94", 0, 9876543210987654m, null, "Los Angeles", "c6154eb4-ea7e-4489-9fce-bed5b32874f1", "Turkey", "Customer", "janesmith@example.com", false, new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Smith", false, null, "A", " Jane A Smith", null, null, null, "777-888-9999", false, "User", "54e7fa26-2265-4183-ac4a-da86b4a9b34c", "456 Elm St", false, null, null },
                    { "def01234-5678-9abc-def0-123456789abc", 0, 1234567812345678m, null, "Paris", "cf7f1b85-7e09-43f2-9b73-9fb5211521dd", "France", "Customer", "sophianbrown@example.com", false, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sophia", "Brown", false, null, "N", "Sophia N Brown", null, null, null, "999-888-7777", false, "User", "82816562-ef72-44b9-85aa-a362cea99cb9", "456 Maple Ave", false, null, null },
                    { "e23edc32-bd6a-4b6b-a28e-ccf60b5c32dc", 0, 9876012345678901m, null, "Sydney", "7cbeea0b-32d3-4357-ab9d-f936e225fe95", "Australia", "Customer", "sarahthompson@example.com", false, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarah", "Thompson", false, null, "L", "Sarah L Thompson", null, null, null, "777-777-8888", false, "User", "b2e2a131-cb33-4944-948c-a0be3217644a", "789 Pine St", false, null, null },
                    { "f0e7f09e-c7ad-4cb0-8f19-6540b4c7c49f", 0, 5432109876543210m, null, "Toronto", "019bb0c9-6a7d-4513-85b6-b6adafde1600", "Canada", "Customer", "davidmiller@example.com", false, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "Miller", false, null, "M", "David M Miller", null, null, null, "999-888-7777", false, "User", "8faef54c-8727-4213-9817-e39f46711b70", "123 Oak Ave", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CartId", "CustomerId" },
                values: new object[,]
                {
                    { new Guid("100dbd14-b12c-4cac-9c35-2bf2978457fd"), new Guid("c7d3e80a-7a4a-4c54-91a6-89c0df051c94") },
                    { new Guid("147ac894-adc1-4a0f-87f5-4cc4221c8a00"), new Guid("bcdef012-3456-789a-bcde-f01234567890") },
                    { new Guid("1f100372-ef3c-4170-98cc-130c19d5e034"), new Guid("e23edc32-bd6a-4b6b-a28e-ccf60b5c32dc") },
                    { new Guid("211560d9-2bd1-4dfb-a9ea-7c0a20298356"), new Guid("74f5b2b3-3d10-4a85-93b5-8c6d0c992bb8") },
                    { new Guid("2315596f-aa3b-4afc-b352-34593a4b68aa"), new Guid("0e67a2e5-df53-4a92-9854-8e1ad46a4e61") },
                    { new Guid("3aa55686-6a15-424f-bd20-f60288e2b2f9"), new Guid("724587e6-9314-4fe6-9c3e-6fd612f50234") },
                    { new Guid("41c81de1-4a13-4e94-8eff-60bcb45a7a06"), new Guid("22ac8dc9-4385-48ae-90a3-7d8c898c6d5d") },
                    { new Guid("465e0713-f748-43be-b742-d8a79015c95d"), new Guid("f0e7f09e-c7ad-4cb0-8f19-6540b4c7c49f") },
                    { new Guid("5e6cebb2-7820-4b9d-ba7f-8e6e59383630"), new Guid("74f5b2b3-3d10-4a85-93b5-8c6d0c992b58") },
                    { new Guid("98874aa6-3a4c-46a5-8331-2ddcd75dd27a"), new Guid("234cdf89-12a3-45b6-789c-0123456789de") },
                    { new Guid("9ddafd60-411a-4a3f-8bd2-7f8b6dfa6fb8"), new Guid("74f5b2b3-3d10-4a85-93b5-8c6d0c992bb7") },
                    { new Guid("a8b91928-5edd-455e-a8f1-791bfd3fef52"), new Guid("def01234-5678-9abc-def0-123456789abc") },
                    { new Guid("be7b9194-73c1-4d4b-8311-186f992c4db6"), new Guid("6789abcd-ef01-2345-6789-abcd01234567") },
                    { new Guid("ceddf5ed-2c68-4f7b-bfe2-343f747e8ac0"), new Guid("23456789-01ab-cdef-0123-456789abcdef") },
                    { new Guid("e1b0f2e8-fa91-442a-a1dd-407e774d7558"), new Guid("8901def0-1234-5678-9abc-def012345678") },
                    { new Guid("eab5d508-d784-4c18-9924-0a01f612b769"), new Guid("2345cdef-0123-4567-89ab-cdef01234567") },
                    { new Guid("fac7ec72-bdff-4a99-af92-05226aebaaa4"), new Guid("b6a76b15-33e5-4d26-98b9-c948c7823b84") }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Image", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f"), "Kids's Clothing", "Kids.jpg", "Kids", null },
                    { new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d"), "Women's Clothing", "Women.jpg", "Women", null },
                    { new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583"), "Men's Clothing", "men.jpg", "Men", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Discount", "Name", "Price", "Rate" },
                values: new object[,]
                {
                    { new Guid("0499bf6a-30c3-4d74-9c6d-c5480400adcb"), "Elegant dress for women", 0.1m, "Women's Dress", 49.99m, 0m },
                    { new Guid("0629761c-f56e-462f-9c74-cfb4251f8b7b"), "Cozy hoodie for kids", 0m, "Kids' Hoodie", 29.99m, 0m },
                    { new Guid("08aa994c-6a3a-4c9c-aaaf-c82b62e5c5ff"), "Comfortable shorts for men", 0m, "Men's Shorts", 24.99m, 0m },
                    { new Guid("08e748cd-46c3-4c88-823b-c0d358225fda"), "Cozy sweater for women", 0m, "Women's Sweater", 39.99m, 0m },
                    { new Guid("0bc2723a-0cab-4536-a8ee-1fe94e497b72"), "Sporty sneakers for men", 0.1m, "Men's Sneakers", 54.99m, 0m },
                    { new Guid("0e79bf11-f62e-4e58-9919-a6367244eafe"), "Comfortable hoodie for men", 0m, "Men's Hoodie", 29.99m, 0m },
                    { new Guid("121ab62a-5940-4d34-97c7-3da72e869ccd"), "Stylish trousers for kids", 0.05m, "Kids' Trousers", 34.99m, 0m },
                    { new Guid("147531a1-3228-4264-b61e-4c54d4f5ad69"), "Elegant dress for women", 0.1m, "Women's Dress", 49.99m, 0m },
                    { new Guid("157deed6-ced6-46ea-879a-e15d0bbc07bf"), "Classic polo shirt for men", 0m, "Men's Polo Shirt", 22.99m, 0m },
                    { new Guid("158bf75d-8e27-43c1-9135-7713adb12ba8"), "Formal shirt for men", 0.15m, "Men's Shirt", 34.99m, 0m },
                    { new Guid("18794c59-9e41-46fd-8df4-5b83a4e92888"), "Cozy hoodie for kids", 0m, "Kids' Hoodie", 29.99m, 0m },
                    { new Guid("18fe0d6a-e96a-4120-b180-a5a235c47848"), "Elegant blazer for women", 0.2m, "Women's Blazer", 59.99m, 0m },
                    { new Guid("1a1f3c3d-923b-48c0-9b9a-80cf0493585b"), "Stylish sneakers for men", 0.15m, "Men's Sneakers", 59.99m, 0m },
                    { new Guid("1d0ddc3b-1267-4ea3-8a02-6df96fa9e142"), "Stylish jacket for women", 0m, "Women's Jacket", 54.99m, 0m },
                    { new Guid("1d15f440-2786-47d3-a0c0-e7e5e3cfc7a7"), "Warm jacket for kids", 0.1m, "Kids' Jacket", 39.99m, 0m },
                    { new Guid("2109a4c6-aec6-40ae-abd6-0076fbe8a11b"), "Casual t-shirt for women", 0.2m, "Women's T-Shirt", 19.99m, 0m },
                    { new Guid("25219121-5bd9-4f35-8ea2-2cd8e1b7a485"), "Warm jacket for men", 0.2m, "Men's Jacket", 59.99m, 0m },
                    { new Guid("256a73f6-aa9f-413d-a3a6-39cfdde086df"), "Warm hoodie for men", 0.05m, "Men's Hoodie", 39.99m, 0m },
                    { new Guid("257080cd-8cf9-48ac-9bf5-fcaff7256993"), "Comfortable hoodie for men", 0m, "Men's Hoodie", 29.99m, 0m },
                    { new Guid("2575a1a0-4791-49be-9d3b-d14316ebfae8"), "Elegant dress for women", 0.1m, "Women's Dress", 49.99m, 0m },
                    { new Guid("25bfd950-ea7b-4b2a-be40-a73c756d14f0"), "Stylish pants for women", 0.05m, "Women's Pants", 44.99m, 0m },
                    { new Guid("26d7f035-0769-41dd-aa02-5fd2e2171907"), "Comfortable cotton t-shirt for men", 0m, "Men's T-Shirt", 15.99m, 0m },
                    { new Guid("273e896f-5caf-462b-9e7f-2c25157a3bf4"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("2eb4ae6c-1885-4e4b-aed1-7af817ad628e"), "Elegant dress for women", 0.1m, "Women's Dress", 49.99m, 0m },
                    { new Guid("328f1609-4db1-4962-b8d6-32a1d47f73de"), "Cozy hoodie for kids", 0m, "Kids' Hoodie", 29.99m, 0m },
                    { new Guid("333e504c-0b52-4d02-8174-8986ded54bbc"), "Warm hoodie for men", 0.05m, "Men's Hoodie", 39.99m, 0m },
                    { new Guid("36ef4e33-0da9-4817-8861-42a7d246250b"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("37036ea1-47d2-4f69-82b2-444f2db7e0e3"), "Classic pants for men", 0.1m, "Men's Pants", 49.99m, 0m },
                    { new Guid("398a6d0c-b221-4372-9967-4819f7ba299c"), "Adorable shirt for kids", 0.15m, "Kids' Shirt", 17.99m, 0m },
                    { new Guid("3a02b618-0d21-452d-ae66-0c1920883912"), "Warm jacket for men", 0.2m, "Men's Jacket", 59.99m, 0m },
                    { new Guid("3eab08e1-d781-4dac-b509-e831dfac9db3"), "Elegant dress for women", 0.1m, "Women's Dress", 49.99m, 0m },
                    { new Guid("4862ff1b-38fe-42a3-b2c3-d9e6a8f0db6a"), "Stylish jacket for kids", 0m, "Kids' Jacket", 39.99m, 0m },
                    { new Guid("4ad85a37-b5fc-4ab1-b613-70a473125d52"), "Classic pants for men", 0.1m, "Men's Pants", 49.99m, 0m },
                    { new Guid("4df96f8b-0a80-433c-a5d6-f495914b79bf"), "Stylish pants for women", 0.05m, "Women's Pants", 44.99m, 0m },
                    { new Guid("4e769d77-8738-4ecd-9373-81e73627abd2"), "Fashionable skirt for women", 0m, "Women's Skirt", 27.99m, 0m },
                    { new Guid("50019367-4043-49d8-a155-ecaa13bf5e97"), "Formal shirt for men", 0.15m, "Men's Shirt", 34.99m, 0m },
                    { new Guid("50192eed-1aa1-4b29-82d7-3515fdc6aff3"), "Casual trousers for kids", 0.1m, "Kids' Trousers", 21.99m, 0m },
                    { new Guid("50d74f21-a83c-4105-bb32-cce361166504"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("536d7a11-8cfb-4890-bd3d-e5cd93eb0f8a"), "Fashionable skirt for women", 0m, "Women's Skirt", 27.99m, 0m },
                    { new Guid("53a4d620-0335-4be7-87b8-4f0e47ce713d"), "Comfortable hoodie for men", 0m, "Men's Hoodie", 29.99m, 0m },
                    { new Guid("56b03b73-fedc-427b-85d2-fc8dfded99bc"), "Classic pants for men", 0.1m, "Men's Pants", 49.99m, 0m },
                    { new Guid("5a27f5dc-8096-4898-aff3-8f704df1b80d"), "Stylish denim jeans for women", 0.05m, "Women's Jeans", 44.99m, 0m },
                    { new Guid("6640972c-43dc-432e-bc74-92e3579f0ab8"), "Adorable t-shirt for kids", 0m, "Kids' T-Shirt", 12.99m, 0m },
                    { new Guid("6981cb97-d9f5-451d-a15c-f85e0e9fdfa0"), "Spacious backpack for kids", 0m, "Kids' Backpack", 19.99m, 0m },
                    { new Guid("69ec1a9f-9fed-45f3-baf2-fd0937c4a80b"), "Warm jacket for men", 0.2m, "Men's Jacket", 59.99m, 0m },
                    { new Guid("69fc24e1-97c4-461a-98ab-3cddf2caef47"), "Warm hoodie for men", 0.05m, "Men's Hoodie", 39.99m, 0m },
                    { new Guid("6d8f8c57-d4c5-4516-997f-e89bafa53b37"), "Stylish pants for women", 0.05m, "Women's Pants", 44.99m, 0m },
                    { new Guid("6da4efb8-20d5-4a96-918f-39e14c968254"), "Warm sweater for kids", 0m, "Kids' Sweater", 34.99m, 0m },
                    { new Guid("709d833b-2c34-4f18-9511-a571edd734c6"), "Sporty sneakers for women", 0m, "Women's Sneakers", 49.99m, 0m },
                    { new Guid("72eae71d-213a-4310-a855-7716273daa06"), "Fashionable sandals for women", 0.1m, "Women's Sandals", 29.99m, 0m },
                    { new Guid("733c0337-85da-4e2c-b636-2bbc7a68942e"), "Casual shorts for men", 0.1m, "Men's Shorts", 17.99m, 0m },
                    { new Guid("7642bee8-94f1-4f88-b8cf-eb00ae711575"), "Stylish trousers for kids", 0.05m, "Kids' Trousers4", 34.99m, 0m },
                    { new Guid("79bc6c6a-40fe-485c-8e56-414cbfe4985b"), "Cozy hoodie for kids", 0m, "Kids' Hoodie", 29.99m, 0m },
                    { new Guid("7bda3943-83fb-4f5f-8c18-d00e77f89676"), "Comfortable hoodie for men", 0m, "Men's Hoodie", 29.99m, 0m },
                    { new Guid("7d0728c2-c3b6-423f-80d8-81a6f514e13e"), "Comfortable cotton t-shirt for men", 0m, "Men's T-Shirt", 15.99m, 0m },
                    { new Guid("7d77b647-a189-400b-9cda-a517d5959aff"), "Comfortable cotton t-shirt for men", 0m, "Men's T-Shirt", 15.99m, 0m },
                    { new Guid("80e39c41-5e30-47ec-8ee8-866572e95aaf"), "Comfortable cotton t-shirt for men", 0m, "Men's T-Shirt", 15.99m, 0m },
                    { new Guid("86d77404-4901-434e-b670-8b21ea372668"), "Comfortable cotton t-shirt for men", 0m, "Men's T-Shirt", 15.99m, 0m },
                    { new Guid("89a06fa9-a046-49bf-bdcc-cb1a66bf6455"), "Fashionable skirt for women", 0m, "Women's Skirt", 27.99m, 0m },
                    { new Guid("9011c450-38e3-4757-9f05-33a35d230040"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("94e3840f-0330-4acb-8fdd-928910f5ea8e"), "Formal shirt for men", 0.15m, "Men's Shirt", 34.99m, 0m },
                    { new Guid("9508dcc4-4966-42a2-a930-b0e8cd7ce089"), "Stylish jacket for kids", 0m, "Kids' Jacket", 39.99m, 0m },
                    { new Guid("a0b552d6-9f85-40d4-9c64-9621f28e4079"), "Stylish pants for women", 0.05m, "Women's Pants", 44.99m, 0m },
                    { new Guid("a26fb055-1dea-4eee-997c-75f091f4a328"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("ab767be9-2d06-44fe-9532-99087c353b3a"), "Comfortable sandals for women", 0.2m, "Women's Sandals", 34.99m, 0m },
                    { new Guid("af0514b8-b690-48be-89a7-1e174964420c"), "Sporty sneakers for men", 0.1m, "Men's Sneakers", 54.99m, 0m },
                    { new Guid("b757424f-02ff-4da5-b044-88b872d5919a"), "Stylish blouse for women", 0m, "Women's Blouse", 24.99m, 0m },
                    { new Guid("ba89acdd-5922-4a61-be94-5c8b87b6eef2"), "Fashionable skirt for women", 0m, "Women's Skirt", 27.99m, 0m },
                    { new Guid("c279cd78-923f-476a-b4ed-5f8b02e29038"), "Stylish trousers for kids", 0.05m, "Kids' Trousers2", 34.99m, 0m },
                    { new Guid("c4308eac-26e9-4528-989e-1b191d6bbed2"), "Warm jacket for men", 0.2m, "Men's Jacket", 59.99m, 0m },
                    { new Guid("c63e6247-1a2d-4794-ba28-83d48e2080e0"), "Warm hoodie for men", 0.05m, "Men's Hoodie", 39.99m, 0m },
                    { new Guid("c69fa6f2-dd53-4282-88b5-1f104409e53b"), "Elegant dress for women", 0.1m, "Women's Dress", 49.99m, 0m },
                    { new Guid("ca3cb2ab-7f6b-4095-978c-3b8b5dbf4911"), "Cute dress for kids", 0m, "Kids' Dress", 32.99m, 0m },
                    { new Guid("cb520136-0dd0-4123-b548-0cc28a0170f9"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("db9c2922-4193-4879-b3af-9b3df51c83da"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("dd238258-3c01-4fb3-9990-4e5e49a75fdb"), "Stylish trousers for kids", 0.05m, "Kids' Trousers3", 34.99m, 0m },
                    { new Guid("e11480dd-4069-4f65-addd-f8f5b181d33a"), "Stylish jacket for kids", 0m, "Kids' Jacket", 39.99m, 0m },
                    { new Guid("e55b5007-0353-4d62-94b5-46aad47ec69b"), "Warm sweater for kids", 0m, "Kids' Sweater", 34.99m, 0m },
                    { new Guid("e809c2b2-bd14-406c-871e-19070cc26780"), "Formal shirt for men", 0.15m, "Men's Shirt", 34.99m, 0m },
                    { new Guid("e94e473a-4373-4a5c-8f03-6db494480603"), "Classic denim jeans for men", 0.05m, "Men's Jeans", 39.99m, 0m },
                    { new Guid("edb45cda-dd29-4caf-badf-fe9c0dabf26a"), "Classic pants for men", 0.1m, "Men's Pants", 49.99m, 0m },
                    { new Guid("f872333d-7411-4766-bda1-959054116508"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("f8ae15e9-11f1-43f6-ba5c-4931873b541e"), "Colorful shoes for kids", 0.15m, "Kids' Shoes", 29.99m, 0m },
                    { new Guid("fb202ddc-9edc-4377-ae3c-e98baf06f0cc"), "Warm sweater for men", 0.1m, "Men's Sweater", 39.99m, 0m },
                    { new Guid("fb2328ed-ee14-4d0d-92f6-ed685666f31e"), "Casual shorts for kids", 0m, "Kids' Shorts", 15.99m, 0m },
                    { new Guid("ff521906-e932-4b9e-85a4-5ca600a95722"), "Spacious backpack for kids", 0m, "Kids' Backpack", 19.99m, 0m },
                    { new Guid("fff4088c-b21e-4522-b9f9-5be4e406af2e"), "Warm hoodie for men", 0.05m, "Men's Hoodie", 39.99m, 0m }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Image", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("1d53debe-03e6-487f-9b34-6b26c68fc1e5"), "Kids Pants's Clothing", "Kids Pants.jpg", "Pants", new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f") },
                    { new Guid("35b303b9-25a0-4379-89b3-64e4ae51291f"), "Women Shoes's Clothing", "Women Shoes.jpg", "Shoes", new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d") },
                    { new Guid("47a38a48-8747-4461-ba32-7e573be663ee"), "Women Jackets's Clothing", "Women Jackets.jpg", "Jackets", new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d") },
                    { new Guid("6b3c4ef5-01ad-49c7-a8ff-36ae55d0ce8d"), "Men Shoes's Clothing", "men Shoes.jpg", "Shoes", new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583") },
                    { new Guid("6f6c6c4c-9e6e-4e0c-97cc-8b52c055918b"), "Men Jackets's Clothing", "men Jackets.jpg", "Jackets", new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583") },
                    { new Guid("8a6d4a19-47cc-4a4e-822b-cac1de2efc8d"), "Kids shirts's Clothing", "Kids shirts.jpg", "Shirts", new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f") },
                    { new Guid("9a938bc1-0717-4b8d-8f8b-3a2f55de49db"), "Men Pants's Clothing", "men Pants.jpg", "Pants", new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583") },
                    { new Guid("a6c4de53-33c5-48e1-9f21-5649726d3a3d"), "Women shirts's Clothing", "Women shirts.jpg", "Shirts", new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d") },
                    { new Guid("a6d7e8b5-2f4d-4f51-b24b-4fcb52e36f5f"), "Men Hoodies's Clothing", "men Hoodies.jpg", "Hoodies", new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583") },
                    { new Guid("b19a53a3-04e7-4804-84bc-84da64d738a6"), "Kids Jackets's Clothing", "Kids Jackets.jpg", "Jackets", new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f") },
                    { new Guid("c2ae51c9-913a-4e7d-a7b5-ef1efc8f9d3e"), "Kids Hoodies's Clothing", "Kids Hoodies.jpg", "Hoodies", new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f") },
                    { new Guid("ca09f6a1-5b87-4b56-9ee3-c6fb6ad070c2"), "Kids Shoes's Clothing", "Kids Shoes.jpg", "Shoes", new Guid("52d40b0a-7039-4bc6-899d-0c36adff6b8f") },
                    { new Guid("d9f02e92-d14c-4b6d-86ad-6e4e6c48020a"), "Women Pants's Clothing", "Women Pants.jpg", "Pants", new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d") },
                    { new Guid("e18e42b7-799e-4b3b-a084-c55d4bb5da3f"), "Women Hoodies's Clothing", "Women Hoodies.jpg", "Hoodies", new Guid("a6c4de53-33c5-48e1-9f21-5649726d2a3d") },
                    { new Guid("f032f788-2340-431f-9f8f-eeb176a35177"), "Mens shirts's Clothing", "men shirts.jpg", "Shirts", new Guid("edc6b9e0-9252-4e9d-b4d3-9203b6de2583") }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ArrivalDate", "City", "Country", "CustomerId", "Discount", "OrderData", "OrderStatus", "PaymentMethod", "PaymentStatus", "Street", "TotalPrice" },
                values: new object[,]
                {
                    { new Guid("07d96ed8-155d-49c7-a77a-615f109d75c3"), new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Zimbabwe", "b6a76b15-33e5-4d26-98b9-c948c7823b84", 1.0, new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CashOnDelivery", "Paid", "789 Oak St", 0m },
                    { new Guid("07d96ed8-155d-49c7-a77a-615f109d77c3"), new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Zimbabwe", "e23edc32-bd6a-4b6b-a28e-ccf60b5c32dc", 1.0, new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CashOnDelivery", "Paid", "789 Oak St", 0m },
                    { new Guid("0e67a2e5-df53-4a92-9854-8e1ad46a4e61"), new DateTime(2027, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "New York", "Belgium", "0e67a2e5-df53-4a92-9854-8e1ad46a4e61", 0.0, new DateTime(2027, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CreditCard", "Unpaid", "123 Elm St", 0m },
                    { new Guid("22ac8dc9-4385-48ae-90a3-7d8c898c6d5d"), new DateTime(2027, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Los Angeles", "Belize", "74f5b2b3-3d10-4a85-93b5-8c6d0c992b58", 0.5, new DateTime(2027, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shipped", "CashOnDelivery", "Paid", "456 Main St", 0m },
                    { new Guid("23456789-01ab-cdef-0123-456789abcdef"), new DateTime(2027, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Francisco", "Oman", "234cdf89-12a3-45b6-789c-0123456789de", 0.10000000000000001, new DateTime(2027, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CreditCard", "Paid", "321 Maple Ave", 0m },
                    { new Guid("2345cdef-0123-4567-89ab-cdef11234567"), new DateTime(2027, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seattle", "Taiwan", "6789abcd-ef01-2345-6789-abcd01234567", 0.20000000000000001, new DateTime(2027, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CreditCard", "Paid", "567 Pine St", 0m },
                    { new Guid("6789abcd-ef01-2345-6789-abcd01234567"), new DateTime(2029, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seattle", "Libya", "c7d3e80a-7a4a-4c54-91a6-89c0df051c94", 0.20000000000000001, new DateTime(2029, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CreditCard", "Paid", "789 Elm St", 0m },
                    { new Guid("724587e6-9314-4fe6-9c3e-7fd612f50232"), new DateTime(2029, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Francisco", "Senegal", "def01234-5678-9abc-def0-123456789abc", 0.29999999999999999, new DateTime(2029, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CreditCard", "Paid", "123 Maple Ave", 0m },
                    { new Guid("724587e6-9314-4fe6-9c3e-7fd612f50233"), new DateTime(2029, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seattle", "Samoa", "c7d3e80a-7a4a-4c54-91a6-89c0df051c94", 0.20000000000000001, new DateTime(2029, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CashOnDelivery", "Paid", "789 Pine St", 0m },
                    { new Guid("724587e6-9314-4fe6-9c3e-7fd612f50234"), new DateTime(2029, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dallas", "Samoa", "b6a76b15-33e5-4d26-98b9-c948c7823b84", 0.10000000000000001, new DateTime(2029, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CashOnDelivery", "Paid", "987 Cedar St", 0m },
                    { new Guid("74f5b2b3-3d10-4a85-93b5-8c6d0c992b58"), new DateTime(2029, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Diego", "Samoa", "bcdef012-3456-789a-bcde-f01234567890", 0.0, new DateTime(2029, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CashOnDelivery", "Unpaid", "456 Oak St", 0m },
                    { new Guid("8901def0-1234-5678-9abc-def012345678"), new DateTime(2029, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Francisco", "Afghanistan", "74f5b2b3-3d10-4a85-93b5-8c6d0c992bb7", 0.0, new DateTime(2029, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CashOnDelivery", "Unpaid", "123 Pine St", 0m },
                    { new Guid("b6a76b15-33e5-4d26-98b9-c948c7823b84"), new DateTime(2029, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Los Angeles", "Andorra", "74f5b2b3-3d10-4a85-93b5-8c6d0c992bb8", 0.10000000000000001, new DateTime(2029, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CashOnDelivery", "Paid", "456 Maple Ave", 0m },
                    { new Guid("c7d3e80a-7a4a-4c54-91a6-89c0df051c94"), new DateTime(2029, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Iraq", "07d96ed8-155d-49c7-a77a-615f109d77c3", 0.10000000000000001, new DateTime(2029, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CashOnDelivery", "Paid", "567 Oak St", 0m },
                    { new Guid("def01234-5678-9abc-def0-113456789abc"), new DateTime(2028, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miami", "Fiji", "bcdef012-3456-789a-bcde-f01234567890", 0.29999999999999999, new DateTime(2028, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CreditCard", "Paid", "901 Cherry Ln", 0m },
                    { new Guid("e23edc32-bd6a-4b6b-a28e-ccf90b5c32dc"), new DateTime(2028, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boston", "Denmark", "2345cdef-0123-4567-89ab-cdef01234567", 0.14999999999999999, new DateTime(2028, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "CashOnDelivery", "Paid", "246 Elm St", 0m },
                    { new Guid("f0e7f09e-c7ad-4cb0-8f19-6540b4c7c49f"), new DateTime(2029, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Canada", "724587e6-9314-4fe6-9c3e-6fd612f50234", 0.20000000000000001, new DateTime(2028, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CreditCard", "Unpaid", "789 Elm St", 0m },
                    { new Guid("f0e7f09e-c7ad-4cb0-8f19-6540b5c7c49f"), new DateTime(2029, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", "Canada", "8901def0-1234-5678-9abc-def012345678", 0.20000000000000001, new DateTime(2029, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "CreditCard", "Unpaid", "789 Elm St", 0m }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ImageURL", "ProductID" },
                values: new object[,]
                {
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("0499bf6a-30c3-4d74-9c6d-c5480400adcb") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("147531a1-3228-4264-b61e-4c54d4f5ad69") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("26d7f035-0769-41dd-aa02-5fd2e2171907") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("273e896f-5caf-462b-9e7f-2c25157a3bf4") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("2eb4ae6c-1885-4e4b-aed1-7af817ad628e") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("3eab08e1-d781-4dac-b509-e831dfac9db3") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("50d74f21-a83c-4105-bb32-cce361166504") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("7d0728c2-c3b6-423f-80d8-81a6f514e13e") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("7d77b647-a189-400b-9cda-a517d5959aff") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("86d77404-4901-434e-b670-8b21ea372668") },
                    { "https://townteam.com/cdn/shop/files/SSH23SAER19684TM1-Multicolor-3_600x.jpg?v=1684071642", new Guid("c69fa6f2-dd53-4282-88b5-1f104409e53b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CartID",
                table: "AspNetUsers",
                column: "CartID",
                unique: true,
                filter: "[CartID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WishListID",
                table: "AspNetUsers",
                column: "WishListID",
                unique: true,
                filter: "[WishListID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_CartId",
                table: "CartProduct",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersReviews_CustomerId",
                table: "CustomersReviews",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWishList_WishListsId",
                table: "ProductWishList",
                column: "WishListsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "CustomersReviews");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductsInfo");

            migrationBuilder.DropTable(
                name: "ProductWishList");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "WishLists");
        }
    }
}
