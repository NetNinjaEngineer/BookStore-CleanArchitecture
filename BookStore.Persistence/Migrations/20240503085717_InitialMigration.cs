using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    PublicationYear = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ImageName = table.Column<string>(type: "varchar(Max)", nullable: true),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId");
                });

            migrationBuilder.CreateTable(
                name: "AuthorBooks",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBooks", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "AuthorName" },
                values: new object[,]
                {
                    { 1, "George Orwell" },
                    { 2, "Harper Lee" },
                    { 3, "F. Scott Fitzgerald" },
                    { 4, "Jane Austen" },
                    { 5, "J. D. Salinger" },
                    { 6, "J. K. Rowling" },
                    { 7, "J. R. R. Tolkien" },
                    { 8, "J. R. R. Tolkien" },
                    { 9, "George Orwell" },
                    { 10, "C. S. Lewis" },
                    { 11, "Dan Brown" },
                    { 12, "Paulo Coelho" },
                    { 13, "Stieg Larsson" },
                    { 14, "Gillian Flynn" },
                    { 15, "Suzanne Collins" },
                    { 16, "Douglas Adams" },
                    { 17, "Charlotte Brontë" },
                    { 18, "Aldous Huxley" },
                    { 19, "Herman Melville" },
                    { 20, "George R. R. Martin" },
                    { 21, "Cormac McCarthy" },
                    { 22, "Khaled Hosseini" },
                    { 23, "Emily Brontë" },
                    { 24, "Fyodor Dostoyevsky" },
                    { 25, "Oscar Wilde" },
                    { 26, "Mary Shelley" },
                    { 27, "Alexandre Dumas" },
                    { 28, "Sylvia Plath" },
                    { 29, "Stephen King" },
                    { 30, "William Golding" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "GenreName" },
                values: new object[,]
                {
                    { 1, "Mystery" },
                    { 2, "Romance" },
                    { 3, "Science Fiction" },
                    { 4, "Fantasy" },
                    { 5, "Thriller" },
                    { 6, "Horror" },
                    { 7, "Historical Fiction" },
                    { 8, "Biography" },
                    { 9, "Memoir" },
                    { 10, "Self-help" },
                    { 11, "Travel" },
                    { 12, "Poetry" },
                    { 13, "Comedy" },
                    { 14, "Drama" },
                    { 15, "Crime Fiction" },
                    { 16, "Action and Adventure" },
                    { 17, "Children's" },
                    { 18, "Young Adult" },
                    { 19, "Paranormal" },
                    { 20, "Urban Fantasy" },
                    { 21, "Non-fiction" },
                    { 22, "Satire" },
                    { 23, "Western" },
                    { 24, "Dystopian" },
                    { 25, "Fairy Tale" },
                    { 26, "LGBTQ+" },
                    { 27, "War" },
                    { 28, "Spiritual" },
                    { 29, "Philosophy" },
                    { 30, "Classic" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "GenreId", "ImageName", "Price", "PublicationYear", "Title" },
                values: new object[,]
                {
                    { 1, 24, null, 10.99m, 1949, "1984" },
                    { 2, 7, null, 12.99m, 1960, "To Kill a Mockingbird" },
                    { 3, 14, null, 9.99m, 1925, "The Great Gatsby" },
                    { 4, 2, null, 8.99m, 1813, "Pride and Prejudice" },
                    { 5, 14, null, 11.99m, 1951, "The Catcher in the Rye" },
                    { 6, 4, null, 15.99m, 1997, "Harry Potter and the Philosopher's Stone" },
                    { 7, 4, null, 18.99m, 1954, "The Lord of the Rings" },
                    { 8, 4, null, 14.99m, 1937, "The Hobbit" },
                    { 9, 14, null, 10.99m, 1945, "Animal Farm" },
                    { 10, 4, null, 17.99m, 1950, "The Chronicles of Narnia" },
                    { 11, 1, null, 13.99m, 2003, "The Da Vinci Code" },
                    { 12, 21, null, 11.99m, 1988, "The Alchemist" },
                    { 13, 15, null, 14.99m, 2005, "The Girl with the Dragon Tattoo" },
                    { 14, 15, null, 12.99m, 2012, "Gone Girl" },
                    { 15, 16, null, 10.99m, 2008, "The Hunger Games" },
                    { 16, 4, null, 9.99m, 1979, "The Hitchhiker's Guide to the Galaxy" },
                    { 17, 2, null, 8.99m, 1847, "Jane Eyre" },
                    { 18, 24, null, 12.99m, 1932, "Brave New World" },
                    { 19, 4, null, 15.99m, 1851, "Moby-Dick" },
                    { 20, 4, null, 20.99m, 1996, "A Game of Thrones" },
                    { 21, 24, null, 11.99m, 2006, "The Road" },
                    { 22, 24, null, 13.99m, 2003, "The Kite Runner" },
                    { 23, 2, null, 10.99m, 1847, "Wuthering Heights" },
                    { 24, 15, null, 14.99m, 1866, "Crime and Punishment" },
                    { 25, 14, null, 9.99m, 1890, "The Picture of Dorian Gray" },
                    { 26, 6, null, 11.99m, 1818, "Frankenstein" },
                    { 27, 14, null, 16.99m, 1844, "The Count of Monte Cristo" },
                    { 28, 9, null, 12.99m, 1963, "The Bell Jar" },
                    { 29, 6, null, 13.99m, 1977, "The Shining" },
                    { 30, 6, null, 10.99m, 1954, "Lord of the Flies" }
                });

            migrationBuilder.InsertData(
                table: "AuthorBooks",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 },
                    { 11, 11 },
                    { 12, 12 },
                    { 13, 13 },
                    { 14, 14 },
                    { 15, 15 },
                    { 16, 16 },
                    { 17, 17 },
                    { 18, 18 },
                    { 19, 19 },
                    { 20, 20 },
                    { 21, 21 },
                    { 22, 22 },
                    { 23, 23 },
                    { 24, 24 },
                    { 25, 25 },
                    { 26, 26 },
                    { 27, 27 },
                    { 28, 28 },
                    { 29, 29 },
                    { 30, 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBooks_AuthorId",
                table: "AuthorBooks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBooks");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
