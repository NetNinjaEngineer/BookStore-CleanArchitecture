using BookStore.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Identity;
public sealed class BookStoreIdentityDbContext
    (DbContextOptions options) : IdentityDbContext<ApplicationUser>(options)
{

}
