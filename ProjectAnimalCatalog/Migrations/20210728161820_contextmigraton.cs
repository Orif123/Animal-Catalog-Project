using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectAnimalCatalog.Migrations
{
    public partial class contextmigraton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalsID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Age = table.Column<byte>(type: "tinyint", nullable: false),
                    PictureName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalsID);
                    table.ForeignKey(
                        name: "FK_Animals_Categories",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false),
                    AnimalID = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_Animals",
                        column: x => x.AnimalID,
                        principalTable: "Animals",
                        principalColumn: "AnimalsID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { 1, "mammals" },
                    { 2, "birds" },
                    { 3, "adm" },
                    { 4, "fishes" },
                    { 5, "reptiles" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalsID", "Age", "CategoryID", "Description", "Name", "PictureName" },
                values: new object[,]
                {
                    { 1, (byte)69, 1, "a large, mostly herbivorous, semiaquatic mammal", "Hipo", "Hipo.jpg" },
                    { 3, (byte)51, 1, " is a domesticated descendant of the wolf", "Dog", "Dog.jpg" },
                    { 4, (byte)32, 1, "a domestic species of small carnivorous mammal", "Cat", "Cat.jpg" },
                    { 6, (byte)72, 1, "aquatic mammals within the infraorder Cetacea", "Dolphin", "Dolphin.jpg" },
                    { 7, (byte)11, 1, "aquatic mammals within the infraorder Cetacea", "Lion", "Lion.jpg" },
                    { 2, (byte)87, 3, "Snakes are elongated, limbless", "Snake", "Snake-Pit-Vipet.jpg" },
                    { 8, (byte)39, 3, "A frog is any member of a diverse", "Frog", "Frog.png" },
                    { 5, (byte)44, 4, "Sharks are a group of elasmobranch fish", "Shark", "Shark.jpg" },
                    { 9, (byte)8, 4, "Shrimp are decapod crustaceans", "Shrimp", "Shrimp.jpg" },
                    { 10, (byte)2, 5, "Lizards are a widespread group of ", "Lizard", "Lizard.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "AnimalID", "Comment" },
                values: new object[,]
                {
                    { 1, 1, "Wonderful" },
                    { 2, 1, "Wonderful" },
                    { 6, 1, "Wonderful" },
                    { 5, 3, "Wonderful" },
                    { 7, 3, "Wonderful" },
                    { 8, 3, "Wonderful" },
                    { 3, 2, "Wonderful" },
                    { 4, 2, "Wonderful" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CategoryID",
                table: "Animals",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnimalID",
                table: "Comments",
                column: "AnimalID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
