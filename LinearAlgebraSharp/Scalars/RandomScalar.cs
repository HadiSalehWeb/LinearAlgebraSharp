using System;

namespace LinearAlgebraSharp.Scalars
{
    public class RandomScalar<T>
        where T : struct
    {
        private readonly Random rand;

        public RandomScalar(int seed)
        {
            rand = new Random(seed);
        }

        /// <summary>
        /// Returns a random number that is greater than or equal to Scalar&lt;<typeparamref name="T"/>&gt;.MinValue, and less than or equal to Scalar&lt;<typeparamref name="T"/>&gt;.MaxValue.
        /// </summary>
        public Scalar<T> Next()
        {
            double next = rand.NextDouble(), min = Scalar<T>.MinValue, max = Scalar<T>.MaxValue;
            return min - min * next + max * next;
        }

        /// <summary>
        /// Returns a random number that is greater than or equal to Scalar&lt;<typeparamref name="T"/>&gt;.Zero, and less than Scalar&lt;<typeparamref name="T"/>&gt;.One.
        /// </summary>
        public Scalar<T> NextBetweenZeroOne()
        {
            double next = rand.NextDouble();

            if (Scalar<T>.algebraicStructure <= AlgebraicStructure.Ring)
                return next < .5 ? Scalar<T>.Zero : Scalar<T>.One;

            return next;
        }
    }
}
