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
                    AuthorName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: true)
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
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "Id", "AuthorName", "BookId" },
                values: new object[,]
                {
                    { 1, "George Orwell", null },
                    { 2, "Harper Lee", null },
                    { 3, "F. Scott Fitzgerald", null },
                    { 4, "Jane Austen", null },
                    { 5, "J. D. Salinger", null },
                    { 6, "J. K. Rowling", null },
                    { 7, "J. R. R. Tolkien", null },
                    { 8, "J. R. R. Tolkien", null },
                    { 9, "George Orwell", null },
                    { 10, "C. S. Lewis", null },
                    { 11, "Dan Brown", null },
                    { 12, "Paulo Coelho", null },
                    { 13, "Stieg Larsson", null },
                    { 14, "Gillian Flynn", null },
                    { 15, "Suzanne Collins", null },
                    { 16, "Douglas Adams", null },
                    { 17, "Charlotte Brontë", null },
                    { 18, "Aldous Huxley", null },
                    { 19, "Herman Melville", null },
                    { 20, "George R. R. Martin", null },
                    { 21, "Cormac McCarthy", null },
                    { 22, "Khaled Hosseini", null },
                    { 23, "Emily Brontë", null },
                    { 24, "Fyodor Dostoyevsky", null },
                    { 25, "Oscar Wilde", null },
                    { 26, "Mary Shelley", null },
                    { 27, "Alexandre Dumas", null },
                    { 28, "Sylvia Plath", null },
                    { 29, "Stephen King", null },
                    { 30, "William Golding", null }
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
                columns: new[] { "Id", "GenreId", "Price", "PublicationYear", "Title" },
                values: new object[,]
                {
                    { 1, 24, 10.99m, 1949, "1984" },
                    { 2, 7, 12.99m, 1960, "To Kill a Mockingbird" },
                    { 3, 14, 9.99m, 1925, "The Great Gatsby" },
                    { 4, 2, 8.99m, 1813, "Pride and Prejudice" },
                    { 5, 14, 11.99m, 1951, "The Catcher in the Rye" },
                    { 6, 4, 15.99m, 1997, "Harry Potter and the Philosopher's Stone" },
                    { 7, 4, 18.99m, 1954, "The Lord of the Rings" },
                    { 8, 4, 14.99m, 1937, "The Hobbit" },
                    { 9, 14, 10.99m, 1945, "Animal Farm" },
                    { 10, 4, 17.99m, 1950, "The Chronicles of Narnia" },
                    { 11, 1, 13.99m, 2003, "The Da Vinci Code" },
                    { 12, 21, 11.99m, 1988, "The Alchemist" },
                    { 13, 15, 14.99m, 2005, "The Girl with the Dragon Tattoo" },
                    { 14, 15, 12.99m, 2012, "Gone Girl" },
                    { 15, 16, 10.99m, 2008, "The Hunger Games" },
                    { 16, 4, 9.99m, 1979, "The Hitchhiker's Guide to the Galaxy" },
                    { 17, 2, 8.99m, 1847, "Jane Eyre" },
                    { 18, 24, 12.99m, 1932, "Brave New World" },
                    { 19, 4, 15.99m, 1851, "Moby-Dick" },
                    { 20, 4, 20.99m, 1996, "A Game of Thrones" },
                    { 21, 24, 11.99m, 2006, "The Road" },
                    { 22, 24, 13.99m, 2003, "The Kite Runner" },
                    { 23, 2, 10.99m, 1847, "Wuthering Heights" },
                    { 24, 15, 14.99m, 1866, "Crime and Punishment" },
                    { 25, 14, 9.99m, 1890, "The Picture of Dorian Gray" },
                    { 26, 6, 11.99m, 1818, "Frankenstein" },
                    { 27, 14, 16.99m, 1844, "The Count of Monte Cristo" },
                    { 28, 9, 12.99m, 1963, "The Bell Jar" },
                    { 29, 6, 13.99m, 1977, "The Shining" },
                    { 30, 6, 10.99m, 1954, "Lord of the Flies" }
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
