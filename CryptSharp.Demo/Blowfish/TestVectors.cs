using CryptSharp.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace CryptSharp.Demo.Blowfish
{
    static class TestVectors
    {
        public static void Test()
        {
            Console.Write("Testing Blowfish");
            using (Stream stream =
                Assembly.GetExecutingAssembly().GetManifestResourceStream
                ("CryptSharp.Demo.Blowfish.TestVectors.txt"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Match match = Regex.Match(line, @"^([0-9A-z]{16})\s*([0-9A-z]{16})\s*([0-9A-z]{16})$");
                        if (!match.Success) { continue; }

                        string key = match.Groups[1].Value, clear = match.Groups[2].Value, cipher = match.Groups[3].Value;
                        byte[] keyBytes = Base16Encoding.Hex.GetBytes(key);
                        byte[] clearBytes = Base16Encoding.Hex.GetBytes(clear);

                        Console.Write(".");
                        using (Utility.BlowfishCipher fish = Utility.BlowfishCipher.Create(keyBytes))
                        {
                            byte[] testCipherBytes = new byte[8]; fish.Encipher(clearBytes, 0, testCipherBytes, 0);
                            string testCipher = Base16Encoding.Hex.GetString(testCipherBytes);
                            if (cipher != testCipher) { Console.WriteLine("WARNING: Encipher failed test ({0} became {1})", cipher, testCipher); }

                            byte[] testClearBytes = new byte[8]; fish.Decipher(testCipherBytes, 0, testClearBytes, 0);
                            string testClear = Base16Encoding.Hex.GetString(testClearBytes);
                            if (clear != testClear) { Console.WriteLine("WARNING: Decipher failed ({0} became {1})", clear, testClear); }
                        }
                    }
                }
            }

            Console.WriteLine("done.");
        }
    }
}
