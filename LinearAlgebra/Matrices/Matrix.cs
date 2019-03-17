using LinearAlgebra.Vectors;
using LinearAlgebra.Scalars;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LinearAlgebra.Matrices
{
    public struct Matrix1x1<T> : ICloneable, IEquatable<Matrix1x1<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>
        where T : struct, IComparable
    {
        public readonly Scalar<T> e00;

        public Vector2<int> Dimensions => new Vector2<int>(1, 1);

        public Scalar<T>[,] Data => new Scalar<T>[1, 1] {
            { e00 }
        };

        public static Matrix1x1<T> Zero()
        {
            return new Matrix1x1<T>(0);
        }
		
        public static Matrix1x1<T> One()
        {
            return new Matrix1x1<T>(1);
        }
		
        public Matrix1x1(Scalar<T> e00)
        {
            this.e00 = e00;
        }

        public Matrix1x1(T e00)
        {
            this.e00 = new Scalar<T>(e00);
        }

        public Scalar<T> this[int i, int j] => Data[i, j];

        public Vector1<T>[] Rows
        {
            get
            {
                return new Vector1<T>[]
                {
                    new Vector1<T>(e00)
                };
            }
        }

        public Vector1<T>[] Columns
        {
            get
            {
                return new Vector1<T>[]
                {
                    new Vector1<T>(e00)
                };
            }
        }

        public Vector1<T> Transform(Vector1<T> vec)
        {
            return new Vector1<T>(
                e00 * vec.x
            );
        }

        public Matrix1x1<T> Transform(Matrix1x1<T> mat)
        {
            return new Matrix1x1<T>(
                e00 * mat.e00
            );
        }

        public override string ToString()
        {
            return $"Matrix1x1(" + Environment.NewLine +
                    $"\t({ e00 })" + Environment.NewLine +
                $")";
        }
		
        public override bool Equals(object obj)
        {
            if (obj is Matrix1x1<T> m)
                return Equals(m);

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new Matrix1x1<T>(e00);
        }

        public bool Equals(Matrix1x1<T> other)
        {
            return e00 == other.e00;
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<Scalar<T>> IEnumerable<Scalar<T>>.GetEnumerator()
        {
            yield return e00;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            yield return e00.Value;
        }
    }

    public struct Matrix1x2<T> : ICloneable, IEquatable<Matrix1x2<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>
        where T : struct, IComparable
    {
        public readonly Scalar<T> e00, e01;

        public Vector2<int> Dimensions => new Vector2<int>(1, 2);

        public Scalar<T>[,] Data => new Scalar<T>[1, 2] {
            { e00, e01 }
        };

        public static Matrix1x2<T> Zero()
        {
            return new Matrix1x2<T>(0, 0);
        }
		
        public Matrix1x2(Scalar<T> e00, Scalar<T> e01)
        {
            this.e00 = e00;
            this.e01 = e01;
        }

        public Matrix1x2(T e00, T e01)
        {
            this.e00 = new Scalar<T>(e00);
            this.e01 = new Scalar<T>(e01);
        }

        public Scalar<T> this[int i, int j] => Data[i, j];

        public Vector2<T>[] Rows
        {
            get
            {
                return new Vector2<T>[]
                {
                    new Vector2<T>(e00, e01)
                };
            }
        }

        public Vector1<T>[] Columns
        {
            get
            {
                return new Vector1<T>[]
                {
                    new Vector1<T>(e00),
                    new Vector1<T>(e01)
                };
            }
        }

        public Vector1<T> Transform(Vector2<T> vec)
        {
            return new Vector1<T>(
                e00 * vec.x + e01 * vec.y
            );
        }

        public Matrix1x1<T> Transform(Matrix2x1<T> mat)
        {
            return new Matrix1x1<T>(
                e00 * mat.e00 + e01 * mat.e10
            );
        }

        public override string ToString()
        {
            return $"Matrix1x2(" + Environment.NewLine +
                    $"\t({ e00 }, { e01 })" + Environment.NewLine +
                $")";
        }
		
        public override bool Equals(object obj)
        {
            if (obj is Matrix1x2<T> m)
                return Equals(m);

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new Matrix1x2<T>(e00, e01);
        }

        public bool Equals(Matrix1x2<T> other)
        {
            return e00 == other.e00 && e01 == other.e01;
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<Scalar<T>> IEnumerable<Scalar<T>>.GetEnumerator()
        {
            yield return e00;
            yield return e01;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            yield return e00.Value;
            yield return e01.Value;
        }
    }

    public struct Matrix2x1<T> : ICloneable, IEquatable<Matrix2x1<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>
        where T : struct, IComparable
    {
        public readonly Scalar<T> e00, e10;

        public Vector2<int> Dimensions => new Vector2<int>(2, 1);

        public Scalar<T>[,] Data => new Scalar<T>[2, 1] {
            { e00 },
            { e10 }
        };

        public static Matrix2x1<T> Zero()
        {
            return new Matrix2x1<T>(0, 0);
        }
		
        public Matrix2x1(Scalar<T> e00, Scalar<T> e10)
        {
            this.e00 = e00;
            this.e10 = e10;
        }

        public Matrix2x1(T e00, T e10)
        {
            this.e00 = new Scalar<T>(e00);
            this.e10 = new Scalar<T>(e10);
        }

        public Scalar<T> this[int i, int j] => Data[i, j];

        public Vector1<T>[] Rows
        {
            get
            {
                return new Vector1<T>[]
                {
                    new Vector1<T>(e00),
                    new Vector1<T>(e10)
                };
            }
        }

        public Vector2<T>[] Columns
        {
            get
            {
                return new Vector2<T>[]
                {
                    new Vector2<T>(e00, e10)
                };
            }
        }

        public Vector2<T> Transform(Vector1<T> vec)
        {
            return new Vector2<T>(
                e00 * vec.x,
                e10 * vec.x
            );
        }

        public Matrix1x2<T> Transform(Matrix1x1<T> mat)
        {
            return new Matrix1x2<T>(
                e00 * mat.e00,
                e10 * mat.e00
            );
        }

        public override string ToString()
        {
            return $"Matrix2x1(" + Environment.NewLine +
                    $"\t({ e00 })," + Environment.NewLine +
                    $"\t({ e10 })" + Environment.NewLine +
                $")";
        }
		
        public override bool Equals(object obj)
        {
            if (obj is Matrix2x1<T> m)
                return Equals(m);

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new Matrix2x1<T>(e00, e10);
        }

        public bool Equals(Matrix2x1<T> other)
        {
            return e00 == other.e00 && e10 == other.e10;
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<Scalar<T>> IEnumerable<Scalar<T>>.GetEnumerator()
        {
            yield return e00;
            yield return e10;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            yield return e00.Value;
            yield return e10.Value;
        }
    }

    public struct Matrix1x3<T> : ICloneable, IEquatable<Matrix1x3<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>
        where T : struct, IComparable
    {
        public readonly Scalar<T> e00, e01, e02;

        public Vector2<int> Dimensions => new Vector2<int>(1, 3);

        public Scalar<T>[,] Data => new Scalar<T>[1, 3] {
            { e00, e01, e02 }
        };

        public static Matrix1x3<T> Zero()
        {
            return new Matrix1x3<T>(0, 0, 0);
        }
		
        public Matrix1x3(Scalar<T> e00, Scalar<T> e01, Scalar<T> e02)
        {
            this.e00 = e00;
            this.e01 = e01;
            this.e02 = e02;
        }

        public Matrix1x3(T e00, T e01, T e02)
        {
            this.e00 = new Scalar<T>(e00);
            this.e01 = new Scalar<T>(e01);
            this.e02 = new Scalar<T>(e02);
        }

        public Scalar<T> this[int i, int j] => Data[i, j];

        public Vector3<T>[] Rows
        {
            get
            {
                return new Vector3<T>[]
                {
                    new Vector3<T>(e00, e01, e02)
                };
            }
        }

        public Vector1<T>[] Columns
        {
            get
            {
                return new Vector1<T>[]
                {
                    new Vector1<T>(e00),
                    new Vector1<T>(e01),
                    new Vector1<T>(e02)
                };
            }
        }

        public Vector1<T> Transform(Vector3<T> vec)
        {
            return new Vector1<T>(
                e00 * vec.x + e01 * vec.y + e02 * vec.z
            );
        }

        public Matrix1x1<T> Transform(Matrix3x1<T> mat)
        {
            return new Matrix1x1<T>(
                e00 * mat.e00 + e01 * mat.e10 + e02 * mat.e20
            );
        }

        public override string ToString()
        {
            return $"Matrix1x3(" + Environment.NewLine +
                    $"\t({ e00 }, { e01 }, { e02 })" + Environment.NewLine +
                $")";
        }
		
        public override bool Equals(object obj)
        {
            if (obj is Matrix1x3<T> m)
                return Equals(m);

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new Matrix1x3<T>(e00, e01, e02);
        }

        public bool Equals(Matrix1x3<T> other)
        {
            return e00 == other.e00 && e01 == other.e01 && e02 == other.e02;
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<Scalar<T>> IEnumerable<Scalar<T>>.GetEnumerator()
        {
            yield return e00;
            yield return e01;
            yield return e02;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            yield return e00.Value;
            yield return e01.Value;
            yield return e02.Value;
        }
    }

    public struct Matrix3x1<T> : ICloneable, IEquatable<Matrix3x1<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>
        where T : struct, IComparable
    {
        public readonly Scalar<T> e00, e10, e20;

        public Vector2<int> Dimensions => new Vector2<int>(3, 1);

        public Scalar<T>[,] Data => new Scalar<T>[3, 1] {
            { e00 },
            { e10 },
            { e20 }
        };

        public static Matrix3x1<T> Zero()
        {
            return new Matrix3x1<T>(0, 0, 0);
        }
		
        public Matrix3x1(Scalar<T> e00, Scalar<T> e10, Scalar<T> e20)
        {
            this.e00 = e00;
            this.e10 = e10;
            this.e20 = e20;
        }

        public Matrix3x1(T e00, T e10, T e20)
        {
            this.e00 = new Scalar<T>(e00);
            this.e10 = new Scalar<T>(e10);
            this.e20 = new Scalar<T>(e20);
        }

        public Scalar<T> this[int i, int j] => Data[i, j];

        public Vector1<T>[] Rows
        {
            get
            {
                return new Vector1<T>[]
                {
                    new Vector1<T>(e00),
                    new Vector1<T>(e10),
                    new Vector1<T>(e20)
                };
            }
        }

        public Vector3<T>[] Columns
        {
            get
            {
                return new Vector3<T>[]
                {
                    new Vector3<T>(e00, e10, e20)
                };
            }
        }

        public Vector3<T> Transform(Vector1<T> vec)
        {
            return new Vector3<T>(
                e00 * vec.x,
                e10 * vec.x,
                e20 * vec.x
            );
        }

        public Matrix1x3<T> Transform(Matrix1x1<T> mat)
        {
            return new Matrix1x3<T>(
                e00 * mat.e00,
                e10 * mat.e00,
                e20 * mat.e00
            );
        }

        public override string ToString()
        {
            return $"Matrix3x1(" + Environment.NewLine +
                    $"\t({ e00 })," + Environment.NewLine +
                    $"\t({ e10 })," + Environment.NewLine +
                    $"\t({ e20 })" + Environment.NewLine +
                $")";
        }
		
        public override bool Equals(object obj)
        {
            if (obj is Matrix3x1<T> m)
                return Equals(m);

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new Matrix3x1<T>(e00, e10, e20);
        }

        public bool Equals(Matrix3x1<T> other)
        {
            return e00 == other.e00 && e10 == other.e10 && e20 == other.e20;
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<Scalar<T>> IEnumerable<Scalar<T>>.GetEnumerator()
        {
            yield return e00;
            yield return e10;
            yield return e20;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            yield return e00.Value;
            yield return e10.Value;
            yield return e20.Value;
        }
    }

    public struct Matrix1x4<T> : ICloneable, IEquatable<Matrix1x4<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>
        where T : struct, IComparable
    {
        public readonly Scalar<T> e00, e01, e02, e03;

        public Vector2<int> Dimensions => new Vector2<int>(1, 4);

        public Scalar<T>[,] Data => new Scalar<T>[1, 4] {
            { e00, e01, e02, e03 }
        };

        public static Matrix1x4<T> Zero()
        {
            return new Matrix1x4<T>(0, 0, 0, 0);
        }
		
        public Matrix1x4(Scalar<T> e00, Scalar<T> e01, Scalar<T> e02, Scalar<T> e03)
        {
            this.e00 = e00;
            this.e01 = e01;
            this.e02 = e02;
            this.e03 = e03;
        }

        public Matrix1x4(T e00, T e01, T e02, T e03)
        {
            this.e00 = new Scalar<T>(e00);
            this.e01 = new Scalar<T>(e01);
            this.e02 = new Scalar<T>(e02);
            this.e03 = new Scalar<T>(e03);
        }

        public Scalar<T> this[int i, int j] => Data[i, j];

        public Vector4<T>[] Rows
        {
            get
            {
                return new Vector4<T>[]
                {
                    new Vector4<T>(e00, e01, e02, e03)
                };
            }
        }

        public Vector1<T>[] Columns
        {
            get
            {
                return new Vector1<T>[]
                {
                    new Vector1<T>(e00),
                    new Vector1<T>(e01),
                    new Vector1<T>(e02),
                    new Vector1<T>(e03)
                };
            }
        }

        public Vector1<T> Transform(Vector4<T> vec)
        {
            return new Vector1<T>(
                e00 * vec.x + e01 * vec.y + e02 * vec.z + e03 * vec.w
            );
        }

        public Matrix1x1<T> Transform(Matrix4x1<T> mat)
        {
            return new Matrix1x1<T>(
                e00 * mat.e00 + e01 * mat.e10 + e02 * mat.e20 + e03 * mat.e30
            );
        }

        public override string ToString()
        {
            return $"Matrix1x4(" + Environment.NewLine +
                    $"\t({ e00 }, { e01 }, { e02 }, { e03 })" + Environment.NewLine +
                $")";
        }
		
        public override bool Equals(object obj)
        {
            if (obj is Matrix1x4<T> m)
                return Equals(m);

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new Matrix1x4<T>(e00, e01, e02, e03);
        }

        public bool Equals(Matrix1x4<T> other)
        {
            return e00 == other.e00 && e01 == other.e01 && e02 == other.e02 && e03 == other.e03;
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<Scalar<T>> IEnumerable<Scalar<T>>.GetEnumerator()
        {
            yield return e00;
            yield return e01;
            yield return e02;
            yield return e03;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            yield return e00.Value;
            yield return e01.Value;
            yield return e02.Value;
            yield return e03.Value;
        }
    }

    public struct Matrix4x1<T> : ICloneable, IEquatable<Matrix4x1<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>
        where T : struct, IComparable
    {
        public readonly Scalar<T> e00, e10, e20, e30;

        public Vector2<int> Dimensions => new Vector2<int>(4, 1);

        public Scalar<T>[,] Data => new Scalar<T>[4, 1] {
            { e00 },
            { e10 },
            { e20 },
            { e30 }
        };

        public static Matrix4x1<T> Zero()
        {
            return new Matrix4x1<T>(0, 0, 0, 0);
        }
		
        public Matrix4x1(Scalar<T> e00, Scalar<T> e10, Scalar<T> e20, Scalar<T> e30)
        {
            this.e00 = e00;
            this.e10 = e10;
            this.e20 = e20;
            this.e30 = e30;
        }

        public Matrix4x1(T e00, T e10, T e20, T e30)
        {
            this.e00 = new Scalar<T>(e00);
            this.e10 = new Scalar<T>(e10);
            this.e20 = new Scalar<T>(e20);
            this.e30 = new Scalar<T>(e30);
        }

        public Scalar<T> this[int i, int j] => Data[i, j];

        public Vector1<T>[] Rows
        {
            get
            {
                return new Vector1<T>[]
                {
                    new Vector1<T>(e00),
                    new Vector1<T>(e10),
                    new Vector1<T>(e20),
                    new Vector1<T>(e30)
                };
            }
        }

        public Vector4<T>[] Columns
        {
            get
            {
                return new Vector4<T>[]
                {
                    new Vector4<T>(e00, e10, e20, e30)
                };
            }
        }

        public Vector4<T> Transform(Vector1<T> vec)
        {
            return new Vector4<T>(
                e00 * vec.x,
                e10 * vec.x,
                e20 * vec.x,
                e30 * vec.x
            );
        }

        public Matrix1x4<T> Transform(Matrix1x1<T> mat)
        {
            return new Matrix1x4<T>(
                e00 * mat.e00,
                e10 * mat.e00,
                e20 * mat.e00,
                e30 * mat.e00
            );
        }

        public override string ToString()
        {
            return $"Matrix4x1(" + Environment.NewLine +
                    $"\t({ e00 })," + Environment.NewLine +
                    $"\t({ e10 })," + Environment.NewLine +
                    $"\t({ e20 })," + Environment.NewLine +
                    $"\t({ e30 })" + Environment.NewLine +
                $")";
        }
		
        public override bool Equals(object obj)
        {
            if (obj is Matrix4x1<T> m)
                return Equals(m);

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new Matrix4x1<T>(e00, e10, e20, e30);
        }

        public bool Equals(Matrix4x1<T> other)
        {
            return e00 == other.e00 && e10 == other.e10 && e20 == other.e20 && e30 == other.e30;
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<Scalar<T>> IEnumerable<Scalar<T>>.GetEnumerator()
        {
            yield return e00;
            yield return e10;
            yield return e20;
            yield return e30;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            yield return e00.Value;
            yield return e10.Value;
            yield return e20.Value;
            yield return e30.Value;
        }
    }

    public struct Matrix2x2<T> : ICloneable, IEquatable<Matrix2x2<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>
        where T : struct, IComparable
    {
        public readonly Scalar<T> e00, e01, e10, e11;

        public Vector2<int> Dimensions => new Vector2<int>(2, 2);

        public Scalar<T>[,] Data => new Scalar<T>[2, 2] {
            { e00, e01 },
            { e10, e11 }
        };

        public static Matrix2x2<T> Zero()
        {
            return new Matrix2x2<T>(0, 0, 0, 0);
        }
		
        public static Matrix2x2<T> One()
        {
            return new Matrix2x2<T>(1, 0, 0, 1);
        }
		
        public Matrix2x2(Scalar<T> e00, Scalar<T> e01, Scalar<T> e10, Scalar<T> e11)
        {
            this.e00 = e00;
            this.e01 = e01;
            this.e10 = e10;
            this.e11 = e11;
        }

        public Matrix2x2(T e00, T e01, T e10, T e11)
        {
            this.e00 = new Scalar<T>(e00);
            this.e01 = new Scalar<T>(e01);
            this.e10 = new Scalar<T>(e10);
            this.e11 = new Scalar<T>(e11);
        }

        public Scalar<T> this[int i, int j] => Data[i, j];

        public Vector2<T>[] Rows
        {
            get
            {
                return new Vector2<T>[]
                {
                    new Vector2<T>(e00, e01),
                    new Vector2<T>(e10, e11)
                };
            }
        }

        public Vector2<T>[] Columns
        {
            get
            {
                return new Vector2<T>[]
                {
                    new Vector2<T>(e00, e10),
                    new Vector2<T>(e01, e11)
                };
            }
        }

        public Vector2<T> Transform(Vector2<T> vec)
        {
            return new Vector2<T>(
                e00 * vec.x + e01 * vec.y,
                e10 * vec.x + e11 * vec.y
            );
        }

        public Matrix1x2<T> Transform(Matrix2x1<T> mat)
        {
            return new Matrix1x2<T>(
                e00 * mat.e00 + e01 * mat.e10,
                e10 * mat.e00 + e11 * mat.e10
            );
        }

        public static implicit operator Matrix2x2<T>(((T, T), (T, T)) t)
        {
            return new Matrix2x2<T>(
                t.Item1.Item1, t.Item1.Item2,
                t.Item2.Item1, t.Item2.Item2
            );
        }

        public override string ToString()
        {
            return $"Matrix2x2(" + Environment.NewLine +
                    $"\t({ e00 }, { e01 })," + Environment.NewLine +
                    $"\t({ e10 }, { e11 })" + Environment.NewLine +
                $")";
        }
		
        public override bool Equals(object obj)
        {
            if (obj is Matrix2x2<T> m)
                return Equals(m);

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new Matrix2x2<T>(e00, e01, e10, e11);
        }

        public bool Equals(Matrix2x2<T> other)
        {
            return e00 == other.e00 && e01 == other.e01 && e10 == other.e10 && e11 == other.e11;
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<Scalar<T>> IEnumerable<Scalar<T>>.GetEnumerator()
        {
            yield return e00;
            yield return e01;
            yield return e10;
            yield return e11;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            yield return e00.Value;
            yield return e01.Value;
            yield return e10.Value;
            yield return e11.Value;
        }
    }

    public struct Matrix3x3<T> : ICloneable, IEquatable<Matrix3x3<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>
        where T : struct, IComparable
    {
        public readonly Scalar<T> e00, e01, e02, e10, e11, e12, e20, e21, e22;

        public Vector2<int> Dimensions => new Vector2<int>(3, 3);

        public Scalar<T>[,] Data => new Scalar<T>[3, 3] {
            { e00, e01, e02 },
            { e10, e11, e12 },
            { e20, e21, e22 }
        };

        public static Matrix3x3<T> Zero()
        {
            return new Matrix3x3<T>(0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
		
        public static Matrix3x3<T> One()
        {
            return new Matrix3x3<T>(1, 0, 0, 0, 1, 0, 0, 0, 1);
        }
		
        public Matrix3x3(Scalar<T> e00, Scalar<T> e01, Scalar<T> e02, Scalar<T> e10, Scalar<T> e11, Scalar<T> e12, Scalar<T> e20, Scalar<T> e21, Scalar<T> e22)
        {
            this.e00 = e00;
            this.e01 = e01;
            this.e02 = e02;
            this.e10 = e10;
            this.e11 = e11;
            this.e12 = e12;
            this.e20 = e20;
            this.e21 = e21;
            this.e22 = e22;
        }

        public Matrix3x3(T e00, T e01, T e02, T e10, T e11, T e12, T e20, T e21, T e22)
        {
            this.e00 = new Scalar<T>(e00);
            this.e01 = new Scalar<T>(e01);
            this.e02 = new Scalar<T>(e02);
            this.e10 = new Scalar<T>(e10);
            this.e11 = new Scalar<T>(e11);
            this.e12 = new Scalar<T>(e12);
            this.e20 = new Scalar<T>(e20);
            this.e21 = new Scalar<T>(e21);
            this.e22 = new Scalar<T>(e22);
        }

        public Scalar<T> this[int i, int j] => Data[i, j];

        public Vector3<T>[] Rows
        {
            get
            {
                return new Vector3<T>[]
                {
                    new Vector3<T>(e00, e01, e02),
                    new Vector3<T>(e10, e11, e12),
                    new Vector3<T>(e20, e21, e22)
                };
            }
        }

        public Vector3<T>[] Columns
        {
            get
            {
                return new Vector3<T>[]
                {
                    new Vector3<T>(e00, e10, e20),
                    new Vector3<T>(e01, e11, e21),
                    new Vector3<T>(e02, e12, e22)
                };
            }
        }

        public Vector3<T> Transform(Vector3<T> vec)
        {
            return new Vector3<T>(
                e00 * vec.x + e01 * vec.y + e02 * vec.z,
                e10 * vec.x + e11 * vec.y + e12 * vec.z,
                e20 * vec.x + e21 * vec.y + e22 * vec.z
            );
        }

        public Matrix1x3<T> Transform(Matrix3x1<T> mat)
        {
            return new Matrix1x3<T>(
                e00 * mat.e00 + e01 * mat.e10 + e02 * mat.e20,
                e10 * mat.e00 + e11 * mat.e10 + e12 * mat.e20,
                e20 * mat.e00 + e21 * mat.e10 + e22 * mat.e20
            );
        }

        public static implicit operator Matrix3x3<T>(((T, T, T), (T, T, T), (T, T, T)) t)
        {
            return new Matrix3x3<T>(
                t.Item1.Item1, t.Item1.Item2, t.Item1.Item3,
                t.Item2.Item1, t.Item2.Item2, t.Item2.Item3,
                t.Item3.Item1, t.Item3.Item2, t.Item3.Item3
            );
        }

        public override string ToString()
        {
            return $"Matrix3x3(" + Environment.NewLine +
                    $"\t({ e00 }, { e01 }, { e02 })," + Environment.NewLine +
                    $"\t({ e10 }, { e11 }, { e12 })," + Environment.NewLine +
                    $"\t({ e20 }, { e21 }, { e22 })" + Environment.NewLine +
                $")";
        }
		
        public override bool Equals(object obj)
        {
            if (obj is Matrix3x3<T> m)
                return Equals(m);

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new Matrix3x3<T>(e00, e01, e02, e10, e11, e12, e20, e21, e22);
        }

        public bool Equals(Matrix3x3<T> other)
        {
            return e00 == other.e00 && e01 == other.e01 && e02 == other.e02 && e10 == other.e10 && e11 == other.e11 && e12 == other.e12 && e20 == other.e20 && e21 == other.e21 && e22 == other.e22;
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<Scalar<T>> IEnumerable<Scalar<T>>.GetEnumerator()
        {
            yield return e00;
            yield return e01;
            yield return e02;
            yield return e10;
            yield return e11;
            yield return e12;
            yield return e20;
            yield return e21;
            yield return e22;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            yield return e00.Value;
            yield return e01.Value;
            yield return e02.Value;
            yield return e10.Value;
            yield return e11.Value;
            yield return e12.Value;
            yield return e20.Value;
            yield return e21.Value;
            yield return e22.Value;
        }
    }

    public struct Matrix4x4<T> : ICloneable, IEquatable<Matrix4x4<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>
        where T : struct, IComparable
    {
        public readonly Scalar<T> e00, e01, e02, e03, e10, e11, e12, e13, e20, e21, e22, e23, e30, e31, e32, e33;

        public Vector2<int> Dimensions => new Vector2<int>(4, 4);

        public Scalar<T>[,] Data => new Scalar<T>[4, 4] {
            { e00, e01, e02, e03 },
            { e10, e11, e12, e13 },
            { e20, e21, e22, e23 },
            { e30, e31, e32, e33 }
        };

        public static Matrix4x4<T> Zero()
        {
            return new Matrix4x4<T>(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
		
        public static Matrix4x4<T> One()
        {
            return new Matrix4x4<T>(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
        }
		
        public Matrix4x4(Scalar<T> e00, Scalar<T> e01, Scalar<T> e02, Scalar<T> e03, Scalar<T> e10, Scalar<T> e11, Scalar<T> e12, Scalar<T> e13, Scalar<T> e20, Scalar<T> e21, Scalar<T> e22, Scalar<T> e23, Scalar<T> e30, Scalar<T> e31, Scalar<T> e32, Scalar<T> e33)
        {
            this.e00 = e00;
            this.e01 = e01;
            this.e02 = e02;
            this.e03 = e03;
            this.e10 = e10;
            this.e11 = e11;
            this.e12 = e12;
            this.e13 = e13;
            this.e20 = e20;
            this.e21 = e21;
            this.e22 = e22;
            this.e23 = e23;
            this.e30 = e30;
            this.e31 = e31;
            this.e32 = e32;
            this.e33 = e33;
        }

        public Matrix4x4(T e00, T e01, T e02, T e03, T e10, T e11, T e12, T e13, T e20, T e21, T e22, T e23, T e30, T e31, T e32, T e33)
        {
            this.e00 = new Scalar<T>(e00);
            this.e01 = new Scalar<T>(e01);
            this.e02 = new Scalar<T>(e02);
            this.e03 = new Scalar<T>(e03);
            this.e10 = new Scalar<T>(e10);
            this.e11 = new Scalar<T>(e11);
            this.e12 = new Scalar<T>(e12);
            this.e13 = new Scalar<T>(e13);
            this.e20 = new Scalar<T>(e20);
            this.e21 = new Scalar<T>(e21);
            this.e22 = new Scalar<T>(e22);
            this.e23 = new Scalar<T>(e23);
            this.e30 = new Scalar<T>(e30);
            this.e31 = new Scalar<T>(e31);
            this.e32 = new Scalar<T>(e32);
            this.e33 = new Scalar<T>(e33);
        }

        public Scalar<T> this[int i, int j] => Data[i, j];

        public Vector4<T>[] Rows
        {
            get
            {
                return new Vector4<T>[]
                {
                    new Vector4<T>(e00, e01, e02, e03),
                    new Vector4<T>(e10, e11, e12, e13),
                    new Vector4<T>(e20, e21, e22, e23),
                    new Vector4<T>(e30, e31, e32, e33)
                };
            }
        }

        public Vector4<T>[] Columns
        {
            get
            {
                return new Vector4<T>[]
                {
                    new Vector4<T>(e00, e10, e20, e30),
                    new Vector4<T>(e01, e11, e21, e31),
                    new Vector4<T>(e02, e12, e22, e32),
                    new Vector4<T>(e03, e13, e23, e33)
                };
            }
        }

        public Vector4<T> Transform(Vector4<T> vec)
        {
            return new Vector4<T>(
                e00 * vec.x + e01 * vec.y + e02 * vec.z + e03 * vec.w,
                e10 * vec.x + e11 * vec.y + e12 * vec.z + e13 * vec.w,
                e20 * vec.x + e21 * vec.y + e22 * vec.z + e23 * vec.w,
                e30 * vec.x + e31 * vec.y + e32 * vec.z + e33 * vec.w
            );
        }

        public Matrix1x4<T> Transform(Matrix4x1<T> mat)
        {
            return new Matrix1x4<T>(
                e00 * mat.e00 + e01 * mat.e10 + e02 * mat.e20 + e03 * mat.e30,
                e10 * mat.e00 + e11 * mat.e10 + e12 * mat.e20 + e13 * mat.e30,
                e20 * mat.e00 + e21 * mat.e10 + e22 * mat.e20 + e23 * mat.e30,
                e30 * mat.e00 + e31 * mat.e10 + e32 * mat.e20 + e33 * mat.e30
            );
        }

        public static implicit operator Matrix4x4<T>(((T, T, T, T), (T, T, T, T), (T, T, T, T), (T, T, T, T)) t)
        {
            return new Matrix4x4<T>(
                t.Item1.Item1, t.Item1.Item2, t.Item1.Item3, t.Item1.Item4,
                t.Item2.Item1, t.Item2.Item2, t.Item2.Item3, t.Item2.Item4,
                t.Item3.Item1, t.Item3.Item2, t.Item3.Item3, t.Item3.Item4,
                t.Item4.Item1, t.Item4.Item2, t.Item4.Item3, t.Item4.Item4
            );
        }

        public override string ToString()
        {
            return $"Matrix4x4(" + Environment.NewLine +
                    $"\t({ e00 }, { e01 }, { e02 }, { e03 })," + Environment.NewLine +
                    $"\t({ e10 }, { e11 }, { e12 }, { e13 })," + Environment.NewLine +
                    $"\t({ e20 }, { e21 }, { e22 }, { e23 })," + Environment.NewLine +
                    $"\t({ e30 }, { e31 }, { e32 }, { e33 })" + Environment.NewLine +
                $")";
        }
		
        public override bool Equals(object obj)
        {
            if (obj is Matrix4x4<T> m)
                return Equals(m);

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new Matrix4x4<T>(e00, e01, e02, e03, e10, e11, e12, e13, e20, e21, e22, e23, e30, e31, e32, e33);
        }

        public bool Equals(Matrix4x4<T> other)
        {
            return e00 == other.e00 && e01 == other.e01 && e02 == other.e02 && e03 == other.e03 && e10 == other.e10 && e11 == other.e11 && e12 == other.e12 && e13 == other.e13 && e20 == other.e20 && e21 == other.e21 && e22 == other.e22 && e23 == other.e23 && e30 == other.e30 && e31 == other.e31 && e32 == other.e32 && e33 == other.e33;
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<Scalar<T>> IEnumerable<Scalar<T>>.GetEnumerator()
        {
            yield return e00;
            yield return e01;
            yield return e02;
            yield return e03;
            yield return e10;
            yield return e11;
            yield return e12;
            yield return e13;
            yield return e20;
            yield return e21;
            yield return e22;
            yield return e23;
            yield return e30;
            yield return e31;
            yield return e32;
            yield return e33;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            yield return e00.Value;
            yield return e01.Value;
            yield return e02.Value;
            yield return e03.Value;
            yield return e10.Value;
            yield return e11.Value;
            yield return e12.Value;
            yield return e13.Value;
            yield return e20.Value;
            yield return e21.Value;
            yield return e22.Value;
            yield return e23.Value;
            yield return e30.Value;
            yield return e31.Value;
            yield return e32.Value;
            yield return e33.Value;
        }
    }

    public struct Matrix2x3<T> : ICloneable, IEquatable<Matrix2x3<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>
        where T : struct, IComparable
    {
        public readonly Scalar<T> e00, e01, e02, e10, e11, e12;

        public Vector2<int> Dimensions => new Vector2<int>(2, 3);

        public Scalar<T>[,] Data => new Scalar<T>[2, 3] {
            { e00, e01, e02 },
            { e10, e11, e12 }
        };

        public static Matrix2x3<T> Zero()
        {
            return new Matrix2x3<T>(0, 0, 0, 0, 0, 0);
        }
		
        public Matrix2x3(Scalar<T> e00, Scalar<T> e01, Scalar<T> e02, Scalar<T> e10, Scalar<T> e11, Scalar<T> e12)
        {
            this.e00 = e00;
            this.e01 = e01;
            this.e02 = e02;
            this.e10 = e10;
            this.e11 = e11;
            this.e12 = e12;
        }

        public Matrix2x3(T e00, T e01, T e02, T e10, T e11, T e12)
        {
            this.e00 = new Scalar<T>(e00);
            this.e01 = new Scalar<T>(e01);
            this.e02 = new Scalar<T>(e02);
            this.e10 = new Scalar<T>(e10);
            this.e11 = new Scalar<T>(e11);
            this.e12 = new Scalar<T>(e12);
        }

        public Scalar<T> this[int i, int j] => Data[i, j];

        public Vector3<T>[] Rows
        {
            get
            {
                return new Vector3<T>[]
                {
                    new Vector3<T>(e00, e01, e02),
                    new Vector3<T>(e10, e11, e12)
                };
            }
        }

        public Vector2<T>[] Columns
        {
            get
            {
                return new Vector2<T>[]
                {
                    new Vector2<T>(e00, e10),
                    new Vector2<T>(e01, e11),
                    new Vector2<T>(e02, e12)
                };
            }
        }

        public Vector2<T> Transform(Vector3<T> vec)
        {
            return new Vector2<T>(
                e00 * vec.x + e01 * vec.y + e02 * vec.z,
                e10 * vec.x + e11 * vec.y + e12 * vec.z
            );
        }

        public Matrix1x2<T> Transform(Matrix3x1<T> mat)
        {
            return new Matrix1x2<T>(
                e00 * mat.e00 + e01 * mat.e10 + e02 * mat.e20,
                e10 * mat.e00 + e11 * mat.e10 + e12 * mat.e20
            );
        }

        public static implicit operator Matrix2x3<T>(((T, T, T), (T, T, T)) t)
        {
            return new Matrix2x3<T>(
                t.Item1.Item1, t.Item1.Item2, t.Item1.Item3,
                t.Item2.Item1, t.Item2.Item2, t.Item2.Item3
            );
        }

        public override string ToString()
        {
            return $"Matrix2x3(" + Environment.NewLine +
                    $"\t({ e00 }, { e01 }, { e02 })," + Environment.NewLine +
                    $"\t({ e10 }, { e11 }, { e12 })" + Environment.NewLine +
                $")";
        }
		
        public override bool Equals(object obj)
        {
            if (obj is Matrix2x3<T> m)
                return Equals(m);

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new Matrix2x3<T>(e00, e01, e02, e10, e11, e12);
        }

        public bool Equals(Matrix2x3<T> other)
        {
            return e00 == other.e00 && e01 == other.e01 && e02 == other.e02 && e10 == other.e10 && e11 == other.e11 && e12 == other.e12;
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<Scalar<T>> IEnumerable<Scalar<T>>.GetEnumerator()
        {
            yield return e00;
            yield return e01;
            yield return e02;
            yield return e10;
            yield return e11;
            yield return e12;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            yield return e00.Value;
            yield return e01.Value;
            yield return e02.Value;
            yield return e10.Value;
            yield return e11.Value;
            yield return e12.Value;
        }
    }

    public struct Matrix3x4<T> : ICloneable, IEquatable<Matrix3x4<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>
        where T : struct, IComparable
    {
        public readonly Scalar<T> e00, e01, e02, e03, e10, e11, e12, e13, e20, e21, e22, e23;

        public Vector2<int> Dimensions => new Vector2<int>(3, 4);

        public Scalar<T>[,] Data => new Scalar<T>[3, 4] {
            { e00, e01, e02, e03 },
            { e10, e11, e12, e13 },
            { e20, e21, e22, e23 }
        };

        public static Matrix3x4<T> Zero()
        {
            return new Matrix3x4<T>(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
		
        public Matrix3x4(Scalar<T> e00, Scalar<T> e01, Scalar<T> e02, Scalar<T> e03, Scalar<T> e10, Scalar<T> e11, Scalar<T> e12, Scalar<T> e13, Scalar<T> e20, Scalar<T> e21, Scalar<T> e22, Scalar<T> e23)
        {
            this.e00 = e00;
            this.e01 = e01;
            this.e02 = e02;
            this.e03 = e03;
            this.e10 = e10;
            this.e11 = e11;
            this.e12 = e12;
            this.e13 = e13;
            this.e20 = e20;
            this.e21 = e21;
            this.e22 = e22;
            this.e23 = e23;
        }

        public Matrix3x4(T e00, T e01, T e02, T e03, T e10, T e11, T e12, T e13, T e20, T e21, T e22, T e23)
        {
            this.e00 = new Scalar<T>(e00);
            this.e01 = new Scalar<T>(e01);
            this.e02 = new Scalar<T>(e02);
            this.e03 = new Scalar<T>(e03);
            this.e10 = new Scalar<T>(e10);
            this.e11 = new Scalar<T>(e11);
            this.e12 = new Scalar<T>(e12);
            this.e13 = new Scalar<T>(e13);
            this.e20 = new Scalar<T>(e20);
            this.e21 = new Scalar<T>(e21);
            this.e22 = new Scalar<T>(e22);
            this.e23 = new Scalar<T>(e23);
        }

        public Scalar<T> this[int i, int j] => Data[i, j];

        public Vector4<T>[] Rows
        {
            get
            {
                return new Vector4<T>[]
                {
                    new Vector4<T>(e00, e01, e02, e03),
                    new Vector4<T>(e10, e11, e12, e13),
                    new Vector4<T>(e20, e21, e22, e23)
                };
            }
        }

        public Vector3<T>[] Columns
        {
            get
            {
                return new Vector3<T>[]
                {
                    new Vector3<T>(e00, e10, e20),
                    new Vector3<T>(e01, e11, e21),
                    new Vector3<T>(e02, e12, e22),
                    new Vector3<T>(e03, e13, e23)
                };
            }
        }

        public Vector3<T> Transform(Vector4<T> vec)
        {
            return new Vector3<T>(
                e00 * vec.x + e01 * vec.y + e02 * vec.z + e03 * vec.w,
                e10 * vec.x + e11 * vec.y + e12 * vec.z + e13 * vec.w,
                e20 * vec.x + e21 * vec.y + e22 * vec.z + e23 * vec.w
            );
        }

        public Matrix1x3<T> Transform(Matrix4x1<T> mat)
        {
            return new Matrix1x3<T>(
                e00 * mat.e00 + e01 * mat.e10 + e02 * mat.e20 + e03 * mat.e30,
                e10 * mat.e00 + e11 * mat.e10 + e12 * mat.e20 + e13 * mat.e30,
                e20 * mat.e00 + e21 * mat.e10 + e22 * mat.e20 + e23 * mat.e30
            );
        }

        public static implicit operator Matrix3x4<T>(((T, T, T, T), (T, T, T, T), (T, T, T, T)) t)
        {
            return new Matrix3x4<T>(
                t.Item1.Item1, t.Item1.Item2, t.Item1.Item3, t.Item1.Item4,
                t.Item2.Item1, t.Item2.Item2, t.Item2.Item3, t.Item2.Item4,
                t.Item3.Item1, t.Item3.Item2, t.Item3.Item3, t.Item3.Item4
            );
        }

        public override string ToString()
        {
            return $"Matrix3x4(" + Environment.NewLine +
                    $"\t({ e00 }, { e01 }, { e02 }, { e03 })," + Environment.NewLine +
                    $"\t({ e10 }, { e11 }, { e12 }, { e13 })," + Environment.NewLine +
                    $"\t({ e20 }, { e21 }, { e22 }, { e23 })" + Environment.NewLine +
                $")";
        }
		
        public override bool Equals(object obj)
        {
            if (obj is Matrix3x4<T> m)
                return Equals(m);

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new Matrix3x4<T>(e00, e01, e02, e03, e10, e11, e12, e13, e20, e21, e22, e23);
        }

        public bool Equals(Matrix3x4<T> other)
        {
            return e00 == other.e00 && e01 == other.e01 && e02 == other.e02 && e03 == other.e03 && e10 == other.e10 && e11 == other.e11 && e12 == other.e12 && e13 == other.e13 && e20 == other.e20 && e21 == other.e21 && e22 == other.e22 && e23 == other.e23;
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<Scalar<T>> IEnumerable<Scalar<T>>.GetEnumerator()
        {
            yield return e00;
            yield return e01;
            yield return e02;
            yield return e03;
            yield return e10;
            yield return e11;
            yield return e12;
            yield return e13;
            yield return e20;
            yield return e21;
            yield return e22;
            yield return e23;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            yield return e00.Value;
            yield return e01.Value;
            yield return e02.Value;
            yield return e03.Value;
            yield return e10.Value;
            yield return e11.Value;
            yield return e12.Value;
            yield return e13.Value;
            yield return e20.Value;
            yield return e21.Value;
            yield return e22.Value;
            yield return e23.Value;
        }
    }
}