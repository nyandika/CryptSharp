using System;
using System.Collections.Generic;
using System.Text;

namespace CryptSharp
{
    /// <summary>
    /// Options that modify the LDAP crypt operation.
    /// </summary>
    public class LdapCrypterOption : CrypterOption
    {
        /// <summary>
        /// The crypter to use with <see cref="LdapCrypterVariant.Crypt"/>.
        /// </summary>
        public static readonly CrypterOptionKey Crypter = new CrypterOptionKey("Crypter", typeof(Crypter));

        /// <summary>
        /// The options to pass to the crypter specified by <see cref="LdapCrypterOption.Crypter"/>.
        /// </summary>
        public static readonly CrypterOptionKey CrypterOptions = new CrypterOptionKey("CrypterOptions", typeof(CrypterOptions));

        protected LdapCrypterOption()
        {

        }
    }
}
