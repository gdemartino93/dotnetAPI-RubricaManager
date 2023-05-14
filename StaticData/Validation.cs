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
        //VALIDATE A TELEPHONE NUMBER
        public static bool IsValidTelephone(string telephone)
        {
            // regex per validare il numero di telefono
            //deve iniziare con +39 o 39 o niente e deve avere 9 o 10 cifre

            string pattern = @"^(\+[0-9]{2,3})?[0-9]{9,10}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(telephone);
        }

    }
}
