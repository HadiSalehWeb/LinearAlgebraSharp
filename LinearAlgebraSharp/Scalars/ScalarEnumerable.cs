using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinearAlgebraSharp.Scalars
{
    public static class ScalarEnumerable
    {
        public static Scalar<T> Sum<T>(this IEnumerable<Scalar<T>> list)
            where T : struct
        {
            Scalar<T> res = Scalar<T>.Zero;

            foreach (var sca in list)
                res += sca;

            return res;
        }

        public static Scalar<T> Average<T>(this IEnumerable<Scalar<T>> list)
            where T : struct
        {
            return list.Sum() / list.Count();
        }

        public static Scalar<T> Max<T>(this IEnumerable<Scalar<T>> list)
            where T : struct
        {
            var max = Scalar<T>.MinValue;

            foreach (var item in list)
                if (item > max)
                    max = item;

            return max;
        }

        public static Scalar<T> Min<T>(this IEnumerable<Scalar<T>> list)
            where T : struct
        {
            var min = Scalar<T>.MaxValue;

            foreach (var item in list)
                if (item < min)
                    min = item;

            return min;
        }
    }
}
