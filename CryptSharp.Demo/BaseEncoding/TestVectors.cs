using CryptSharp.Utility;
using System;
using System.Text;

namespace CryptSharp.Demo.BaseEncoding
{
    static class TestVectors
    {
        public static void Test()
        {
            Console.Write("Testing Base16");
            TestConversion(Base16Encoding.Hex, new byte[] { 0xba, 0xad, 0xf0, 0x0d }, "BAADF00D");
            TestDone();

            Console.Write("Testing Base32");
            TestConversion(Base32Encoding.Crockford, BitConverter.GetBytes((ushort)1234), "J610");
            // These values are from the z-base-32 design document.
            TestConversion(Base32Encoding.ZBase32, new byte[] { 0x00 }, "yy");
            TestConversion(Base32Encoding.ZBase32, new byte[] { 0xf0, 0xbf, 0xc7 }, "6n9hq");
            TestConversion(Base32Encoding.ZBase32, new byte[] { 0xd4, 0x7a, 0x04 }, "4t7ye");
            TestDone();

            Console.Write("Testing Base64");
            TestConversion(Base64Encoding.Blowfish, new byte[] { 0x00, 0x01, 0x02 }, "..CA");
            TestConversion(Base64Encoding.UnixMD5, new byte[] { 0x00, 0x01, 0x02 }, ".2U.");
            TestDone();
        }

        static void TestConversion(Encoding encoding, byte[] testBytes, string expectedString)
        {
            Console.Write(".");

            string actualString = encoding.GetString(testBytes);
            if (actualString != expectedString)
            {
                Console.WriteLine("{0} resulted in '{1}' instead of expected '{2}'.",
                    encoding, actualString, expectedString);
                return;
            }

            byte[] roundtripBytes = encoding.GetBytes(actualString);
            if (roundtripBytes.Length != testBytes.Length)
            {
                Console.WriteLine("{0} had {1} bytes, not {2} bytes, on roundtrip for string '{3}'.",
                    encoding, roundtripBytes.Length, testBytes.Length, expectedString);
                return;
            }

            for (int i = 0; i < testBytes.Length; i++)
            {
                if (roundtripBytes[i] != testBytes[i])
                {
                    Console.WriteLine("{0} had '{1}' not '{2}' at index {3} for string '{4}'.",
                        encoding, roundtripBytes[i], testBytes[i], i, expectedString);
                    return;
                }
            }
        }

        static void TestDone()
        {
            Console.WriteLine("done.");
        }
    }
}
