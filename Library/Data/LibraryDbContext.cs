using Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : IdentityDbContext<LibraryUser>(options)
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public async Task Seeder(UserManager<LibraryUser> userManager)
        {
            await Database.MigrateAsync();

            await LibraryUser.Seeder(this, userManager);
        }
    }
}
