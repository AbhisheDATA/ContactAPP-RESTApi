using ContactApplication_.contactContract;
using ContactApplication_.Entities;
using ContactApplication_.Model;
using Microsoft.EntityFrameworkCore;
namespace ContactApplication_.Repository
{
    public class FavouriteContactRepository : IFavouriteContact
    {
        private readonly ContactAppContext _appContext;


        public FavouriteContactRepository(ContactAppContext context)
        {
            _appContext = context;
        }
        public FavouriteContactRepository()
        {
            _appContext = new ContactAppContext();
        }
        public async Task AddToFavouriteList(int id)
        {
            try
            {
                var data = await _appContext.Contacts.FirstOrDefaultAsync(c => c.Id == id);
               
                
                FavouriteContact favouriteContact = new FavouriteContact()
                {
                    Id = data.Id,
                    Name = data.Name,
                    Age = data.Age,
                    PhoneNo = data.PhoneNo,
                    City = data.City,
                    Country = data.Country,
                    Email = data.Email,
                    Gender = data.Gender,
                    DateOfBirth = data.DateOfBirth
                };

                _appContext.Add(favouriteContact);
                await _appContext.SaveChangesAsync();



            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<FavouriteContact> GetFavrtContactById(int id)
        {
            try
            {
                FavouriteContact contact = await _appContext.Favourites.FindAsync(id);


                return contact;
            }
            catch (Exception)

            {
                throw;
            }

        }
        public async Task<List<FavouriteContact>> GetAllFavouriteContact()
        {
            try
            {
                List<FavouriteContact> contacts = await _appContext.Favourites.ToListAsync();


                return contacts;
            }
            catch (Exception)

            {
                throw;
            }

        }
        public async Task<List<FavouriteContact>> GetFvrtContactByName(string name)
        {
            try
            {
                List<FavouriteContact> contacts = await _appContext.Favourites.Where(x => x.Name == name).ToListAsync();

                return contacts;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteFvrtContactAsync(int id)
        {
            try
            {
                FavouriteContact favouriteContact = await _appContext.Favourites.FindAsync(id);
                if (favouriteContact != null)
                {
                    _appContext.Favourites.Remove(favouriteContact);
                    await _appContext.SaveChangesAsync();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
