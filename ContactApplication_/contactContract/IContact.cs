using ContactApplication_.Model;
using ContactApplication_.Entities;
namespace ContactApplication_.contactContract
{

    public interface IContact
    {
        Task<int> AddContactAsync(Contact contact);
        Task<Contact> GetContactById(int id);
        List<Contact> GetAllContact();

        Task<List<Contact>> GetContactByName(string name);

        Task<Contact> UpdateContactAsync(int id, ContactModel contactModel);
        Task DeleteContactAsync(int id);


    }
}