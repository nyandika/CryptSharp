using CryptSharp.Internal;
using System.Runtime.CompilerServices;

namespace CryptSharp.Utility
{
    /// <summary>
    /// Provides comparison methods resistant to timing attack.
    /// </summary>
    public static class SecureComparison
    {
        /// <summary>
        /// Compares two strings in a timing-insensitive manner.
        /// </summary>
        /// <param name="potentialAttackerSuppliedString">The string controlled by a potential attacker.</param>
        /// <param name="referenceString">The string not controlled by a potential attacker.</param>
        /// <returns><c>true</c> if the strings are equal.</returns>
        /// <remarks>
        ///     If the reference string is zero-length, this method does not protect it against timing attacks.
        ///     If the reference string is extremely long, memory caching effects may reveal that fact.
        /// </remarks>
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static bool Equals(string potentialAttackerSuppliedString, string referenceString)
        {
            Check.Null("potentialAttackerSuppliedString", potentialAttackerSuppliedString);
            Check.Null("referenceString", referenceString);

            if (referenceString.Length == 0)
            {
                return potentialAttackerSuppliedString.Length == 0;
            }

            int attackLength = potentialAttackerSuppliedString.Length;
            int referenceLength = referenceString.Length;

            int differences = attackLength ^ referenceLength;
            for (int i = 0; i < potentialAttackerSuppliedString.Length; i++)
            {
                differences |= potentialAttackerSuppliedString[i] ^ referenceString[i % referenceString.Length];
            }
            return differences == 0;
        }
    }
}
