namespace Holistic3D_courses.Mathematics_for_gamedev.Bitwise_operations
{
    public static class BitwiseUtils
    {
        public static void SetFlag(ref int result, int mask)
        {
            result |= mask;
        }
        
        public static void RemoveFlag(ref int result, int mask)
        {
            result &= ~mask;
        }
        
        public static void ToggleFlag(ref int result, int mask)
        {
            result ^= mask;
        }
        
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