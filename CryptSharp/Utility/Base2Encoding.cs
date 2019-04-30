using System;
using System.Collections.Generic;
using System.Text;

namespace CryptSharp.Utility
{
    /// <summary>
    /// Base-2 binary-to-text encodings.
    /// </summary>
    public static class Base2Encoding
    {
        static Base2Encoding()
        {
            Binary = new BaseEncoding("01", true);
        }

        /// <summary>
        /// Binary. Useful for debugging.
        /// </summary>
        public static BaseEncoding Binary
        {
            get;
            private set;
        }
    }
}
