using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace B03.EE.SchuermansEva.WebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDay = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    StopDateTime = table.Column<DateTime>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activity_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    ActivityId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registration_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registration_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName", "Created" },
                values: new object[,]
                {
                    { 1, "None", new DateTime(2019, 1, 26, 17, 19, 25, 534, DateTimeKind.Local) },
                    { 2, "Crafts", new DateTime(2019, 1, 26, 17, 19, 25, 534, DateTimeKind.Local) },
                    { 3, "Culinary", new DateTime(2019, 1, 26, 17, 19, 25, 534, DateTimeKind.Local) },
                    { 4, "Culture", new DateTime(2019, 1, 26, 17, 19, 25, 534, DateTimeKind.Local) },
                    { 5, "Sports", new DateTime(2019, 1, 26, 17, 19, 25, 534, DateTimeKind.Local) },
                    { 6, "Wellness", new DateTime(2019, 1, 26, 17, 19, 25, 534, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "CountryName", "Created" },
                values: new object[,]
                {
                    { 17, "Lithuania", new DateTime(2019, 1, 26, 17, 19, 25, 561, DateTimeKind.Local) },
                    { 18, "Luxembourg", new DateTime(2019, 1, 26, 17, 19, 25, 561, DateTimeKind.Local) },
                    { 19, "Malta", new DateTime(2019, 1, 26, 17, 19, 25, 561, DateTimeKind.Local) },
                    { 20, "Netherlands", new DateTime(2019, 1, 26, 17, 19, 25, 561, DateTimeKind.Local) },
                    { 21, "Poland", new DateTime(2019, 1, 26, 17, 19, 25, 561, DateTimeKind.Local) },
                    { 22, "Portugal", new DateTime(2019, 1, 26, 17, 19, 25, 561, DateTimeKind.Local) },
                    { 25, "Slovenia", new DateTime(2019, 1, 26, 17, 19, 25, 561, DateTimeKind.Local) },
                    { 24, "Slovakia", new DateTime(2019, 1, 26, 17, 19, 25, 561, DateTimeKind.Local) },
                    { 16, "Latvia", new DateTime(2019, 1, 26, 17, 19, 25, 561, DateTimeKind.Local) },
                    { 26, "Spain", new DateTime(2019, 1, 26, 17, 19, 25, 561, DateTimeKind.Local) },
                    { 27, "Sweden", new DateTime(2019, 1, 26, 17, 19, 25, 561, DateTimeKind.Local) },
                    { 28, "United Kingdom", new DateTime(2019, 1, 26, 17, 19, 25, 561, DateTimeKind.Local) },
                    { 23, "Romania", new DateTime(2019, 1, 26, 17, 19, 25, 561, DateTimeKind.Local) },
                    { 15, "Italy", new DateTime(2019, 1, 26, 17, 19, 25, 561, DateTimeKind.Local) },
                    { 13, "Hungary", new DateTime(2019, 1, 26, 17, 19, 25, 560, DateTimeKind.Local) },
                    { 5, "Cyprus", new DateTime(2019, 1, 26, 17, 19, 25, 560, DateTimeKind.Local) },
                    { 12, "Greece", new DateTime(2019, 1, 26, 17, 19, 25, 560, DateTimeKind.Local) },
                    { 11, "Germany", new DateTime(2019, 1, 26, 17, 19, 25, 560, DateTimeKind.Local) },
                    { 10, "France", new DateTime(2019, 1, 26, 17, 19, 25, 560, DateTimeKind.Local) },
                    { 9, "Finland", new DateTime(2019, 1, 26, 17, 19, 25, 560, DateTimeKind.Local) },
                    { 8, "Estonia", new DateTime(2019, 1, 26, 17, 19, 25, 560, DateTimeKind.Local) },
                    { 7, "Denmark", new DateTime(2019, 1, 26, 17, 19, 25, 560, DateTimeKind.Local) },
                    { 6, "Czechia", new DateTime(2019, 1, 26, 17, 19, 25, 560, DateTimeKind.Local) },
                    { 14, "Ireland", new DateTime(2019, 1, 26, 17, 19, 25, 560, DateTimeKind.Local) },
                    { 4, "Croatia", new DateTime(2019, 1, 26, 17, 19, 25, 560, DateTimeKind.Local) },
                    { 3, "Bulgaria", new DateTime(2019, 1, 26, 17, 19, 25, 560, DateTimeKind.Local) },
                    { 2, "Belgium", new DateTime(2019, 1, 26, 17, 19, 25, 560, DateTimeKind.Local) },
                    { 1, "Austria", new DateTime(2019, 1, 26, 17, 19, 25, 560, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "BirthDay", "Created", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 2, new DateTime(1979, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 26, 17, 19, 25, 591, DateTimeKind.Local), "Stijn", "Schaballie" },
                    { 3, new DateTime(2015, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 26, 17, 19, 25, 591, DateTimeKind.Local), "Lore", "Schaballie" },
                    { 1, new DateTime(1987, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 26, 17, 19, 25, 591, DateTimeKind.Local), "Eva", "Schuermans" },
                    { 4, new DateTime(2017, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 26, 17, 19, 25, 591, DateTimeKind.Local), "Eppo", "Schaballie" }
                });

            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "Id", "CategoryId", "CountryId", "Created", "Description", "StartDateTime", "StopDateTime", "Title" },
                values: new object[] { 1, 5, 2, new DateTime(2019, 1, 26, 17, 19, 25, 490, DateTimeKind.Local), "Family-clycling-tour near Bruges. We start and end at RSS1.", new DateTime(2019, 5, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), "Bicycleride" });

            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "Id", "CategoryId", "CountryId", "Created", "Description", "StartDateTime", "StopDateTime", "Title" },
                values: new object[] { 3, 5, 10, new DateTime(2019, 1, 26, 17, 19, 25, 490, DateTimeKind.Local), "Family-canyon in South France. Everybody who wants to participate, has to be able te swim 25m.", new DateTime(2019, 6, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 10, 16, 30, 0, 0, DateTimeKind.Unspecified), "Gorges de Galamus" });

            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "Id", "CategoryId", "CountryId", "Created", "Description", "StartDateTime", "StopDateTime", "Title" },
                values: new object[] { 2, 4, 11, new DateTime(2019, 1, 26, 17, 19, 25, 490, DateTimeKind.Local), "Visit Berlin in three days. Guided tour around the city, where the east and west part meet eachother", new DateTime(2019, 4, 22, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 21, 20, 0, 0, 0, DateTimeKind.Unspecified), "Easter Citytrip" });

            migrationBuilder.InsertData(
                table: "Registration",
                columns: new[] { "Id", "ActivityId", "Created", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 1, 26, 17, 19, 25, 573, DateTimeKind.Local), 1 },
                    { 2, 1, new DateTime(2019, 1, 26, 17, 19, 25, 573, DateTimeKind.Local), 2 },
                    { 3, 1, new DateTime(2019, 1, 26, 17, 19, 25, 573, DateTimeKind.Local), 3 },
                    { 4, 1, new DateTime(2019, 1, 26, 17, 19, 25, 573, DateTimeKind.Local), 4 },
                    { 5, 3, new DateTime(2019, 1, 26, 17, 19, 25, 573, DateTimeKind.Local), 1 },
                    { 6, 3, new DateTime(2019, 1, 26, 17, 19, 25, 573, DateTimeKind.Local), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_CategoryId",
                table: "Activity",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_CountryId",
                table: "Activity",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_ActivityId",
                table: "Registration",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_UserId",
                table: "Registration",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
