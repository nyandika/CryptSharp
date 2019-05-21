using System;

namespace CryptSharp.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseEncoding.TestVectors.Test();
            Blowfish.TestVectors.Test();
            Pbkdf2Test.TestVectors.Test();
            SCryptTest.TestVectors.Test();
            CrypterTest.TestVectors.Test();

            Console.WriteLine();

            Console.WriteLine("Now a simple BCrypt demo.");
            string crypt = CryptSharp.Crypter.Blowfish.GenerateSalt();
            Console.WriteLine("Our salt is: {0}", crypt);

            for (int i = 0; i < 10; i++)
            {
                // Try this against PHP's crypt('password', 'output of this function').
                crypt = CryptSharp.Crypter.Blowfish.Crypt("Hello World!", crypt);
                Console.WriteLine(crypt);
            }

            Console.WriteLine();

            Console.WriteLine("CryptSharp can also generate Apache-compatible htpasswd MD5...");
            Console.WriteLine("   (it does require an additional parameter)");
            Console.WriteLine("The password HelloWorld crypts to: {0}",
                Crypter.MD5.Crypt("HelloWorld", new CrypterOptions
                    {
                        { CrypterOption.Variant, MD5CrypterVariant.Apache }
                    }));

            Console.WriteLine();

            Console.WriteLine("WordPress uses portable PHPass passwords.");
            string wpPassword = Crypter.Phpass.Crypt("HelloWorld");
            Console.WriteLine("The password HelloWorld crypts to: {0}", wpPassword);
            Console.WriteLine("The above statement is {0}.", Crypter.CheckPassword("HelloWorld", wpPassword));
            Console.WriteLine("It is {0} that the password is OpenSesame.", Crypter.CheckPassword("OpenSesame", wpPassword));

            Console.WriteLine();

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }
    }
}
