using System;
using System.Security.Cryptography;

namespace DesafioUBC.Uteis
{
    public class CriptografiaPassword
    {
        public static string ComputeMd5Hash(string pass)
        {
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(pass);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
