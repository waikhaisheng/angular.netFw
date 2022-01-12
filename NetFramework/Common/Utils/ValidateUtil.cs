using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Utils
{
    public static class ValidateUtil
    {
        public static bool ValidateEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static bool ValidatePhone(string phone)
        {
            if (phone == null)
            {
                throw new ArgumentNullException();
            }
            var reg = @"(?:\+?(\d+))";
            Regex rx = new Regex(reg, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return rx.IsMatch(phone, 0);
        }
    }
}
