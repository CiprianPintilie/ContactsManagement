using BusinessLayer.Services;
using DataAccessLayer.Entities;
using DataAccessLayer.Interop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLayer.UnitTests
{
    [TestClass]
    public class CompanyServiceUnitTests
    {
        [TestMethod]
        public void CompanyDataConflictsAsync_ShouldReturnTrue_IfACompanyAlreadyExistsWithTheProvidedVatAndName()
        {
            //Arrange

            const string EXISTING_NAME = "Some NAME";
            const string EXISTING_VAT = "Some VAT";

            var companyCommandMock = new Mock<ICompanyCommand>();
            var companyQueryMock = new Mock<ICompanyQuery>();

            companyQueryMock
                .Setup(i => i.GetByNameAsync(EXISTING_NAME))
                .ReturnsAsync(new CompanyEntity());
            companyQueryMock
                .Setup(i => i.GetByVatAsync(EXISTING_VAT))
                .ReturnsAsync(new CompanyEntity());

            //Act

            var companyService = new CompanyService(companyCommandMock.Object, companyQueryMock.Object);
            var result = companyService.CompanyDataConflictsAsync(EXISTING_NAME, EXISTING_VAT).Result;

            //Assert

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CompanyDataConflictsAsync_ShouldReturnFalse_IfNoCompanyExistsWithProvidedVatOrName()
        {
            //Arrange

            const string EXISTING_NAME = "Some NAME";
            const string EXISTING_VAT = "Some VAT";

            var companyCommandMock = new Mock<ICompanyCommand>();
            var companyQueryMock = new Mock<ICompanyQuery>();

            companyQueryMock
                .Setup(i => i.GetByNameAsync(EXISTING_NAME))
                .ReturnsAsync((CompanyEntity)null);
            companyQueryMock
                .Setup(i => i.GetByVatAsync(EXISTING_VAT))
                .ReturnsAsync((CompanyEntity)null);

            //Act

            var companyService = new CompanyService(companyCommandMock.Object, companyQueryMock.Object);
            var result = companyService.CompanyDataConflictsAsync(EXISTING_NAME, EXISTING_VAT).Result;

            //Assert

            Assert.IsFalse(result);
        }
    }
}
