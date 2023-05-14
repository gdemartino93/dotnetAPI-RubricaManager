using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StaticData
{
    public class Validation
    {
        public static bool IsValidEmail(string email)
        {
            // regex per validare l'email
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
    }
}
