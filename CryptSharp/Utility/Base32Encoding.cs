using System.Collections.Generic;

namespace CryptSharp.Utility
{
    /// <summary>
    /// Base-32 binary to text encodings.
    /// 
    /// I needed multiple variations of base-64 for the various crypt algorithms, and base-16 (hex) for test vectors,
    /// so base-32 is mostly a freebie. It's great for e-mail verifications, product keys - really anywhere you need
    /// someone to type in a randomly-generated code.
    /// </summary>
    public static class Base32Encoding
    {
        static Base32Encoding()
        {
            Crockford = new BaseEncoding("0123456789ABCDEFGHJKMNPQRSTVWXYZ", false, new Dictionary<char, int>()
                {
                    { 'O', 0 },
                    { 'I', 1 },
                    { 'L', 1 },
                    { 'U', 27 }
                }, ch => char.ToUpperInvariant(ch));

            ZBase32 = new BaseEncoding("ybndrfg8ejkmcpqxot1uwisza345h769", true, new Dictionary<char, int>()
                {
                    { '0', 16 },
                    { 'l', 18 },
                    { 'v', 19 },
                    { '2', 23 },
                }, ch => char.ToLowerInvariant(ch));
        }

        /// <summary>
        /// Crockford base-32 is somewhat traditional, but still better than the RFC 4648 standard.
        /// It is specified at http://www.crockford.com/wrmg/base32.html.
        /// </summary>
        public static BaseEncoding Crockford
        {
            get;
            private set;
        }

        /// <summary>
        /// z-base-32 is a lowercase base-32 encoding designed to be easily hand-written and read.
        /// It is specified at http://www.zer7.com/files/oss/cryptsharp/zbase32.txt.
        /// </summary>
        public static BaseEncoding ZBase32
        {
            get;
            private set;
        }
    }
}
