using System.Text.RegularExpressions;
using Cs_6_appValidationExpanded;
using Moq;

namespace TestValidationsExpanded
{
    [TestClass]
    public class TestEmailValid
    {
        [TestMethod]
        public void Is_email_valid()
        {
            // Arrange
            var email = "thisemailisvalid@validemails.com";
            var mockValidator = new Mock<emailValidateEx>();

            // Act
            var result = mockValidator.Object.validateEmail(email);
            
            // Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void Is_email_repeated()
        {
            // Arrange
            var email = "thisemailisvalid@validemails.com";
            var mockValidator = new Mock<emailValidateEx>();

            // Act
            mockValidator.Object.emails.Add(email);
            var result = mockValidator.Object.validateEmail(email);

            // Assert
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void Is_email_invalid()
        {
            // Arrange
            var email = "thisemailisNOTvalid-INvalidemails.com";
            var mockValidator = new Mock<emailValidateEx>();

            // Act
            var result = mockValidator.Object.validateEmail(email);

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}