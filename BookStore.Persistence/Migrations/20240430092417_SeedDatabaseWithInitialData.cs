using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabaseWithInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 24);
        }
    }
}
