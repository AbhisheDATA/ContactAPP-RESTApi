using ContactApplication_.Entities;
using ContactApplication_.Repository;
using ContactApplication_.Controllers;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ContactApplication_.Model;
using ContactApplication_.contactContract;

using System.Threading;
using Microsoft.EntityFrameworkCore;


namespace ContactApplication_.Test
{
    [TestFixture]
    public class TestContactController
    {
        private ContactsController contactsController;
        private Mock<IContact> _contactMock;
        private ContactRepository contactRepository;    


        [SetUp]
        public void Setup()
        {
            _contactMock = new Mock<IContact>();
            contactsController = new ContactsController(_contactMock.Object);
            contactRepository = new ContactRepository();
        }

        [Test]
        public void TestGettAllContact()
        {
            //Arrange
            List<Contact> contacts = new List<Contact>();




            //Act
            _contactMock.Setup(x => x.GetAllContact()).Returns(contacts);
            Assert.IsNotNull(contacts);
        }
        [Test]
        public async Task TestContactByid()
        {
            // Act
            var result = await contactsController.GetcontactByid(4);


            // Assert

            Assert.IsNotNull(result);
        }
       


    }



}










