using System;

namespace SwarmAlgorithm.Utils
{
    public static class RandomWrap
    {
        private static readonly Random _random;

        static RandomWrap()
        {
            _random = new Random();
        }

        public static float NextFloat()
        {
            return (float)_random.NextDouble();
            // double mantissa = (_random.NextDouble() * 2.0) - 1.0;
            // double exponent = Math.Pow(2.0, _random.Next(-126, 128));
            // return (float)(mantissa * exponent);
        }
    }
}