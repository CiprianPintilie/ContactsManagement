using BusinessLayer.Models;
using BusinessLayer.Services;
using DataAccessLayer.Interop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLayer.UnitTests
{
    [TestClass]
    public class ContactServiceUnitTests
    {
        [TestMethod]
        public void ContactDataIsValidRegardingType_ShouldReturnFalse_IfContactIsEmployeeAndHaveVat()
        {
            //Arrange

            var contact = new ContactModel
            {
                Type = ContactType.EMPLOYEE,
                Vat = "Some VAT"
            };

            var contactCommandMock = new Mock<IContactCommand>();
            var contactQueryMock = new Mock<IContactQuery>();

            //Act

            var contactService = new ContactService(contactCommandMock.Object, contactQueryMock.Object);

            var result = contactService.ContactDataIsValidRegardingType(contact);

            //Assert

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ContactDataIsValidRegardingType_ShouldReturnFalse_IfContactIsFreelanceAndDoesNotHaveVat()
        {
            //Arrange

            var contact = new ContactModel
            {
                Type = ContactType.FREELANCE
            };

            var contactCommandMock = new Mock<IContactCommand>();
            var contactQueryMock = new Mock<IContactQuery>();

            //Act

            var contactService = new ContactService(contactCommandMock.Object, contactQueryMock.Object);

            var result = contactService.ContactDataIsValidRegardingType(contact);

            //Assert

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ContactDataIsValidRegardingType_ShouldReturnTrue_IfContactIsFreelanceAndDoesHaveVat()
        {
            //Arrange

            var contact = new ContactModel
            {
                Type = ContactType.FREELANCE,
                Vat = "Some VAT"
            };

            var contactCommandMock = new Mock<IContactCommand>();
            var contactQueryMock = new Mock<IContactQuery>();

            //Act

            var contactService = new ContactService(contactCommandMock.Object, contactQueryMock.Object);

            var result = contactService.ContactDataIsValidRegardingType(contact);

            //Assert

            Assert.IsTrue(result);
        }
    }
}
