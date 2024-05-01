using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BookStore.Identity;
public sealed class BookStoreIdentityDbContextFactory
    : IDesignTimeDbContextFactory<BookStoreIdentityDbContext>
{
    public BookStoreIdentityDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<BookStoreIdentityDbContext>();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("BookStoreIdentityConnection"));

        return new BookStoreIdentityDbContext(optionsBuilder.Options);
    }
}
