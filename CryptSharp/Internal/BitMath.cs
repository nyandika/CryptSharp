namespace CryptSharp.Internal
{
    static class BitMath
    {
        public static int CountLeadingZeros(int value)
        {
            int count;
            for (count = 0; count < 32 && 0 == (value & (0x80000000 >> count)); count++) ;
            return count;
        }

        public static bool IsPositivePowerOf2(int value)
        {
            return 0 < value && 0 == (value & (value - 1));
        }

        public static byte ReverseBits(byte value)
        {
            byte reversed = (byte)((((ulong)value * 0x80200802) & 0x884422110) * 0x101010101 >> 32);
            return reversed;
        }

        public static byte ShiftLeft(byte value, int bits)
        {
            return (byte)(bits > 0 ? value << bits : value >> (-bits));
        }

        public static byte ShiftRight(byte value, int bits)
        {
            return ShiftLeft(value, -bits);
        }

        public static void Swap<T>(ref T left, ref T right)
        {
            T temp;
            temp = right;
            right = left;
            left = temp;
        }
    }
}
