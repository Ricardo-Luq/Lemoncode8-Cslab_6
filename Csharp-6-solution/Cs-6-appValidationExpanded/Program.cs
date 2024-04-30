namespace Cs_6_appValidationExpanded;

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
}
