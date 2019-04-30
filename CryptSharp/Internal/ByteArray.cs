using System;

namespace CryptSharp.Internal
{
    static class ByteArray
    {
        public static int NullTerminatedLength(byte[] buffer, int maxLength)
        {
            if (maxLength > buffer.Length) { maxLength = buffer.Length; }

            int length;
            for (length = 0; length < maxLength && buffer[length] != 0; length++) ;
            return length;
        }

        public static byte[] TruncateAndCopy(byte[] buffer, int maxLength)
        {
            byte[] truncatedBuffer = new byte[Math.Min(buffer.Length, maxLength)];
            Array.Copy(buffer, truncatedBuffer, truncatedBuffer.Length);
            return truncatedBuffer;
        }
    }
}
