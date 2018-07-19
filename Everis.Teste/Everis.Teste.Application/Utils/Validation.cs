using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Everis.Teste.Application.Utils
{
    public static class Validation
    {
        public static void MailAddresValidation(string address)
        {
            string emailRegex = string.Format("{0}{1}",
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))",
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");

            try
            {
                bool valid = Regex.IsMatch(
                    address,
                    emailRegex);

                if (!valid)
                    throw new ArgumentException("Email inválido");
            }
            catch (RegexMatchTimeoutException)
            {
                throw new ArgumentException("Email inválido");
            }
        }
        public static void NameValidation(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 3)
                throw new ArgumentException("Nome inválido");
        }
    }
}
