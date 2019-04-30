using System;
using System.Security.Cryptography;

namespace CryptSharp.Internal
{
    static class Security
    {
        public static void Clear(Array array)
        {
            if (array != null) { Array.Clear(array, 0, array.Length); }
        }

        public static byte[] GenerateRandomBytes(int count)
        {
            Check.Range("count", count, 0, int.MaxValue);

            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] bytes = new byte[count]; rng.GetBytes(bytes); return bytes;
        }
    }
}
