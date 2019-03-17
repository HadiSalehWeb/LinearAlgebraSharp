using LinearAlgebra.Scalars;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LinearAlgebra.Vectors
{
    public struct Vector1<T> : ICloneable, IEquatable<Vector1<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>
        where T : struct, IComparable
    {
        public readonly Scalar<T> x;

        public static readonly Vector1<T> zero = new Vector1<T>(Scalar<T>.Zero);
        public static readonly Vector1<T> one = new Vector1<T>(Scalar<T>.One);

        public static readonly Vector1<T> right = new Vector1<T>(Scalar<T>.One);
        public static readonly Vector1<T> left = new Vector1<T>(-Scalar<T>.One);

        public Scalar<int> Dimension => 1;
        public Scalar<T>[] Data => new Scalar<T>[1] { x };
        public Scalar<T> this[int i] => Data[i];
		
        public Vector1(Scalar<T> x)
        {
            this.x = x;
        }

        public Vector1(T x)
        {
            this.x = new Scalar<T>(x);
        }

        public static Vector1<T> operator +(Vector1<T> left, Vector1<T> right)
        {
            return new Vector1<T>(left.x + right.x);
        }

        public static Vector1<T> operator -(Vector1<T> left, Vector1<T> right)
        {
            return new Vector1<T>(left.x - right.x);
        }

        public static Vector1<T> operator *(Vector1<T> left, Scalar<T> right)
        {
            return new Vector1<T>(left.x * right);
        }

        public static Vector1<T> operator *(Scalar<T> left, Vector1<T> right)
        {
            return new Vector1<T>(left * right.x);
        }

        public static Vector1<T> operator /(Vector1<T> left, Scalar<T> right)
        {
            return new Vector1<T>(left.x / right);
        }

        public static Vector1<T> operator /(Scalar<T> left, Vector1<T> right)
        {
            return new Vector1<T>(left / right.x);
        }

        public static bool operator ==(Vector1<T> left, Vector1<T> right)
        {
            return left.x == right.x;
        }

        public static bool operator !=(Vector1<T> left, Vector1<T> right)
        {
            return left.x != right.x;
        }

        public Vector1<T> Scale(Vector1<T> vec)
        {
            return new Vector1<T>(x * vec.x);
        }

        public Scalar<T> Dot(Vector1<T> vec)
        {
            return x * vec.x;
        }

        public static implicit operator Vector1<T>(T t)
        {
            return new Vector1<T>(t);
        }

        public static implicit operator Vector<T>(Vector1<T> t)
        {
            return new Vector<T>(t.Data);
        }

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
			return this.GetEnumerator();
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
            return 1 * x;
        }

        public Scalar<T> SqrMagnitude => x * x;
        public Scalar<T> Magnitude => Math.Sqrt(SqrMagnitude);
        public Vector1<T> Normalized => this / Magnitude;
    }

    public struct Vector2<T> : ICloneable, IEquatable<Vector2<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>
        where T : struct, IComparable
    {
        public readonly Scalar<T> x, y;

        public static readonly Vector2<T> zero = new Vector2<T>(Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector2<T> one = new Vector2<T>(Scalar<T>.One, Scalar<T>.One);

        public static readonly Vector2<T> right = new Vector2<T>(Scalar<T>.One, Scalar<T>.Zero);
        public static readonly Vector2<T> left = new Vector2<T>(-Scalar<T>.One, Scalar<T>.Zero);
        public static readonly Vector2<T> up = new Vector2<T>(Scalar<T>.Zero, Scalar<T>.One);
        public static readonly Vector2<T> down = new Vector2<T>(Scalar<T>.Zero, -Scalar<T>.One);

        public Scalar<int> Dimension => 2;
        public Scalar<T>[] Data => new Scalar<T>[2] { x, y };
        public Scalar<T> this[int i] => Data[i];
		
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
            this.x = s;
            this.y = s;
        }

        public Vector2(T t)
        {
            this.x = new Scalar<T>(t);
            this.y = new Scalar<T>(t);
        }

        public static Vector2<T> operator +(Vector2<T> left, Vector2<T> right)
        {
            return new Vector2<T>(left.x + right.x, left.y + right.y);
        }

        public static Vector2<T> operator -(Vector2<T> left, Vector2<T> right)
        {
            return new Vector2<T>(left.x - right.x, left.y - right.y);
        }

        public static Vector2<T> operator *(Vector2<T> left, Scalar<T> right)
        {
            return new Vector2<T>(left.x * right, left.y * right);
        }

        public static Vector2<T> operator *(Scalar<T> left, Vector2<T> right)
        {
            return new Vector2<T>(left * right.x, left * right.y);
        }

        public static Vector2<T> operator /(Vector2<T> left, Scalar<T> right)
        {
            return new Vector2<T>(left.x / right, left.y / right);
        }

        public static Vector2<T> operator /(Scalar<T> left, Vector2<T> right)
        {
            return new Vector2<T>(left / right.x, left / right.y);
        }

        public static bool operator ==(Vector2<T> left, Vector2<T> right)
        {
            return left.x == right.x && left.y == right.y;
        }

        public static bool operator !=(Vector2<T> left, Vector2<T> right)
        {
            return left.x != right.x || left.y != right.y;
        }

        public Vector2<T> Scale(Vector2<T> vec)
        {
            return new Vector2<T>(x * vec.x, y * vec.y);
        }

        public Scalar<T> Dot(Vector2<T> vec)
        {
            return x * vec.x + y * vec.y;
        }

        public static implicit operator Vector2<T>((T, T) t)
        {
            return new Vector2<T>(t.Item1, t.Item2);
        }

        public static implicit operator Vector<T>(Vector2<T> t)
        {
            return new Vector<T>(t.Data);
        }

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
			return this.GetEnumerator();
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
            return 1 * x + 2136537719 * y;
        }

        public Scalar<T> SqrMagnitude => x * x + y * y;
        public Scalar<T> Magnitude => Math.Sqrt(SqrMagnitude);
        public Vector2<T> Normalized => this / Magnitude;
    }

    public struct Vector3<T> : ICloneable, IEquatable<Vector3<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>
        where T : struct, IComparable
    {
        public readonly Scalar<T> x, y, z;

        public static readonly Vector3<T> zero = new Vector3<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector3<T> one = new Vector3<T>(Scalar<T>.One, Scalar<T>.One, Scalar<T>.One);

        public static readonly Vector3<T> right = new Vector3<T>(Scalar<T>.One, Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector3<T> left = new Vector3<T>(-Scalar<T>.One, Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector3<T> up = new Vector3<T>(Scalar<T>.Zero, Scalar<T>.One, Scalar<T>.Zero);
        public static readonly Vector3<T> down = new Vector3<T>(Scalar<T>.Zero, -Scalar<T>.One, Scalar<T>.Zero);
        public static readonly Vector3<T> forward = new Vector3<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.One);
        public static readonly Vector3<T> backward = new Vector3<T>(Scalar<T>.Zero, Scalar<T>.Zero, -Scalar<T>.One);

        public Scalar<int> Dimension => 3;
        public Scalar<T>[] Data => new Scalar<T>[3] { x, y, z };
        public Scalar<T> this[int i] => Data[i];
		
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
            this.x = s;
            this.y = s;
            this.z = s;
        }

        public Vector3(T t)
        {
            this.x = new Scalar<T>(t);
            this.y = new Scalar<T>(t);
            this.z = new Scalar<T>(t);
        }

        public static Vector3<T> operator +(Vector3<T> left, Vector3<T> right)
        {
            return new Vector3<T>(left.x + right.x, left.y + right.y, left.z + right.z);
        }

        public static Vector3<T> operator -(Vector3<T> left, Vector3<T> right)
        {
            return new Vector3<T>(left.x - right.x, left.y - right.y, left.z - right.z);
        }

        public static Vector3<T> operator *(Vector3<T> left, Scalar<T> right)
        {
            return new Vector3<T>(left.x * right, left.y * right, left.z * right);
        }

        public static Vector3<T> operator *(Scalar<T> left, Vector3<T> right)
        {
            return new Vector3<T>(left * right.x, left * right.y, left * right.z);
        }

        public static Vector3<T> operator /(Vector3<T> left, Scalar<T> right)
        {
            return new Vector3<T>(left.x / right, left.y / right, left.z / right);
        }

        public static Vector3<T> operator /(Scalar<T> left, Vector3<T> right)
        {
            return new Vector3<T>(left / right.x, left / right.y, left / right.z);
        }

        public static bool operator ==(Vector3<T> left, Vector3<T> right)
        {
            return left.x == right.x && left.y == right.y && left.z == right.z;
        }

        public static bool operator !=(Vector3<T> left, Vector3<T> right)
        {
            return left.x != right.x || left.y != right.y || left.z != right.z;
        }

        public Vector3<T> Scale(Vector3<T> vec)
        {
            return new Vector3<T>(x * vec.x, y * vec.y, z * vec.z);
        }

        public Scalar<T> Dot(Vector3<T> vec)
        {
            return x * vec.x + y * vec.y + z * vec.z;
        }

        public static implicit operator Vector3<T>((T, T, T) t)
        {
            return new Vector3<T>(t.Item1, t.Item2, t.Item3);
        }

        public static implicit operator Vector<T>(Vector3<T> t)
        {
            return new Vector<T>(t.Data);
        }

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
			return this.GetEnumerator();
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
            return 1 * x + 2136537719 * y + 298955857 * z;
        }

        public Scalar<T> SqrMagnitude => x * x + y * y + z * z;
        public Scalar<T> Magnitude => Math.Sqrt(SqrMagnitude);
        public Vector3<T> Normalized => this / Magnitude;
    }

    public struct Vector4<T> : ICloneable, IEquatable<Vector4<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>
        where T : struct, IComparable
    {
        public readonly Scalar<T> x, y, z, w;

        public static readonly Vector4<T> zero = new Vector4<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector4<T> one = new Vector4<T>(Scalar<T>.One, Scalar<T>.One, Scalar<T>.One, Scalar<T>.One);

        public static readonly Vector4<T> right = new Vector4<T>(Scalar<T>.One, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector4<T> left = new Vector4<T>(-Scalar<T>.One, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector4<T> up = new Vector4<T>(Scalar<T>.Zero, Scalar<T>.One, Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector4<T> down = new Vector4<T>(Scalar<T>.Zero, -Scalar<T>.One, Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector4<T> forward = new Vector4<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.One, Scalar<T>.Zero);
        public static readonly Vector4<T> backward = new Vector4<T>(Scalar<T>.Zero, Scalar<T>.Zero, -Scalar<T>.One, Scalar<T>.Zero);
        public static readonly Vector4<T> ana = new Vector4<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.One);
        public static readonly Vector4<T> kata = new Vector4<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero, -Scalar<T>.One);

        public Scalar<int> Dimension => 4;
        public Scalar<T>[] Data => new Scalar<T>[4] { x, y, z, w };
        public Scalar<T> this[int i] => Data[i];
		
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
            this.x = s;
            this.y = s;
            this.z = s;
            this.w = s;
        }

        public Vector4(T t)
        {
            this.x = new Scalar<T>(t);
            this.y = new Scalar<T>(t);
            this.z = new Scalar<T>(t);
            this.w = new Scalar<T>(t);
        }

        public static Vector4<T> operator +(Vector4<T> left, Vector4<T> right)
        {
            return new Vector4<T>(left.x + right.x, left.y + right.y, left.z + right.z, left.w + right.w);
        }

        public static Vector4<T> operator -(Vector4<T> left, Vector4<T> right)
        {
            return new Vector4<T>(left.x - right.x, left.y - right.y, left.z - right.z, left.w - right.w);
        }

        public static Vector4<T> operator *(Vector4<T> left, Scalar<T> right)
        {
            return new Vector4<T>(left.x * right, left.y * right, left.z * right, left.w * right);
        }

        public static Vector4<T> operator *(Scalar<T> left, Vector4<T> right)
        {
            return new Vector4<T>(left * right.x, left * right.y, left * right.z, left * right.w);
        }

        public static Vector4<T> operator /(Vector4<T> left, Scalar<T> right)
        {
            return new Vector4<T>(left.x / right, left.y / right, left.z / right, left.w / right);
        }

        public static Vector4<T> operator /(Scalar<T> left, Vector4<T> right)
        {
            return new Vector4<T>(left / right.x, left / right.y, left / right.z, left / right.w);
        }

        public static bool operator ==(Vector4<T> left, Vector4<T> right)
        {
            return left.x == right.x && left.y == right.y && left.z == right.z && left.w == right.w;
        }

        public static bool operator !=(Vector4<T> left, Vector4<T> right)
        {
            return left.x != right.x || left.y != right.y || left.z != right.z || left.w != right.w;
        }

        public Vector4<T> Scale(Vector4<T> vec)
        {
            return new Vector4<T>(x * vec.x, y * vec.y, z * vec.z, w * vec.w);
        }

        public Scalar<T> Dot(Vector4<T> vec)
        {
            return x * vec.x + y * vec.y + z * vec.z + w * vec.w;
        }

        public static implicit operator Vector4<T>((T, T, T, T) t)
        {
            return new Vector4<T>(t.Item1, t.Item2, t.Item3, t.Item4);
        }

        public static implicit operator Vector<T>(Vector4<T> t)
        {
            return new Vector<T>(t.Data);
        }

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
			return this.GetEnumerator();
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
            return 1 * x + 2136537719 * y + 298955857 * z + 421235453 * w;
        }

        public Scalar<T> SqrMagnitude => x * x + y * y + z * z + w * w;
        public Scalar<T> Magnitude => Math.Sqrt(SqrMagnitude);
        public Vector4<T> Normalized => this / Magnitude;
    }

    public struct Vector5<T> : ICloneable, IEquatable<Vector5<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>
        where T : struct, IComparable
    {
        public readonly Scalar<T> v0, v1, v2, v3, v4;

        public static readonly Vector5<T> zero = new Vector5<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero);
        public static readonly Vector5<T> one = new Vector5<T>(Scalar<T>.One, Scalar<T>.One, Scalar<T>.One, Scalar<T>.One, Scalar<T>.One);


        public Scalar<int> Dimension => 5;
        public Scalar<T>[] Data => new Scalar<T>[5] { v0, v1, v2, v3, v4 };
        public Scalar<T> this[int i] => Data[i];
		
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
            this.v0 = s;
            this.v1 = s;
            this.v2 = s;
            this.v3 = s;
            this.v4 = s;
        }

        public Vector5(T t)
        {
            this.v0 = new Scalar<T>(t);
            this.v1 = new Scalar<T>(t);
            this.v2 = new Scalar<T>(t);
            this.v3 = new Scalar<T>(t);
            this.v4 = new Scalar<T>(t);
        }

        public static Vector5<T> operator +(Vector5<T> left, Vector5<T> right)
        {
            return new Vector5<T>(left.v0 + right.v0, left.v1 + right.v1, left.v2 + right.v2, left.v3 + right.v3, left.v4 + right.v4);
        }

        public static Vector5<T> operator -(Vector5<T> left, Vector5<T> right)
        {
            return new Vector5<T>(left.v0 - right.v0, left.v1 - right.v1, left.v2 - right.v2, left.v3 - right.v3, left.v4 - right.v4);
        }

        public static Vector5<T> operator *(Vector5<T> left, Scalar<T> right)
        {
            return new Vector5<T>(left.v0 * right, left.v1 * right, left.v2 * right, left.v3 * right, left.v4 * right);
        }

        public static Vector5<T> operator *(Scalar<T> left, Vector5<T> right)
        {
            return new Vector5<T>(left * right.v0, left * right.v1, left * right.v2, left * right.v3, left * right.v4);
        }

        public static Vector5<T> operator /(Vector5<T> left, Scalar<T> right)
        {
            return new Vector5<T>(left.v0 / right, left.v1 / right, left.v2 / right, left.v3 / right, left.v4 / right);
        }

        public static Vector5<T> operator /(Scalar<T> left, Vector5<T> right)
        {
            return new Vector5<T>(left / right.v0, left / right.v1, left / right.v2, left / right.v3, left / right.v4);
        }

        public static bool operator ==(Vector5<T> left, Vector5<T> right)
        {
            return left.v0 == right.v0 && left.v1 == right.v1 && left.v2 == right.v2 && left.v3 == right.v3 && left.v4 == right.v4;
        }

        public static bool operator !=(Vector5<T> left, Vector5<T> right)
        {
            return left.v0 != right.v0 || left.v1 != right.v1 || left.v2 != right.v2 || left.v3 != right.v3 || left.v4 != right.v4;
        }

        public Vector5<T> Scale(Vector5<T> vec)
        {
            return new Vector5<T>(v0 * vec.v0, v1 * vec.v1, v2 * vec.v2, v3 * vec.v3, v4 * vec.v4);
        }

        public Scalar<T> Dot(Vector5<T> vec)
        {
            return v0 * vec.v0 + v1 * vec.v1 + v2 * vec.v2 + v3 * vec.v3 + v4 * vec.v4;
        }

        public static implicit operator Vector5<T>((T, T, T, T, T) t)
        {
            return new Vector5<T>(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5);
        }

        public static implicit operator Vector<T>(Vector5<T> t)
        {
            return new Vector<T>(t.Data);
        }

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
			return this.GetEnumerator();
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
            return 1 * v0 + 2136537719 * v1 + 298955857 * v2 + 421235453 * v3 + 311692756 * v4;
        }

        public Scalar<T> SqrMagnitude => v0 * v0 + v1 * v1 + v2 * v2 + v3 * v3 + v4 * v4;
        public Scalar<T> Magnitude => Math.Sqrt(SqrMagnitude);
        public Vector5<T> Normalized => this / Magnitude;
    }
}