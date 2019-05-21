using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using CryptSharp.Utility;

namespace CryptSharp.Demo.Pbkdf2Test
{
    static class TestVectors
    {
        public static void Test()
        {
            Console.Write("Testing PBKDF2");

            // Data Source: http://tools.ietf.org/html/draft-josefsson-pbkdf2-test-vectors-02#page-3
            TestSHA1("password", "salt", 1, 20,
                @"0c 60 c8 0f 96 1f 0e 71
                f3 a9 b5 24 af 60 12 06
                2f e0 37 a6");
            TestSHA1("password", "salt", 2, 20,
                @"ea 6c 01 4d c7 2d 6f 8c
                cd 1e d9 2a ce 1d 41 f0
                d8 de 89 57");
            TestSHA1("password", "salt", 4096, 20,
                @"4b 00 79 01 b7 65 48 9a
                be ad 49 d9 26 f7 21 d0
                65 a4 29 c1");
            TestSHA1("passwordPASSWORDpassword", "saltSALTsaltSALTsaltSALTsaltSALTsalt", 4096, 25,
                @"3d 2e ec 4f e4 1c 84 9b
                80 c8 d8 36 62 c0 e4 4a
                8b 29 1a 96 4c f2 f0 70
                38");
            TestSHA1("pass\0word", "sa\0lt", 4096, 16,
                @"56 fa 6a a7 55 48 09 9d
                  cc 37 d7 f0 34 25 e0 c3");

            // The test vector file is generated with PHP 5.5+.
            TestFile("CryptSharp.Demo.Pbkdf2.TestVectors-PBKDF2.txt");

            Console.WriteLine("done.");
        }

        static void TestSHA1(string password, string salt, int c, int len,
            string expected)
        {
            Console.Write(".");

            byte[] keyBytes = Encoding.ASCII.GetBytes(password);
            byte[] saltBytes = Encoding.ASCII.GetBytes(salt);
            byte[] derivedBytes = Utility.Pbkdf2.ComputeDerivedKey(new HMACSHA1(keyBytes), saltBytes, c, len);

            expected = expected
                .Replace(" ", "")
                .Replace("\r", "")
                .Replace("\n", "")
                .Replace("\t", "")
                .ToUpper();
            string derived = Base16Encoding.Hex.GetString(derivedBytes);
            if (expected != derived) { Console.WriteLine("WARNING: PBKDF2 failed test ({0} instead of {1})", derived, expected); }
        }

        static void TestFile(string filename)
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(filename))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    int startTime = Environment.TickCount;

                    string line; int count = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.Write(".");

                        string[] parts = line.Split(new[] { ',' }, 4);
                        if (parts.Length != 4) { continue; }

                        byte[] key = Convert.FromBase64String(parts[0]);
                        byte[] salt = Convert.FromBase64String(parts[1]);
                        int iterations = int.Parse(parts[2]);
                        byte[] expectedKey = Convert.FromBase64String(parts[3]);
                        byte[] derivedKey = Pbkdf2.ComputeDerivedKey(new HMACSHA256(key), salt, iterations, 128);

                        for (int i = 0; i < expectedKey.Length; i++)
                        {
                            if (expectedKey[i] != derivedKey[i])
                            {
                                Console.WriteLine("PBKDF2 entry #{0} does not match.", count + 1);
                                break;
                            }
                        }

                        count++;
                    }

                    Console.Write("...({0} ms for {1} vectors)...", Environment.TickCount - startTime, count);
                }
            }
        }
    }
}
