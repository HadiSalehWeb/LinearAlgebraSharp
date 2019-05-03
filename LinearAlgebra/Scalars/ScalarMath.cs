using System;
using System.Collections.Generic;
using System.Text;

namespace LinearAlgebra.Scalars
{
    public class ScalarMath<T>
        where T : struct
    {
        #region Constants

        private static readonly Scalar<T>? _e;
        private static readonly Scalar<T>? _pi;

        public static Scalar<T> E
        {
            get
            {
                if (!_e.HasValue) throw new Exception("E is only defined on types that accept a decimal point.");
                return _e.Value;
            }
        }
        public static Scalar<T> PI
        {
            get
            {
                if (!_pi.HasValue) throw new Exception("PI is only defined on types that accept a decimal point.");
                return _pi.Value;
            }
        }

        static ScalarMath()
        {
            if (Scalar<T>.algebraicStructure == Scalar<T>.AlgebraicStructure.Field)
            {
                _e = Math.E;
                _pi = Math.PI;
            }
            else
            {
                _e = null;
                _pi = null;
            }
        }

        #endregion

        #region Universal Functions

        public Scalar<int> Sign(Scalar<T> s)
        {
            return s >= 0 ? Scalar<int>.One : Scalar<int>.One.Negate();
        }

        public Scalar<T> Abs(Scalar<T> s)
        {
            return s < Scalar<T>.Zero ? s.Negate() : s;
        }

        public Scalar<T> Min(Scalar<T> s1, Scalar<T> s2)
        {
            return s1 < s2 ? s1 : s2;
        }

        public Scalar<T> Max(Scalar<T> s1, Scalar<T> s2)
        {
            return s1 > s2 ? s1 : s2;
        }

        #endregion

        #region Field Functions

        internal static Scalar<T> Sqrt(Scalar<T> s)
        {
            double sqrt = Math.Sqrt(s);

            if (Scalar<T>.algebraicStructure == Scalar<T>.AlgebraicStructure.Field || sqrt % 1 == 0)
                return sqrt;

            throw new Exception($"Square root of { s.ToString() }: Scalar<{typeof(T).Name}> contains a decimal point and can't be casted back to Scalar<{typeof(T).Name}>.");
        }

        public Scalar<T> Floor(Scalar<T> s)
        {
            if (Scalar<T>.algebraicStructure <= Scalar<T>.AlgebraicStructure.Ring)
                return s;


            if (s is Scalar<double> d)
                return Math.Floor(d.Value);
            if (s is Scalar<float> f)
                return (float)Math.Floor(f.Value);
            if (s is Scalar<decimal> m)
                return Math.Floor(m.Value);

            throw new Exception("Unrecognized scalar type.");
        }

        public Scalar<T> Ceiling(Scalar<T> s)
        {
            if (Scalar<T>.algebraicStructure <= Scalar<T>.AlgebraicStructure.Ring)
                return s;


            if (s is Scalar<double> d)
                return Math.Ceiling(d.Value);
            if (s is Scalar<float> f)
                return (float)Math.Ceiling(f.Value);
            if (s is Scalar<decimal> m)
                return Math.Ceiling(m.Value);

            throw new Exception("Unrecognized scalar type.");
        }

        public Scalar<T> Sin(Scalar<T> s)
        {
            if (s is Scalar<double> d)
                return Math.Sin(d.Value);
            if (s is Scalar<float> f)
                return (float)Math.Sin(f.Value);
            if (s is Scalar<decimal> m)
                return (decimal)Math.Sin((double)m.Value);

            throw new Exception($"Function can't be performed on type Scalar<{ typeof(T).Name }>.");
        }

        public Scalar<T> Cos(Scalar<T> s)
        {
            if (s is Scalar<double> d)
                return Math.Cos(d.Value);
            if (s is Scalar<float> f)
                return (float)Math.Cos(f.Value);
            if (s is Scalar<decimal> m)
                return (decimal)Math.Cos((double)m.Value);

            throw new Exception($"Function can't be performed on type Scalar<{ typeof(T).Name }>.");
        }

        public Scalar<T> Tan(Scalar<T> s)
        {
            if (s is Scalar<double> d)
                return Math.Tan(d.Value);
            if (s is Scalar<float> f)
                return (float)Math.Tan(f.Value);
            if (s is Scalar<decimal> m)
                return (decimal)Math.Tan((double)m.Value);

            throw new Exception($"Function can't be performed on type Scalar<{ typeof(T).Name }>.");
        }

        public Scalar<T> Asin(Scalar<T> s)
        {
            if (s is Scalar<double> d)
                return Math.Asin(d.Value);
            if (s is Scalar<float> f)
                return (float)Math.Asin(f.Value);
            if (s is Scalar<decimal> m)
                return (decimal)Math.Asin((double)m.Value);

            throw new Exception($"Function can't be performed on type Scalar<{ typeof(T).Name }>.");
        }

        public Scalar<T> Acos(Scalar<T> s)
        {
            if (s is Scalar<double> d)
                return Math.Acos(d.Value);
            if (s is Scalar<float> f)
                return (float)Math.Acos(f.Value);
            if (s is Scalar<decimal> m)
                return (decimal)Math.Acos((double)m.Value);

            throw new Exception($"Function can't be performed on type Scalar<{ typeof(T).Name }>.");
        }

        public Scalar<T> Atan(Scalar<T> s)
        {
            if (s is Scalar<double> d)
                return Math.Atan(d.Value);
            if (s is Scalar<float> f)
                return (float)Math.Atan(f.Value);
            if (s is Scalar<decimal> m)
                return (decimal)Math.Atan((double)m.Value);

            throw new Exception($"Function can't be performed on type Scalar<{ typeof(T).Name }>.");
        }

        public Scalar<T> Atan2(Scalar<T> s1, Scalar<T> s2)
        {
            if (s1 is Scalar<double> d1 && s2 is Scalar<double> d2)
                return Math.Atan2(d1.Value, d2.Value);
            if (s1 is Scalar<float> f1 && s2 is Scalar<float> f2)
                return (float)Math.Atan2(f1.Value, f2.Value);
            if (s1 is Scalar<decimal> m1 && s2 is Scalar<decimal> m2)
                return (decimal)Math.Atan2((double)m1.Value, (double)m2.Value);

            throw new Exception($"Function can't be performed on type Scalar<{ typeof(T).Name }>.");
        }

        public Scalar<T> Sinh(Scalar<T> s)
        {
            if (s is Scalar<double> d)
                return Math.Sinh(d.Value);
            if (s is Scalar<float> f)
                return (float)Math.Sinh(f.Value);
            if (s is Scalar<decimal> m)
                return (decimal)Math.Sinh((double)m.Value);

            throw new Exception($"Function can't be performed on type Scalar<{ typeof(T).Name }>.");
        }

        public Scalar<T> Cosh(Scalar<T> s)
        {
            if (s is Scalar<double> d)
                return Math.Cosh(d.Value);
            if (s is Scalar<float> f)
                return (float)Math.Cosh(f.Value);
            if (s is Scalar<decimal> m)
                return (decimal)Math.Cosh((double)m.Value);

            throw new Exception($"Function can't be performed on type Scalar<{ typeof(T).Name }>.");
        }

        public Scalar<T> Tanh(Scalar<T> s)
        {
            if (s is Scalar<double> d)
                return Math.Tanh(d.Value);
            if (s is Scalar<float> f)
                return (float)Math.Tanh(f.Value);
            if (s is Scalar<decimal> m)
                return (decimal)Math.Tanh((double)m.Value);

            throw new Exception($"Function can't be performed on type Scalar<{ typeof(T).Name }>.");
        }

        public Scalar<T> Exp(Scalar<T> s)
        {
            if (s is Scalar<double> d)
                return Math.Exp(d.Value);
            if (s is Scalar<float> f)
                return (float)Math.Exp(f.Value);
            if (s is Scalar<decimal> m)
                return (decimal)Math.Exp((double)m.Value);

            throw new Exception($"Function can't be performed on type Scalar<{ typeof(T).Name }>.");
        }

        public Scalar<T> Log(Scalar<T> s)
        {
            if (s is Scalar<double> d)
                return Math.Log(d.Value);
            if (s is Scalar<float> f)
                return (float)Math.Log(f.Value);
            if (s is Scalar<decimal> m)
                return (decimal)Math.Log((double)m.Value);

            throw new Exception($"Function can't be performed on type Scalar<{ typeof(T).Name }>.");
        }

        public Scalar<T> Log10(Scalar<T> s)
        {
            if (s is Scalar<double> d)
                return Math.Log10(d.Value);
            if (s is Scalar<float> f)
                return (float)Math.Log10(f.Value);
            if (s is Scalar<decimal> m)
                return (decimal)Math.Log10((double)m.Value);

            throw new Exception($"Function can't be performed on type Scalar<{ typeof(T).Name }>.");
        }

        public Scalar<T> Pow(Scalar<T> s1, Scalar<T> s2)
        {
            if (Scalar<T>.algebraicStructure == Scalar<T>.AlgebraicStructure.Ring && s1 < Scalar<T>.Zero)
                throw new Exception("Non-field elements can only be raised to positive powers.");

            return Math.Pow(s1, s2);
        }

        public Scalar<T> Round(Scalar<T> s)
        {
            if (s is Scalar<double> d)
                return Math.Round(d.Value);
            if (s is Scalar<float> f)
                return (float)Math.Round(f.Value);
            if (s is Scalar<decimal> m)
                return (decimal)Math.Round((double)m.Value);

            throw new Exception($"Function can't be performed on type Scalar<{ typeof(T).Name }>.");
        }

        public Scalar<T> Round(Scalar<T> s, int digits)
        {
            if (s is Scalar<double> d)
                return Math.Round(d.Value, digits);
            if (s is Scalar<float> f)
                return (float)Math.Round(f.Value, digits);
            if (s is Scalar<decimal> m)
                return (decimal)Math.Round((double)m.Value, digits);

            throw new Exception($"Function can't be performed on type Scalar<{ typeof(T).Name }>.");
        }

        public Scalar<T> Round(Scalar<T> s, MidpointRounding mode)
        {
            if (s is Scalar<double> d)
                return Math.Round(d.Value, mode);
            if (s is Scalar<float> f)
                return (float)Math.Round(f.Value, mode);
            if (s is Scalar<decimal> m)
                return (decimal)Math.Round((double)m.Value, mode);

            throw new Exception($"Function can't be performed on type Scalar<{ typeof(T).Name }>.");
        }

        public Scalar<T> Round(Scalar<T> s, int digits, MidpointRounding mode)
        {
            if (s is Scalar<double> d)
                return Math.Round(d.Value, digits, mode);
            if (s is Scalar<float> f)
                return (float)Math.Round(f.Value, digits, mode);
            if (s is Scalar<decimal> m)
                return (decimal)Math.Round((double)m.Value, digits, mode);

            throw new Exception($"Function can't be performed on type Scalar<{ typeof(T).Name }>.");
        }

        public Scalar<T> Truncate(Scalar<T> s)
        {
            if (s is Scalar<double> d)
                return Math.Truncate(d.Value);
            if (s is Scalar<float> f)
                return (float)Math.Truncate(f.Value);
            if (s is Scalar<decimal> m)
                return (decimal)Math.Truncate((double)m.Value);

            throw new Exception($"Function can't be performed on type Scalar<{ typeof(T).Name }>.");
        }

        #endregion
    }
}