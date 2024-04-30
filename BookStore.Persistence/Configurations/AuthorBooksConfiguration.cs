using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.Configurations;
internal class AuthorBooksConfiguration : IEntityTypeConfiguration<AuthorBooks>
{
    public void Configure(EntityTypeBuilder<AuthorBooks> builder)
    {
        builder.HasKey(x => new { x.BookId, x.AuthorId });

        builder.HasData(SeedDatabase.GetAuthorBooks());

        builder.ToTable("AuthorBooks");
    }
}
