using BookStore.Domain;

namespace BookStore.Persistence;

public static class SeedDatabase
{
    public static IEnumerable<Genre> GetGenres()
    {
        List<Genre> genres =
        [
            new Genre { Id = 1, GenreName = "Mystery" },
            new Genre { Id = 2, GenreName = "Romance" },
            new Genre { Id = 3, GenreName = "Science Fiction" },
            new Genre { Id = 4, GenreName = "Fantasy" },
            new Genre { Id = 5, GenreName = "Thriller" },
            new Genre { Id = 6, GenreName = "Horror" },
            new Genre { Id = 7, GenreName = "Historical Fiction" },
            new Genre { Id = 8, GenreName = "Biography" },
            new Genre { Id = 9, GenreName = "Memoir" },
            new Genre { Id = 10, GenreName = "Self-help" },
            new Genre { Id = 11, GenreName = "Travel" },
            new Genre { Id = 12, GenreName = "Poetry" },
            new Genre { Id = 13, GenreName = "Comedy" },
            new Genre { Id = 14, GenreName = "Drama" },
            new Genre { Id = 15, GenreName = "Crime Fiction" },
            new Genre { Id = 16, GenreName = "Action and Adventure" },
            new Genre { Id = 17, GenreName = "Children's" },
            new Genre { Id = 18, GenreName = "Young Adult" },
            new Genre { Id = 19, GenreName = "Paranormal" },
            new Genre { Id = 20, GenreName = "Urban Fantasy" },
            new Genre { Id = 21, GenreName = "Non-fiction" },
            new Genre { Id = 22, GenreName = "Satire" },
            new Genre { Id = 23, GenreName = "Western" },
            new Genre { Id = 24, GenreName = "Dystopian" },
            new Genre { Id = 25, GenreName = "Fairy Tale" },
            new Genre { Id = 26, GenreName = "LGBTQ+" },
            new Genre { Id = 27, GenreName = "War" },
            new Genre { Id = 28, GenreName = "Spiritual" },
            new Genre { Id = 29, GenreName = "Philosophy" },
            new Genre { Id = 30, GenreName = "Classic" }
        ];

        return genres;
    }

