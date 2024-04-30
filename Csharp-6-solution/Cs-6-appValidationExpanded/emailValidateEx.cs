using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cs_6_appValidationExpanded
{
    internal interface IemailValidateEx
    {
        
    }
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
}
