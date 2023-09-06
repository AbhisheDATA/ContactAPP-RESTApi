using ContactApplication.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ContactApplication.Entities
{
    public class ContactAppContext : IdentityDbContext<ApplicationUser>
    {
        public ContactAppContext(DbContextOptions<ContactAppContext> options):base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }    
        public DbSet<FavouriteContact> Favourites { get; set; }
        

        //Connection string in Program file

    }
}
