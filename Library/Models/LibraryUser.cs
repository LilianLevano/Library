using Library.Data;
using Microsoft.AspNetCore.Identity;

namespace Library.Models
{
    public class LibraryUser : IdentityUser
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }

        static public async Task Seeder(LibraryDbContext context, UserManager<LibraryUser> userManager)
        {
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new List<IdentityRole>
                    {
                        new IdentityRole{ Id = "Administrator", Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
                        new IdentityRole{ Id = "User", Name = "User", NormalizedName = "USER" }
                    });
                

                context.Users.Add(new LibraryUser
                {
                    Id = "Dummy",
                    UserName = "?",
                    Achternaam = "?",
                    Voornaam = "?",
                    Email = "?@?.?",

                });
                await context.SaveChangesAsync();

                LibraryUser admin = new LibraryUser
                {
                    Voornaam = "Admin",
                    Achternaam = "Admin",
                    UserName = "Admin",
                    Email = "admin@test.com",

                };

                var result = await userManager.CreateAsync(admin, "Admin1234!");

                await userManager.AddToRolesAsync(admin, ["Administrator", "User"]);


            }
        }

    }
}
