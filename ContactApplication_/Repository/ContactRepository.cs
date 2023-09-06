using ContactApplication_.contactContract;
using ContactApplication_.Entities;
using ContactApplication_.Model;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ContactApplication_.Controllers;

namespace ContactApplication_.Repository
{
    public class ContactRepository : IContact
    {
        private readonly ContactAppContext _appContext;
        public ContactRepository(ContactAppContext context)
        {
            _appContext = context;
        }
        public ContactRepository()
        {
            _appContext = new ContactAppContext();
        }



        public async Task<int> AddContactAsync(Contact contact)
        {
            try
            {
                
                _appContext.Add(contact);
                await _appContext.SaveChangesAsync();
                return contact.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Contact> GetContactById(int id)
        {
            try
            {
                Contact contact = await _appContext.Contacts.FindAsync(id);


                return contact;
            }
            catch (Exception)

            {
                throw;
            }

        }
        public List<Contact> GetAllContact()
        {
            try
            {
               


                return _appContext.Contacts.ToList();
            }
            catch (Exception)

            {
                throw;
            }

        }
        public async Task<List<Contact>> GetContactByName(string name)
        {
            try
            {
                List<Contact> contacts = await _appContext.Contacts.Where(x => x.Name == name).ToListAsync();

                return contacts;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Contact> UpdateContactAsync(int id, ContactModel contactModel)
        {
            try
            {
                var contact = new Contact()
                {
                    Id = id,
                    Name = contactModel.Name,
                    Gender = contactModel.Gender,
                    PhoneNo = contactModel.PhoneNo,
                    Age = contactModel.Age,
                    City = contactModel.City,
                    Country = contactModel.Country,
                    DateOfBirth = contactModel.DateOfBirth,
                    Email = contactModel.Email,

                };

                FavouriteContact favouriteContact = await _appContext.Favourites.FindAsync(id);
                if (favouriteContact != null)
                {
                    favouriteContact.Id = id;
                    favouriteContact.Name = contactModel.Name;
                    favouriteContact.Age = contactModel.Age;
                    favouriteContact.PhoneNo = contactModel.PhoneNo;
                    favouriteContact.Gender = contactModel.Gender;
                    favouriteContact.City = contactModel.City;
                    favouriteContact.Email = contactModel.Email;
                    favouriteContact.Country = contactModel.Country;
                    favouriteContact.DateOfBirth = contactModel.DateOfBirth;
                    _appContext.Favourites.Update(favouriteContact);
                    await _appContext.SaveChangesAsync();
                }

                _appContext.Contacts.Update(contact);
                await _appContext.SaveChangesAsync();
                return contact;

            }
            catch (Exception)
            {
                throw;
            }


        }

        public async Task DeleteContactAsync(int id)
        {
            try
            {
                Contact contact = await _appContext.Contacts.FindAsync(id);
                if (contact != null)
                {
                    FavouriteContact favouriteContact = await _appContext.Favourites.FindAsync(id);
                    if (favouriteContact != null)
                    {
                        _appContext.Favourites.Remove(favouriteContact);
                        await _appContext.SaveChangesAsync();
                    }
                    _appContext.Contacts.Remove(contact);
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
