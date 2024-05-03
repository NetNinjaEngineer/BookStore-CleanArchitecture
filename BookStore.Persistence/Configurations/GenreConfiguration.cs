using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.Configurations;

public sealed class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(x => x.GenreId);
        builder.Property(x => x.GenreId).ValueGeneratedOnAdd();

        builder.Property(x => x.GenreName)
            .HasColumnType("varchar").HasMaxLength(50)
            .IsRequired();

        builder.HasData(SeedDatabase.GetGenres());

        builder.ToTable("Genres");
    }
}