    public static IEnumerable<Book> GetBooks()
    {
        List<Book> books =
        [
            new Book { Id = 1, Title = "1984", PublicationYear = 1949, Price = 10.99m, GenreId = 24 },
            new Book { Id = 2, Title = "To Kill a Mockingbird", PublicationYear = 1960, Price = 12.99m, GenreId = 7 },
            new Book { Id = 3, Title = "The Great Gatsby", PublicationYear = 1925, Price = 9.99m, GenreId = 14 },
            new Book { Id = 4, Title = "Pride and Prejudice", PublicationYear = 1813, Price = 8.99m, GenreId = 2 },
            new Book { Id = 5, Title = "The Catcher in the Rye", PublicationYear = 1951, Price = 11.99m, GenreId = 14 },
            new Book { Id = 6, Title = "Harry Potter and the Philosopher's Stone", PublicationYear = 1997, Price = 15.99m, GenreId = 4 },
            new Book { Id = 7, Title = "The Lord of the Rings", PublicationYear = 1954, Price = 18.99m, GenreId = 4 },
            new Book { Id = 8, Title = "The Hobbit", PublicationYear = 1937, Price = 14.99m, GenreId = 4 },
            new Book { Id = 9, Title = "Animal Farm", PublicationYear = 1945, Price = 10.99m, GenreId = 14 },
            new Book { Id = 10, Title = "The Chronicles of Narnia", PublicationYear = 1950, Price = 17.99m, GenreId = 4 },
            new Book { Id = 11, Title = "The Da Vinci Code", PublicationYear = 2003, Price = 13.99m, GenreId = 1 },
            new Book { Id = 12, Title = "The Alchemist", PublicationYear = 1988, Price = 11.99m, GenreId = 21 },
            new Book { Id = 13, Title = "The Girl with the Dragon Tattoo", PublicationYear = 2005, Price = 14.99m, GenreId = 15 },
            new Book { Id = 14, Title = "Gone Girl", PublicationYear = 2012, Price = 12.99m, GenreId = 15 },
            new Book { Id = 15, Title = "The Hunger Games", PublicationYear = 2008, Price = 10.99m, GenreId = 16 },
            new Book { Id = 16, Title = "The Hitchhiker's Guide to the Galaxy", PublicationYear = 1979, Price = 9.99m, GenreId = 4 },
            new Book { Id = 17, Title = "Jane Eyre", PublicationYear = 1847, Price = 8.99m, GenreId = 2 },
            new Book { Id = 18, Title = "Brave New World", PublicationYear = 1932, Price = 12.99m, GenreId = 24 },
            new Book { Id = 19, Title = "Moby-Dick", PublicationYear = 1851, Price = 15.99m, GenreId = 4 },
            new Book { Id = 20, Title = "A Game of Thrones", PublicationYear = 1996, Price = 20.99m, GenreId = 4 },
            new Book { Id = 21, Title = "The Road", PublicationYear = 2006, Price = 11.99m, GenreId = 24 },
            new Book { Id = 22, Title = "The Kite Runner", PublicationYear = 2003, Price = 13.99m, GenreId = 24 },
            new Book { Id = 23, Title = "Wuthering Heights", PublicationYear = 1847, Price = 10.99m, GenreId = 2 },
            new Book { Id = 24, Title = "Crime and Punishment", PublicationYear = 1866, Price = 14.99m, GenreId = 15 },
            new Book { Id = 25, Title = "The Picture of Dorian Gray", PublicationYear = 1890, Price = 9.99m, GenreId = 14 },
            new Book { Id = 26, Title = "Frankenstein", PublicationYear = 1818, Price = 11.99m, GenreId = 6 },
            new Book { Id = 27, Title = "The Count of Monte Cristo", PublicationYear = 1844, Price = 16.99m, GenreId = 14 },
            new Book { Id = 28, Title = "The Bell Jar", PublicationYear = 1963, Price = 12.99m, GenreId = 9 },
            new Book { Id = 29, Title = "The Shining", PublicationYear = 1977, Price = 13.99m, GenreId = 6 },
            new Book { Id = 30, Title = "Lord of the Flies", PublicationYear = 1954, Price = 10.99m, GenreId = 6 }
        ];
        return books;
    }

