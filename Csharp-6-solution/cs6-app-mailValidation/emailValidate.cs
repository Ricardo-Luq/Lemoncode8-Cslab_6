using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cs6_app_mailValidation
{
    public class emailValidate
    { 
        public bool validateEmail(string email)
        {
            string emailValidation_rgx = @"^([\w\d._%-]+@[\w\d.-]+\.[\w]{2,})$";
            return Regex.IsMatch(email, emailValidation_rgx);
        }

    }
}
