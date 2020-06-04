using System;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace SWLAPI.ClassesExtension
{
    public static class MailAddressExtension
    {
        public static string GetSHA1(this MailAddress mailAddress)
        {
            var retVal = default(string);
            var sha1 = SHA1.Create();

            var byteArray = sha1.ComputeHash(Encoding.UTF8.GetBytes(mailAddress.Address));
            var hex = new StringBuilder(byteArray.Length * 2);
            foreach (var b in byteArray)
                hex.AppendFormat("{0:x2}", b);
            retVal = hex.ToString();
            return retVal;
        }
    }
}