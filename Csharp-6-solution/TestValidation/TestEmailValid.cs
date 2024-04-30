using cs6_app_mailValidation;

namespace TestValidation
{
    [TestClass]
    public class TestEmailValid
    {
        [TestMethod]
        public void Is_email_valid()
        {
            // Arrange
            var emailValidator = new emailValidate();
            var email = "thisemailisvalid@validemails.com";
            // Act
            var result = emailValidator.validateEmail(email);
            // Assert
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void Is_email_invalid()
        {
            // Arrange
            var emailValidator = new emailValidate();
            var email = "thisemailisNOTvalid-INvalidemails.com";
            // Act
            var result = emailValidator.validateEmail(email);
            // Assert
            Assert.AreEqual(false, result);
        }
    }
}