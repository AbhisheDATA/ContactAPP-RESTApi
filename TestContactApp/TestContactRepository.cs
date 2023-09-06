using ContactApplication_.Entities;
using ContactApplication_.Repository;
using ContactApplication_.Model;


namespace TestContactApp
{
    [TestFixture]
    public  class TestContactRepository
    {
        private ContactRepository contactRepository;

        [SetUp]
        public void Setup()
        {
            contactRepository = new ContactRepository();
        }

        [Test]
        public void TestGetAllContact()
        {
            //Arrange
            int count=0;
            //Act
            List<Contact> contacts=contactRepository.GetAllContact();   
            //Assert
            Assert.IsNotNull(contacts);
            count=contacts.Count(); 
            Assert.Greater(count, 0);
        }
        [Test]
        public async Task TestGetContactById()
        {
            //Arrange
            int id = 2;
            //Act
            Contact contact = await contactRepository.GetContactById(id);
            Assert.IsNotNull(contact);

        }
        [Test]
        public async Task TestGetContactByName()
        {
            //Arrange
            string name = "Borish";
            //Act
            var contact = await  contactRepository.GetContactByName(name);
            //Assert
            Assert.IsNotNull(contact);
        }
        [Test]
        public async Task TestAddContact()
        {
            //Act
            var contact = new Contact()
            {
                Name="Pratyush",
                PhoneNo="8409456044",
                Age=24,
                Email="pratyush12346@gmail.com",
                City="Muzzarfarpur",
                Country="India",
                Gender="Male",
                DateOfBirth=DateTime.Parse("2000.10.10")
             };
            await contactRepository.AddContactAsync(contact);
            //Act
            var contacts = contactRepository.GetContactById(3);
            //Assert
            Assert.IsNotNull(contacts);
        }
        [Test]
        public async Task TestDeleteContact()
        {
            //Arrange
            int id = 4;
            //Act
            await contactRepository.DeleteContactAsync(id); 
            var contact= await contactRepository.GetContactById(id);    
            //Assert
            Assert.IsNull(contact);


        }
        [Test]
        public async Task TestUpdateContact()
        {
            var contact = new ContactModel()
            {
                Id=3,
                Name = "Pratyush",
                PhoneNo = "8409456044",
                Age = 22,
                Email = "pratyush1234@gmail.com",
                City = "Muzzarfarpur",
                Country = "India",
                Gender = "Male",
                DateOfBirth = DateTime.Parse("2000.10.10")
            };
            //Act
            await contactRepository.UpdateContactAsync(contact.Id,contact);
            Contact contact1 = await contactRepository.GetContactById(contact.Id);
            //Assert
            Assert.That(contact1.Age, Is.EqualTo(contact.Age));
        }

    }
}
