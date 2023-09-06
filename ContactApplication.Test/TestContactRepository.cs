using ContactApplication.Entities;
using ContactApplication.Repository;
using ContactApplication.Model;
using ContactApplication.ContractApp;

namespace ContactApplication.Test
{
    public class Tests
    {
        private   ContactRepository contactRepository;
        private readonly ContactAppContext context;
        [SetUp]
        public void Setup()
        {
            contactRepository = new ContactRepository(context);
        }

        [Test]
        public async Task  TestGettAllContact()
        {
            //Arrange
            int count = 0;
            //Act
            List<Contact> contacts = await  contactRepository.GetAllContact();
            count = contacts.Count;
            Assert.IsNotNull(contacts);
            Assert.Greater(count, 0);
        }
    }
}