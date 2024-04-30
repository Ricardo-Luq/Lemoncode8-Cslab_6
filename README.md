# Lemoncode8-Cslab6
Laboratory made for learning about basic C# unit test development

## Tasks:
### 1. The app will ask for an email and confirm if it is valid. This will continue until "quit" is introduced as an email.
The objective is to create all the necesary tests to check if the validation is working correctly.
- in cs6-app-mailValidation/Program.cs
```cs
 internal class Program
    {
        static void Main(string[] args)
        {
            bool doLoop = true;
            Console.WriteLine("[Email validator]\n");
            do
            {
                var emailVal = new emailValidate();
                Console.WriteLine("> Enter an email to validate (or quit to exit)\n");
                var currentEmail = Console.ReadLine().ToLower();
                if (currentEmail != "quit") 
                { 
                    if (emailVal.validateEmail(currentEmail))
                    {
                        Console.WriteLine("\n> Email VALID\n");
                    } 
                    else
                    {
                        Console.WriteLine("\n> Email INVALID\n");
                    }
                } else { doLoop = false; }
            } while (doLoop);  
        }
    }
```
- in cs6-app-mailValidation/emailValidate.cs
```cs
public class emailValidate
    { 
        public bool validateEmail(string email)
        {
            string emailValidation_rgx = @"^([\w\d._%-]+@[\w\d.-]+\.[\w]{2,})$";
            return Regex.IsMatch(email, emailValidation_rgx);
        }
    }
```
- in TestValidation/TestEmailValid.cs
```cs
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
```
### 2. Modify the previous exercise so that emails are stored in memory. If an email had been inputted previously, show the following message:

> "The email has already been validated"

Use Moq to isolate checking if the email has already been introduced.
- in Cs-6-appValidationExpanded/Program.cs
```cs
internal class Program
{
    static void Main(string[] args)
    {
        bool doLoop = true;
        Console.WriteLine("[Email validator]\n");
        var emailVal = new emailValidateEx();

        do
        {
            Console.WriteLine("> Enter an email to validate (or quit to exit)\n");
            var currentEmail = Console.ReadLine().ToLower();
            if (currentEmail != "quit")
            {
                switch (emailVal.validateEmail(currentEmail))
                {
                    case -1:
                        Console.WriteLine("\n ERROR: This email has been validated already");
                        break;
                    case 0:
                        Console.WriteLine("\n> ERROR: Email INVALID\n");
                        break;
                    case 1:
                        Console.WriteLine("\n> Email VALID\n");
                        break;
                }
            }
            else { doLoop = false; }
        } while (doLoop);
    }
```
- in Cs-6-appValidationExpanded/emailValidateEx.cs
```cs
 public class emailValidateEx
    { 
        public List<string> emails = new List<string>();
        public int validateEmail(string email)
        {
            string emailValidation_rgx = @"^([\w\d._%-]+@[\w\d.-]+\.[\w]{2,})$";
            if (Regex.IsMatch(email, emailValidation_rgx)) // Checks if it is an email
            { // It is an email, then check if it was already input'd 
                if (emails.Contains(email))
                { //It was introduced previously
                    return -1;
                }
                else
                { //It is a new email
                    emails.Add(email);
                    return 1;
                }
            } 
            else
            { // It is not a valid email
                return 0; 
            }
        }

    }
```
- in TestValidationsExpanded/TestEmailValidMoq.cs
```cs
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
```
