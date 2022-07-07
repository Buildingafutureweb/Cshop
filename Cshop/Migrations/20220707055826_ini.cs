using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cshop.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ShopId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Body = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    ShopId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShopName = table.Column<string>(type: "TEXT", nullable: true),
                    ShopDesciption = table.Column<string>(type: "TEXT", nullable: true),
                    ShopPicture = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.ShopId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    Sn = table.Column<string>(type: "TEXT", nullable: true),
                    Detail = table.Column<string>(type: "TEXT", nullable: true),
                    Picture = table.Column<string>(type: "TEXT", nullable: true),
                    ShopId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLists",
                columns: table => new
                {
                    OrderListId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    ShopId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalSum = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLists", x => x.OrderListId);
                    table.ForeignKey(
                        name: "FK_OrderLists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    Detail = table.Column<string>(type: "TEXT", nullable: true),
                    Picture = table.Column<string>(type: "TEXT", nullable: true),
                    ShopId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalSum = table.Column<decimal>(type: "TEXT", nullable: true),
                    OrderListId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_OrderLists_OrderListId",
                        column: x => x.OrderListId,
                        principalTable: "OrderLists",
                        principalColumn: "OrderListId");
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ShopId" },
                values: new object[] { 1, "cate1", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ShopId" },
                values: new object[] { 2, "cate2", 2 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ShopId" },
                values: new object[] { 3, "cate1", 3 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ShopId" },
                values: new object[] { 4, "cate1", 4 });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopId", "ShopDesciption", "ShopName", "ShopPicture" },
                values: new object[] { 1, "Welcome to Our Chinese Shop!", "OrientalDragon", "/pic/shops/shop1.jpg" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopId", "ShopDesciption", "ShopName", "ShopPicture" },
                values: new object[] { 2, "Indonesian Shop is quite good!", "Indomie", "/pic/shops/shop2.png" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopId", "ShopDesciption", "ShopName", "ShopPicture" },
                values: new object[] { 3, "Please do more shoping in this Indian Shop!", "TataGroup", "/pic/shops/shop3.jpg" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopId", "ShopDesciption", "ShopName", "ShopPicture" },
                values: new object[] { 4, "You can't find a better shop than our Sri Lanka Shop!", "Parippu", "/pic/shops/shop4.png" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 1, 1, "With 14 wash cycles including Wool and Refresh, which uses steam technology. 4.5-star water rating and 4.5-star energy rating. Specialised UV Protect wash modifier to kill more than 99.99% of bacteria.Eco wash option reduces energy use by up to 44%, and water use by more than 25L per load on a Cotton cycle", null, "/pic/cases/OrientalDragon01.png", 300m, "Haier Washing Machine", 11, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 2, 1, "No need to BAT-tery an eyelash about the long lasting power of these Alkaline D energy pills!Duracell multi-purpose alkaline batteries are ideal for reliably powering everyday devices that require a kick of additional power. Duracell alkaline batteries are available in size AA, AAA, C, D and 9V. Duralock technology keeps unused Duracell batteries fresh and powered up to 10 years in ambient storage. These batteries give you the freedom to enjoy the use of your appliances by giving you a product you can rely on. Long lasting power guaranteed. Best used when you are looking for reliable, long-lasting power in your every day devices such as motorised toys, flashlights, portable games consoles, remote controls, etc. D size batteries. Also known as MN-1300, MN1300. Pack of 2.", null, "/pic/cases/OrientalDragon02.png", 12m, "Zhongguo Alkaline Battery", 11, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 3, 1, "Pickup trucks are hugely popular, and many models offer more off-road and towing capabilities than most people need. The good news is that the resurgence of smaller trucks makes the body style even more accessible pricewise while maintaining a notable amount of versatility and capability. From entry-level work trucks and heavy-duty haulers to hybrid-powered and high-performance models, these pickups are the very best of the breed.", null, "/pic/cases/OrientalDragon03.png", 4500m, "Changchen Pickup Truck", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 4, 1, "Join one of the world's most popular free poker games with more tables, more tournaments, more jackpots, and more players to challenge than ever before! Whether you prefer casual Texas Holdem Poker or competitive poker tournaments, Zynga Poker is your home for authentic gameplay.", null, "/pic/cases/OrientalDragon04.png", 15m, "Heilongjiang Poker", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 5, 1, "Waterproof, floating, tough. Ideal for home, work, car or toolbox. Carabiner clip inclueded. 50 lumens. 50m beam distance. 7hr runtime. Runs off 1xAA battery (included)", null, "/pic/cases/OrientalDragon05.png", 25m, "Hubei Torch", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 6, 1, "Presenting you the fine quality of genuine leather sofas from one of the renowned furniture companies in the world. The CASTLEFORD is a lovely, soft, and comfy, L-shaped, corner sofa. It is upholstered in white genuine leather, has a flexible layout, and is available with a chaise on the left or right side. The relaxing headrests can be removed and changed to different positions. The CASTLEFORD set includes a corner seat and a console -with s/steel cupholders and a generous storage box for remotes or treats. The 5 separate pieces can be joined together to suit your needs, see the photos here for suggestions.", null, "/pic/cases/OrientalDragon06.png", 2500m, "Shanghai Furniture", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 7, 1, "Cosy and comfortable to hold, these beautiful cups are perfect for all kinds of hot drinks. The stoneware construction keeps the contents warmer for longer, so you can keep sipping. These mugs are great for making your guests feel special, or for bringing elegance to your own everyday ritual.", null, "/pic/cases/OrientalDragon07.png", 35m, "Beijing China Cup", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 8, 1, "An elegant folding custom fan Crafted with eco-friendly, sustainable bamboo frame. Made of heavy paper with smooth bamboo ribbing. Oriental Folding Fans are the classiest paper fans on our website! Have your message printed on these fun giveaways and hand them.", null, "/pic/cases/OrientalDragon08.png", 65m, "Jiangsu Bamboo Fan", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 9, 1, "Chinese herbal products have been studied for many medical problems, including stroke, heart disease, mental disorders, and respiratory diseases (such as bronchitis and the common cold), and a national survey showed that about one in five Americans use them. Because many studies have been of poor quality, no firm conclusions can be made about their effectiveness. For more information about specific herbs, see NCCIH’s Herbs at a Glance webpage. You can find additional information on botanical (plant) dietary supplements on the Office of Dietary Supplements website.", null, "/pic/cases/OrientalDragon09.png", 550m, "Guanzhou Chinese Herbs", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 10, 1, "This Hongkong Magnifying Glass from Amalfi is the perfect accessory to enlarge writing for easier reading. With a tortoiseshell handle and resin detailing, it’s both stylish and practical. Now you can read writing that may have been too small before. While you’re there, discover everyday items around your home in a new light. Try this Hongkong Marilla Magnifying Glass and enlarge writing for easier reading.", null, "/pic/cases/OrientalDragon10.png", 25m, "Hongkong Magnifying Glass", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 11, 1, "Hazel is a soft furry pink elephant with gray ears. She loves wearing a blue bow next to her ear. She and Humphrey, a super cute gray elephant, are first cousins.  Hazel sits 10cm tall and is made of polyester. Imported.", null, "/pic/cases/OrientalDragon11.png", 35m, "Taiwan Pink Elephant Plush", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 12, 1, "VALYV smartwatch for men is built in latest accurate dynamic detection sensor SC7A20, which supports automatic and more accurate 24h heart rate/ blood oxygen monitor. You can get the real time health data to get a better know about your health. Tracking you sleep status and give you corresponding analysis, VALYV fitness tracker watch will help you live more healthier.", null, "/pic/cases/OrientalDragon12.png", 95m, "Zhejiang Military Smart Watch", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 13, 1, "Engineered with FIGS’ signature FIONTechnology fabric, Pisco scrub pants for men offer a four-way stretch, moisture-wicking properties and hidden elastic waistband with drawcord for optimal hold and comfort. FIGS’ innovative fabric is also anti-wrinkle, lightweight and ridiculously soft.The Pisco basic scrub pant is modern, clean and tailored to fit so you will look polished and professional without sacrificing comfort and function.", null, "/pic/cases/OrientalDragon13.png", 155m, "Nanjing Basic Scrub Pants for Men", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 14, 1, "Five-layer filtration system of the safety mask effectively prevent droplets, pollen, dust, and other harmful particles.3D-FIT DESIGN: Our 3D design with the metal nose clip provides a tight seal to ensure air flows through layers which give you superior protection and prevent glasses fogging. At the same time, all respirator mask with better seal can be uncomfortable over time.The KN95 face masks stays in place and have plenty of room around your mouth.MULTI-PURPOSE APPLICATIONS: Ideal for indoor & outdoor setting like school, office, air travel, healthcare, construction work and more.DISCLAIMER: This KN95 mask is NOT an N95 mask.For more information about KN95 masks please see the following before you purchase: amazon.com / AboutKN95s", null, "/pic/cases/OrientalDragon14.png", 12m, "Wuhan Face Mask", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 15, 1, "Multi-bit screwdriver / nut driver shaft holds 8 popular tips and converts to 3 nut driver sizes.Includes industrial strength heat treated bits: 3/8-Inch, 5/16-Inch and 1/4-Inch nut drivers, #1 and #2 Phillips, 1/4-Inch and 3/16-Inch slotted, T10 and T15 TORX, and #1 and #2 square recess. Interchangeable blade for fast and easy switch out; comfortable Cushion-Grip handle.Blast finish bit tips provide a firm hold and reduce cam-out", null, "/pic/cases/OrientalDragon15.png", 15m, "Shanghai Screwdriver", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 16, 1, "13 different tools including a hammer, hex wrench, wire cutters, nail claw, bottle opener, nail file, Phillips screwdriver, Flat screwdriver, blade, screwdriver storage, saw blade. There are 2 safety locks, DR.LILIANG multitool hammer is so handy & has lock feature for the pliers and handle; Non-slip handle, This multitool for camping is easier to hold if palms are sweating; Safe to open gadget, protect from hand if open small tools: blade bottle opener saw, etc.", null, "/pic/cases/OrientalDragon16.png", 35m, "Beijing Multitool Camping Accessories", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 17, 1, "【Energy Saving Design】: Low consumption power low noise. Suitable for storage of frozen food and fresh food.【Adjustable Temperature Ranges】: Refrigerator Compartment 32' to 50' F/ Freezer Compartment 3' to -1'F. Fresh section: 2.3 Cu Ft, freezer section: 1.2 Cu Ft.【Double Door Design】:Small fridge with interior Light, the top door for freezer and bottom door, door handles need to be installed manually", null, "/pic/cases/OrientalDragon17.png", 550m, "Wuhan Compact Refrigerator", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 18, 1, "The product is refurbished, is fully functional and in excellent condition. Backed by the 90-day Amazon Renewed Guarantee.This pre-owned product has been professionally inspected, tested and cleaned by Amazon qualified vendors.This product is in Excellent condition. It shows no signs of cosmetic damage visible from a distance of 12 inches.This product will have a battery that exceeds 80% capacity relative to new.Accessories may not be original, but will be compatible and fully functional. Product may come in generic box.This product is eligible for a replacement or refund within 90 days of receipt if it does not work as expected.", null, "/pic/cases/OrientalDragon18.png", 900m, "Guangzhou 720p Smart TV", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 19, 1, "Bring gaming worlds to life - Feel your in-game actions and environment simulated through haptic feedback*. Experience varying force and tension at your fingertips with adaptive triggers.Find your voice, share your passion - Chat online through the built-in microphone. Connect a headset directly via the 3.5mm jack. Record and broadcast your epic gaming moments with the create button.A gaming icon in your hands - Enjoy a comfortable, evolved design with an iconic layout and enhanced sticks. Hear higher-fidelity** sound effects through the built-in speaker in supported games", null, "/pic/cases/OrientalDragon19.png", 80m, "Hongkong DualSense Wireless Controller", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 20, 1, "GREAT WEAR-RESISTANCE AND DURABILITY - Our adjustable gaming chair is made of delicate leather surface fabric, which has excellent wear-resistance and breathability. The seat is filled with high-density sponge to better increase comfort that allow you sit comfortably for a long time. Very durable to use.ERGONOMIC HEADREST AND LUMBAR SUPPORT – Our gaming chair for adults is equipped with an ergonomic headrest and lumbar support, which can provide very strong support for your head, neck and waist.It can fit your neck and back, which can relieve your fatigue and pain after sitting for a long time.FREELY ADJUST ANGLE FOR RECLINING - This office chair supports an adjustable angle of 130 degrees, so you can play games vigorously and relax completely.This feature allows you can lie down and rest after the game, helping you to regain energy, it is very easy to adjust and use.", null, "/pic/cases/OrientalDragon20.png", 450m, "Yunnan Ergonomic Leather Gaming Chair", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 21, 1, "Locks in juices and flavors: Sear at 450 degrees or use adjustable temperature dial to grill at lower heat for optimal grilling results.Enjoy grilling all year long: This indoor grill with hood has a high searing heat that locks in juices and flavors, and lid closes to give you signature grill marks; Serves up to 6 with 118 square inch grilling surface.Easy to clean: Indoor grill hood, plate, and extra-large drip tray are all removable and dishwasher safe.Less mess: Extra - large drip tray catches juices so they don't spill on your counter and it's dishwasher safe for easy cleaning.Power and preheat lights: Eliminate guesswork while using your electric grill.Cooks more than steaks, BBQ and burgers: Grill chicken, fish, pizza, vegetables, fruit and more. Also great for Paleo and Keto diets.Powerful 1200 watts and 1 year limited warranty.Dimensions: 12.4 inches L x 16.7 inches W x 6.8 inches H", null, "/pic/cases/OrientalDragon21.png", 150m, "Taiwan Beach Electric Indoor Searing Grill", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 22, 1, "Special edition: Complement your kitchen with the premium nickel colored finish, metal handle and drip tray.4 cup sizes: 6, 8, 10, and 12 ounce.Simple button controls: Just insert any k cup pod and use the button controls to brew delicious coffee, or make hot or iced lattes and cappuccinos.120v.Large 60 ounce water reservoir: Allows you to brew 6 cups before having to refill, saving you time and simplifying your morning routine; Removable reservoir makes refilling easy.Smart start: Your coffee maker heats, then brews in one simple process; No need to wait for it to heat before selecting your cup size.Energy efficient: Programmable auto off feature automatically turns your brewer off 2 hours after the last brew for energy savings", null, "/pic/cases/OrientalDragon22.png", 400m, "Shanghai Stainless Steel Coffee Machine Maker", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 23, 1, "150-Watt Motor in 110-120Voltage with 5 speeds light weight handheld mixer can help to find the right speed for every mixing task. You can slowly increase speed for optimal mixing consistency and to prevent messes.The attachments include 2 wire beaters,2 balloon whisks, they are dishwasher-safe and easy to remove with press button.", null, "/pic/cases/OrientalDragon23.png", 300m, "Guangdong Electric Hand Mixer Mixing Bowls Set", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 24, 1, "Lime Flavored Beer Salt: This bold lime flavor is a perfect partner to any Mexican import, domestic lager, beer-rita, or tequila. Add flavor & fun to special events & everyday activities!Portable Flavor & Fun: Inspired by the Latino tradition of adding citrus & salt to beer. Sprinkle our beer salt onto your bottle, can or mug & take the pocket-sized mini beer bottle with you anywhere!Add Excitement to Any Beer: It's especially great on Domestic Lagers, Mexican Imports & Belgian-style wheat beers. Simply add a dash of Beer Salt to the top of your beer, then lick, drink & repeat!One-of-a-Kind Blends: We make a variety of unique flavors to enhance your food & drinks from beer salts, michelada mix & margarita rim salts to seasonings like chile lime, tamarind, sriracha & more!Everything Goes with Twang: We are dedicated to adding fun, flavor & excitement to your favorite food & drink through the creation of high quality, one-of-a-kind salt, sugar, & spice blends.", null, "/pic/cases/OrientalDragon24.png", 60m, "Qingdao Flavored Beer", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 25, 1, "【THOUGHTFULLY DESIGNED】- Our gel wine sleeves are made from a medical grade vinyl heat-sealed shell and unique non-toxic gel that won't leak. The design does not require support and can be placed independently on the table. The unique honeycomb design makes the wine cover easier to fit the wine bottle.【EASY TO USE】- You just store it in the refrigerator, take it out when you need it, and put the wine or drink you want to cool down. No need for troublesome ice cubes and ice buckets.If it gets dirty, it can be washed with clean water or soapy water, it is tough and durable.", null, "/pic/cases/OrientalDragon25.png", 800m, "Beijing Ice Wine", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 26, 1, "Youre about to fall in love with this gourmet take on a ramen we all grew up with. Let the decadent broth of our Spicy Beef Ramen Noodle Soup melt in your mouth as you enjoy the subtle heat from the chilis that season it. We make our products using organic ramen noodles that we make from scratch in Woodland, CA each day. Check out our recipe suggestions to make your own world-class Craft Ramen bowl and Savor The Good.", null, "/pic/cases/OrientalDragon26.png", 15m, "Shenzhen Oil Instant Ramen Noodles", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 27, 1, "When you get the call to arms, reach for rifle that has proven itself time and again in battles around the globe: the Battlemaster. With the realistic styling of an AK47, this AEG can go from semi-auto to full-auto capable of firing over 565 shots per minute up to 200 FPS.  The Battlemaster features sling mounts and there's a sling included for comfortable carry.  The magazine capacity is 430 rounds. A 7.2 volt 700 mAH Ni-Cd battery and charger are included.", null, "/pic/cases/OrientalDragon27.png", 800m, "Wuhan Electric Full/Semi-Auto AK Airsoft Rifle", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 28, 1, "【Altitude Hold Function】Compared with other helicopters, our helicopter is equipped with this function, it is easier to control for beginners and kids. because kids can release the throttle stick and the helicopter will keep the current height, super easy to play with.【One Key Take Off/Landing】Just press one key, this mini helicopter will take off and hover at a certain height, and when your helicopter needs landing, also press one key landing to shut the helicopter off. Easy control for beginners and kids.【3 Channel Helicopter】RC helicopter - ascend / descend, left / right, forward / backward, hovering(built -in gyro).Moves more flexible and stable.Suitable for flying indoors.", null, "/pic/cases/OrientalDragon28.png", 500m, "Hongkong Remote Control Helicopter", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 29, 1, "Crystal Surround Sound: High precision 50mm magnetic neodymium drivers, immersive gaming experience with incredibly realistic sound. What you play, where you are. Great gaming headset for football games, shooting games, race games, switch games and so on.Professional Comfort: Ultra light weight design. Our gaming headphone is less than 8 oz with high quality memory protein earmuffs and elastic head pad, which is customized designed for long time wearing.No worry and no complains for ears hurts from several hours gaming.", null, "/pic/cases/OrientalDragon29.png", 100m, "Guandong Headset", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 30, 1, "Getting your Jeep enthusiast something small and thoughtful is a great way to show that you care about them without breaking the bank. At our store, you can find jeep themed glasses, mugs, patches, stickers, decals, signs, banners, magnets, keychains, and other products that offer an easy way to show off your love to this iconic brand. Explore the largest selection of stylish Jeep accessories that make perfect gifts for your colleagues, family members, and friends who are Jeep enthusiasts for many different occasions. They will allow you to express yourself and tell everyone you are a Jeep fan. You can use them to give your home or car a new exciting look and set it apart from the rest.", null, "/pic/cases/OrientalDragon30.png", 50m, "Guanzhou Jeep Text Logo Hat", 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 31, 1, "Boil the green beans for 10 minutes in a pan of boiling water. Then drain. Chop the onion, ginger and garlic very fine, you can also do this in a food processor.Fry this finely chopped mixture for 2 minutes in a pan with 1 tablespoon of sunflower oil. Add the soy sauce, laos, sambal(to taste) and sugar and mix together.Pour in the coconut milk and crumble in half the stock cube.Bring to a gentle boil.Add the green beans and mix everything well.Let the sayur beans cook and simmer for another 5 minutes.Then serve, for example, as part of the rice table with prawn crackers and rice.", null, "/pic/cases/Indomie01.png", 70m, "Sajoer Boontjes", 12, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 32, 1, "Luscious tomatoes grown under the mediterraneean sun from the emilia romagna region lay a rich foundation for this delightful combination. Finished with mild red chilli and parsley to balance this delicious sauce.Try this sauce in seafood fettuccine.", null, "/pic/cases/Indomie02.png", 50m, "Providore Pasta Sauce Tomato & Red Chilli", 12, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 33, 1, "Chili, or a combination chilies, is the ingredient for sambal, the Indonesian chili paste or sauce which is either cooked or raw. Secondary ingredients vary. Garlic, ginger, shallot, scallions, shrimp paste, lime juice and palm sugar may be added to modify the flavor of sambal.", null, "/pic/cases/Indomie03.png", 45m, "Sambal Chili Paste", 2, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 34, 1, "So, if you're in the mood for a delicious mug of instant coffee that has spent almost a month in transit, buy yourself some cheap cigarettes and thank whichever god you believe in that the person shipping them has some sort of grudge against bubble wrap. Or, you know, just get it straight from Amazon.", null, "/pic/cases/Indomie04.png", 55m, "Indonesian Instant Coffee", 2, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 35, 1, "Those taste lies on the ingredient that’s used, especially seasoning. Indonesian seasoning is famously known as rich because Indonesian food often use various kind of herbs and spices to make their foods has rich flavour.There are many kinds of seasoning ingredient from Indonesia.", null, "/pic/cases/Indomie05.png", 25m, "Herbs and Spices", 2, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 36, 1, "'If it ain't cooked and you can't peel it, don't eat it' is a mantra for many travelers determined to keep stomach bugs at bay. It's one I just can't subscribe to here in Southeast Asia, where most of the time temperatures hover around scorching and rolling carts packed with peeled fresh fruit beckon from many a corner.", null, "/pic/cases/Indomie06.png", 35m, "Tropical Fruits", 2, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 37, 1, "Boil noodles for 3 minutes in water. Drain noodles. Empty condiment contents into pan on medium heat. Return noodles into pan and stir fry quickly for 1 - 2 minutes, evenly coating noodles. Enjoy!", null, "/pic/cases/Indomie07.png", 65m, "Indomie Instant Stir Fry Noodles", 2, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 38, 1, "Powered by a BLUE CORE 1 125cm3 engine, the Free Go was developed based on the concept of a “compact scooter for family comfort,” and balances elegant styling with highly-usable, practical performance. Main features include 1) a BLUE CORE engine which is light in weight and produces low vibration enabling more comfortable riding, 2) a Smart Motor Generator which combines startup with power generation functionality to deliver quieter starts while also reducing power generation loss, 3) an amply-sized and highly-comfortable 720mm-long seat, 4) a front fuel port, removing the need to open and close the seat when refueling, 5) generous large-capacity (approx. 25L) under-seat storage space, and 6) LCD instruments exuding a sense of both high quality and innovation.", null, "/pic/cases/Indomie08.png", 15500m, "Yamaha Motor", 2, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 39, 1, "ABC Hot and Sweet Chili Sauce (ABC Sambal Manis Pedas Lampung)in 11.5oz Bottle. Traditional Indonesian Chili Sauce with hot and spicy blend of tomatoes, chilies, vinegar, sugar and spices. Sambal ABC Manis Pedas is use as a condiment and is perfect for dipping Fish Crackers (Kerupuk) and may also be added to any fried rice or noodle dish, or simply try it on hotdog or pizza. Product of Indonesia. Halal Certified.", null, "/pic/cases/Indomie09.png", 45m, "Sambal Hot & Sweet Chili Sauce", 2, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 40, 1, "The best quality tea producers provide taste and aroma its refined, rich in antioxidants and ingredients beneficial to health. Universal Tea Indonesia Black Tea products include BOPI, BOP (Broken Orange Pekoe), BOPF (Broken Orange Pekoe Faning), PF (Pekoe Faning), BT (Broken Tea), BP (Broken Pekoe), DUST, PF II, Dust II, BP1, PF1, D1, PD, D2.", null, "/pic/cases/Indomie10.png", 25m, "Universal Tea Indonesia", 2, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 41, 1, "Incorporating Quinoa in your meals will not only increase the protein levels in your body, but also the Fiber in it will help improve your digestion, which in turn helps manage weight.Quinoa has a mild, nutty flavor and is often used as a rice substitute. Add to salads, stir-fries, or serve as a side dish.  ", null, "/pic/cases/TataGroup01.png", 80m, "Urban Platter Whole White Quinoa Grain", 3, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 42, 1, "Vedantika Herbals Lemon Ginger Energy Drink is a nice blend of lemon and ginger. Lemon rich in vitamin C and citric acid strengthens the digestive system. It helps to clean the liver and works as good blood purifier. The drink also helps to flush out toxins out of the body. The high content of vitamin C helps to combat free radicals and neutralizes the cell damages. It also strengthens the immunity system of the body.The drink is ideal for indigestion, gas pain and stomach cramps. Ginger in the drink helps to minimize motion sickness and also nausea. The drink replenishes the body with essential nutrients, vitamin, minerals and salts which increases the energy level of the body. The anti-inflammatory properties of ginger help control the cholesterol level in the body. The ginger lemon drink gives relief and help recover quickly from cough and cold. The drink has no added artificial colour or flavour. Vedantika Herbals Lemon Ginger Energy Drink is definitely a revitalizing drink.", null, "/pic/cases/TataGroup02.png", 50m, "Vedantika Herbals Lemon Ginger Herbal Drink", 3, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 43, 1, "Ready to Ship after 4 - 6 days of Order confirmation.Fresh & Genuine Branded Products.Free Expedited Shipping from India.Delivery with in 4 - 7 Business Days.", null, "/pic/cases/TataGroup03.png", 90m, "Urban Platter Exotic Macadamia Nuts", 3, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 44, 1, "Trident tropical twist gum. New refreshing tropical flavor sugar free gum. A wonderful gum that is also good for your teeth. 18 STICK Sugar Free Gum With Xylitol.", null, "/pic/cases/TataGroup04.png", 50m, "Trident Tropical Twist Sugar Free Mint", 3, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 45, 1, "Phalada Pure and sure is a range of certified organic food products stemmed from our aim of providing complete solutions across organic supply chain. By offering end consumers quality organic food products which are sourced directly from farmers, we make sure our involvement in the supply chain from farm to hands. Our products guarantee purity and reach your hands without the use of chemical fertilizers, additives or artificial ingredients. We go one step further to satisfy our customers: In areas where our supplies are limited, we source premium organic products from across the globe and deliver a complete range of pure products that sure serves you the best. By sowing our vision, we harvest quality and spread healthy organic practices.", null, "/pic/cases/TataGroup05.png", 70m, "Pure & Sure Organic Ground Nut Oil", 3, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 46, 1, "Mustard oil is highly recommended for the reason that it is full of monounsaturated fatty acids (MUFA).According to a study done by the American Journal of Clinical Nutrition, including mustard oil in your regular diet could prove to be beneficial to your heart health.Mustard oil has anti-bacterial, anti-fungal and anti-viral properties. Its external as well as internal usage is said to help in multiple ways to fight against infections, including digestive tract infections.Mustard oil, because of its anti-microbial properties, it is used as a preservative for pickles.Mustard oil has oleic acid and linoleic acid which are essential fatty acids that make it a good hair tonic.Hair massage with this oil is said to increase blood circulation and promote hair growth.", null, "/pic/cases/TataGroup06.png", 50m, "Patanjali Kachi Ghani Mustard Oil", 3, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 47, 1, "Ready to Ship after 2 - 3 days of Order Confirmation.Fresh & Genuine Branded Products.Free Expedited Shipping from India.Delivery with in 4 - 7 Business Days.", null, "/pic/cases/TataGroup07.png", 80m, "Nescafe Classic Instant Coffee Pouch", 3, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 48, 1, "Kenny Delights Roasted Seeds Combo Pumpkin, Sunflower, Coated Sunflower, Flax, Chia & Watermelon - 900 gm.This seeds combo from Kenny Delights has a shelf life of 4 months. These products are gluten free and is suitable for vegans.Store in cool and dry place.", null, "/pic/cases/TataGroup08.png", 150m, "Kenny Delights Roasted Seeds Combo Pumpkin, Sunflower, Coated Sunflower, Flax, Chia & Watermelon", 3, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 49, 1, "Kapiva makes its product from the right herbs in the right dosage which are 100% pure, natural and vegetarian. Our Amla + Giloy Juice is 100% pure, natural, free from any synthetic flavour, colour, seed, impurities and oil.", null, "/pic/cases/TataGroup09.png", 50m, "Kapiva Tulsi Giloy Juice - Natural Detox", 3, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 50, 1, "Inlife Green Tea Extract Vegetarian Capsules Have Green Tea Extract.The Extract Is Mainly Derived From The Leaves Of Green Tea. Green Tea Contains Antioxidants In A Great Amount Which Are Beneficial For Human Health.Chaha Is Another Name Of Green Tea. Each Capsule Of Inlife Green Tea Extract Vegetarian Capsules Contains 500mg Of Green Tea Extract.The Extract Is Very Helpful In Maintaining Glowing Skin And Keeps It Healthy And Fresh.The antioxidants present in the extract promotes metabolism which helps in weight management.A proper metabolism is necessary for a healthy body and hence this extract helps in getting it indirectly.It can also help you to have a strong immune system, a healthy body with maintained healthy blood pressure and many other health benefits.It can help you in getting a healthy body and mind. ", null, "/pic/cases/TataGroup10.png", 90m, "Inlife Green Tea Extract 500 mg Capsules", 3, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 51, 1, "Perfect lounge for land or water use Designed for maximum comfort and hours of relaxation Room for 6 pump not included REQUIRED FOR INLATION Nonstop Outdoor Fun You can use it on land or water, as poolside furniture, on your patio or deck-any location. Maximum Capacity: 6 Built-in inflatable bench seat and cooler 5 heavy-duty handles 8 cup holders Boarding platform Heavy-gauge PVC for years of use Speedy inflation and deflation quick release safety valve Battery pump not included.", null, "/pic/cases/Parippu01.png", 1250000m, "6-Person Breeze Boat", 4, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 52, 1, "Hailed as the mythical Tarshish, the legendary island of invaluable gemstones, Sri Lanka has been the source of many celebrated gemstones, pearls and luxury jewellery throughout history and has a long association with the international gem and jewellery trade. Today, Sri Lanka is the ninth-largest exporter of precious stones to the global market and one of the five most important gem bearing nations of the world.", null, "/pic/cases/Parippu02.png", 85000m, "GEMS & JEWELLERY", 4, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 53, 1, "100% ORGANIC; coconut oil, coconut butter, coconut jam, coconut sugar, coconut flour, coconut milk, coconut cream, coconut milk powder, MCT coconut oil, coconut nectar, desiccated coconut, coconut chips, coconut threads, coconut vinegar, coconut amino sauce, coconut water, handmade coconut soap and even a nut-free peanut butter alternative made wholly of 100% ground toasted coconut!", null, "/pic/cases/Parippu03.png", 80m, "Milk Coconut", 4, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 54, 1, "Pull your weekend looks together with our fuss-free and versatile Isla platform sandals. Featuring soothing chalk-white puffy straps, use these sandals to turn a simple outfit into a trendy and elegant look. Bonus points for the 4.5cm platform sole that offers a little elevation and whole lot of style. Wear them with a skater dress and a woven crossbody bag for the ultimate casual-chic ensemble.", null, "/pic/cases/Parippu04.png", 50m, "Rozie Slides", 4, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 55, 1, "The major fruit varieties grown in Sri Lanka are mango, papaya, pineapple, avocado, banana, watermelon, rambutan, mangosteen, wood apple, guava, pomegranate and jackfruits. Banana, pineapple and papaya are commercially grown whereas other varieties of fruit come from home gardens for the most part. The extent of fruit crops at present is about 69,800 ha and it yields an average annual production of about 590,000 metric tonnes. Out of that, about 50-55% is locally consumed, 30- 40% is wasted and about 11% is exported, according to 2018 data (2). Fruits produced in Sri Lanka are mainly exported to the United Arab Emirates, India and the Maldives.", null, "/pic/cases/Parippu05.png", 70m, "SRI LANKAN FRUITS", 4, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 56, 1, "According to sources, the use of clay in Sri Lanka started to gain more attention with the introduction of Buddhism to the island. Buddhist stupas were built using clay. Clay craftsmen have been coming down to Sri Lanka on various historical occasions which eventually improved the local crafting talents creating professions for creators. (2) The country specializes in its patterns and styles when it comes to its pottery products. Each form of pottery served a different purpose. Pottery used for domestic purposes was often not decorated whereas decorative pottery was coloured and glazed.", null, "/pic/cases/Parippu06.png", 50m, "SRI LANKA CLAYWARE", 4, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 57, 1, "Whether after a long day or a night out, a cup of green tea is a great way to relax and also give your eyes a little spa treatment at the same time. Cool down your green tea bags and lightly squeeze out any excess water – place them over your eyes for 20 minutes and any puffiness will be greatly reduced.", null, "/pic/cases/Parippu07.png", 80m, "Tea Ceylon", 4, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 58, 1, "Sri Lankan Spice Blend, also called Sri Lankan Curry Powder, is a unique mix of ingredients that enhances the flavour of your desired cooking. A traditional and authentic masala with carefully chosen ingredients. Ground and roasted to bring out the best of Sri Lankan flavour. Can be used with meat, chicken, fish and vegetables.", null, "/pic/cases/Parippu08.png", 100m, "Sri Lankan Spice Blend Masala", 4, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 59, 1, "Today, Sri Lanka has emerged as a quality fish and seafood exporter, supplying predominantly yellowfin and bigeye tuna species, crabs, prawns, and molluscs species to international markets. Adherence to the latest technology in product development, processing, and packaging techniques ensures that Sri Lankan fish and seafood products that reach the international market are superior in quality, taste and texture.", null, "/pic/cases/Parippu09.png", 200m, "FISH & FISHERIES", 4, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 60, 1, "The Sri Lankan medicinal system predominantly utilizes herbs and spices for the treatment of various ailments. This is mostly because Sri Lanka is a tropical country, a biodiverse hot-spot　blessed　with a plethora of flora and fauna. Traditional Herbal Remedies of Sri Lanka looks at the traditional medicinal practices of　the country　that utilize plant material from a cultural, philosophical and scientific perspective. When it comes to the scientific aspects, several Sri Lankan herbs have been in the spotlight for possessing bioactive constituents with promising therapeutic effects. It is hoped that these will be considered as strong candidates to combat currently prevailing global disease conditions.", null, "/pic/cases/Parippu10.png", 90m, "Ayurveda Herbs", 4, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 61, 1, "Batik is a cloth made traditionally using a manual wax-resistant dyeing technique. It has been practiced in Indonesia since ancient times. The traditional colors of Javanese batik are indigo, dark brown and white. Certain patterns were worn only by nobility, others by royalty, and so on. Each region of Indonesia has its own unique patterns for batik that includes flowers, animals, folklore or people. Nowadays, batik is also produced by automated techniques and is called batik cap and batik print. The handmade batik is nowadays known as batik tulis (written batik).", null, "/pic/cases/Indomie11.png", 750m, "Batik Textiles", 2, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 62, 1, "Incense has been known to people for centuries, mostly in relation to religion or medicine. It has appeared in different forms: raw wood, chopped herbs, pastes, powders, liquids or oils. The most common shape incense appears today in is joss-sticks or cones. If you want to bring home a piece of Indonesia in the form of incense, there's nothing better than the fragrance coming from the exotic island of Bali, particularly that made by Gopala Bhakta Sakti. Their products are made from natural powdered roots and woods perfumed in accordance with traditional formula. Their incense comes in a variety of shapes, such as butterflies, frogs, pandas, turtles, etc., and in just as many aromas.", null, "/pic/cases/Indomie12.png", 55m, "Aromatic Incense", 2, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Detail", "Picture", "Price", "ProductName", "ShopId", "Sn" },
                values: new object[] { 63, 1, "Pottery has been produced in Indonesia since ancient times. It was mostly earthenware and stoneware. Later, the Chinese introduced porcelain. There are many centers in Indonesia where pottery is made.The most renowned of them are Kasongan, Pundong, Melikan, Klampok, Plered, Sitiwinangun, Lombok and Singkawang. The multitude of ethnic groups, each with its own tradition, create an interesting mixture of ethnic designs. Until recently, most of the pottery made in Indonesia were plain without much ornamentation. However, with the increased exports, more decorative pottery have started to appear.", null, "/pic/cases/Indomie13.png", 550m, "Pottery Indonesia", 2, null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "IX_OrderLists_UserId",
                table: "OrderLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderListId",
                table: "Orders",
                column: "OrderListId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

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
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "OrderLists");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
