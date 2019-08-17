using LinearAlgebraSharp.Scalars;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LinearAlgebraSharp.Vectors
{
    [Serializable]
    public struct Vector0<T> :
        IVector<T, Vector0<T>>
        where T : struct
    {
        #region Fields and Properties

        public static Scalar<int> Order => Scalar<int>.One;
        public Vector1<int> Dimension => 0;
        public int Length => 0;
        public Scalar<T>[] Data => new Scalar<T>[0] { };
        public Scalar<T> this[int i] => Data[i];

        #endregion

        #region Static

        public static readonly Vector0<T> zero = new Vector0<T>();
        public static readonly Vector0<T> one = new Vector0<T>();


        public static Vector0<T> Range(T start)
        {
            return Range(start, Scalar<T>.One.Value);
        }

        public static Vector0<T> Range(T start, T step)
        {
            return new Vector0<T>();
        }
        #endregion

        #region Functions

        public Scalar<T> SqrMagnitude => Scalar<T>.Zero;
        public Scalar<T> Magnitude => ScalarMath<T>.Sqrt(SqrMagnitude);
        public Vector0<T> Normalized => this / Magnitude;

        public Vector0<T> SetComponent(int component, Scalar<T> value)
        {
            return new Vector0<T>();
        }

        public Scalar<T> Norm(int p)
        {
            if (p < 1) throw new ArgumentException("p must be greater than or equal to 1.", nameof(p));
            return Scalar<T>.Zero;
        }

        public Scalar<T> MaximumNorm()
        {
            return Scalar<T>.Zero;
        }
		
        /// <summary>
        /// Appends Scalar<typeparamref name="T"/>.One at the end of the vector. Used for e.g. affine transformations.
        /// </summary>
        public Vector1<T> Append1()
        {
            return new Vector1<T>(Scalar<T>.One);
        }
		
        public Vector0<U> Cast<U>()
            where U : struct
        {
            return new Vector0<U>();
        }

        public Vector0<T> ElementwiseProduct(Vector0<T> vec)
        {
            return new Vector0<T>();
        }

        public Vector0<T> ElementwiseQuotient(Vector0<T> vec)
        {
            return new Vector0<T>();
        }

        public Scalar<T> Dot(Vector0<T> vec)
        {
            return Scalar<T>.Zero;
        }

        public Scalar<T> AngleTo(Vector0<T> vec)
        {
            return ScalarMath<T>.Acos(Dot(vec) / (Magnitude * vec.Magnitude));
        }

        public Vector0<T> ProjectionOnto(Vector0<T> vec)
        {
            return vec.Multiply(Dot(vec) / vec.Dot(vec));
        }

        public Scalar<T> SquareDistanceTo(Vector0<T> vec)
        {
            return Substract(vec).SqrMagnitude;
        }

        public Scalar<T> DistanceTo(Vector0<T> vec)
        {
            return Substract(vec).Magnitude;
        }

        public Vector0<T> Lerp(Vector0<T> vec, Scalar<T> t)
        {
            return Add(vec.Substract(this).Multiply(t));
        }

        #endregion

        #region Operators

        #region Arithmetic

        public Vector0<T> Add(Vector0<T> vec)
        {
            return new Vector0<T>();
        }

        public static Vector0<T> operator +(Vector0<T> left, Vector0<T> right)
        {
            return left.Add(right);
        }

        public Vector0<T> Substract(Vector0<T> vec)
        {
            return new Vector0<T>();
        }

        public static Vector0<T> operator -(Vector0<T> left, Vector0<T> right)
        {
            return left.Substract(right);
        }

        public Vector0<T> Multiply(Scalar<T> s)
        {
            return new Vector0<T>();
        }

        public static Vector0<T> operator *(Vector0<T> left, Scalar<T> right)
        {
            return left.Multiply(right);
        }

        public static Vector0<T> operator *(Scalar<T> left, Vector0<T> right)
        {
            return right.Multiply(left);
        }

        public Vector0<T> DivideLeft(Scalar<T> s)
        {
            return new Vector0<T>();
        }

        public static Vector0<T> operator /(Vector0<T> left, Scalar<T> right)
        {
            return left.DivideLeft(right);
        }

        public Vector0<T> DivideRight(Scalar<T> s)
        {
            return new Vector0<T>();
        }

        public Vector0<T> Reciprocal()
        {
            return new Vector0<T>();
        }

        public static Vector0<T> operator /(Scalar<T> left, Vector0<T> right)
        {
            return right.DivideRight(left);
        }

        public Vector0<T> Negate()
        {
            return new Vector0<T>();
        }

        public static Vector0<T> operator -(Vector0<T> v)
        {
            return v.Negate();
        }

        #endregion

        #region Identity

        public static bool operator ==(Vector0<T> left, Vector0<T> right)
        {
            return true;
        }

        public static bool operator !=(Vector0<T> left, Vector0<T> right)
        {
            return false;
        }

        #endregion

        #endregion

        #region Implicit Conversion

        public static implicit operator Vector<T>(Vector0<T> t)
        {
            return new Vector<T>(t.Data);
        }

        public static implicit operator T[] (Vector0<T> t)
        {
            return new T[0] { };
        }

        #endregion

        #region Interface Implementation

        public object Clone()
        {
            return new Vector0<T>();
        }

        IEnumerator<Scalar<T>> IEnumerable<Scalar<T>>.GetEnumerator()
        {
            yield break;
        }

        public IEnumerator<T> GetEnumerator()
        {
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        public bool Equals(Vector0<T> other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector0<T> vec)
                return true;

            return false;
        }

        public override string ToString()
        {
            return $"Vector0()";
        }

        public override int GetHashCode()
        {
            return 1;
        }

        #endregion
    }

    [Serializable]
    public struct Vector1<T> :
        IVector<T, Vector1<T>>
        where T : struct
    {
        #region Fields and Properties

        public readonly Scalar<T> x;

        public static Scalar<int> Order => Scalar<int>.One;
        public Vector1<int> Dimension => 1;
        public int Length => 1;
        public Scalar<T>[] Data => new Scalar<T>[1] { x };
        public Scalar<T> this[int i] => Data[i];

        #endregion

        #region Static

        public static readonly Vector1<T> zero = new Vector1<T>(Scalar<T>.Zero);
        public static readonly Vector1<T> one = new Vector1<T>(Scalar<T>.One);

        public static readonly Vector1<T> right = new Vector1<T>(Scalar<T>.One);
        public static readonly Vector1<T> left = new Vector1<T>(Scalar<T>.NegativeOneOrZero);


        public static Vector1<T> Range(T start)
        {
            return Range(start, Scalar<T>.One.Value);
        }

        public static Vector1<T> Range(T start, T step)
        {
            var sStart = new Scalar<T>(start);
            return new Vector1<T>(sStart);
        }
        #endregion

        #region Constructors

        public Vector1(Scalar<T> x)
        {
            this.x = x;
        }

        public Vector1(T x)
        {
            this.x = new Scalar<T>(x);
        }

        #endregion

        #region Functions

        public Scalar<T> SqrMagnitude => x * x;
        public Scalar<T> Magnitude => ScalarMath<T>.Sqrt(SqrMagnitude);
        public Vector1<T> Normalized => this / Magnitude;

        public Vector1<T> SetComponent(int component, Scalar<T> value)
        {
            return new Vector1<T>(component == 0 ? value : x);
        }

        public Scalar<T> Norm(int p)
        {
            if (p < 1) throw new ArgumentException("p must be greater than or equal to 1.", nameof(p));
            return ScalarMath<T>.Abs(x);
        }

        public Scalar<T> MaximumNorm()
        {
            return ScalarMath<T>.Abs(x);
        }
		
        /// <summary>
        /// Appends Scalar<typeparamref name="T"/>.One at the end of the vector. Used for e.g. affine transformations.
        /// </summary>
        public Vector2<T> Append1()
        {
            return new Vector2<T>(x, Scalar<T>.One);
        }
		
        public Vector1<U> Cast<U>()
            where U : struct
        {
            return new Vector1<U>(x.Cast<U>());
        }

        public Vector1<T> ElementwiseProduct(Vector1<T> vec)
        {
            return new Vector1<T>(x * vec.x);
        }

        public Vector1<T> ElementwiseQuotient(Vector1<T> vec)
        {
            return new Vector1<T>(x / vec.x);
        }

        public Scalar<T> Dot(Vector1<T> vec)
        {
            return x * vec.x;
        }

        public Scalar<T> AngleTo(Vector1<T> vec)
        {
            return ScalarMath<T>.Acos(Dot(vec) / (Magnitude * vec.Magnitude));
        }

        public Vector1<T> ProjectionOnto(Vector1<T> vec)
        {
            return vec.Multiply(Dot(vec) / vec.Dot(vec));
        }

        public Scalar<T> SquareDistanceTo(Vector1<T> vec)
        {
            return Substract(vec).SqrMagnitude;
        }

        public Scalar<T> DistanceTo(Vector1<T> vec)
        {
            return Substract(vec).Magnitude;
        }

        public Vector1<T> Lerp(Vector1<T> vec, Scalar<T> t)
        {
            return Add(vec.Substract(this).Multiply(t));
        }

        #endregion

        #region Operators

        #region Arithmetic

        public Vector1<T> Add(Vector1<T> vec)
        {
            return new Vector1<T>(x + vec.x);
        }

        public static Vector1<T> operator +(Vector1<T> left, Vector1<T> right)
        {
            return left.Add(right);
        }

        public Vector1<T> Substract(Vector1<T> vec)
        {
            return new Vector1<T>(x - vec.x);
        }

        public static Vector1<T> operator -(Vector1<T> left, Vector1<T> right)
        {
            return left.Substract(right);
        }

        public Vector1<T> Multiply(Scalar<T> s)
        {
            return new Vector1<T>(x * s);
        }

        public static Vector1<T> operator *(Vector1<T> left, Scalar<T> right)
        {
            return left.Multiply(right);
        }

        public static Vector1<T> operator *(Scalar<T> left, Vector1<T> right)
        {
            return right.Multiply(left);
        }

        public Vector1<T> DivideLeft(Scalar<T> s)
        {
            return new Vector1<T>(x / s);
        }

        public static Vector1<T> operator /(Vector1<T> left, Scalar<T> right)
        {
            return left.DivideLeft(right);
        }

        public Vector1<T> DivideRight(Scalar<T> s)
        {
            return new Vector1<T>(s / x);
        }

        public Vector1<T> Reciprocal()
        {
            return new Vector1<T>(Scalar<T>.One / x);
        }

        public static Vector1<T> operator /(Scalar<T> left, Vector1<T> right)
        {
            return right.DivideRight(left);
        }

        public Vector1<T> Negate()
        {
            return new Vector1<T>(-x);
        }

        public static Vector1<T> operator -(Vector1<T> v)
        {
            return v.Negate();
        }

        #endregion

        #region Identity

        public static bool operator ==(Vector1<T> left, Vector1<T> right)
        {
            return left.x == right.x;
        }

        public static bool operator !=(Vector1<T> left, Vector1<T> right)
        {
            return left.x != right.x;
        }

        #endregion

        #endregion

        #region Implicit Conversion

        public static implicit operator Vector1<T>(T t)
        {
            return new Vector1<T>(t);
        }

        public static implicit operator T(Vector1<T> vec)
        {
            return vec.x.Value;
        }

        public static implicit operator Vector<T>(Vector1<T> t)
        {
            return new Vector<T>(t.Data);
        }

        public static implicit operator T[] (Vector1<T> t)
        {
            return new T[1] { t.x.Value };
        }

        public void Deconstruct(out T x)
        {
            x = this.x.Value;
        }

        #endregion

        #region Interface Implementation

        public object Clone()
        {
            return new Vector1<T>(x);
        }

        IEnumerator<Scalar<T>> IEnumerable<Scalar<T>>.GetEnumerator()
        {
            yield return x;
        }

        public IEnumerator<T> GetEnumerator()
        {
            yield return x.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        public bool Equals(Vector1<T> other)
        {
            return x.Equals(other.x);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector1<T> vec)
                return x.Equals(vec.x);

            return false;
        }

        public override string ToString()
        {
            return $"Vector1({ x })";
        }

        public override int GetHashCode()
        {
            return 31 * (1) + x.GetHashCode();
        }

        #endregion
    }

    [Serializable]
    public struct Vector2<T> :
        IVector<T, Vector2<T>>
        where T : struct
    {
        #region Fields and Properties

        public readonly Scalar<T> x, y;

        public static Scalar<int> Order => Scalar<int>.One;
        public Vector1<int> Dimension => 2;
        public int Length => 2;
        public Scalar<T>[] Data => new Scalar<T>[2] { x, y };
        public Scalar<T> this[int i] => Data[i];

        #endregion

        #region Static

        public static readonly Vector2<T> zero = new Vector2<T>(Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector2<T> one = new Vector2<T>(Scalar<T>.One, Scalar<T>.One);

        public static readonly Vector2<T> right = new Vector2<T>(Scalar<T>.One, Scalar<T>.Zero);
        public static readonly Vector2<T> left = new Vector2<T>(Scalar<T>.NegativeOneOrZero, Scalar<T>.Zero);

        public static readonly Vector2<T> up = new Vector2<T>(Scalar<T>.Zero, Scalar<T>.One);
        public static readonly Vector2<T> down = new Vector2<T>(Scalar<T>.Zero, Scalar<T>.NegativeOneOrZero);


        public static Vector2<T> Range(T start)
        {
            return Range(start, Scalar<T>.One.Value);
        }

        public static Vector2<T> Range(T start, T step)
        {
            var sStart = new Scalar<T>(start);
            var sStep = new Scalar<T>(step);
            return new Vector2<T>(sStart, sStart + sStep);
        }
        #endregion

        #region Constructors

        public Vector2(Scalar<T> x, Scalar<T> y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2(T x, T y)
        {
            this.x = new Scalar<T>(x);
            this.y = new Scalar<T>(y);
        }

        public Vector2(Scalar<T> s)
        {
            x = s;
            y = s;
        }

        public Vector2(T t)
        {
            x = new Scalar<T>(t);
            y = new Scalar<T>(t);
        }

        #endregion

        #region Functions

        public Scalar<T> SqrMagnitude => x * x + y * y;
        public Scalar<T> Magnitude => ScalarMath<T>.Sqrt(SqrMagnitude);
        public Vector2<T> Normalized => this / Magnitude;

        public Vector2<T> SetComponent(int component, Scalar<T> value)
        {
            return new Vector2<T>(component == 0 ? value : x, component == 1 ? value : y);
        }

        public Scalar<T> Norm(int p)
        {
            if (p < 1) throw new ArgumentException("p must be greater than or equal to 1.", nameof(p));
            return ScalarMath<T>.Pow(ScalarMath<T>.Pow(ScalarMath<T>.Abs(x), p) + ScalarMath<T>.Pow(ScalarMath<T>.Abs(y), p), 1d / p);
        }

        public Scalar<T> MaximumNorm()
        {
            Scalar<T> max = ScalarMath<T>.Abs(x);

            if (ScalarMath<T>.Abs(y) > max)
                max = ScalarMath<T>.Abs(y);

            return max;
        }
		
        /// <summary>
        /// Appends Scalar<typeparamref name="T"/>.One at the end of the vector. Used for e.g. affine transformations.
        /// </summary>
        public Vector3<T> Append1()
        {
            return new Vector3<T>(x, y, Scalar<T>.One);
        }
		
        public Vector2<U> Cast<U>()
            where U : struct
        {
            return new Vector2<U>(x.Cast<U>(), y.Cast<U>());
        }

        public Vector2<T> ElementwiseProduct(Vector2<T> vec)
        {
            return new Vector2<T>(x * vec.x, y * vec.y);
        }

        public Vector2<T> ElementwiseQuotient(Vector2<T> vec)
        {
            return new Vector2<T>(x / vec.x, y / vec.y);
        }

        public Scalar<T> Dot(Vector2<T> vec)
        {
            return x * vec.x + y * vec.y;
        }

        public Scalar<T> AngleTo(Vector2<T> vec)
        {
            return ScalarMath<T>.Acos(Dot(vec) / (Magnitude * vec.Magnitude));
        }

        public Vector2<T> ProjectionOnto(Vector2<T> vec)
        {
            return vec.Multiply(Dot(vec) / vec.Dot(vec));
        }

        public Scalar<T> SquareDistanceTo(Vector2<T> vec)
        {
            return Substract(vec).SqrMagnitude;
        }

        public Scalar<T> DistanceTo(Vector2<T> vec)
        {
            return Substract(vec).Magnitude;
        }

        public Vector2<T> Lerp(Vector2<T> vec, Scalar<T> t)
        {
            return Add(vec.Substract(this).Multiply(t));
        }

        #endregion

        #region Operators

        #region Arithmetic

        public Vector2<T> Add(Vector2<T> vec)
        {
            return new Vector2<T>(x + vec.x, y + vec.y);
        }

        public static Vector2<T> operator +(Vector2<T> left, Vector2<T> right)
        {
            return left.Add(right);
        }

        public Vector2<T> Substract(Vector2<T> vec)
        {
            return new Vector2<T>(x - vec.x, y - vec.y);
        }

        public static Vector2<T> operator -(Vector2<T> left, Vector2<T> right)
        {
            return left.Substract(right);
        }

        public Vector2<T> Multiply(Scalar<T> s)
        {
            return new Vector2<T>(x * s, y * s);
        }

        public static Vector2<T> operator *(Vector2<T> left, Scalar<T> right)
        {
            return left.Multiply(right);
        }

        public static Vector2<T> operator *(Scalar<T> left, Vector2<T> right)
        {
            return right.Multiply(left);
        }

        public Vector2<T> DivideLeft(Scalar<T> s)
        {
            return new Vector2<T>(x / s, y / s);
        }

        public static Vector2<T> operator /(Vector2<T> left, Scalar<T> right)
        {
            return left.DivideLeft(right);
        }

        public Vector2<T> DivideRight(Scalar<T> s)
        {
            return new Vector2<T>(s / x, s / y);
        }

        public Vector2<T> Reciprocal()
        {
            return new Vector2<T>(Scalar<T>.One / x, Scalar<T>.One / y);
        }

        public static Vector2<T> operator /(Scalar<T> left, Vector2<T> right)
        {
            return right.DivideRight(left);
        }

        public Vector2<T> Negate()
        {
            return new Vector2<T>(-x, -y);
        }

        public static Vector2<T> operator -(Vector2<T> v)
        {
            return v.Negate();
        }

        #endregion

        #region Identity

        public static bool operator ==(Vector2<T> left, Vector2<T> right)
        {
            return left.x == right.x && left.y == right.y;
        }

        public static bool operator !=(Vector2<T> left, Vector2<T> right)
        {
            return left.x != right.x || left.y != right.y;
        }

        #endregion

        #endregion

        #region Implicit Conversion

        public static implicit operator Vector2<T>((T, T) t)
        {
            return new Vector2<T>(t.Item1, t.Item2);
        }

        public static implicit operator (T, T) (Vector2<T> vec)
        {
            return (vec.x.Value, vec.y.Value);
        }

        public static implicit operator Vector<T>(Vector2<T> t)
        {
            return new Vector<T>(t.Data);
        }

        public static implicit operator T[] (Vector2<T> t)
        {
            return new T[2] { t.x.Value, t.y.Value };
        }

        public void Deconstruct(out T x, out T y)
        {
            x = this.x.Value;
            y = this.y.Value;
        }

        #endregion

        #region Interface Implementation

        public object Clone()
        {
            return new Vector2<T>(x, y);
        }

        IEnumerator<Scalar<T>> IEnumerable<Scalar<T>>.GetEnumerator()
        {
            yield return x;
            yield return y;
        }

        public IEnumerator<T> GetEnumerator()
        {
            yield return x.Value;
            yield return y.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        public bool Equals(Vector2<T> other)
        {
            return x.Equals(other.x) && y.Equals(other.y);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2<T> vec)
                return x.Equals(vec.x) && y.Equals(vec.y);

            return false;
        }

        public override string ToString()
        {
            return $"Vector2({ x }, { y })";
        }

        public override int GetHashCode()
        {
            return 31 * (31 * (1) + x.GetHashCode()) + y.GetHashCode();
        }

        #endregion
    }

    [Serializable]
    public struct Vector3<T> :
        IVector<T, Vector3<T>>
        where T : struct
    {
        #region Fields and Properties

        public readonly Scalar<T> x, y, z;

        public static Scalar<int> Order => Scalar<int>.One;
        public Vector1<int> Dimension => 3;
        public int Length => 3;
        public Scalar<T>[] Data => new Scalar<T>[3] { x, y, z };
        public Scalar<T> this[int i] => Data[i];

        #endregion

        #region Static

        public static readonly Vector3<T> zero = new Vector3<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector3<T> one = new Vector3<T>(Scalar<T>.One, Scalar<T>.One, Scalar<T>.One);

        public static readonly Vector3<T> right = new Vector3<T>(Scalar<T>.One, Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector3<T> left = new Vector3<T>(Scalar<T>.NegativeOneOrZero, Scalar<T>.Zero, Scalar<T>.Zero);

        public static readonly Vector3<T> up = new Vector3<T>(Scalar<T>.Zero, Scalar<T>.One, Scalar<T>.Zero);
        public static readonly Vector3<T> down = new Vector3<T>(Scalar<T>.Zero, Scalar<T>.NegativeOneOrZero, Scalar<T>.Zero);

        public static readonly Vector3<T> forward = new Vector3<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.One);
        public static readonly Vector3<T> backward = new Vector3<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.NegativeOneOrZero);


        public static Vector3<T> Range(T start)
        {
            return Range(start, Scalar<T>.One.Value);
        }

        public static Vector3<T> Range(T start, T step)
        {
            var sStart = new Scalar<T>(start);
            var sStep = new Scalar<T>(step);
            return new Vector3<T>(sStart, sStart + sStep, sStart + sStep + sStep);
        }
        #endregion

        #region Constructors

        public Vector3(Scalar<T> x, Scalar<T> y, Scalar<T> z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(T x, T y, T z)
        {
            this.x = new Scalar<T>(x);
            this.y = new Scalar<T>(y);
            this.z = new Scalar<T>(z);
        }

        public Vector3(Scalar<T> s)
        {
            x = s;
            y = s;
            z = s;
        }

        public Vector3(T t)
        {
            x = new Scalar<T>(t);
            y = new Scalar<T>(t);
            z = new Scalar<T>(t);
        }

        #endregion

        #region Functions

        public Scalar<T> SqrMagnitude => x * x + y * y + z * z;
        public Scalar<T> Magnitude => ScalarMath<T>.Sqrt(SqrMagnitude);
        public Vector3<T> Normalized => this / Magnitude;

        public Vector3<T> SetComponent(int component, Scalar<T> value)
        {
            return new Vector3<T>(component == 0 ? value : x, component == 1 ? value : y, component == 2 ? value : z);
        }

        public Scalar<T> Norm(int p)
        {
            if (p < 1) throw new ArgumentException("p must be greater than or equal to 1.", nameof(p));
            return ScalarMath<T>.Pow(ScalarMath<T>.Pow(ScalarMath<T>.Abs(x), p) + ScalarMath<T>.Pow(ScalarMath<T>.Abs(y), p) + ScalarMath<T>.Pow(ScalarMath<T>.Abs(z), p), 1d / p);
        }

        public Scalar<T> MaximumNorm()
        {
            Scalar<T> max = ScalarMath<T>.Abs(x);

            if (ScalarMath<T>.Abs(y) > max)
                max = ScalarMath<T>.Abs(y);
            if (ScalarMath<T>.Abs(z) > max)
                max = ScalarMath<T>.Abs(z);

            return max;
        }
		
        /// <summary>
        /// Appends Scalar<typeparamref name="T"/>.One at the end of the vector. Used for e.g. affine transformations.
        /// </summary>
        public Vector4<T> Append1()
        {
            return new Vector4<T>(x, y, z, Scalar<T>.One);
        }
		
        public Vector3<U> Cast<U>()
            where U : struct
        {
            return new Vector3<U>(x.Cast<U>(), y.Cast<U>(), z.Cast<U>());
        }

        public Vector3<T> ElementwiseProduct(Vector3<T> vec)
        {
            return new Vector3<T>(x * vec.x, y * vec.y, z * vec.z);
        }

        public Vector3<T> ElementwiseQuotient(Vector3<T> vec)
        {
            return new Vector3<T>(x / vec.x, y / vec.y, z / vec.z);
        }

        public Scalar<T> Dot(Vector3<T> vec)
        {
            return x * vec.x + y * vec.y + z * vec.z;
        }

        public Scalar<T> AngleTo(Vector3<T> vec)
        {
            return ScalarMath<T>.Acos(Dot(vec) / (Magnitude * vec.Magnitude));
        }

        public Vector3<T> ProjectionOnto(Vector3<T> vec)
        {
            return vec.Multiply(Dot(vec) / vec.Dot(vec));
        }

        public Scalar<T> SquareDistanceTo(Vector3<T> vec)
        {
            return Substract(vec).SqrMagnitude;
        }

        public Scalar<T> DistanceTo(Vector3<T> vec)
        {
            return Substract(vec).Magnitude;
        }

        public Vector3<T> Lerp(Vector3<T> vec, Scalar<T> t)
        {
            return Add(vec.Substract(this).Multiply(t));
        }

        #endregion

        #region Operators

        #region Arithmetic

        public Vector3<T> Add(Vector3<T> vec)
        {
            return new Vector3<T>(x + vec.x, y + vec.y, z + vec.z);
        }

        public static Vector3<T> operator +(Vector3<T> left, Vector3<T> right)
        {
            return left.Add(right);
        }

        public Vector3<T> Substract(Vector3<T> vec)
        {
            return new Vector3<T>(x - vec.x, y - vec.y, z - vec.z);
        }

        public static Vector3<T> operator -(Vector3<T> left, Vector3<T> right)
        {
            return left.Substract(right);
        }

        public Vector3<T> Multiply(Scalar<T> s)
        {
            return new Vector3<T>(x * s, y * s, z * s);
        }

        public static Vector3<T> operator *(Vector3<T> left, Scalar<T> right)
        {
            return left.Multiply(right);
        }

        public static Vector3<T> operator *(Scalar<T> left, Vector3<T> right)
        {
            return right.Multiply(left);
        }

        public Vector3<T> DivideLeft(Scalar<T> s)
        {
            return new Vector3<T>(x / s, y / s, z / s);
        }

        public static Vector3<T> operator /(Vector3<T> left, Scalar<T> right)
        {
            return left.DivideLeft(right);
        }

        public Vector3<T> DivideRight(Scalar<T> s)
        {
            return new Vector3<T>(s / x, s / y, s / z);
        }

        public Vector3<T> Reciprocal()
        {
            return new Vector3<T>(Scalar<T>.One / x, Scalar<T>.One / y, Scalar<T>.One / z);
        }

        public static Vector3<T> operator /(Scalar<T> left, Vector3<T> right)
        {
            return right.DivideRight(left);
        }

        public Vector3<T> Negate()
        {
            return new Vector3<T>(-x, -y, -z);
        }

        public static Vector3<T> operator -(Vector3<T> v)
        {
            return v.Negate();
        }

        #endregion

        #region Identity

        public static bool operator ==(Vector3<T> left, Vector3<T> right)
        {
            return left.x == right.x && left.y == right.y && left.z == right.z;
        }

        public static bool operator !=(Vector3<T> left, Vector3<T> right)
        {
            return left.x != right.x || left.y != right.y || left.z != right.z;
        }

        #endregion

        #endregion

        #region Implicit Conversion

        public static implicit operator Vector3<T>((T, T, T) t)
        {
            return new Vector3<T>(t.Item1, t.Item2, t.Item3);
        }

        public static implicit operator (T, T, T) (Vector3<T> vec)
        {
            return (vec.x.Value, vec.y.Value, vec.z.Value);
        }

        public static implicit operator Vector<T>(Vector3<T> t)
        {
            return new Vector<T>(t.Data);
        }

        public static implicit operator T[] (Vector3<T> t)
        {
            return new T[3] { t.x.Value, t.y.Value, t.z.Value };
        }

        public void Deconstruct(out T x, out T y, out T z)
        {
            x = this.x.Value;
            y = this.y.Value;
            z = this.z.Value;
        }

        #endregion

        #region Interface Implementation

        public object Clone()
        {
            return new Vector3<T>(x, y, z);
        }

        IEnumerator<Scalar<T>> IEnumerable<Scalar<T>>.GetEnumerator()
        {
            yield return x;
            yield return y;
            yield return z;
        }

        public IEnumerator<T> GetEnumerator()
        {
            yield return x.Value;
            yield return y.Value;
            yield return z.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        public bool Equals(Vector3<T> other)
        {
            return x.Equals(other.x) && y.Equals(other.y) && z.Equals(other.z);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector3<T> vec)
                return x.Equals(vec.x) && y.Equals(vec.y) && z.Equals(vec.z);

            return false;
        }

        public override string ToString()
        {
            return $"Vector3({ x }, { y }, { z })";
        }

        public override int GetHashCode()
        {
            return 31 * (31 * (31 * (1) + x.GetHashCode()) + y.GetHashCode()) + z.GetHashCode();
        }

        #endregion
    }

    [Serializable]
    public struct Vector4<T> :
        IVector<T, Vector4<T>>
        where T : struct
    {
        #region Fields and Properties

        public readonly Scalar<T> x, y, z, w;

        public static Scalar<int> Order => Scalar<int>.One;
        public Vector1<int> Dimension => 4;
        public int Length => 4;
        public Scalar<T>[] Data => new Scalar<T>[4] { x, y, z, w };
        public Scalar<T> this[int i] => Data[i];

        #endregion

        #region Static

        public static readonly Vector4<T> zero = new Vector4<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector4<T> one = new Vector4<T>(Scalar<T>.One, Scalar<T>.One, Scalar<T>.One, Scalar<T>.One);

        public static readonly Vector4<T> right = new Vector4<T>(Scalar<T>.One, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector4<T> left = new Vector4<T>(Scalar<T>.NegativeOneOrZero, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero);

        public static readonly Vector4<T> up = new Vector4<T>(Scalar<T>.Zero, Scalar<T>.One, Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector4<T> down = new Vector4<T>(Scalar<T>.Zero, Scalar<T>.NegativeOneOrZero, Scalar<T>.Zero, Scalar<T>.Zero);

        public static readonly Vector4<T> forward = new Vector4<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.One, Scalar<T>.Zero);
        public static readonly Vector4<T> backward = new Vector4<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.NegativeOneOrZero, Scalar<T>.Zero);

        public static readonly Vector4<T> ana = new Vector4<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.One);
        public static readonly Vector4<T> kata = new Vector4<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.NegativeOneOrZero);


        public static Vector4<T> Range(T start)
        {
            return Range(start, Scalar<T>.One.Value);
        }

        public static Vector4<T> Range(T start, T step)
        {
            var sStart = new Scalar<T>(start);
            var sStep = new Scalar<T>(step);
            return new Vector4<T>(sStart, sStart + sStep, sStart + sStep + sStep, sStart + sStep + sStep + sStep);
        }
        #endregion

        #region Constructors

        public Vector4(Scalar<T> x, Scalar<T> y, Scalar<T> z, Scalar<T> w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Vector4(T x, T y, T z, T w)
        {
            this.x = new Scalar<T>(x);
            this.y = new Scalar<T>(y);
            this.z = new Scalar<T>(z);
            this.w = new Scalar<T>(w);
        }

        public Vector4(Scalar<T> s)
        {
            x = s;
            y = s;
            z = s;
            w = s;
        }

        public Vector4(T t)
        {
            x = new Scalar<T>(t);
            y = new Scalar<T>(t);
            z = new Scalar<T>(t);
            w = new Scalar<T>(t);
        }

        #endregion

        #region Functions

        public Scalar<T> SqrMagnitude => x * x + y * y + z * z + w * w;
        public Scalar<T> Magnitude => ScalarMath<T>.Sqrt(SqrMagnitude);
        public Vector4<T> Normalized => this / Magnitude;

        public Vector4<T> SetComponent(int component, Scalar<T> value)
        {
            return new Vector4<T>(component == 0 ? value : x, component == 1 ? value : y, component == 2 ? value : z, component == 3 ? value : w);
        }

        public Scalar<T> Norm(int p)
        {
            if (p < 1) throw new ArgumentException("p must be greater than or equal to 1.", nameof(p));
            return ScalarMath<T>.Pow(ScalarMath<T>.Pow(ScalarMath<T>.Abs(x), p) + ScalarMath<T>.Pow(ScalarMath<T>.Abs(y), p) + ScalarMath<T>.Pow(ScalarMath<T>.Abs(z), p) + ScalarMath<T>.Pow(ScalarMath<T>.Abs(w), p), 1d / p);
        }

        public Scalar<T> MaximumNorm()
        {
            Scalar<T> max = ScalarMath<T>.Abs(x);

            if (ScalarMath<T>.Abs(y) > max)
                max = ScalarMath<T>.Abs(y);
            if (ScalarMath<T>.Abs(z) > max)
                max = ScalarMath<T>.Abs(z);
            if (ScalarMath<T>.Abs(w) > max)
                max = ScalarMath<T>.Abs(w);

            return max;
        }
		
        /// <summary>
        /// Appends Scalar<typeparamref name="T"/>.One at the end of the vector. Used for e.g. affine transformations.
        /// </summary>
        public Vector5<T> Append1()
        {
            return new Vector5<T>(x, y, z, w, Scalar<T>.One);
        }
		
        public Vector4<U> Cast<U>()
            where U : struct
        {
            return new Vector4<U>(x.Cast<U>(), y.Cast<U>(), z.Cast<U>(), w.Cast<U>());
        }

        public Vector4<T> ElementwiseProduct(Vector4<T> vec)
        {
            return new Vector4<T>(x * vec.x, y * vec.y, z * vec.z, w * vec.w);
        }

        public Vector4<T> ElementwiseQuotient(Vector4<T> vec)
        {
            return new Vector4<T>(x / vec.x, y / vec.y, z / vec.z, w / vec.w);
        }

        public Scalar<T> Dot(Vector4<T> vec)
        {
            return x * vec.x + y * vec.y + z * vec.z + w * vec.w;
        }

        public Scalar<T> AngleTo(Vector4<T> vec)
        {
            return ScalarMath<T>.Acos(Dot(vec) / (Magnitude * vec.Magnitude));
        }

        public Vector4<T> ProjectionOnto(Vector4<T> vec)
        {
            return vec.Multiply(Dot(vec) / vec.Dot(vec));
        }

        public Scalar<T> SquareDistanceTo(Vector4<T> vec)
        {
            return Substract(vec).SqrMagnitude;
        }

        public Scalar<T> DistanceTo(Vector4<T> vec)
        {
            return Substract(vec).Magnitude;
        }

        public Vector4<T> Lerp(Vector4<T> vec, Scalar<T> t)
        {
            return Add(vec.Substract(this).Multiply(t));
        }

        #endregion

        #region Operators

        #region Arithmetic

        public Vector4<T> Add(Vector4<T> vec)
        {
            return new Vector4<T>(x + vec.x, y + vec.y, z + vec.z, w + vec.w);
        }

        public static Vector4<T> operator +(Vector4<T> left, Vector4<T> right)
        {
            return left.Add(right);
        }

        public Vector4<T> Substract(Vector4<T> vec)
        {
            return new Vector4<T>(x - vec.x, y - vec.y, z - vec.z, w - vec.w);
        }

        public static Vector4<T> operator -(Vector4<T> left, Vector4<T> right)
        {
            return left.Substract(right);
        }

        public Vector4<T> Multiply(Scalar<T> s)
        {
            return new Vector4<T>(x * s, y * s, z * s, w * s);
        }

        public static Vector4<T> operator *(Vector4<T> left, Scalar<T> right)
        {
            return left.Multiply(right);
        }

        public static Vector4<T> operator *(Scalar<T> left, Vector4<T> right)
        {
            return right.Multiply(left);
        }

        public Vector4<T> DivideLeft(Scalar<T> s)
        {
            return new Vector4<T>(x / s, y / s, z / s, w / s);
        }

        public static Vector4<T> operator /(Vector4<T> left, Scalar<T> right)
        {
            return left.DivideLeft(right);
        }

        public Vector4<T> DivideRight(Scalar<T> s)
        {
            return new Vector4<T>(s / x, s / y, s / z, s / w);
        }

        public Vector4<T> Reciprocal()
        {
            return new Vector4<T>(Scalar<T>.One / x, Scalar<T>.One / y, Scalar<T>.One / z, Scalar<T>.One / w);
        }

        public static Vector4<T> operator /(Scalar<T> left, Vector4<T> right)
        {
            return right.DivideRight(left);
        }

        public Vector4<T> Negate()
        {
            return new Vector4<T>(-x, -y, -z, -w);
        }

        public static Vector4<T> operator -(Vector4<T> v)
        {
            return v.Negate();
        }

        #endregion

        #region Identity

        public static bool operator ==(Vector4<T> left, Vector4<T> right)
        {
            return left.x == right.x && left.y == right.y && left.z == right.z && left.w == right.w;
        }

        public static bool operator !=(Vector4<T> left, Vector4<T> right)
        {
            return left.x != right.x || left.y != right.y || left.z != right.z || left.w != right.w;
        }

        #endregion

        #endregion

        #region Implicit Conversion

        public static implicit operator Vector4<T>((T, T, T, T) t)
        {
            return new Vector4<T>(t.Item1, t.Item2, t.Item3, t.Item4);
        }

        public static implicit operator (T, T, T, T) (Vector4<T> vec)
        {
            return (vec.x.Value, vec.y.Value, vec.z.Value, vec.w.Value);
        }

        public static implicit operator Vector<T>(Vector4<T> t)
        {
            return new Vector<T>(t.Data);
        }

        public static implicit operator T[] (Vector4<T> t)
        {
            return new T[4] { t.x.Value, t.y.Value, t.z.Value, t.w.Value };
        }

        public void Deconstruct(out T x, out T y, out T z, out T w)
        {
            x = this.x.Value;
            y = this.y.Value;
            z = this.z.Value;
            w = this.w.Value;
        }

        #endregion

        #region Interface Implementation

        public object Clone()
        {
            return new Vector4<T>(x, y, z, w);
        }

        IEnumerator<Scalar<T>> IEnumerable<Scalar<T>>.GetEnumerator()
        {
            yield return x;
            yield return y;
            yield return z;
            yield return w;
        }

        public IEnumerator<T> GetEnumerator()
        {
            yield return x.Value;
            yield return y.Value;
            yield return z.Value;
            yield return w.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        public bool Equals(Vector4<T> other)
        {
            return x.Equals(other.x) && y.Equals(other.y) && z.Equals(other.z) && w.Equals(other.w);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector4<T> vec)
                return x.Equals(vec.x) && y.Equals(vec.y) && z.Equals(vec.z) && w.Equals(vec.w);

            return false;
        }

        public override string ToString()
        {
            return $"Vector4({ x }, { y }, { z }, { w })";
        }

        public override int GetHashCode()
        {
            return 31 * (31 * (31 * (31 * (1) + x.GetHashCode()) + y.GetHashCode()) + z.GetHashCode()) + w.GetHashCode();
        }

        #endregion
    }

    [Serializable]
    public struct Vector5<T> :
        IVector<T, Vector5<T>>
        where T : struct
    {
        #region Fields and Properties

        public readonly Scalar<T> v0, v1, v2, v3, v4;

        public static Scalar<int> Order => Scalar<int>.One;
        public Vector1<int> Dimension => 5;
        public int Length => 5;
        public Scalar<T>[] Data => new Scalar<T>[5] { v0, v1, v2, v3, v4 };
        public Scalar<T> this[int i] => Data[i];

        #endregion

        #region Static

        public static readonly Vector5<T> zero = new Vector5<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector5<T> one = new Vector5<T>(Scalar<T>.One, Scalar<T>.One, Scalar<T>.One, Scalar<T>.One, Scalar<T>.One);

        public static readonly Vector5<T> right = new Vector5<T>(Scalar<T>.One, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector5<T> left = new Vector5<T>(Scalar<T>.NegativeOneOrZero, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero);

        public static readonly Vector5<T> up = new Vector5<T>(Scalar<T>.Zero, Scalar<T>.One, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector5<T> down = new Vector5<T>(Scalar<T>.Zero, Scalar<T>.NegativeOneOrZero, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero);

        public static readonly Vector5<T> forward = new Vector5<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.One, Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector5<T> backward = new Vector5<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.NegativeOneOrZero, Scalar<T>.Zero, Scalar<T>.Zero);

        public static readonly Vector5<T> ana = new Vector5<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.One, Scalar<T>.Zero);
        public static readonly Vector5<T> kata = new Vector5<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.NegativeOneOrZero, Scalar<T>.Zero);

        public static readonly Vector5<T> basis5 = new Vector5<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.One);


        public static Vector5<T> Range(T start)
        {
            return Range(start, Scalar<T>.One.Value);
        }

        public static Vector5<T> Range(T start, T step)
        {
            var sStart = new Scalar<T>(start);
            var sStep = new Scalar<T>(step);
            return new Vector5<T>(sStart, sStart + sStep, sStart + sStep + sStep, sStart + sStep + sStep + sStep, sStart + sStep + sStep + sStep + sStep);
        }
        #endregion

        #region Constructors

        public Vector5(Scalar<T> v0, Scalar<T> v1, Scalar<T> v2, Scalar<T> v3, Scalar<T> v4)
        {
            this.v0 = v0;
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
        }

        public Vector5(T v0, T v1, T v2, T v3, T v4)
        {
            this.v0 = new Scalar<T>(v0);
            this.v1 = new Scalar<T>(v1);
            this.v2 = new Scalar<T>(v2);
            this.v3 = new Scalar<T>(v3);
            this.v4 = new Scalar<T>(v4);
        }

        public Vector5(Scalar<T> s)
        {
            v0 = s;
            v1 = s;
            v2 = s;
            v3 = s;
            v4 = s;
        }

        public Vector5(T t)
        {
            v0 = new Scalar<T>(t);
            v1 = new Scalar<T>(t);
            v2 = new Scalar<T>(t);
            v3 = new Scalar<T>(t);
            v4 = new Scalar<T>(t);
        }

        #endregion

        #region Functions

        public Scalar<T> SqrMagnitude => v0 * v0 + v1 * v1 + v2 * v2 + v3 * v3 + v4 * v4;
        public Scalar<T> Magnitude => ScalarMath<T>.Sqrt(SqrMagnitude);
        public Vector5<T> Normalized => this / Magnitude;

        public Vector5<T> SetComponent(int component, Scalar<T> value)
        {
            return new Vector5<T>(component == 0 ? value : v0, component == 1 ? value : v1, component == 2 ? value : v2, component == 3 ? value : v3, component == 4 ? value : v4);
        }

        public Scalar<T> Norm(int p)
        {
            if (p < 1) throw new ArgumentException("p must be greater than or equal to 1.", nameof(p));
            return ScalarMath<T>.Pow(ScalarMath<T>.Pow(ScalarMath<T>.Abs(v0), p) + ScalarMath<T>.Pow(ScalarMath<T>.Abs(v1), p) + ScalarMath<T>.Pow(ScalarMath<T>.Abs(v2), p) + ScalarMath<T>.Pow(ScalarMath<T>.Abs(v3), p) + ScalarMath<T>.Pow(ScalarMath<T>.Abs(v4), p), 1d / p);
        }

        public Scalar<T> MaximumNorm()
        {
            Scalar<T> max = ScalarMath<T>.Abs(v0);

            if (ScalarMath<T>.Abs(v1) > max)
                max = ScalarMath<T>.Abs(v1);
            if (ScalarMath<T>.Abs(v2) > max)
                max = ScalarMath<T>.Abs(v2);
            if (ScalarMath<T>.Abs(v3) > max)
                max = ScalarMath<T>.Abs(v3);
            if (ScalarMath<T>.Abs(v4) > max)
                max = ScalarMath<T>.Abs(v4);

            return max;
        }
		
        public Vector5<U> Cast<U>()
            where U : struct
        {
            return new Vector5<U>(v0.Cast<U>(), v1.Cast<U>(), v2.Cast<U>(), v3.Cast<U>(), v4.Cast<U>());
        }

        public Vector5<T> ElementwiseProduct(Vector5<T> vec)
        {
            return new Vector5<T>(v0 * vec.v0, v1 * vec.v1, v2 * vec.v2, v3 * vec.v3, v4 * vec.v4);
        }

        public Vector5<T> ElementwiseQuotient(Vector5<T> vec)
        {
            return new Vector5<T>(v0 / vec.v0, v1 / vec.v1, v2 / vec.v2, v3 / vec.v3, v4 / vec.v4);
        }

        public Scalar<T> Dot(Vector5<T> vec)
        {
            return v0 * vec.v0 + v1 * vec.v1 + v2 * vec.v2 + v3 * vec.v3 + v4 * vec.v4;
        }

        public Scalar<T> AngleTo(Vector5<T> vec)
        {
            return ScalarMath<T>.Acos(Dot(vec) / (Magnitude * vec.Magnitude));
        }

        public Vector5<T> ProjectionOnto(Vector5<T> vec)
        {
            return vec.Multiply(Dot(vec) / vec.Dot(vec));
        }

        public Scalar<T> SquareDistanceTo(Vector5<T> vec)
        {
            return Substract(vec).SqrMagnitude;
        }

        public Scalar<T> DistanceTo(Vector5<T> vec)
        {
            return Substract(vec).Magnitude;
        }

        public Vector5<T> Lerp(Vector5<T> vec, Scalar<T> t)
        {
            return Add(vec.Substract(this).Multiply(t));
        }

        #endregion

        #region Operators

        #region Arithmetic

        public Vector5<T> Add(Vector5<T> vec)
        {
            return new Vector5<T>(v0 + vec.v0, v1 + vec.v1, v2 + vec.v2, v3 + vec.v3, v4 + vec.v4);
        }

        public static Vector5<T> operator +(Vector5<T> left, Vector5<T> right)
        {
            return left.Add(right);
        }

        public Vector5<T> Substract(Vector5<T> vec)
        {
            return new Vector5<T>(v0 - vec.v0, v1 - vec.v1, v2 - vec.v2, v3 - vec.v3, v4 - vec.v4);
        }

        public static Vector5<T> operator -(Vector5<T> left, Vector5<T> right)
        {
            return left.Substract(right);
        }

        public Vector5<T> Multiply(Scalar<T> s)
        {
            return new Vector5<T>(v0 * s, v1 * s, v2 * s, v3 * s, v4 * s);
        }

        public static Vector5<T> operator *(Vector5<T> left, Scalar<T> right)
        {
            return left.Multiply(right);
        }

        public static Vector5<T> operator *(Scalar<T> left, Vector5<T> right)
        {
            return right.Multiply(left);
        }

        public Vector5<T> DivideLeft(Scalar<T> s)
        {
            return new Vector5<T>(v0 / s, v1 / s, v2 / s, v3 / s, v4 / s);
        }

        public static Vector5<T> operator /(Vector5<T> left, Scalar<T> right)
        {
            return left.DivideLeft(right);
        }

        public Vector5<T> DivideRight(Scalar<T> s)
        {
            return new Vector5<T>(s / v0, s / v1, s / v2, s / v3, s / v4);
        }

        public Vector5<T> Reciprocal()
        {
            return new Vector5<T>(Scalar<T>.One / v0, Scalar<T>.One / v1, Scalar<T>.One / v2, Scalar<T>.One / v3, Scalar<T>.One / v4);
        }

        public static Vector5<T> operator /(Scalar<T> left, Vector5<T> right)
        {
            return right.DivideRight(left);
        }

        public Vector5<T> Negate()
        {
            return new Vector5<T>(-v0, -v1, -v2, -v3, -v4);
        }

        public static Vector5<T> operator -(Vector5<T> v)
        {
            return v.Negate();
        }

        #endregion

        #region Identity

        public static bool operator ==(Vector5<T> left, Vector5<T> right)
        {
            return left.v0 == right.v0 && left.v1 == right.v1 && left.v2 == right.v2 && left.v3 == right.v3 && left.v4 == right.v4;
        }

        public static bool operator !=(Vector5<T> left, Vector5<T> right)
        {
            return left.v0 != right.v0 || left.v1 != right.v1 || left.v2 != right.v2 || left.v3 != right.v3 || left.v4 != right.v4;
        }

        #endregion

        #endregion

        #region Implicit Conversion

        public static implicit operator Vector5<T>((T, T, T, T, T) t)
        {
            return new Vector5<T>(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5);
        }

        public static implicit operator (T, T, T, T, T) (Vector5<T> vec)
        {
            return (vec.v0.Value, vec.v1.Value, vec.v2.Value, vec.v3.Value, vec.v4.Value);
        }

        public static implicit operator Vector<T>(Vector5<T> t)
        {
            return new Vector<T>(t.Data);
        }

        public static implicit operator T[] (Vector5<T> t)
        {
            return new T[5] { t.v0.Value, t.v1.Value, t.v2.Value, t.v3.Value, t.v4.Value };
        }

        public void Deconstruct(out T v0, out T v1, out T v2, out T v3, out T v4)
        {
            v0 = this.v0.Value;
            v1 = this.v1.Value;
            v2 = this.v2.Value;
            v3 = this.v3.Value;
            v4 = this.v4.Value;
        }

        #endregion

        #region Interface Implementation

        public object Clone()
        {
            return new Vector5<T>(v0, v1, v2, v3, v4);
        }

        IEnumerator<Scalar<T>> IEnumerable<Scalar<T>>.GetEnumerator()
        {
            yield return v0;
            yield return v1;
            yield return v2;
            yield return v3;
            yield return v4;
        }

        public IEnumerator<T> GetEnumerator()
        {
            yield return v0.Value;
            yield return v1.Value;
            yield return v2.Value;
            yield return v3.Value;
            yield return v4.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        public bool Equals(Vector5<T> other)
        {
            return v0.Equals(other.v0) && v1.Equals(other.v1) && v2.Equals(other.v2) && v3.Equals(other.v3) && v4.Equals(other.v4);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector5<T> vec)
                return v0.Equals(vec.v0) && v1.Equals(vec.v1) && v2.Equals(vec.v2) && v3.Equals(vec.v3) && v4.Equals(vec.v4);

            return false;
        }

        public override string ToString()
        {
            return $"Vector5({ v0 }, { v1 }, { v2 }, { v3 }, { v4 })";
        }

        public override int GetHashCode()
        {
            return 31 * (31 * (31 * (31 * (31 * (1) + v0.GetHashCode()) + v1.GetHashCode()) + v2.GetHashCode()) + v3.GetHashCode()) + v4.GetHashCode();
        }

        #endregion
    }
}

