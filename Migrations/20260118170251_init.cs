using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RESTAssignment.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Links_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonInterests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Long walks in nature and challenging terrain", "Hiking" },
                    { 2, "Creating delicious meals and experimenting with recipes", "Cooking" },
                    { 3, "Capturing moments through the lens of a camera", "Photography" },
                    { 4, "Playing video games across various platforms", "Gaming" },
                    { 5, "Exploring new places and experiencing different cultures", "Traveling" },
                    { 6, "Diving into books and expanding knowledge", "Reading" },
                    { 7, "Listening to and creating music across genres", "Music" },
                    { 8, "Engaging in physical activities to maintain health and wellness", "Fitness" },
                    { 9, "Cultivating plants and creating beautiful outdoor spaces", "Gardening" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "John", "Doe", "123-456-7890" },
                    { 2, "Jane", "Smith", "987-654-3210" },
                    { 3, "Alice", "Johnson", "555-123-4567" },
                    { 4, "Bob", "Brown", "444-987-6543" },
                    { 5, "Charlie", "Davis", "333-222-1111" }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "InterestId", "PersonId", "Url" },
                values: new object[,]
                {
                    { 1, 1, 1, "https://www.visitstockholm.com/see-do/activities/hiking-trails/" },
                    { 2, 2, 2, "https://cooking.nytimes.com/" },
                    { 3, 4, 3, "https://www.ign.com/" },
                    { 4, 5, 4, "https://www.lonelyplanet.com/" },
                    { 5, 7, 5, "https://www.spotify.com/" },
                    { 6, 3, 1, "https://www.nationalgeographic.com/photography" },
                    { 7, 6, 2, "https://www.goodreads.com/" },
                    { 8, 8, 3, "https://www.fitnessblender.com/" },
                    { 9, 9, 4, "https://www.gardeningknowhow.com/" },
                    { 10, 1, 5, "https://www.alltrails.com/" },
                    { 11, 9, 2, "https://www.rhs.org.uk/" },
                    { 12, 8, 5, "https://www.bodybuilding.com/" },
                    { 13, 5, 1, "https://www.tripadvisor.com/" },
                    { 14, 7, 2, "https://www.rollingstone.com/music/" },
                    { 15, 1, 3, "https://www.hikingproject.com/" },
                    { 16, 2, 4, "https://www.allrecipes.com/" },
                    { 17, 3, 5, "https://www.digitalphotomentor.com/" },
                    { 18, 5, 4, "https://www.nationalgeographic.com/travel/" },
                    { 19, 6, 2, "https://www.projectgutenberg.org/" },
                    { 20, 8, 3, "https://www.myfitnesspal.com/" }
                });

            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 3, 1 },
                    { 3, 5, 1 },
                    { 4, 2, 2 },
                    { 5, 6, 2 },
                    { 6, 7, 2 },
                    { 7, 9, 2 },
                    { 8, 1, 3 },
                    { 9, 4, 3 },
                    { 10, 8, 3 },
                    { 11, 2, 4 },
                    { 12, 5, 4 },
                    { 13, 3, 5 },
                    { 14, 7, 5 },
                    { 15, 9, 5 },
                    { 16, 8, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_InterestId",
                table: "Links",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonId",
                table: "Links",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_InterestId",
                table: "PersonInterests",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_PersonId",
                table: "PersonInterests",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "PersonInterests");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
