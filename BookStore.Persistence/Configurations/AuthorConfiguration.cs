using BookStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.AuthorName)
                .HasColumnType("varchar")
                .HasMaxLength(100).IsRequired();

            builder.HasOne(x => x.Book)
                .WithMany(x => x.Authors)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            builder.HasData(SeedDatabase.GetAuthors());

            builder.ToTable("Authors");
        }
    }
}
