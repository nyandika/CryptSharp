using System;

namespace CryptSharp.Internal
{
    static class Check
    {
        public static void Bounds(string valueName, Array value, int offset, int count)
        {
            Check.Null(valueName, value);

            if (offset < 0 || count < 0 || count > value.Length - offset)
            {
                throw Exceptions.ArgumentOutOfRange(valueName,
                                                    "Range [{0}, {1}) is outside array bounds [0, {2}).",
                                                    offset, offset + count, value.Length);
            }
        }

        public static void Length(string valueName, Array value, int minimum, int maximum)
        {
            Check.Null(valueName, value);

            if (value.Length < minimum || value.Length > maximum)
            {
                throw Exceptions.ArgumentOutOfRange(valueName,
                                                    "Length must be in the range [{0}, {1}].",
                                                    minimum, maximum);
            }
        }

        public static void Null<T>(string valueName, T value)
        {
            if (value == null)
            {
                throw Exceptions.ArgumentNull(valueName);
            }
        }

        public static void Range(string valueName, int value, int minimum, int maximum)
        {
            if (value < minimum || value > maximum)
            {
                throw Exceptions.ArgumentOutOfRange(valueName,
                                                    "Value must be in the range [{0}, {1}].",
                                                    minimum, maximum);
            }
        }
    }
}
