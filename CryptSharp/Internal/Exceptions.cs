using System;

namespace CryptSharp.Internal
{
    static class Exceptions
    {
        public static ArgumentException Argument
            (string valueName, string message, params object[] args)
        {
            message = string.Format(message, args);
            ArgumentException e = valueName == null
                ? new ArgumentException(message)
                : new ArgumentException(message, valueName);
            return e;
        }

        public static ArgumentNullException ArgumentNull(string valueName)
        {
            ArgumentNullException e = valueName == null
                ? new ArgumentNullException()
                : new ArgumentNullException(valueName);
            return e;
        }

        public static ArgumentOutOfRangeException ArgumentOutOfRange
            (string valueName, string message, params object[] args)
        {
            message = string.Format(message, args);
            ArgumentOutOfRangeException e = valueName == null
                ? new ArgumentOutOfRangeException(message, (Exception)null)
                : new ArgumentOutOfRangeException(valueName, message);
            return e;
        }

        public static InvalidOperationException InvalidOperation()
        {
            InvalidOperationException e = new InvalidOperationException();
            return e;
        }

        public static NotSupportedException NotSupported()
        {
            return new NotSupportedException();
        }
    }
}
