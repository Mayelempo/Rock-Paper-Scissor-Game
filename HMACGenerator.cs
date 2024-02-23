using System.Security.Cryptography;
using System.Text;

namespace Task_3
{
    public class HMACGenerator
    {
        public static string GenerateHMAC(string message, byte[] key)
        {
           using(var hmac = new HMACSHA256(key))
            {
                byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(message)); 
                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }
    }
}
