using ContactApplication_.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ContactApplication_.Entities
{
    public class ContactAppContext : IdentityDbContext<ApplicationUser>
    {
        public ContactAppContext(DbContextOptions<ContactAppContext> options) : base(options)
        {

        }
        public ContactAppContext()
        {

        }



        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<FavouriteContact>? Favourites { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DotNetFSD\\SQLEXPRESS;Initial Catalog=ContactAppDB101;MultipleActiveResultSets=true;Persist Security Info=True;User ID=sa;Password=pass@123");
        }


        //Connection string in Program file

    }
}

