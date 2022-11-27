using System.Collections.Generic;

namespace GameEngine.Tests
{
    public class TestDamageHealthData
    {
        private static readonly List<int[]> Data = new List<int[]>
        {
            new int[] { 0, 100 },
            new int[] { 1, 99 },
            new int[] { 50, 50 },
            new int[] { 101, 1 },
        };

        public static IEnumerable<int[]> TestData => Data;

        // only object[] array can work with X-unit, primitives like int[] can't
        public static IEnumerable<object[]> TestDataYield
        {
            get {
                yield return new object[] { 0, 100 };
                yield return new object[] { 1, 99 };
                yield return new object[] { 50, 50 };
                yield return new object[] { 101, 1 };
            }
        }
    }
}