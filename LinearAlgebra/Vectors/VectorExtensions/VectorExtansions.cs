using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra.Vectors.VectorExtensions
{
    public static class VectorExtansions
    {
        public static Vector1<TResult> Select<T, TResult>(this Vector1<T> t, Func<T, TResult> func)
            where T : struct, IComparable
            where TResult : struct, IComparable
        {
            return new Vector1<TResult>(func(t.x.Value));
        }
        public static Vector1<TResult> Select<T, TResult>(this Vector1<T> t, Func<T, int, TResult> func)
            where T : struct, IComparable
            where TResult : struct, IComparable
        {
            return new Vector1<TResult>(func(t.x.Value, 0));
        }

        public static Vector2<TResult> Select<T, TResult>(this Vector2<T> t, Func<T, TResult> func)
            where T : struct, IComparable
            where TResult : struct, IComparable
        {
            return new Vector2<TResult>(func(t.x.Value), func(t.y.Value));
        }
        public static Vector2<TResult> Select<T, TResult>(this Vector2<T> t, Func<T, int, TResult> func)
            where T : struct, IComparable
            where TResult : struct, IComparable
        {
            return new Vector2<TResult>(func(t.x.Value, 0), func(t.y.Value, 1));
        }
        public static T Aggregate<T>(this Vector2<T> t, Func<T, T, T> func)
            where T : struct, IComparable
        {
            return func(t.x.Value, t.y.Value);

        }
        public static TAccumulate Aggregate<T, TAccumulate>(this Vector2<T> t, TAccumulate seed, Func<TAccumulate, T, TAccumulate> func)
            where T : struct, IComparable
        {
            return func(func(seed, t.x.Value), t.y.Value);
        }

        public static Vector3<TResult> Select<T, TResult>(this Vector3<T> t, Func<T, TResult> func)
            where T : struct, IComparable
            where TResult : struct, IComparable
        {
            return new Vector3<TResult>(func(t.x.Value), func(t.y.Value), func(t.z.Value));
        }
        public static Vector3<TResult> Select<T, TResult>(this Vector3<T> t, Func<T, int, TResult> func)
            where T : struct, IComparable
            where TResult : struct, IComparable
        {
            return new Vector3<TResult>(func(t.x.Value, 0), func(t.y.Value, 1), func(t.z.Value, 2));
        }
    }
}
