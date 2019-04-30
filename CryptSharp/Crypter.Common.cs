using System;
using System.Collections.Generic;
using System.Text;

namespace CryptSharp
{
    partial class Crypter
    {
        static Crypter()
        {
            Blowfish = new BlowfishCrypter();
            TraditionalDes = new TraditionalDesCrypter();
            ExtendedDes = new ExtendedDesCrypter();
            Ldap = new LdapCrypter(CrypterEnvironment.Default);
            MD5 = new MD5Crypter();
            Phpass = new PhpassCrypter();
            Sha256 = new Sha256Crypter();
            Sha512 = new Sha512Crypter();

            IList<Crypter> crypters = CrypterEnvironment.Default.Crypters;
            crypters.Add(Crypter.Blowfish);
            crypters.Add(Crypter.MD5);
            crypters.Add(Crypter.Phpass);
            crypters.Add(Crypter.Sha256);
            crypters.Add(Crypter.Sha512);
            crypters.Add(Crypter.Ldap);
            crypters.Add(Crypter.ExtendedDes);
            crypters.Add(Crypter.TraditionalDes);
        }

        /// <summary>
        /// Blowfish crypt, sometimes called BCrypt. A very good choice.
        /// </summary>
        public static BlowfishCrypter Blowfish
        {
            get;
            private set;
        }

        /// <summary>
        /// Traditional DES crypt.
        /// </summary>
        public static TraditionalDesCrypter TraditionalDes
        {
            get;
            private set;
        }

        /// <summary>
        /// Extended DES crypt.
        /// </summary>
        public static ExtendedDesCrypter ExtendedDes
        {
            get;
            private set;
        }

        /// <summary>
        /// LDAP schemes such as {SHA}.
        /// </summary>
        public static LdapCrypter Ldap
        {
            get;
            private set;
        }

        /// <summary>
        /// MD5 crypt, supported by nearly all systems. A variant supports Apache htpasswd files.
        /// </summary>
        public static MD5Crypter MD5
        {
            get;
            private set;
        }

        /// <summary>
        /// PHPass crypt. Used by WordPress. Variants support phpBB and Drupal 7+.
        /// </summary>
        public static PhpassCrypter Phpass
        {
            get;
            private set;
        }

        /// <summary>
        /// SHA256 crypt. A reasonable choice if you cannot use Blowfish crypt for policy reasons.
        /// </summary>
        public static Sha256Crypter Sha256
        {
            get;
            private set;
        }

        /// <summary>
        /// SHA512 crypt. A reasonable choice if you cannot use Blowfish crypt for policy reasons.
        /// </summary>
        public static Sha512Crypter Sha512
        {
            get;
            private set;
        }
    }
}
