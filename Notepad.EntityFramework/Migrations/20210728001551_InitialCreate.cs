using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Notepad.EntityFramework.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoteCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoteCategoryTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NoteCategoryDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApiToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginHit = table.Column<int>(type: "int", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoteTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NoteContent = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_NoteCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "NoteCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "CreatedDate", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("b2b49ad5-3b32-446c-f944-08d9515cdba8"), "Adana", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(1366), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(1808) },
                    { new Guid("91c5e61b-51fb-4627-f97f-08d9515cdba8"), "Tokat", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2775), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2777) },
                    { new Guid("c87f0634-246c-4d0c-f97e-08d9515cdba8"), "Tekirdağ", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2768), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2769) },
                    { new Guid("077a50e6-65c4-47a7-f97d-08d9515cdba8"), "Sivas", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2760), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2761) },
                    { new Guid("ea1a270c-e417-480a-f97c-08d9515cdba8"), "Sinop", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2752), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2754) },
                    { new Guid("20597945-cd86-484f-f97b-08d9515cdba8"), "Siirt", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2744), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2746) },
                    { new Guid("904b279b-27c4-493d-f97a-08d9515cdba8"), "Samsun", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2736), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2738) },
                    { new Guid("9ce0899f-aaf2-413d-f979-08d9515cdba8"), "Sakarya", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2729), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2730) },
                    { new Guid("6412faab-2685-498e-f980-08d9515cdba8"), "Trabzon", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2783), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2785) },
                    { new Guid("1560e5ca-a97f-449e-f978-08d9515cdba8"), "Rize", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2718), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2720) },
                    { new Guid("5a16bd4a-e9b5-4e29-f976-08d9515cdba8"), "Niğde", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2703), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2705) },
                    { new Guid("cc8e7bea-dd8d-4e28-f975-08d9515cdba8"), "Nevşehir", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2695), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2697) },
                    { new Guid("82ac6c08-5c45-4f6d-f974-08d9515cdba8"), "Muş", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2688), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2689) },
                    { new Guid("0845808e-05eb-462c-f973-08d9515cdba8"), "Muğla", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2680), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2681) },
                    { new Guid("da4fdfe6-1ac2-4eb9-f972-08d9515cdba8"), "Mardin", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2672), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2674) },
                    { new Guid("d6de0983-5bd5-495e-f971-08d9515cdba8"), "Kahramanmaraş", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2665), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2666) },
                    { new Guid("1cfdb070-4c5b-4b26-f970-08d9515cdba8"), "Manisa", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2654), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2656) },
                    { new Guid("14900165-54e5-40e7-f977-08d9515cdba8"), "Ordu", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2711), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2712) },
                    { new Guid("f77c8d7d-d635-4cf2-f981-08d9515cdba8"), "Tunceli", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2793), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2795) },
                    { new Guid("9f477796-3874-4062-f982-08d9515cdba8"), "Şanlıurfa", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2801), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2803) },
                    { new Guid("10b20af8-7f89-4f1d-f983-08d9515cdba8"), "Uşak", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2809), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2810) },
                    { new Guid("c74c051f-4e8d-4cba-f994-08d9515cdba8"), "Düzce", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(3015), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(3016) },
                    { new Guid("ccf55da5-5bff-484d-f993-08d9515cdba8"), "Osmaniye", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(3007), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(3009) },
                    { new Guid("cdaf4567-b0c5-4321-f992-08d9515cdba8"), "Kilis", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(3000), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(3001) },
                    { new Guid("90ea19b7-18bf-416b-f991-08d9515cdba8"), "Karabük", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2991), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2992) },
                    { new Guid("0fce1634-8107-4408-f990-08d9515cdba8"), "Yalova", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2912), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2914) },
                    { new Guid("bb4b5db1-bd9b-4c58-f98f-08d9515cdba8"), "Iğdır", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2904), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2906) },
                    { new Guid("e0296fac-6fbc-4f18-f98e-08d9515cdba8"), "Ardahan", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2897), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2898) },
                    { new Guid("95a89454-6063-4714-f98d-08d9515cdba8"), "Bartın", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2889), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2890) },
                    { new Guid("bed6c450-f8f1-457f-f98c-08d9515cdba8"), "Şırnak", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2881), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2883) },
                    { new Guid("e83a411c-4e7e-4e8a-f98b-08d9515cdba8"), "Batman", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2874), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2875) },
                    { new Guid("51c29efc-3e9d-4aa5-f98a-08d9515cdba8"), "Kırıkkale", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2866), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2868) },
                    { new Guid("9348ee7c-a1eb-46c7-f989-08d9515cdba8"), "Karaman", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2858), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2860) },
                    { new Guid("3652a9d0-f22f-429c-f988-08d9515cdba8"), "Bayburt", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2848), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2850) },
                    { new Guid("40b2a17a-3182-4166-f987-08d9515cdba8"), "Aksaray", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2840), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2841) },
                    { new Guid("7f489aec-38b9-429f-f986-08d9515cdba8"), "Zonguldak", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2832), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2833) },
                    { new Guid("32e31a36-1fa3-45c7-f985-08d9515cdba8"), "Yozgat", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2824), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2826) },
                    { new Guid("bbcfb717-718c-4903-f984-08d9515cdba8"), "Van", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2817), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2818) },
                    { new Guid("0c931e4d-e62b-474b-f96f-08d9515cdba8"), "Malatya", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2647), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2648) },
                    { new Guid("c33269cb-9b71-4da3-f96e-08d9515cdba8"), "Kütahya", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2639), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2640) },
                    { new Guid("675cd6b7-b164-468a-f96d-08d9515cdba8"), "Konya", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2631), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2633) },
                    { new Guid("8755be4c-0c57-4955-f957-08d9515cdba8"), "Denizli", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2388), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2389) }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "CreatedDate", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("cc313a37-22e5-4eec-f956-08d9515cdba8"), "Çorum", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2380), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2381) },
                    { new Guid("2d5b1447-88ec-4b99-f955-08d9515cdba8"), "Çankırı", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2372), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2373) },
                    { new Guid("94d30b6f-a008-448c-f954-08d9515cdba8"), "Çanakkale", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2364), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2365) },
                    { new Guid("3532f809-4126-4d12-f953-08d9515cdba8"), "Bursa", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2356), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2357) },
                    { new Guid("96b5d9af-6a7c-4c23-f952-08d9515cdba8"), "Burdur", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2348), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2349) },
                    { new Guid("734ad1f7-850f-49be-f951-08d9515cdba8"), "Bolu", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2340), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2342) },
                    { new Guid("d021e79b-340d-4fcf-f950-08d9515cdba8"), "Bitlis", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2328), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2330) },
                    { new Guid("1e6eb2d7-80e6-4e72-f96c-08d9515cdba8"), "Kocaeli", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2623), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2625) },
                    { new Guid("d49cc89e-244d-4c4f-f94f-08d9515cdba8"), "Bingöl", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2320), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2322) },
                    { new Guid("8ad04a1d-64bc-4d08-f94d-08d9515cdba8"), "Balıkesir", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2305), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2306) },
                    { new Guid("d521a13f-a7c7-4ffa-f94c-08d9515cdba8"), "Aydın", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2297), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2298) },
                    { new Guid("3df3f4d2-9441-4c9c-f94b-08d9515cdba8"), "Artvin", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2289), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2290) },
                    { new Guid("b517156b-865e-41b1-f94a-08d9515cdba8"), "Antalya", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2281), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2282) },
                    { new Guid("bb10baa5-694c-4e0a-f949-08d9515cdba8"), "Ankara", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2273), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2274) },
                    { new Guid("23df673e-4fb2-4bdd-f948-08d9515cdba8"), "Amasya", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2250), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2252) },
                    { new Guid("4e7855a5-a482-4a0f-f947-08d9515cdba8"), "Ağrı", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2242), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2244) },
                    { new Guid("5fd7f4cd-a0e3-4ed0-f94e-08d9515cdba8"), "Bilecik", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2313), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2314) },
                    { new Guid("40392801-a9c7-4ec7-f958-08d9515cdba8"), "Diyarbakır", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2395), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2397) },
                    { new Guid("e7fb068a-1972-4b05-f959-08d9515cdba8"), "Edirne", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2406), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2408) },
                    { new Guid("1651b938-d072-4047-f95a-08d9515cdba8"), "Elazığ", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2414), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2416) },
                    { new Guid("ddf908de-af0c-48db-f96b-08d9515cdba8"), "Kırşehir", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2615), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2617) },
                    { new Guid("a50a90d9-7046-4aed-f96a-08d9515cdba8"), "Kırklareli", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2608), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2609) },
                    { new Guid("ccc1a0e8-6a91-482b-f969-08d9515cdba8"), "Kayseri", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2600), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2601) },
                    { new Guid("19c3d41b-1650-48b1-f968-08d9515cdba8"), "Kastamonu", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2589), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2591) },
                    { new Guid("b40eae40-f1af-4c3b-f967-08d9515cdba8"), "Kars", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2581), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2583) },
                    { new Guid("78a10d31-2304-4cdd-f966-08d9515cdba8"), "İzmir", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2574), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2575) },
                    { new Guid("7ea3e759-aace-4f42-f965-08d9515cdba8"), "İstanbul", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2566), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2567) },
                    { new Guid("063ab0df-df7a-448c-f964-08d9515cdba8"), "Mersin", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2558), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2559) },
                    { new Guid("5db18fb7-807d-4311-f963-08d9515cdba8"), "Isparta", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2550), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2551) },
                    { new Guid("ae7a60a3-dff8-413c-f962-08d9515cdba8"), "Hatay", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2479), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2481) },
                    { new Guid("4eb784d0-9511-48bd-f961-08d9515cdba8"), "Hakkâri", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2472), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2473) },
                    { new Guid("439d7c7c-21fd-4687-f960-08d9515cdba8"), "Gümüşhane", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2461), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2463) },
                    { new Guid("4b2d3a3a-9224-46cb-f95f-08d9515cdba8"), "Giresun", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2453), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2455) },
                    { new Guid("458af0af-55b8-4d1b-f95e-08d9515cdba8"), "Gaziantep", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2446), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2447) },
                    { new Guid("aca7065a-9f70-4448-f95d-08d9515cdba8"), "Eskişehir", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2438), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2439) },
                    { new Guid("a09114da-3bcb-4ddd-f95c-08d9515cdba8"), "Erzurum", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2430), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2431) },
                    { new Guid("244c175d-dbee-465f-f95b-08d9515cdba8"), "Erzincan", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2422), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2423) },
                    { new Guid("9e26f48a-e0ce-4b8a-f946-08d9515cdba8"), "Afyonkarahisar", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2234), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2235) },
                    { new Guid("f50cb2b5-8a29-492c-f945-08d9515cdba8"), "Adıyaman", new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2225), new DateTime(2021, 7, 28, 3, 15, 51, 377, DateTimeKind.Local).AddTicks(2227) }
                });

            migrationBuilder.InsertData(
                table: "NoteCategories",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "NoteCategoryDescription", "NoteCategoryTitle" },
                values: new object[,]
                {
                    { new Guid("610f6af5-df4d-4ac3-f996-08d9515cdba8"), new DateTime(2021, 7, 28, 3, 15, 51, 379, DateTimeKind.Local).AddTicks(5767), new DateTime(2021, 7, 28, 3, 15, 51, 379, DateTimeKind.Local).AddTicks(5771), "Yazılımla Alakalı Notlar", "Yazılım" },
                    { new Guid("c237e6fb-1404-4d1a-f995-08d9515cdba8"), new DateTime(2021, 7, 28, 3, 15, 51, 379, DateTimeKind.Local).AddTicks(5027), new DateTime(2021, 7, 28, 3, 15, 51, 379, DateTimeKind.Local).AddTicks(5033), "Önemli Notlar", "Önemli" },
                    { new Guid("8c95f375-6beb-463d-f997-08d9515cdba8"), new DateTime(2021, 7, 28, 3, 15, 51, 379, DateTimeKind.Local).AddTicks(5775), new DateTime(2021, 7, 28, 3, 15, 51, 379, DateTimeKind.Local).AddTicks(5776), "İş İle İlgili Notlar", "İş" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CategoryId",
                table: "Notes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserId",
                table: "Notes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                table: "Users",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "NoteCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
