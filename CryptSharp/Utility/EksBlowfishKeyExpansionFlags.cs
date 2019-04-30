using System;

namespace CryptSharp.Utility
{   /// <summary>
    /// Modifiers for Expensive Key Schedule (EKS) Blowfish key expansion behavior.
    /// </summary>
    [Flags]
    public enum EksBlowfishKeyExpansionFlags
    {
        /// <summary>
        /// Default behavior.
        /// </summary>
        None = 0,

        /// <summary>
        /// The EksBlowfish code in CryptSharp was implemented as per the specification
        /// at http://static.usenix.org/event/usenix99/provos/provos_html/node4.html.
        /// 
        /// Many other BCrypt implementations, however, are ports originating
        /// originating with the crypt_blowfish C implementation. Pre-2011, crypt_blowfish
        /// had a sign extension bug that caused up to three characters previous to any
        /// 8-bit character to match 0xFF.
        /// 
        /// CryptSharp never had this bug. However, for those who need backwards
        /// compatibility for old password databases created with one of these libraries,
        /// I have added *support* for the bug. You can enable it with this flag.
        /// </summary>
        EmulateCryptBlowfishSignExtensionBug = 1
    }
}
