namespace CryptSharp
{
    /// <summary>
    /// Properties inherent to particular crypt algorithms. 
    /// </summary>
    public class CrypterProperty
    {
        /// <summary>
        /// The maximum password length. Bytes beyond this length will have no effect.
        /// </summary>
        public static readonly CrypterOptionKey MaxPasswordLength = new CrypterOptionKey("MaxPasswordLength", typeof(int));

        /// <summary>
        /// The minimum number for <see cref="CrypterOption.Rounds"/>.
        /// </summary>
        public static readonly CrypterOptionKey MinRounds = new CrypterOptionKey("MinRounds", typeof(int));

        /// <summary>
        /// The maximum number for <see cref="CrypterOption.Rounds"/>.
        /// </summary>
        public static readonly CrypterOptionKey MaxRounds = new CrypterOptionKey("MaxRounds", typeof(int));

        protected CrypterProperty()
        {

        }
    }
}
