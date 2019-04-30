using System;
using System.Collections.Generic;
using System.Text;

namespace CryptSharp.Utility
{
    /// <summary>
    /// Base-16 binary-to-text encodings.
    /// </summary>
    public static class Base16Encoding
    {
        static Base16Encoding()
        {
            Hex = new BaseEncoding("0123456789ABCDEF", true, null, ch => char.ToUpperInvariant(ch));
        }

        /// <summary>
        /// Hexadecimal base-16 uses the numbers 0-9 for 0-9, and the letters A-F for 10-15.
        /// </summary>
        public static BaseEncoding Hex
        {
            get;
            private set;
        }
    }
}
