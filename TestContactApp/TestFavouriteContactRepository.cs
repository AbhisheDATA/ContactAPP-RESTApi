using ContactApplication_.Entities;
using ContactApplication_.Repository;
using ContactApplication_.Model;


namespace TestContactApp
{
    [TestFixture]
    public  class TestFavouriteContactRepository
    {
        private FavouriteContactRepository favouriteContact;

        [SetUp]
        public void Setup()
        {
            favouriteContact = new FavouriteContactRepository();
        }
        [Test]
        public async Task TestGetAllFavouriteContact()
        {
            //Arrange
            int count = 0;
            //Act
            List<FavouriteContact> contacts = await  favouriteContact.GetAllFavouriteContact();
            //Assert
            Assert.IsNotNull(contacts);
            count = contacts.Count();
            Assert.That(count, Is.EqualTo(2));
        }
        [Test]
        public async Task TestGetFavouriteContactById()
        {
            //Arrange
            int id = 5;
            //Act
            FavouriteContact contact = await favouriteContact.GetFavrtContactById(id);
            Assert.IsNotNull(contact);

        }
        [Test]
        public async Task TestGetContactByName()
        {
            //Arrange
            string name = "Abhimanyu";
            //Act
            var contact = await favouriteContact.GetFvrtContactByName(name);
            //Assert
            Assert.IsNotNull(contact);
        }
        [Test]
        public async Task TestAddFavouriteContact()
        {
            //Arrange
            int id = 2;
            //Act
            await favouriteContact.AddToFavouriteList(id);
            FavouriteContact contact = await favouriteContact.GetFavrtContactById(id);
            //Assert
            Assert.IsNotNull(contact);


        }
        [Test]
        public async Task TestDeleteFavouriteContact()
        {
            //Arrange
            int id = 2;
            //Act
            await favouriteContact.DeleteFvrtContactAsync(id);
            FavouriteContact contact = await favouriteContact.GetFavrtContactById(id);
            //Assert
            Assert.IsNull(contact);
        }
    }
}
