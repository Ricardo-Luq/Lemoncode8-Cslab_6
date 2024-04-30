

namespace cs6_app_mailValidation
{
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
}
