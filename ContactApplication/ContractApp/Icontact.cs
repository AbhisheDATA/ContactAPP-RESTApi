using ContactApplication.Model;
using ContactApplication.Entities;
namespace ContactApplication.ContractApp
{
    public interface Icontact
    {
      public  Task<int> AddContactAsync(Contact contact);
      public   Task<Contact> GetContactById(int id);
        public Task<List<Contact>> GetAllContact();

       public Task<List<Contact>> GetContactByName(string name);

      public   Task<Contact> UpdateContactAsync(int id, ContactModel contactModel);
       public Task DeleteContactAsync(int id);


    }
}
