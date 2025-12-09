namespace Holistic3D_courses.Mathematics_for_gamedev.Bitwise_operations
{
    public static class BitwiseUtils
    {
        /// <summary>
        /// Use bitwise OR to set mask in result
        /// </summary>
        public static void SetFlag(ref int result, int mask)
        {
            result |= mask;
        }

        /// <summary>
        /// Use bitwise AND with NOT flag to unset mask in result
        /// </summary>
        public static void RemoveFlag(ref int result, int mask)
        {
            result &= ~mask;
        }

        /// <summary>
        /// Use bitwise XOR to toggle mask in result
        /// </summary>
        public static void ToggleFlag(ref int result, int mask)
        {
            result ^= mask;
        }

        /// <summary>
        /// Use bitwise AND to check if the result contains a mask
        /// </summary>
        public static bool HasFlag(int result, int mask)
        {
            return (result & mask) == mask;
        }

        public static bool HasAnyFlag(int result, int mask)
        {
            return (result & mask) != 0;
        }
    }
}