    public static IEnumerable<Author> GetAuthors()
    {
        List<Author> authors =
        [
            new Author { Id = 1,  AuthorName = "George Orwell", }, // 1984
            new Author { Id = 2,  AuthorName = "Harper Lee", }, // To Kill a Mockingbird
            new Author { Id = 3,  AuthorName = "F. Scott Fitzgerald", }, // The Great Gatsby
            new Author { Id = 4,  AuthorName = "Jane Austen", }, // Pride and Prejudice
            new Author { Id = 5,  AuthorName = "J. D. Salinger", }, // The Catcher in the Rye
            new Author { Id = 6,  AuthorName = "J. K. Rowling", }, // Harry Potter and the Philosopher's Stone
            new Author { Id = 7,  AuthorName = "J. R. R. Tolkien", }, // The Lord of the Rings
            new Author { Id = 8,  AuthorName = "J. R. R. Tolkien", }, // The Hobbit
            new Author { Id = 9,  AuthorName = "George Orwell", }, // Animal Farm
            new Author { Id = 10, AuthorName = "C. S. Lewis", }, // The Chronicles of Narnia
            new Author { Id = 11, AuthorName = "Dan Brown", }, // The Da Vinci Code
            new Author { Id = 12, AuthorName = "Paulo Coelho", }, // The Alchemist
            new Author { Id = 13, AuthorName = "Stieg Larsson", }, // The Girl with the Dragon Tattoo
            new Author { Id = 14, AuthorName = "Gillian Flynn", }, // Gone Girl
            new Author { Id = 15, AuthorName = "Suzanne Collins", }, // The Hunger Games
            new Author { Id = 16, AuthorName = "Douglas Adams", }, // The Hitchhiker's Guide to the Galaxy
            new Author { Id = 17, AuthorName = "Charlotte Brontë", }, // Jane Eyre
            new Author { Id = 18, AuthorName = "Aldous Huxley", }, // Brave New World
            new Author { Id = 19, AuthorName = "Herman Melville", }, // Moby-Dick
            new Author { Id = 20, AuthorName = "George R. R. Martin", }, // A Game of Thrones
            new Author { Id = 21, AuthorName = "Cormac McCarthy", }, // The Road
            new Author { Id = 22, AuthorName = "Khaled Hosseini" }, // The Kite Runner
            new Author { Id = 23, AuthorName = "Emily Brontë", }, // Wuthering Heights
            new Author { Id = 24, AuthorName = "Fyodor Dostoyevsky" }, // Crime and Punishment
            new Author { Id = 25, AuthorName = "Oscar Wilde", }, // The Picture of Dorian Gray
            new Author { Id = 26, AuthorName = "Mary Shelley", }, // Frankenstein
            new Author { Id = 27, AuthorName = "Alexandre Dumas", }, // The Count of Monte Cristo
            new Author { Id = 28, AuthorName = "Sylvia Plath", }, // The Bell Jar
            new Author { Id = 29, AuthorName = "Stephen King", }, // The Shining
            new Author { Id = 30, AuthorName = "William Golding", }, // Lord of the Flies  
        ];
        return authors;
    }

    public static IEnumerable<AuthorBooks> GetAuthorBooks()
    {
        return
        [
            new AuthorBooks { AuthorId = 1, BookId = 1 },
            new AuthorBooks { AuthorId = 2, BookId = 2 },
            new AuthorBooks { AuthorId = 3, BookId = 3 },
            new AuthorBooks { AuthorId = 4, BookId = 4 },
            new AuthorBooks { AuthorId = 5, BookId = 5 },
            new AuthorBooks { AuthorId = 6, BookId = 6 },
            new AuthorBooks { AuthorId = 7, BookId = 7 },
            new AuthorBooks { AuthorId = 8, BookId = 8 },
            new AuthorBooks { AuthorId = 9, BookId = 9 },
            new AuthorBooks { AuthorId = 10, BookId = 10 },
            new AuthorBooks { AuthorId = 11, BookId = 11 },
            new AuthorBooks { AuthorId = 12, BookId = 12 },
            new AuthorBooks { AuthorId = 13, BookId = 13 },
            new AuthorBooks { AuthorId = 14, BookId = 14 },
            new AuthorBooks { AuthorId = 15, BookId = 15 },
            new AuthorBooks { AuthorId = 16, BookId = 16 },
            new AuthorBooks { AuthorId = 17, BookId = 17 },
            new AuthorBooks { AuthorId = 18, BookId = 18 },
            new AuthorBooks { AuthorId = 19, BookId = 19 },
            new AuthorBooks { AuthorId = 20, BookId = 20 },
            new AuthorBooks { AuthorId = 21, BookId = 21 },
            new AuthorBooks { AuthorId = 22, BookId = 22 },
            new AuthorBooks { AuthorId = 23, BookId = 23 },
            new AuthorBooks { AuthorId = 24, BookId = 24 },
            new AuthorBooks { AuthorId = 25, BookId = 25 },
            new AuthorBooks { AuthorId = 26, BookId = 26 },
            new AuthorBooks { AuthorId = 27, BookId = 27 },
            new AuthorBooks { AuthorId = 28, BookId = 28 },
            new AuthorBooks { AuthorId = 29, BookId = 29 },
            new AuthorBooks { AuthorId = 30, BookId = 30 }
        ];
    }
}