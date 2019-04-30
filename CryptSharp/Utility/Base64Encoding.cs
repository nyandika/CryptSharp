namespace CryptSharp.Utility
{
    /// <summary>
    /// Base-64 binary-to-text encodings.
    /// </summary>
    public static class Base64Encoding
    {
        static Base64Encoding()
        {
            Blowfish = new BaseEncoding("./ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", true);

            UnixCrypt = new BaseEncoding("./0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", true);

            UnixMD5 = new BaseEncoding("./0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", false);
        }

        /// <summary>
        /// Blowfish crypt orders characters differently from standard crypt, and begins encoding from
        /// the most-significant bit instead of the least-significant bit.
        /// </summary>
        public static BaseEncoding Blowfish
        {
            get;
            private set;
        }

        /// <summary>
        /// Traditional DES crypt base-64, as seen on Unix /etc/passwd, many websites, database servers, etc.
        /// </summary>
        public static BaseEncoding UnixCrypt
        {
            get;
            private set;
        }

        /// <summary>
        /// MD5, SHA256, and SHA512 crypt base-64, as seen on Unix /etc/passwd, many websites, database servers, etc.
        /// </summary>
        public static BaseEncoding UnixMD5
        {
            get;
            private set;
        }
    }
}
