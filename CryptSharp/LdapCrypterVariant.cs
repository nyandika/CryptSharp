namespace CryptSharp
{
    /// <summary>
    /// LDAP password schemes.
    /// </summary>
    public enum LdapCrypterVariant
    {
        /// <summary>
        /// Salted SHA-1. This is the default.
        /// </summary>
        SSha = 0,

        /// <summary>
        /// Unsalted SHA-1. Used in htpasswd files.
        /// </summary>
        Sha = 1,

        /// <summary>
        /// Salted SHA-256.
        /// </summary>
        SSha256 = 6,

        /// <summary>
        /// Unsalted SHA-256.
        /// </summary>
        Sha256 = 7,

        /// <summary>
        /// Salted SHA-384.
        /// </summary>
        SSha384 = 8,

        /// <summary>
        /// Unsalted SHA-384.
        /// </summary>
        Sha384 = 9,

        /// <summary>
        /// Salted SHA-512.
        /// </summary>
        SSha512 = 10,

        /// <summary>
        /// Unsalted SHA-512.
        /// </summary>
        Sha512 = 11,

        /// <summary>
        /// Salted MD-5.
        /// </summary>
        SMD5 = 2,

        /// <summary>
        /// Unsalted MD-5.
        /// </summary>
        MD5 = 3,

        /// <summary>
        /// No crypt operation is performed. The password can be read easily.
        /// </summary>
        Cleartext = 4,

        /// <summary>
        /// Any crypt algorithm.
        /// 
        /// If you specify this for <see cref="CrypterOption.Variant"/>,
        /// you must also set <see cref="LdapCrypterOption.Crypter"/>
        /// and may optionally set <see cref="LdapCrypterOption.CrypterOptions"/>.
        /// </summary>
        Crypt = 5
    }
}
