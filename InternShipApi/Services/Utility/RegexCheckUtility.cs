using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace InternShipApi.Services.Utility
{
    public class RegexCheckUtility
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(100));

                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();

                    string domainname = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainname;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            try
            {
                return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
