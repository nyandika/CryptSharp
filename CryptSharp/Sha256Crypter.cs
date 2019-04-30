using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace CryptSharp
{
    /// <summary>
    /// SHA256 crypt. A reasonable choice if you cannot use Blowfish crypt for policy reasons.
    /// </summary>
    public class Sha256Crypter : ShaCrypter
    {
        static readonly Regex _regex = CreateDefaultRegex("$5$", 43);

        protected override HashAlgorithm CreateHashAlgorithm()
        {
            return System.Security.Cryptography.SHA256.Create();
        }

        protected override int[] GetCryptPermutation()
        {
            return new[]
            {
                20, 10, 0,
                11, 1, 21,
                2, 22, 12,
                23, 13, 3,
                14, 4, 24,
                5, 25, 15,
                26, 16, 6,
                17, 7, 27,
                8, 28, 18,
                29, 19, 9,
                30, 31
            };
        }

        protected override Regex GetRegex()
        {
            return _regex;
        }

        protected override string CryptPrefix
        {
            get { return "$5$"; }
        }
    }
}
