using System.Security.Cryptography;

namespace Task_3
{
    public class KeyGenerator
    {
        public static byte[] GenerateKey()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] key = new byte[32];
                rng.GetBytes(key);
                return key;
            }
        }
    }
}
