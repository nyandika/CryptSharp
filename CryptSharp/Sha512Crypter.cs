using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace CryptSharp
{
    /// <summary>
    /// SHA512 crypt. A reasonable choice if you cannot use Blowfish crypt for policy reasons.
    /// </summary>
    public class Sha512Crypter : ShaCrypter
    {
        static readonly Regex _regex = CreateDefaultRegex("$6$", 86);

        protected override HashAlgorithm CreateHashAlgorithm()
        {
            return System.Security.Cryptography.SHA512.Create();
        }

        protected override int[] GetCryptPermutation()
        {
            return new[]
            {
                42, 21, 0,
                1, 43, 22,
                23, 2, 44,
                45, 24, 3,
                4, 46, 25,
                26, 5, 47,
                48, 27, 6,
                7, 49, 28,
                29, 8, 50,
                51, 30, 9,
                10, 52, 31,
                32, 11, 53,
                54, 33, 12,
                13, 55, 34,
                35, 14, 56,
                57, 36, 15,
                16, 58, 37,
                38, 17, 59,
                60, 39, 18,
                19, 61, 40,
                41, 20, 62,
                63
            };
        }

        protected override Regex GetRegex()
        {
            return _regex;
        }

        protected override string CryptPrefix
        {
            get { return "$6$"; }
        }
    }
}