namespace LinearAlgebraSharp.Vectors.Extensions
{
    public static partial class VectorExtansions
    {
        #region Vector1 Extensions

        public static Vector1<TResult> Select<T, TResult>(this Vector1<T> t, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            return new Vector1<TResult>(func(t.x.Value));
        }

        public static Vector1<TResult> Select<T, TResult>(this Vector1<T> t, Func<T, int, TResult> func)
            where T : struct
            where TResult : struct
        {
            return new Vector1<TResult>(func(t.x.Value, 0));
        }

        public static T Aggregate<T>(this Vector1<T> v, Func<T, T, T> func)
            where T : struct
        {
            return v.x.Value;
        }

        public static TResult Aggregate<T, TResult>(this Vector1<T> v, TResult seed, Func<TResult, T, TResult> func)
            where T : struct
            where TResult : struct
        {
            return func(seed, v.x.Value);
        }

        public static TResult Aggregate<T, TAccumulate, TResult>(this Vector1<T> v, TAccumulate seed, Func<TAccumulate, T, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
            where T : struct
            where TResult : struct
        {
            return resultSelector(func(seed, v.x.Value));
        }

        public static bool All<T>(this Vector1<T> v, Func<T, bool> pred)
            where T : struct
        {
            return pred(v.x.Value);
        }

        public static bool Any<T>(this Vector1<T> v, Func<T, bool> pred)
            where T : struct
        {
            return pred(v.x.Value);
        }

        public static T Average<T>(this Vector1<T> v)
            where T : struct
        {
            return ((v.x) / (1 * Scalar<T>.One)).Value;
        }

        public static TResult Average<T, TResult>(this Vector1<T> v, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            return (new Scalar<TResult>(func((v.x).Value)) / (1 * Scalar<TResult>.One)).Value;
        }

        public static T Sum<T>(this Vector1<T> v)
            where T : struct
        {
            return ((v.x)).Value;
        }

        public static TResult Sum<T, TResult>(this Vector1<T> v, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            return (new Scalar<TResult>(func((v.x).Value))).Value;
        }

        public static bool Contains<T>(this Vector1<T> v, T t)
            where T : struct
        {
            return v.x.Value.Equals(t);
        }

        public static int Count<T>(this Vector1<T> v, Func<T, bool> pred)
            where T : struct
        {
            return (pred(v.x.Value) ? 1 : 0);
        }

        public static T Max<T>(this Vector1<T> v)
            where T : struct
        {
            Scalar<T> max = v.x;


            return max.Value;
        }

        public static T Min<T>(this Vector1<T> v)
            where T : struct
        {
            Scalar<T> min = v.x;


            return min.Value;
        }

        public static TResult Max<T, TResult>(this Vector1<T> v, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            Scalar<TResult> max = new Scalar<TResult>(func(v.x.Value));


            return max.Value;
        }

        public static TResult Min<T, TResult>(this Vector1<T> v, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            Scalar<TResult> min = new Scalar<TResult>(func(v.x.Value));


            return min.Value;
        }

        public static Vector1<T> Reverse<T>(this Vector1<T> v)
            where T : struct
        {
            return new Vector1<T>(v.x);
        }

        public static Vector1<TResult> Zip<TFirst, TSecond, TResult>(this Vector1<TFirst> t1, Vector1<TSecond> t2, Func<TFirst, TSecond, TResult> func)
            where TFirst : struct
            where TSecond : struct
            where TResult : struct
        {
            return new Vector1<TResult>(func(t1.x.Value, t2.x.Value));
        }

        #endregion

        #region Vector2 Extensions

        public static Vector2<TResult> Select<T, TResult>(this Vector2<T> t, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            return new Vector2<TResult>(func(t.x.Value), func(t.y.Value));
        }

        public static Vector2<TResult> Select<T, TResult>(this Vector2<T> t, Func<T, int, TResult> func)
            where T : struct
            where TResult : struct
        {
            return new Vector2<TResult>(func(t.x.Value, 0), func(t.y.Value, 1));
        }

        public static T Aggregate<T>(this Vector2<T> v, Func<T, T, T> func)
            where T : struct
        {
            return func(v.x.Value, v.y.Value);
        }

        public static TResult Aggregate<T, TResult>(this Vector2<T> v, TResult seed, Func<TResult, T, TResult> func)
            where T : struct
            where TResult : struct
        {
            return func(func(seed, v.x.Value), v.y.Value);
        }

        public static TResult Aggregate<T, TAccumulate, TResult>(this Vector2<T> v, TAccumulate seed, Func<TAccumulate, T, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
            where T : struct
            where TResult : struct
        {
            return resultSelector(func(func(seed, v.x.Value), v.y.Value));
        }

        public static bool All<T>(this Vector2<T> v, Func<T, bool> pred)
            where T : struct
        {
            return pred(v.x.Value) && pred(v.y.Value);
        }

        public static bool Any<T>(this Vector2<T> v, Func<T, bool> pred)
            where T : struct
        {
            return pred(v.x.Value) || pred(v.y.Value);
        }

        public static T Average<T>(this Vector2<T> v)
            where T : struct
        {
            return ((v.x + v.y) / (2 * Scalar<T>.One)).Value;
        }

        public static TResult Average<T, TResult>(this Vector2<T> v, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            return (new Scalar<TResult>(func((v.x + v.y).Value)) / (2 * Scalar<TResult>.One)).Value;
        }

        public static T Sum<T>(this Vector2<T> v)
            where T : struct
        {
            return ((v.x + v.y)).Value;
        }

        public static TResult Sum<T, TResult>(this Vector2<T> v, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            return (new Scalar<TResult>(func((v.x + v.y).Value))).Value;
        }

        public static bool Contains<T>(this Vector2<T> v, T t)
            where T : struct
        {
            return v.x.Value.Equals(t) || v.y.Value.Equals(t);
        }

        public static int Count<T>(this Vector2<T> v, Func<T, bool> pred)
            where T : struct
        {
            return (pred(v.x.Value) ? 1 : 0) + (pred(v.y.Value) ? 1 : 0);
        }

        public static T Max<T>(this Vector2<T> v)
            where T : struct
        {
            Scalar<T> max = v.x;

            if (v.y > max) max = v.y;

            return max.Value;
        }

        public static T Min<T>(this Vector2<T> v)
            where T : struct
        {
            Scalar<T> min = v.x;

            if (v.y < min) min = v.y;

            return min.Value;
        }

        public static TResult Max<T, TResult>(this Vector2<T> v, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            Scalar<TResult> max = new Scalar<TResult>(func(v.x.Value)), temp;

            temp = new Scalar<TResult>(func(v.y.Value));
            if (temp > max) max = temp;

            return max.Value;
        }

        public static TResult Min<T, TResult>(this Vector2<T> v, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            Scalar<TResult> min = new Scalar<TResult>(func(v.x.Value)), temp;

            temp = new Scalar<TResult>(func(v.y.Value));
            if (temp < min) min = temp;

            return min.Value;
        }

        public static Vector2<T> Reverse<T>(this Vector2<T> v)
            where T : struct
        {
            return new Vector2<T>(v.y, v.x);
        }

        public static Vector2<TResult> Zip<TFirst, TSecond, TResult>(this Vector2<TFirst> t1, Vector2<TSecond> t2, Func<TFirst, TSecond, TResult> func)
            where TFirst : struct
            where TSecond : struct
            where TResult : struct
        {
            return new Vector2<TResult>(func(t1.x.Value, t2.x.Value), func(t1.y.Value, t2.y.Value));
        }

        #endregion

        #region Vector3 Extensions

        public static Vector3<TResult> Select<T, TResult>(this Vector3<T> t, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            return new Vector3<TResult>(func(t.x.Value), func(t.y.Value), func(t.z.Value));
        }

        public static Vector3<TResult> Select<T, TResult>(this Vector3<T> t, Func<T, int, TResult> func)
            where T : struct
            where TResult : struct
        {
            return new Vector3<TResult>(func(t.x.Value, 0), func(t.y.Value, 1), func(t.z.Value, 2));
        }

        public static T Aggregate<T>(this Vector3<T> v, Func<T, T, T> func)
            where T : struct
        {
            return func(func(v.x.Value, v.y.Value), v.z.Value);
        }

        public static TResult Aggregate<T, TResult>(this Vector3<T> v, TResult seed, Func<TResult, T, TResult> func)
            where T : struct
            where TResult : struct
        {
            return func(func(func(seed, v.x.Value), v.y.Value), v.z.Value);
        }

        public static TResult Aggregate<T, TAccumulate, TResult>(this Vector3<T> v, TAccumulate seed, Func<TAccumulate, T, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
            where T : struct
            where TResult : struct
        {
            return resultSelector(func(func(func(seed, v.x.Value), v.y.Value), v.z.Value));
        }

        public static bool All<T>(this Vector3<T> v, Func<T, bool> pred)
            where T : struct
        {
            return pred(v.x.Value) && pred(v.y.Value) && pred(v.z.Value);
        }

        public static bool Any<T>(this Vector3<T> v, Func<T, bool> pred)
            where T : struct
        {
            return pred(v.x.Value) || pred(v.y.Value) || pred(v.z.Value);
        }

        public static T Average<T>(this Vector3<T> v)
            where T : struct
        {
            return ((v.x + v.y + v.z) / (3 * Scalar<T>.One)).Value;
        }

        public static TResult Average<T, TResult>(this Vector3<T> v, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            return (new Scalar<TResult>(func((v.x + v.y + v.z).Value)) / (3 * Scalar<TResult>.One)).Value;
        }

        public static T Sum<T>(this Vector3<T> v)
            where T : struct
        {
            return ((v.x + v.y + v.z)).Value;
        }

        public static TResult Sum<T, TResult>(this Vector3<T> v, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            return (new Scalar<TResult>(func((v.x + v.y + v.z).Value))).Value;
        }

        public static bool Contains<T>(this Vector3<T> v, T t)
            where T : struct
        {
            return v.x.Value.Equals(t) || v.y.Value.Equals(t) || v.z.Value.Equals(t);
        }

        public static int Count<T>(this Vector3<T> v, Func<T, bool> pred)
            where T : struct
        {
            return (pred(v.x.Value) ? 1 : 0) + (pred(v.y.Value) ? 1 : 0) + (pred(v.z.Value) ? 1 : 0);
        }

        public static T Max<T>(this Vector3<T> v)
            where T : struct
        {
            Scalar<T> max = v.x;

            if (v.y > max) max = v.y;
            if (v.z > max) max = v.z;

            return max.Value;
        }

        public static T Min<T>(this Vector3<T> v)
            where T : struct
        {
            Scalar<T> min = v.x;

            if (v.y < min) min = v.y;
            if (v.z < min) min = v.z;

            return min.Value;
        }

        public static TResult Max<T, TResult>(this Vector3<T> v, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            Scalar<TResult> max = new Scalar<TResult>(func(v.x.Value)), temp;

            temp = new Scalar<TResult>(func(v.y.Value));
            if (temp > max) max = temp;
            temp = new Scalar<TResult>(func(v.z.Value));
            if (temp > max) max = temp;

            return max.Value;
        }

        public static TResult Min<T, TResult>(this Vector3<T> v, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            Scalar<TResult> min = new Scalar<TResult>(func(v.x.Value)), temp;

            temp = new Scalar<TResult>(func(v.y.Value));
            if (temp < min) min = temp;
            temp = new Scalar<TResult>(func(v.z.Value));
            if (temp < min) min = temp;

            return min.Value;
        }

        public static Vector3<T> Reverse<T>(this Vector3<T> v)
            where T : struct
        {
            return new Vector3<T>(v.z, v.y, v.x);
        }

        public static Vector3<TResult> Zip<TFirst, TSecond, TResult>(this Vector3<TFirst> t1, Vector3<TSecond> t2, Func<TFirst, TSecond, TResult> func)
            where TFirst : struct
            where TSecond : struct
            where TResult : struct
        {
            return new Vector3<TResult>(func(t1.x.Value, t2.x.Value), func(t1.y.Value, t2.y.Value), func(t1.z.Value, t2.z.Value));
        }

        #endregion

        #region Vector4 Extensions

        public static Vector4<TResult> Select<T, TResult>(this Vector4<T> t, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            return new Vector4<TResult>(func(t.x.Value), func(t.y.Value), func(t.z.Value), func(t.w.Value));
        }

        public static Vector4<TResult> Select<T, TResult>(this Vector4<T> t, Func<T, int, TResult> func)
            where T : struct
            where TResult : struct
        {
            return new Vector4<TResult>(func(t.x.Value, 0), func(t.y.Value, 1), func(t.z.Value, 2), func(t.w.Value, 3));
        }

        public static T Aggregate<T>(this Vector4<T> v, Func<T, T, T> func)
            where T : struct
        {
            return func(func(func(v.x.Value, v.y.Value), v.z.Value), v.w.Value);
        }

        public static TResult Aggregate<T, TResult>(this Vector4<T> v, TResult seed, Func<TResult, T, TResult> func)
            where T : struct
            where TResult : struct
        {
            return func(func(func(func(seed, v.x.Value), v.y.Value), v.z.Value), v.w.Value);
        }

        public static TResult Aggregate<T, TAccumulate, TResult>(this Vector4<T> v, TAccumulate seed, Func<TAccumulate, T, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
            where T : struct
            where TResult : struct
        {
            return resultSelector(func(func(func(func(seed, v.x.Value), v.y.Value), v.z.Value), v.w.Value));
        }

        public static bool All<T>(this Vector4<T> v, Func<T, bool> pred)
            where T : struct
        {
            return pred(v.x.Value) && pred(v.y.Value) && pred(v.z.Value) && pred(v.w.Value);
        }

        public static bool Any<T>(this Vector4<T> v, Func<T, bool> pred)
            where T : struct
        {
            return pred(v.x.Value) || pred(v.y.Value) || pred(v.z.Value) || pred(v.w.Value);
        }

        public static T Average<T>(this Vector4<T> v)
            where T : struct
        {
            return ((v.x + v.y + v.z + v.w) / (4 * Scalar<T>.One)).Value;
        }

        public static TResult Average<T, TResult>(this Vector4<T> v, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            return (new Scalar<TResult>(func((v.x + v.y + v.z + v.w).Value)) / (4 * Scalar<TResult>.One)).Value;
        }

        public static T Sum<T>(this Vector4<T> v)
            where T : struct
        {
            return ((v.x + v.y + v.z + v.w)).Value;
        }

        public static TResult Sum<T, TResult>(this Vector4<T> v, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            return (new Scalar<TResult>(func((v.x + v.y + v.z + v.w).Value))).Value;
        }

        public static bool Contains<T>(this Vector4<T> v, T t)
            where T : struct
        {
            return v.x.Value.Equals(t) || v.y.Value.Equals(t) || v.z.Value.Equals(t) || v.w.Value.Equals(t);
        }

        public static int Count<T>(this Vector4<T> v, Func<T, bool> pred)
            where T : struct
        {
            return (pred(v.x.Value) ? 1 : 0) + (pred(v.y.Value) ? 1 : 0) + (pred(v.z.Value) ? 1 : 0) + (pred(v.w.Value) ? 1 : 0);
        }

        public static T Max<T>(this Vector4<T> v)
            where T : struct
        {
            Scalar<T> max = v.x;

            if (v.y > max) max = v.y;
            if (v.z > max) max = v.z;
            if (v.w > max) max = v.w;

            return max.Value;
        }

        public static T Min<T>(this Vector4<T> v)
            where T : struct
        {
            Scalar<T> min = v.x;

            if (v.y < min) min = v.y;
            if (v.z < min) min = v.z;
            if (v.w < min) min = v.w;

            return min.Value;
        }

        public static TResult Max<T, TResult>(this Vector4<T> v, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            Scalar<TResult> max = new Scalar<TResult>(func(v.x.Value)), temp;

            temp = new Scalar<TResult>(func(v.y.Value));
            if (temp > max) max = temp;
            temp = new Scalar<TResult>(func(v.z.Value));
            if (temp > max) max = temp;
            temp = new Scalar<TResult>(func(v.w.Value));
            if (temp > max) max = temp;

            return max.Value;
        }

        public static TResult Min<T, TResult>(this Vector4<T> v, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            Scalar<TResult> min = new Scalar<TResult>(func(v.x.Value)), temp;

            temp = new Scalar<TResult>(func(v.y.Value));
            if (temp < min) min = temp;
            temp = new Scalar<TResult>(func(v.z.Value));
            if (temp < min) min = temp;
            temp = new Scalar<TResult>(func(v.w.Value));
            if (temp < min) min = temp;

            return min.Value;
        }

        public static Vector4<T> Reverse<T>(this Vector4<T> v)
            where T : struct
        {
            return new Vector4<T>(v.w, v.z, v.y, v.x);
        }

        public static Vector4<TResult> Zip<TFirst, TSecond, TResult>(this Vector4<TFirst> t1, Vector4<TSecond> t2, Func<TFirst, TSecond, TResult> func)
            where TFirst : struct
            where TSecond : struct
            where TResult : struct
        {
            return new Vector4<TResult>(func(t1.x.Value, t2.x.Value), func(t1.y.Value, t2.y.Value), func(t1.z.Value, t2.z.Value), func(t1.w.Value, t2.w.Value));
        }

        #endregion

        #region Vector5 Extensions

        public static Vector5<TResult> Select<T, TResult>(this Vector5<T> t, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            return new Vector5<TResult>(func(t.v0.Value), func(t.v1.Value), func(t.v2.Value), func(t.v3.Value), func(t.v4.Value));
        }

        public static Vector5<TResult> Select<T, TResult>(this Vector5<T> t, Func<T, int, TResult> func)
            where T : struct
            where TResult : struct
        {
            return new Vector5<TResult>(func(t.v0.Value, 0), func(t.v1.Value, 1), func(t.v2.Value, 2), func(t.v3.Value, 3), func(t.v4.Value, 4));
        }

        public static T Aggregate<T>(this Vector5<T> v, Func<T, T, T> func)
            where T : struct
        {
            return func(func(func(func(v.v0.Value, v.v1.Value), v.v2.Value), v.v3.Value), v.v4.Value);
        }

        public static TResult Aggregate<T, TResult>(this Vector5<T> v, TResult seed, Func<TResult, T, TResult> func)
            where T : struct
            where TResult : struct
        {
            return func(func(func(func(func(seed, v.v0.Value), v.v1.Value), v.v2.Value), v.v3.Value), v.v4.Value);
        }

        public static TResult Aggregate<T, TAccumulate, TResult>(this Vector5<T> v, TAccumulate seed, Func<TAccumulate, T, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
            where T : struct
            where TResult : struct
        {
            return resultSelector(func(func(func(func(func(seed, v.v0.Value), v.v1.Value), v.v2.Value), v.v3.Value), v.v4.Value));
        }

        public static bool All<T>(this Vector5<T> v, Func<T, bool> pred)
            where T : struct
        {
            return pred(v.v0.Value) && pred(v.v1.Value) && pred(v.v2.Value) && pred(v.v3.Value) && pred(v.v4.Value);
        }

        public static bool Any<T>(this Vector5<T> v, Func<T, bool> pred)
            where T : struct
        {
            return pred(v.v0.Value) || pred(v.v1.Value) || pred(v.v2.Value) || pred(v.v3.Value) || pred(v.v4.Value);
        }

        public static T Average<T>(this Vector5<T> v)
            where T : struct
        {
            return ((v.v0 + v.v1 + v.v2 + v.v3 + v.v4) / (5 * Scalar<T>.One)).Value;
        }

        public static TResult Average<T, TResult>(this Vector5<T> v, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            return (new Scalar<TResult>(func((v.v0 + v.v1 + v.v2 + v.v3 + v.v4).Value)) / (5 * Scalar<TResult>.One)).Value;
        }

        public static T Sum<T>(this Vector5<T> v)
            where T : struct
        {
            return ((v.v0 + v.v1 + v.v2 + v.v3 + v.v4)).Value;
        }

        public static TResult Sum<T, TResult>(this Vector5<T> v, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            return (new Scalar<TResult>(func((v.v0 + v.v1 + v.v2 + v.v3 + v.v4).Value))).Value;
        }

        public static bool Contains<T>(this Vector5<T> v, T t)
            where T : struct
        {
            return v.v0.Value.Equals(t) || v.v1.Value.Equals(t) || v.v2.Value.Equals(t) || v.v3.Value.Equals(t) || v.v4.Value.Equals(t);
        }

        public static int Count<T>(this Vector5<T> v, Func<T, bool> pred)
            where T : struct
        {
            return (pred(v.v0.Value) ? 1 : 0) + (pred(v.v1.Value) ? 1 : 0) + (pred(v.v2.Value) ? 1 : 0) + (pred(v.v3.Value) ? 1 : 0) + (pred(v.v4.Value) ? 1 : 0);
        }

        public static T Max<T>(this Vector5<T> v)
            where T : struct
        {
            Scalar<T> max = v.v0;

            if (v.v1 > max) max = v.v1;
            if (v.v2 > max) max = v.v2;
            if (v.v3 > max) max = v.v3;
            if (v.v4 > max) max = v.v4;

            return max.Value;
        }

        public static T Min<T>(this Vector5<T> v)
            where T : struct
        {
            Scalar<T> min = v.v0;

            if (v.v1 < min) min = v.v1;
            if (v.v2 < min) min = v.v2;
            if (v.v3 < min) min = v.v3;
            if (v.v4 < min) min = v.v4;

            return min.Value;
        }

        public static TResult Max<T, TResult>(this Vector5<T> v, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            Scalar<TResult> max = new Scalar<TResult>(func(v.v0.Value)), temp;

            temp = new Scalar<TResult>(func(v.v1.Value));
            if (temp > max) max = temp;
            temp = new Scalar<TResult>(func(v.v2.Value));
            if (temp > max) max = temp;
            temp = new Scalar<TResult>(func(v.v3.Value));
            if (temp > max) max = temp;
            temp = new Scalar<TResult>(func(v.v4.Value));
            if (temp > max) max = temp;

            return max.Value;
        }

        public static TResult Min<T, TResult>(this Vector5<T> v, Func<T, TResult> func)
            where T : struct
            where TResult : struct
        {
            Scalar<TResult> min = new Scalar<TResult>(func(v.v0.Value)), temp;

            temp = new Scalar<TResult>(func(v.v1.Value));
            if (temp < min) min = temp;
            temp = new Scalar<TResult>(func(v.v2.Value));
            if (temp < min) min = temp;
            temp = new Scalar<TResult>(func(v.v3.Value));
            if (temp < min) min = temp;
            temp = new Scalar<TResult>(func(v.v4.Value));
            if (temp < min) min = temp;

            return min.Value;
        }

        public static Vector5<T> Reverse<T>(this Vector5<T> v)
            where T : struct
        {
            return new Vector5<T>(v.v4, v.v3, v.v2, v.v1, v.v0);
        }

        public static Vector5<TResult> Zip<TFirst, TSecond, TResult>(this Vector5<TFirst> t1, Vector5<TSecond> t2, Func<TFirst, TSecond, TResult> func)
            where TFirst : struct
            where TSecond : struct
            where TResult : struct
        {
            return new Vector5<TResult>(func(t1.v0.Value, t2.v0.Value), func(t1.v1.Value, t2.v1.Value), func(t1.v2.Value, t2.v2.Value), func(t1.v3.Value, t2.v3.Value), func(t1.v4.Value, t2.v4.Value));
        }

        #endregion
    }
}