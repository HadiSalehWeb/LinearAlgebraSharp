using LinearAlgebra.Vectors;
using LinearAlgebra.Scalars;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LinearAlgebra.Matrices
{
    public struct Matrix1x1<T> : ICloneable, IEquatable<Matrix1x1<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>, IMatrix<T>
        where T : struct
    {
        public readonly Scalar<T> e00;

        public Vector2<int> Dimension => new Vector2<int>(1, 1);

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

        public Matrix1x1<T> Transpose()
        {
            return new Matrix1x1<T>(
                e00
            );
        }

        public static Vector1<T> operator *(Matrix1x1<T> left, Vector1<T> right)
        {
            return new Vector1<T>(
                left.e00 * right.x
            );
        }

        public static Matrix1x1<T> operator +(Matrix1x1<T> left, Matrix1x1<T> right)
        {
            return new Matrix1x1<T>(
                left.e00 + right.e00
            );
        }

        public static Matrix1x1<T> operator -(Matrix1x1<T> left, Matrix1x1<T> right)
        {
            return new Matrix1x1<T>(
                left.e00 - right.e00
            );
        }

        public static Matrix1x1<T> operator *(Scalar<T> left, Matrix1x1<T> right)
        {
            return new Matrix1x1<T>(
                left * right.e00
            );
        }

        public static Matrix1x1<T> operator *(Matrix1x1<T> left, Scalar<T> right)
        {
            return right * left;
        }

        public static Matrix1x1<T> operator /(Scalar<T> left, Matrix1x1<T> right)
        {
            return new Matrix1x1<T>(
                left / right.e00
            );
        }

        public static Matrix1x1<T> operator /(Matrix1x1<T> left, Scalar<T> right)
        {
            return new Matrix1x1<T>(
                left.e00 / right
            );
        }

        public static Matrix1x1<T> operator -(Matrix1x1<T> m)
        {
            return new Matrix1x1<T>(
                -m.e00
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

    public struct Matrix2x2<T> : ICloneable, IEquatable<Matrix2x2<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>, IMatrix<T>
        where T : struct
    {
        public readonly Scalar<T> e00, e01, e10, e11;

        public Vector2<int> Dimension => new Vector2<int>(2, 2);

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

        public Matrix2x2<T> Transpose()
        {
            return new Matrix2x2<T>(
                e00, e10,
                e01, e11
            );
        }

        public static Vector2<T> operator *(Matrix2x2<T> left, Vector2<T> right)
        {
            return new Vector2<T>(
                left.e00 * right.x + left.e01 * right.y,
                left.e10 * right.x + left.e11 * right.y
            );
        }

        public static Matrix2x2<T> operator +(Matrix2x2<T> left, Matrix2x2<T> right)
        {
            return new Matrix2x2<T>(
                left.e00 + right.e00, left.e01 + right.e01,
                left.e10 + right.e10, left.e11 + right.e11
            );
        }

        public static Matrix2x2<T> operator -(Matrix2x2<T> left, Matrix2x2<T> right)
        {
            return new Matrix2x2<T>(
                left.e00 - right.e00, left.e01 - right.e01,
                left.e10 - right.e10, left.e11 - right.e11
            );
        }

        public static Matrix2x2<T> operator *(Scalar<T> left, Matrix2x2<T> right)
        {
            return new Matrix2x2<T>(
                left * right.e00, left * right.e01,
                left * right.e10, left * right.e11
            );
        }

        public static Matrix2x2<T> operator *(Matrix2x2<T> left, Scalar<T> right)
        {
            return right * left;
        }

        public static Matrix2x2<T> operator /(Scalar<T> left, Matrix2x2<T> right)
        {
            return new Matrix2x2<T>(
                left / right.e00, left / right.e01,
                left / right.e10, left / right.e11
            );
        }

        public static Matrix2x2<T> operator /(Matrix2x2<T> left, Scalar<T> right)
        {
            return new Matrix2x2<T>(
                left.e00 / right, left.e01 / right,
                left.e10 / right, left.e11 / right
            );
        }

        public static Matrix2x2<T> operator -(Matrix2x2<T> m)
        {
            return new Matrix2x2<T>(
                -m.e00, -m.e01,
                -m.e10, -m.e11
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

    public struct Matrix3x3<T> : ICloneable, IEquatable<Matrix3x3<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>, IMatrix<T>
        where T : struct
    {
        public readonly Scalar<T> e00, e01, e02, e10, e11, e12, e20, e21, e22;

        public Vector2<int> Dimension => new Vector2<int>(3, 3);

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

        public Matrix3x3<T> Transpose()
        {
            return new Matrix3x3<T>(
                e00, e10, e20,
                e01, e11, e21,
                e02, e12, e22
            );
        }

        public static Vector3<T> operator *(Matrix3x3<T> left, Vector3<T> right)
        {
            return new Vector3<T>(
                left.e00 * right.x + left.e01 * right.y + left.e02 * right.z,
                left.e10 * right.x + left.e11 * right.y + left.e12 * right.z,
                left.e20 * right.x + left.e21 * right.y + left.e22 * right.z
            );
        }

        public static Matrix3x3<T> operator +(Matrix3x3<T> left, Matrix3x3<T> right)
        {
            return new Matrix3x3<T>(
                left.e00 + right.e00, left.e01 + right.e01, left.e02 + right.e02,
                left.e10 + right.e10, left.e11 + right.e11, left.e12 + right.e12,
                left.e20 + right.e20, left.e21 + right.e21, left.e22 + right.e22
            );
        }

        public static Matrix3x3<T> operator -(Matrix3x3<T> left, Matrix3x3<T> right)
        {
            return new Matrix3x3<T>(
                left.e00 - right.e00, left.e01 - right.e01, left.e02 - right.e02,
                left.e10 - right.e10, left.e11 - right.e11, left.e12 - right.e12,
                left.e20 - right.e20, left.e21 - right.e21, left.e22 - right.e22
            );
        }

        public static Matrix3x3<T> operator *(Scalar<T> left, Matrix3x3<T> right)
        {
            return new Matrix3x3<T>(
                left * right.e00, left * right.e01, left * right.e02,
                left * right.e10, left * right.e11, left * right.e12,
                left * right.e20, left * right.e21, left * right.e22
            );
        }

        public static Matrix3x3<T> operator *(Matrix3x3<T> left, Scalar<T> right)
        {
            return right * left;
        }

        public static Matrix3x3<T> operator /(Scalar<T> left, Matrix3x3<T> right)
        {
            return new Matrix3x3<T>(
                left / right.e00, left / right.e01, left / right.e02,
                left / right.e10, left / right.e11, left / right.e12,
                left / right.e20, left / right.e21, left / right.e22
            );
        }

        public static Matrix3x3<T> operator /(Matrix3x3<T> left, Scalar<T> right)
        {
            return new Matrix3x3<T>(
                left.e00 / right, left.e01 / right, left.e02 / right,
                left.e10 / right, left.e11 / right, left.e12 / right,
                left.e20 / right, left.e21 / right, left.e22 / right
            );
        }

        public static Matrix3x3<T> operator -(Matrix3x3<T> m)
        {
            return new Matrix3x3<T>(
                -m.e00, -m.e01, -m.e02,
                -m.e10, -m.e11, -m.e12,
                -m.e20, -m.e21, -m.e22
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

    public struct Matrix4x4<T> : ICloneable, IEquatable<Matrix4x4<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>, IMatrix<T>
        where T : struct
    {
        public readonly Scalar<T> e00, e01, e02, e03, e10, e11, e12, e13, e20, e21, e22, e23, e30, e31, e32, e33;

        public Vector2<int> Dimension => new Vector2<int>(4, 4);

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

        public Matrix4x4<T> Transpose()
        {
            return new Matrix4x4<T>(
                e00, e10, e20, e30,
                e01, e11, e21, e31,
                e02, e12, e22, e32,
                e03, e13, e23, e33
            );
        }

        public static Vector4<T> operator *(Matrix4x4<T> left, Vector4<T> right)
        {
            return new Vector4<T>(
                left.e00 * right.x + left.e01 * right.y + left.e02 * right.z + left.e03 * right.w,
                left.e10 * right.x + left.e11 * right.y + left.e12 * right.z + left.e13 * right.w,
                left.e20 * right.x + left.e21 * right.y + left.e22 * right.z + left.e23 * right.w,
                left.e30 * right.x + left.e31 * right.y + left.e32 * right.z + left.e33 * right.w
            );
        }

        public static Matrix4x4<T> operator +(Matrix4x4<T> left, Matrix4x4<T> right)
        {
            return new Matrix4x4<T>(
                left.e00 + right.e00, left.e01 + right.e01, left.e02 + right.e02, left.e03 + right.e03,
                left.e10 + right.e10, left.e11 + right.e11, left.e12 + right.e12, left.e13 + right.e13,
                left.e20 + right.e20, left.e21 + right.e21, left.e22 + right.e22, left.e23 + right.e23,
                left.e30 + right.e30, left.e31 + right.e31, left.e32 + right.e32, left.e33 + right.e33
            );
        }

        public static Matrix4x4<T> operator -(Matrix4x4<T> left, Matrix4x4<T> right)
        {
            return new Matrix4x4<T>(
                left.e00 - right.e00, left.e01 - right.e01, left.e02 - right.e02, left.e03 - right.e03,
                left.e10 - right.e10, left.e11 - right.e11, left.e12 - right.e12, left.e13 - right.e13,
                left.e20 - right.e20, left.e21 - right.e21, left.e22 - right.e22, left.e23 - right.e23,
                left.e30 - right.e30, left.e31 - right.e31, left.e32 - right.e32, left.e33 - right.e33
            );
        }

        public static Matrix4x4<T> operator *(Scalar<T> left, Matrix4x4<T> right)
        {
            return new Matrix4x4<T>(
                left * right.e00, left * right.e01, left * right.e02, left * right.e03,
                left * right.e10, left * right.e11, left * right.e12, left * right.e13,
                left * right.e20, left * right.e21, left * right.e22, left * right.e23,
                left * right.e30, left * right.e31, left * right.e32, left * right.e33
            );
        }

        public static Matrix4x4<T> operator *(Matrix4x4<T> left, Scalar<T> right)
        {
            return right * left;
        }

        public static Matrix4x4<T> operator /(Scalar<T> left, Matrix4x4<T> right)
        {
            return new Matrix4x4<T>(
                left / right.e00, left / right.e01, left / right.e02, left / right.e03,
                left / right.e10, left / right.e11, left / right.e12, left / right.e13,
                left / right.e20, left / right.e21, left / right.e22, left / right.e23,
                left / right.e30, left / right.e31, left / right.e32, left / right.e33
            );
        }

        public static Matrix4x4<T> operator /(Matrix4x4<T> left, Scalar<T> right)
        {
            return new Matrix4x4<T>(
                left.e00 / right, left.e01 / right, left.e02 / right, left.e03 / right,
                left.e10 / right, left.e11 / right, left.e12 / right, left.e13 / right,
                left.e20 / right, left.e21 / right, left.e22 / right, left.e23 / right,
                left.e30 / right, left.e31 / right, left.e32 / right, left.e33 / right
            );
        }

        public static Matrix4x4<T> operator -(Matrix4x4<T> m)
        {
            return new Matrix4x4<T>(
                -m.e00, -m.e01, -m.e02, -m.e03,
                -m.e10, -m.e11, -m.e12, -m.e13,
                -m.e20, -m.e21, -m.e22, -m.e23,
                -m.e30, -m.e31, -m.e32, -m.e33
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

    public struct Matrix1x2<T> : ICloneable, IEquatable<Matrix1x2<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>, IMatrix<T>
        where T : struct
    {
        public readonly Scalar<T> e00, e01;

        public Vector2<int> Dimension => new Vector2<int>(1, 2);

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

        public Matrix2x1<T> Transpose()
        {
            return new Matrix2x1<T>(
                e00,
                e01
            );
        }

        public static Vector1<T> operator *(Matrix1x2<T> left, Vector2<T> right)
        {
            return new Vector1<T>(
                left.e00 * right.x + left.e01 * right.y
            );
        }

        public static Matrix1x2<T> operator +(Matrix1x2<T> left, Matrix1x2<T> right)
        {
            return new Matrix1x2<T>(
                left.e00 + right.e00, left.e01 + right.e01
            );
        }

        public static Matrix1x2<T> operator -(Matrix1x2<T> left, Matrix1x2<T> right)
        {
            return new Matrix1x2<T>(
                left.e00 - right.e00, left.e01 - right.e01
            );
        }

        public static Matrix1x2<T> operator *(Scalar<T> left, Matrix1x2<T> right)
        {
            return new Matrix1x2<T>(
                left * right.e00, left * right.e01
            );
        }

        public static Matrix1x2<T> operator *(Matrix1x2<T> left, Scalar<T> right)
        {
            return right * left;
        }

        public static Matrix1x2<T> operator /(Scalar<T> left, Matrix1x2<T> right)
        {
            return new Matrix1x2<T>(
                left / right.e00, left / right.e01
            );
        }

        public static Matrix1x2<T> operator /(Matrix1x2<T> left, Scalar<T> right)
        {
            return new Matrix1x2<T>(
                left.e00 / right, left.e01 / right
            );
        }

        public static Matrix1x2<T> operator -(Matrix1x2<T> m)
        {
            return new Matrix1x2<T>(
                -m.e00, -m.e01
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

    public struct Matrix2x1<T> : ICloneable, IEquatable<Matrix2x1<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>, IMatrix<T>
        where T : struct
    {
        public readonly Scalar<T> e00, e10;

        public Vector2<int> Dimension => new Vector2<int>(2, 1);

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

        public Matrix1x2<T> Transpose()
        {
            return new Matrix1x2<T>(
                e00, e10
            );
        }

        public static Vector2<T> operator *(Matrix2x1<T> left, Vector1<T> right)
        {
            return new Vector2<T>(
                left.e00 * right.x,
                left.e10 * right.x
            );
        }

        public static Matrix2x1<T> operator +(Matrix2x1<T> left, Matrix2x1<T> right)
        {
            return new Matrix2x1<T>(
                left.e00 + right.e00,
                left.e10 + right.e10
            );
        }

        public static Matrix2x1<T> operator -(Matrix2x1<T> left, Matrix2x1<T> right)
        {
            return new Matrix2x1<T>(
                left.e00 - right.e00,
                left.e10 - right.e10
            );
        }

        public static Matrix2x1<T> operator *(Scalar<T> left, Matrix2x1<T> right)
        {
            return new Matrix2x1<T>(
                left * right.e00,
                left * right.e10
            );
        }

        public static Matrix2x1<T> operator *(Matrix2x1<T> left, Scalar<T> right)
        {
            return right * left;
        }

        public static Matrix2x1<T> operator /(Scalar<T> left, Matrix2x1<T> right)
        {
            return new Matrix2x1<T>(
                left / right.e00,
                left / right.e10
            );
        }

        public static Matrix2x1<T> operator /(Matrix2x1<T> left, Scalar<T> right)
        {
            return new Matrix2x1<T>(
                left.e00 / right,
                left.e10 / right
            );
        }

        public static Matrix2x1<T> operator -(Matrix2x1<T> m)
        {
            return new Matrix2x1<T>(
                -m.e00,
                -m.e10
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

    public struct Matrix1x3<T> : ICloneable, IEquatable<Matrix1x3<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>, IMatrix<T>
        where T : struct
    {
        public readonly Scalar<T> e00, e01, e02;

        public Vector2<int> Dimension => new Vector2<int>(1, 3);

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

        public Matrix3x1<T> Transpose()
        {
            return new Matrix3x1<T>(
                e00,
                e01,
                e02
            );
        }

        public static Vector1<T> operator *(Matrix1x3<T> left, Vector3<T> right)
        {
            return new Vector1<T>(
                left.e00 * right.x + left.e01 * right.y + left.e02 * right.z
            );
        }

        public static Matrix1x3<T> operator +(Matrix1x3<T> left, Matrix1x3<T> right)
        {
            return new Matrix1x3<T>(
                left.e00 + right.e00, left.e01 + right.e01, left.e02 + right.e02
            );
        }

        public static Matrix1x3<T> operator -(Matrix1x3<T> left, Matrix1x3<T> right)
        {
            return new Matrix1x3<T>(
                left.e00 - right.e00, left.e01 - right.e01, left.e02 - right.e02
            );
        }

        public static Matrix1x3<T> operator *(Scalar<T> left, Matrix1x3<T> right)
        {
            return new Matrix1x3<T>(
                left * right.e00, left * right.e01, left * right.e02
            );
        }

        public static Matrix1x3<T> operator *(Matrix1x3<T> left, Scalar<T> right)
        {
            return right * left;
        }

        public static Matrix1x3<T> operator /(Scalar<T> left, Matrix1x3<T> right)
        {
            return new Matrix1x3<T>(
                left / right.e00, left / right.e01, left / right.e02
            );
        }

        public static Matrix1x3<T> operator /(Matrix1x3<T> left, Scalar<T> right)
        {
            return new Matrix1x3<T>(
                left.e00 / right, left.e01 / right, left.e02 / right
            );
        }

        public static Matrix1x3<T> operator -(Matrix1x3<T> m)
        {
            return new Matrix1x3<T>(
                -m.e00, -m.e01, -m.e02
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

    public struct Matrix3x1<T> : ICloneable, IEquatable<Matrix3x1<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>, IMatrix<T>
        where T : struct
    {
        public readonly Scalar<T> e00, e10, e20;

        public Vector2<int> Dimension => new Vector2<int>(3, 1);

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

        public Matrix1x3<T> Transpose()
        {
            return new Matrix1x3<T>(
                e00, e10, e20
            );
        }

        public static Vector3<T> operator *(Matrix3x1<T> left, Vector1<T> right)
        {
            return new Vector3<T>(
                left.e00 * right.x,
                left.e10 * right.x,
                left.e20 * right.x
            );
        }

        public static Matrix3x1<T> operator +(Matrix3x1<T> left, Matrix3x1<T> right)
        {
            return new Matrix3x1<T>(
                left.e00 + right.e00,
                left.e10 + right.e10,
                left.e20 + right.e20
            );
        }

        public static Matrix3x1<T> operator -(Matrix3x1<T> left, Matrix3x1<T> right)
        {
            return new Matrix3x1<T>(
                left.e00 - right.e00,
                left.e10 - right.e10,
                left.e20 - right.e20
            );
        }

        public static Matrix3x1<T> operator *(Scalar<T> left, Matrix3x1<T> right)
        {
            return new Matrix3x1<T>(
                left * right.e00,
                left * right.e10,
                left * right.e20
            );
        }

        public static Matrix3x1<T> operator *(Matrix3x1<T> left, Scalar<T> right)
        {
            return right * left;
        }

        public static Matrix3x1<T> operator /(Scalar<T> left, Matrix3x1<T> right)
        {
            return new Matrix3x1<T>(
                left / right.e00,
                left / right.e10,
                left / right.e20
            );
        }

        public static Matrix3x1<T> operator /(Matrix3x1<T> left, Scalar<T> right)
        {
            return new Matrix3x1<T>(
                left.e00 / right,
                left.e10 / right,
                left.e20 / right
            );
        }

        public static Matrix3x1<T> operator -(Matrix3x1<T> m)
        {
            return new Matrix3x1<T>(
                -m.e00,
                -m.e10,
                -m.e20
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

    public struct Matrix1x4<T> : ICloneable, IEquatable<Matrix1x4<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>, IMatrix<T>
        where T : struct
    {
        public readonly Scalar<T> e00, e01, e02, e03;

        public Vector2<int> Dimension => new Vector2<int>(1, 4);

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

        public Matrix4x1<T> Transpose()
        {
            return new Matrix4x1<T>(
                e00,
                e01,
                e02,
                e03
            );
        }

        public static Vector1<T> operator *(Matrix1x4<T> left, Vector4<T> right)
        {
            return new Vector1<T>(
                left.e00 * right.x + left.e01 * right.y + left.e02 * right.z + left.e03 * right.w
            );
        }

        public static Matrix1x4<T> operator +(Matrix1x4<T> left, Matrix1x4<T> right)
        {
            return new Matrix1x4<T>(
                left.e00 + right.e00, left.e01 + right.e01, left.e02 + right.e02, left.e03 + right.e03
            );
        }

        public static Matrix1x4<T> operator -(Matrix1x4<T> left, Matrix1x4<T> right)
        {
            return new Matrix1x4<T>(
                left.e00 - right.e00, left.e01 - right.e01, left.e02 - right.e02, left.e03 - right.e03
            );
        }

        public static Matrix1x4<T> operator *(Scalar<T> left, Matrix1x4<T> right)
        {
            return new Matrix1x4<T>(
                left * right.e00, left * right.e01, left * right.e02, left * right.e03
            );
        }

        public static Matrix1x4<T> operator *(Matrix1x4<T> left, Scalar<T> right)
        {
            return right * left;
        }

        public static Matrix1x4<T> operator /(Scalar<T> left, Matrix1x4<T> right)
        {
            return new Matrix1x4<T>(
                left / right.e00, left / right.e01, left / right.e02, left / right.e03
            );
        }

        public static Matrix1x4<T> operator /(Matrix1x4<T> left, Scalar<T> right)
        {
            return new Matrix1x4<T>(
                left.e00 / right, left.e01 / right, left.e02 / right, left.e03 / right
            );
        }

        public static Matrix1x4<T> operator -(Matrix1x4<T> m)
        {
            return new Matrix1x4<T>(
                -m.e00, -m.e01, -m.e02, -m.e03
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

    public struct Matrix4x1<T> : ICloneable, IEquatable<Matrix4x1<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>, IMatrix<T>
        where T : struct
    {
        public readonly Scalar<T> e00, e10, e20, e30;

        public Vector2<int> Dimension => new Vector2<int>(4, 1);

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

        public Matrix1x4<T> Transpose()
        {
            return new Matrix1x4<T>(
                e00, e10, e20, e30
            );
        }

        public static Vector4<T> operator *(Matrix4x1<T> left, Vector1<T> right)
        {
            return new Vector4<T>(
                left.e00 * right.x,
                left.e10 * right.x,
                left.e20 * right.x,
                left.e30 * right.x
            );
        }

        public static Matrix4x1<T> operator +(Matrix4x1<T> left, Matrix4x1<T> right)
        {
            return new Matrix4x1<T>(
                left.e00 + right.e00,
                left.e10 + right.e10,
                left.e20 + right.e20,
                left.e30 + right.e30
            );
        }

        public static Matrix4x1<T> operator -(Matrix4x1<T> left, Matrix4x1<T> right)
        {
            return new Matrix4x1<T>(
                left.e00 - right.e00,
                left.e10 - right.e10,
                left.e20 - right.e20,
                left.e30 - right.e30
            );
        }

        public static Matrix4x1<T> operator *(Scalar<T> left, Matrix4x1<T> right)
        {
            return new Matrix4x1<T>(
                left * right.e00,
                left * right.e10,
                left * right.e20,
                left * right.e30
            );
        }

        public static Matrix4x1<T> operator *(Matrix4x1<T> left, Scalar<T> right)
        {
            return right * left;
        }

        public static Matrix4x1<T> operator /(Scalar<T> left, Matrix4x1<T> right)
        {
            return new Matrix4x1<T>(
                left / right.e00,
                left / right.e10,
                left / right.e20,
                left / right.e30
            );
        }

        public static Matrix4x1<T> operator /(Matrix4x1<T> left, Scalar<T> right)
        {
            return new Matrix4x1<T>(
                left.e00 / right,
                left.e10 / right,
                left.e20 / right,
                left.e30 / right
            );
        }

        public static Matrix4x1<T> operator -(Matrix4x1<T> m)
        {
            return new Matrix4x1<T>(
                -m.e00,
                -m.e10,
                -m.e20,
                -m.e30
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

    public struct Matrix2x3<T> : ICloneable, IEquatable<Matrix2x3<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>, IMatrix<T>
        where T : struct
    {
        public readonly Scalar<T> e00, e01, e02, e10, e11, e12;

        public Vector2<int> Dimension => new Vector2<int>(2, 3);

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

        public Matrix3x2<T> Transpose()
        {
            return new Matrix3x2<T>(
                e00, e10,
                e01, e11,
                e02, e12
            );
        }

        public static Vector2<T> operator *(Matrix2x3<T> left, Vector3<T> right)
        {
            return new Vector2<T>(
                left.e00 * right.x + left.e01 * right.y + left.e02 * right.z,
                left.e10 * right.x + left.e11 * right.y + left.e12 * right.z
            );
        }

        public static Matrix2x3<T> operator +(Matrix2x3<T> left, Matrix2x3<T> right)
        {
            return new Matrix2x3<T>(
                left.e00 + right.e00, left.e01 + right.e01, left.e02 + right.e02,
                left.e10 + right.e10, left.e11 + right.e11, left.e12 + right.e12
            );
        }

        public static Matrix2x3<T> operator -(Matrix2x3<T> left, Matrix2x3<T> right)
        {
            return new Matrix2x3<T>(
                left.e00 - right.e00, left.e01 - right.e01, left.e02 - right.e02,
                left.e10 - right.e10, left.e11 - right.e11, left.e12 - right.e12
            );
        }

        public static Matrix2x3<T> operator *(Scalar<T> left, Matrix2x3<T> right)
        {
            return new Matrix2x3<T>(
                left * right.e00, left * right.e01, left * right.e02,
                left * right.e10, left * right.e11, left * right.e12
            );
        }

        public static Matrix2x3<T> operator *(Matrix2x3<T> left, Scalar<T> right)
        {
            return right * left;
        }

        public static Matrix2x3<T> operator /(Scalar<T> left, Matrix2x3<T> right)
        {
            return new Matrix2x3<T>(
                left / right.e00, left / right.e01, left / right.e02,
                left / right.e10, left / right.e11, left / right.e12
            );
        }

        public static Matrix2x3<T> operator /(Matrix2x3<T> left, Scalar<T> right)
        {
            return new Matrix2x3<T>(
                left.e00 / right, left.e01 / right, left.e02 / right,
                left.e10 / right, left.e11 / right, left.e12 / right
            );
        }

        public static Matrix2x3<T> operator -(Matrix2x3<T> m)
        {
            return new Matrix2x3<T>(
                -m.e00, -m.e01, -m.e02,
                -m.e10, -m.e11, -m.e12
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

    public struct Matrix3x2<T> : ICloneable, IEquatable<Matrix3x2<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>, IMatrix<T>
        where T : struct
    {
        public readonly Scalar<T> e00, e01, e10, e11, e20, e21;

        public Vector2<int> Dimension => new Vector2<int>(3, 2);

        public Scalar<T>[,] Data => new Scalar<T>[3, 2] {
            { e00, e01 },
            { e10, e11 },
            { e20, e21 }
        };

        public static Matrix3x2<T> Zero()
        {
            return new Matrix3x2<T>(0, 0, 0, 0, 0, 0);
        }

        public Matrix3x2(Scalar<T> e00, Scalar<T> e01, Scalar<T> e10, Scalar<T> e11, Scalar<T> e20, Scalar<T> e21)
        {
            this.e00 = e00;
            this.e01 = e01;
            this.e10 = e10;
            this.e11 = e11;
            this.e20 = e20;
            this.e21 = e21;
        }

        public Matrix3x2(T e00, T e01, T e10, T e11, T e20, T e21)
        {
            this.e00 = new Scalar<T>(e00);
            this.e01 = new Scalar<T>(e01);
            this.e10 = new Scalar<T>(e10);
            this.e11 = new Scalar<T>(e11);
            this.e20 = new Scalar<T>(e20);
            this.e21 = new Scalar<T>(e21);
        }

        public Scalar<T> this[int i, int j] => Data[i, j];

        public Vector2<T>[] Rows
        {
            get
            {
                return new Vector2<T>[]
                {
                    new Vector2<T>(e00, e01),
                    new Vector2<T>(e10, e11),
                    new Vector2<T>(e20, e21)
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
                    new Vector3<T>(e01, e11, e21)
                };
            }
        }

        public Vector3<T> Transform(Vector2<T> vec)
        {
            return new Vector3<T>(
                e00 * vec.x + e01 * vec.y,
                e10 * vec.x + e11 * vec.y,
                e20 * vec.x + e21 * vec.y
            );
        }

        public Matrix1x3<T> Transform(Matrix2x1<T> mat)
        {
            return new Matrix1x3<T>(
                e00 * mat.e00 + e01 * mat.e10,
                e10 * mat.e00 + e11 * mat.e10,
                e20 * mat.e00 + e21 * mat.e10
            );
        }

        public Matrix2x3<T> Transpose()
        {
            return new Matrix2x3<T>(
                e00, e10, e20,
                e01, e11, e21
            );
        }

        public static Vector3<T> operator *(Matrix3x2<T> left, Vector2<T> right)
        {
            return new Vector3<T>(
                left.e00 * right.x + left.e01 * right.y,
                left.e10 * right.x + left.e11 * right.y,
                left.e20 * right.x + left.e21 * right.y
            );
        }

        public static Matrix3x2<T> operator +(Matrix3x2<T> left, Matrix3x2<T> right)
        {
            return new Matrix3x2<T>(
                left.e00 + right.e00, left.e01 + right.e01,
                left.e10 + right.e10, left.e11 + right.e11,
                left.e20 + right.e20, left.e21 + right.e21
            );
        }

        public static Matrix3x2<T> operator -(Matrix3x2<T> left, Matrix3x2<T> right)
        {
            return new Matrix3x2<T>(
                left.e00 - right.e00, left.e01 - right.e01,
                left.e10 - right.e10, left.e11 - right.e11,
                left.e20 - right.e20, left.e21 - right.e21
            );
        }

        public static Matrix3x2<T> operator *(Scalar<T> left, Matrix3x2<T> right)
        {
            return new Matrix3x2<T>(
                left * right.e00, left * right.e01,
                left * right.e10, left * right.e11,
                left * right.e20, left * right.e21
            );
        }

        public static Matrix3x2<T> operator *(Matrix3x2<T> left, Scalar<T> right)
        {
            return right * left;
        }

        public static Matrix3x2<T> operator /(Scalar<T> left, Matrix3x2<T> right)
        {
            return new Matrix3x2<T>(
                left / right.e00, left / right.e01,
                left / right.e10, left / right.e11,
                left / right.e20, left / right.e21
            );
        }

        public static Matrix3x2<T> operator /(Matrix3x2<T> left, Scalar<T> right)
        {
            return new Matrix3x2<T>(
                left.e00 / right, left.e01 / right,
                left.e10 / right, left.e11 / right,
                left.e20 / right, left.e21 / right
            );
        }

        public static Matrix3x2<T> operator -(Matrix3x2<T> m)
        {
            return new Matrix3x2<T>(
                -m.e00, -m.e01,
                -m.e10, -m.e11,
                -m.e20, -m.e21
            );
        }

        public static implicit operator Matrix3x2<T>(((T, T), (T, T), (T, T)) t)
        {
            return new Matrix3x2<T>(
                t.Item1.Item1, t.Item1.Item2,
                t.Item2.Item1, t.Item2.Item2,
                t.Item3.Item1, t.Item3.Item2
            );
        }

        public override string ToString()
        {
            return $"Matrix3x2(" + Environment.NewLine +
                    $"\t({ e00 }, { e01 })," + Environment.NewLine +
                    $"\t({ e10 }, { e11 })," + Environment.NewLine +
                    $"\t({ e20 }, { e21 })" + Environment.NewLine +
                $")";
        }

        public override bool Equals(object obj)
        {
            if (obj is Matrix3x2<T> m)
                return Equals(m);

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new Matrix3x2<T>(e00, e01, e10, e11, e20, e21);
        }

        public bool Equals(Matrix3x2<T> other)
        {
            return e00 == other.e00 && e01 == other.e01 && e10 == other.e10 && e11 == other.e11 && e20 == other.e20 && e21 == other.e21;
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
            yield return e20;
            yield return e21;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            yield return e00.Value;
            yield return e01.Value;
            yield return e10.Value;
            yield return e11.Value;
            yield return e20.Value;
            yield return e21.Value;
        }
    }

    public struct Matrix2x4<T> : ICloneable, IEquatable<Matrix2x4<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>, IMatrix<T>
        where T : struct
    {
        public readonly Scalar<T> e00, e01, e02, e03, e10, e11, e12, e13;

        public Vector2<int> Dimension => new Vector2<int>(2, 4);

        public Scalar<T>[,] Data => new Scalar<T>[2, 4] {
            { e00, e01, e02, e03 },
            { e10, e11, e12, e13 }
        };

        public static Matrix2x4<T> Zero()
        {
            return new Matrix2x4<T>(0, 0, 0, 0, 0, 0, 0, 0);
        }

        public Matrix2x4(Scalar<T> e00, Scalar<T> e01, Scalar<T> e02, Scalar<T> e03, Scalar<T> e10, Scalar<T> e11, Scalar<T> e12, Scalar<T> e13)
        {
            this.e00 = e00;
            this.e01 = e01;
            this.e02 = e02;
            this.e03 = e03;
            this.e10 = e10;
            this.e11 = e11;
            this.e12 = e12;
            this.e13 = e13;
        }

        public Matrix2x4(T e00, T e01, T e02, T e03, T e10, T e11, T e12, T e13)
        {
            this.e00 = new Scalar<T>(e00);
            this.e01 = new Scalar<T>(e01);
            this.e02 = new Scalar<T>(e02);
            this.e03 = new Scalar<T>(e03);
            this.e10 = new Scalar<T>(e10);
            this.e11 = new Scalar<T>(e11);
            this.e12 = new Scalar<T>(e12);
            this.e13 = new Scalar<T>(e13);
        }

        public Scalar<T> this[int i, int j] => Data[i, j];

        public Vector4<T>[] Rows
        {
            get
            {
                return new Vector4<T>[]
                {
                    new Vector4<T>(e00, e01, e02, e03),
                    new Vector4<T>(e10, e11, e12, e13)
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
                    new Vector2<T>(e02, e12),
                    new Vector2<T>(e03, e13)
                };
            }
        }

        public Vector2<T> Transform(Vector4<T> vec)
        {
            return new Vector2<T>(
                e00 * vec.x + e01 * vec.y + e02 * vec.z + e03 * vec.w,
                e10 * vec.x + e11 * vec.y + e12 * vec.z + e13 * vec.w
            );
        }

        public Matrix1x2<T> Transform(Matrix4x1<T> mat)
        {
            return new Matrix1x2<T>(
                e00 * mat.e00 + e01 * mat.e10 + e02 * mat.e20 + e03 * mat.e30,
                e10 * mat.e00 + e11 * mat.e10 + e12 * mat.e20 + e13 * mat.e30
            );
        }

        public Matrix4x2<T> Transpose()
        {
            return new Matrix4x2<T>(
                e00, e10,
                e01, e11,
                e02, e12,
                e03, e13
            );
        }

        public static Vector2<T> operator *(Matrix2x4<T> left, Vector4<T> right)
        {
            return new Vector2<T>(
                left.e00 * right.x + left.e01 * right.y + left.e02 * right.z + left.e03 * right.w,
                left.e10 * right.x + left.e11 * right.y + left.e12 * right.z + left.e13 * right.w
            );
        }

        public static Matrix2x4<T> operator +(Matrix2x4<T> left, Matrix2x4<T> right)
        {
            return new Matrix2x4<T>(
                left.e00 + right.e00, left.e01 + right.e01, left.e02 + right.e02, left.e03 + right.e03,
                left.e10 + right.e10, left.e11 + right.e11, left.e12 + right.e12, left.e13 + right.e13
            );
        }

        public static Matrix2x4<T> operator -(Matrix2x4<T> left, Matrix2x4<T> right)
        {
            return new Matrix2x4<T>(
                left.e00 - right.e00, left.e01 - right.e01, left.e02 - right.e02, left.e03 - right.e03,
                left.e10 - right.e10, left.e11 - right.e11, left.e12 - right.e12, left.e13 - right.e13
            );
        }

        public static Matrix2x4<T> operator *(Scalar<T> left, Matrix2x4<T> right)
        {
            return new Matrix2x4<T>(
                left * right.e00, left * right.e01, left * right.e02, left * right.e03,
                left * right.e10, left * right.e11, left * right.e12, left * right.e13
            );
        }

        public static Matrix2x4<T> operator *(Matrix2x4<T> left, Scalar<T> right)
        {
            return right * left;
        }

        public static Matrix2x4<T> operator /(Scalar<T> left, Matrix2x4<T> right)
        {
            return new Matrix2x4<T>(
                left / right.e00, left / right.e01, left / right.e02, left / right.e03,
                left / right.e10, left / right.e11, left / right.e12, left / right.e13
            );
        }

        public static Matrix2x4<T> operator /(Matrix2x4<T> left, Scalar<T> right)
        {
            return new Matrix2x4<T>(
                left.e00 / right, left.e01 / right, left.e02 / right, left.e03 / right,
                left.e10 / right, left.e11 / right, left.e12 / right, left.e13 / right
            );
        }

        public static Matrix2x4<T> operator -(Matrix2x4<T> m)
        {
            return new Matrix2x4<T>(
                -m.e00, -m.e01, -m.e02, -m.e03,
                -m.e10, -m.e11, -m.e12, -m.e13
            );
        }

        public static implicit operator Matrix2x4<T>(((T, T, T, T), (T, T, T, T)) t)
        {
            return new Matrix2x4<T>(
                t.Item1.Item1, t.Item1.Item2, t.Item1.Item3, t.Item1.Item4,
                t.Item2.Item1, t.Item2.Item2, t.Item2.Item3, t.Item2.Item4
            );
        }

        public override string ToString()
        {
            return $"Matrix2x4(" + Environment.NewLine +
                    $"\t({ e00 }, { e01 }, { e02 }, { e03 })," + Environment.NewLine +
                    $"\t({ e10 }, { e11 }, { e12 }, { e13 })" + Environment.NewLine +
                $")";
        }

        public override bool Equals(object obj)
        {
            if (obj is Matrix2x4<T> m)
                return Equals(m);

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new Matrix2x4<T>(e00, e01, e02, e03, e10, e11, e12, e13);
        }

        public bool Equals(Matrix2x4<T> other)
        {
            return e00 == other.e00 && e01 == other.e01 && e02 == other.e02 && e03 == other.e03 && e10 == other.e10 && e11 == other.e11 && e12 == other.e12 && e13 == other.e13;
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
        }
    }

    public struct Matrix4x2<T> : ICloneable, IEquatable<Matrix4x2<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>, IMatrix<T>
        where T : struct
    {
        public readonly Scalar<T> e00, e01, e10, e11, e20, e21, e30, e31;

        public Vector2<int> Dimension => new Vector2<int>(4, 2);

        public Scalar<T>[,] Data => new Scalar<T>[4, 2] {
            { e00, e01 },
            { e10, e11 },
            { e20, e21 },
            { e30, e31 }
        };

        public static Matrix4x2<T> Zero()
        {
            return new Matrix4x2<T>(0, 0, 0, 0, 0, 0, 0, 0);
        }

        public Matrix4x2(Scalar<T> e00, Scalar<T> e01, Scalar<T> e10, Scalar<T> e11, Scalar<T> e20, Scalar<T> e21, Scalar<T> e30, Scalar<T> e31)
        {
            this.e00 = e00;
            this.e01 = e01;
            this.e10 = e10;
            this.e11 = e11;
            this.e20 = e20;
            this.e21 = e21;
            this.e30 = e30;
            this.e31 = e31;
        }

        public Matrix4x2(T e00, T e01, T e10, T e11, T e20, T e21, T e30, T e31)
        {
            this.e00 = new Scalar<T>(e00);
            this.e01 = new Scalar<T>(e01);
            this.e10 = new Scalar<T>(e10);
            this.e11 = new Scalar<T>(e11);
            this.e20 = new Scalar<T>(e20);
            this.e21 = new Scalar<T>(e21);
            this.e30 = new Scalar<T>(e30);
            this.e31 = new Scalar<T>(e31);
        }

        public Scalar<T> this[int i, int j] => Data[i, j];

        public Vector2<T>[] Rows
        {
            get
            {
                return new Vector2<T>[]
                {
                    new Vector2<T>(e00, e01),
                    new Vector2<T>(e10, e11),
                    new Vector2<T>(e20, e21),
                    new Vector2<T>(e30, e31)
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
                    new Vector4<T>(e01, e11, e21, e31)
                };
            }
        }

        public Vector4<T> Transform(Vector2<T> vec)
        {
            return new Vector4<T>(
                e00 * vec.x + e01 * vec.y,
                e10 * vec.x + e11 * vec.y,
                e20 * vec.x + e21 * vec.y,
                e30 * vec.x + e31 * vec.y
            );
        }

        public Matrix1x4<T> Transform(Matrix2x1<T> mat)
        {
            return new Matrix1x4<T>(
                e00 * mat.e00 + e01 * mat.e10,
                e10 * mat.e00 + e11 * mat.e10,
                e20 * mat.e00 + e21 * mat.e10,
                e30 * mat.e00 + e31 * mat.e10
            );
        }

        public Matrix2x4<T> Transpose()
        {
            return new Matrix2x4<T>(
                e00, e10, e20, e30,
                e01, e11, e21, e31
            );
        }

        public static Vector4<T> operator *(Matrix4x2<T> left, Vector2<T> right)
        {
            return new Vector4<T>(
                left.e00 * right.x + left.e01 * right.y,
                left.e10 * right.x + left.e11 * right.y,
                left.e20 * right.x + left.e21 * right.y,
                left.e30 * right.x + left.e31 * right.y
            );
        }

        public static Matrix4x2<T> operator +(Matrix4x2<T> left, Matrix4x2<T> right)
        {
            return new Matrix4x2<T>(
                left.e00 + right.e00, left.e01 + right.e01,
                left.e10 + right.e10, left.e11 + right.e11,
                left.e20 + right.e20, left.e21 + right.e21,
                left.e30 + right.e30, left.e31 + right.e31
            );
        }

        public static Matrix4x2<T> operator -(Matrix4x2<T> left, Matrix4x2<T> right)
        {
            return new Matrix4x2<T>(
                left.e00 - right.e00, left.e01 - right.e01,
                left.e10 - right.e10, left.e11 - right.e11,
                left.e20 - right.e20, left.e21 - right.e21,
                left.e30 - right.e30, left.e31 - right.e31
            );
        }

        public static Matrix4x2<T> operator *(Scalar<T> left, Matrix4x2<T> right)
        {
            return new Matrix4x2<T>(
                left * right.e00, left * right.e01,
                left * right.e10, left * right.e11,
                left * right.e20, left * right.e21,
                left * right.e30, left * right.e31
            );
        }

        public static Matrix4x2<T> operator *(Matrix4x2<T> left, Scalar<T> right)
        {
            return right * left;
        }

        public static Matrix4x2<T> operator /(Scalar<T> left, Matrix4x2<T> right)
        {
            return new Matrix4x2<T>(
                left / right.e00, left / right.e01,
                left / right.e10, left / right.e11,
                left / right.e20, left / right.e21,
                left / right.e30, left / right.e31
            );
        }

        public static Matrix4x2<T> operator /(Matrix4x2<T> left, Scalar<T> right)
        {
            return new Matrix4x2<T>(
                left.e00 / right, left.e01 / right,
                left.e10 / right, left.e11 / right,
                left.e20 / right, left.e21 / right,
                left.e30 / right, left.e31 / right
            );
        }

        public static Matrix4x2<T> operator -(Matrix4x2<T> m)
        {
            return new Matrix4x2<T>(
                -m.e00, -m.e01,
                -m.e10, -m.e11,
                -m.e20, -m.e21,
                -m.e30, -m.e31
            );
        }

        public static implicit operator Matrix4x2<T>(((T, T), (T, T), (T, T), (T, T)) t)
        {
            return new Matrix4x2<T>(
                t.Item1.Item1, t.Item1.Item2,
                t.Item2.Item1, t.Item2.Item2,
                t.Item3.Item1, t.Item3.Item2,
                t.Item4.Item1, t.Item4.Item2
            );
        }

        public override string ToString()
        {
            return $"Matrix4x2(" + Environment.NewLine +
                    $"\t({ e00 }, { e01 })," + Environment.NewLine +
                    $"\t({ e10 }, { e11 })," + Environment.NewLine +
                    $"\t({ e20 }, { e21 })," + Environment.NewLine +
                    $"\t({ e30 }, { e31 })" + Environment.NewLine +
                $")";
        }

        public override bool Equals(object obj)
        {
            if (obj is Matrix4x2<T> m)
                return Equals(m);

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new Matrix4x2<T>(e00, e01, e10, e11, e20, e21, e30, e31);
        }

        public bool Equals(Matrix4x2<T> other)
        {
            return e00 == other.e00 && e01 == other.e01 && e10 == other.e10 && e11 == other.e11 && e20 == other.e20 && e21 == other.e21 && e30 == other.e30 && e31 == other.e31;
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
            yield return e20;
            yield return e21;
            yield return e30;
            yield return e31;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            yield return e00.Value;
            yield return e01.Value;
            yield return e10.Value;
            yield return e11.Value;
            yield return e20.Value;
            yield return e21.Value;
            yield return e30.Value;
            yield return e31.Value;
        }
    }

    public struct Matrix3x4<T> : ICloneable, IEquatable<Matrix3x4<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>, IMatrix<T>
        where T : struct
    {
        public readonly Scalar<T> e00, e01, e02, e03, e10, e11, e12, e13, e20, e21, e22, e23;

        public Vector2<int> Dimension => new Vector2<int>(3, 4);

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

        public Matrix4x3<T> Transpose()
        {
            return new Matrix4x3<T>(
                e00, e10, e20,
                e01, e11, e21,
                e02, e12, e22,
                e03, e13, e23
            );
        }

        public static Vector3<T> operator *(Matrix3x4<T> left, Vector4<T> right)
        {
            return new Vector3<T>(
                left.e00 * right.x + left.e01 * right.y + left.e02 * right.z + left.e03 * right.w,
                left.e10 * right.x + left.e11 * right.y + left.e12 * right.z + left.e13 * right.w,
                left.e20 * right.x + left.e21 * right.y + left.e22 * right.z + left.e23 * right.w
            );
        }

        public static Matrix3x4<T> operator +(Matrix3x4<T> left, Matrix3x4<T> right)
        {
            return new Matrix3x4<T>(
                left.e00 + right.e00, left.e01 + right.e01, left.e02 + right.e02, left.e03 + right.e03,
                left.e10 + right.e10, left.e11 + right.e11, left.e12 + right.e12, left.e13 + right.e13,
                left.e20 + right.e20, left.e21 + right.e21, left.e22 + right.e22, left.e23 + right.e23
            );
        }

        public static Matrix3x4<T> operator -(Matrix3x4<T> left, Matrix3x4<T> right)
        {
            return new Matrix3x4<T>(
                left.e00 - right.e00, left.e01 - right.e01, left.e02 - right.e02, left.e03 - right.e03,
                left.e10 - right.e10, left.e11 - right.e11, left.e12 - right.e12, left.e13 - right.e13,
                left.e20 - right.e20, left.e21 - right.e21, left.e22 - right.e22, left.e23 - right.e23
            );
        }

        public static Matrix3x4<T> operator *(Scalar<T> left, Matrix3x4<T> right)
        {
            return new Matrix3x4<T>(
                left * right.e00, left * right.e01, left * right.e02, left * right.e03,
                left * right.e10, left * right.e11, left * right.e12, left * right.e13,
                left * right.e20, left * right.e21, left * right.e22, left * right.e23
            );
        }

        public static Matrix3x4<T> operator *(Matrix3x4<T> left, Scalar<T> right)
        {
            return right * left;
        }

        public static Matrix3x4<T> operator /(Scalar<T> left, Matrix3x4<T> right)
        {
            return new Matrix3x4<T>(
                left / right.e00, left / right.e01, left / right.e02, left / right.e03,
                left / right.e10, left / right.e11, left / right.e12, left / right.e13,
                left / right.e20, left / right.e21, left / right.e22, left / right.e23
            );
        }

        public static Matrix3x4<T> operator /(Matrix3x4<T> left, Scalar<T> right)
        {
            return new Matrix3x4<T>(
                left.e00 / right, left.e01 / right, left.e02 / right, left.e03 / right,
                left.e10 / right, left.e11 / right, left.e12 / right, left.e13 / right,
                left.e20 / right, left.e21 / right, left.e22 / right, left.e23 / right
            );
        }

        public static Matrix3x4<T> operator -(Matrix3x4<T> m)
        {
            return new Matrix3x4<T>(
                -m.e00, -m.e01, -m.e02, -m.e03,
                -m.e10, -m.e11, -m.e12, -m.e13,
                -m.e20, -m.e21, -m.e22, -m.e23
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

    public struct Matrix4x3<T> : ICloneable, IEquatable<Matrix4x3<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>, IMatrix<T>
        where T : struct
    {
        public readonly Scalar<T> e00, e01, e02, e10, e11, e12, e20, e21, e22, e30, e31, e32;

        public Vector2<int> Dimension => new Vector2<int>(4, 3);

        public Scalar<T>[,] Data => new Scalar<T>[4, 3] {
            { e00, e01, e02 },
            { e10, e11, e12 },
            { e20, e21, e22 },
            { e30, e31, e32 }
        };

        public static Matrix4x3<T> Zero()
        {
            return new Matrix4x3<T>(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }

        public Matrix4x3(Scalar<T> e00, Scalar<T> e01, Scalar<T> e02, Scalar<T> e10, Scalar<T> e11, Scalar<T> e12, Scalar<T> e20, Scalar<T> e21, Scalar<T> e22, Scalar<T> e30, Scalar<T> e31, Scalar<T> e32)
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
            this.e30 = e30;
            this.e31 = e31;
            this.e32 = e32;
        }

        public Matrix4x3(T e00, T e01, T e02, T e10, T e11, T e12, T e20, T e21, T e22, T e30, T e31, T e32)
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
            this.e30 = new Scalar<T>(e30);
            this.e31 = new Scalar<T>(e31);
            this.e32 = new Scalar<T>(e32);
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
                    new Vector3<T>(e20, e21, e22),
                    new Vector3<T>(e30, e31, e32)
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
                    new Vector4<T>(e02, e12, e22, e32)
                };
            }
        }

        public Vector4<T> Transform(Vector3<T> vec)
        {
            return new Vector4<T>(
                e00 * vec.x + e01 * vec.y + e02 * vec.z,
                e10 * vec.x + e11 * vec.y + e12 * vec.z,
                e20 * vec.x + e21 * vec.y + e22 * vec.z,
                e30 * vec.x + e31 * vec.y + e32 * vec.z
            );
        }

        public Matrix1x4<T> Transform(Matrix3x1<T> mat)
        {
            return new Matrix1x4<T>(
                e00 * mat.e00 + e01 * mat.e10 + e02 * mat.e20,
                e10 * mat.e00 + e11 * mat.e10 + e12 * mat.e20,
                e20 * mat.e00 + e21 * mat.e10 + e22 * mat.e20,
                e30 * mat.e00 + e31 * mat.e10 + e32 * mat.e20
            );
        }

        public Matrix3x4<T> Transpose()
        {
            return new Matrix3x4<T>(
                e00, e10, e20, e30,
                e01, e11, e21, e31,
                e02, e12, e22, e32
            );
        }

        public static Vector4<T> operator *(Matrix4x3<T> left, Vector3<T> right)
        {
            return new Vector4<T>(
                left.e00 * right.x + left.e01 * right.y + left.e02 * right.z,
                left.e10 * right.x + left.e11 * right.y + left.e12 * right.z,
                left.e20 * right.x + left.e21 * right.y + left.e22 * right.z,
                left.e30 * right.x + left.e31 * right.y + left.e32 * right.z
            );
        }

        public static Matrix4x3<T> operator +(Matrix4x3<T> left, Matrix4x3<T> right)
        {
            return new Matrix4x3<T>(
                left.e00 + right.e00, left.e01 + right.e01, left.e02 + right.e02,
                left.e10 + right.e10, left.e11 + right.e11, left.e12 + right.e12,
                left.e20 + right.e20, left.e21 + right.e21, left.e22 + right.e22,
                left.e30 + right.e30, left.e31 + right.e31, left.e32 + right.e32
            );
        }

        public static Matrix4x3<T> operator -(Matrix4x3<T> left, Matrix4x3<T> right)
        {
            return new Matrix4x3<T>(
                left.e00 - right.e00, left.e01 - right.e01, left.e02 - right.e02,
                left.e10 - right.e10, left.e11 - right.e11, left.e12 - right.e12,
                left.e20 - right.e20, left.e21 - right.e21, left.e22 - right.e22,
                left.e30 - right.e30, left.e31 - right.e31, left.e32 - right.e32
            );
        }

        public static Matrix4x3<T> operator *(Scalar<T> left, Matrix4x3<T> right)
        {
            return new Matrix4x3<T>(
                left * right.e00, left * right.e01, left * right.e02,
                left * right.e10, left * right.e11, left * right.e12,
                left * right.e20, left * right.e21, left * right.e22,
                left * right.e30, left * right.e31, left * right.e32
            );
        }

        public static Matrix4x3<T> operator *(Matrix4x3<T> left, Scalar<T> right)
        {
            return right * left;
        }

        public static Matrix4x3<T> operator /(Scalar<T> left, Matrix4x3<T> right)
        {
            return new Matrix4x3<T>(
                left / right.e00, left / right.e01, left / right.e02,
                left / right.e10, left / right.e11, left / right.e12,
                left / right.e20, left / right.e21, left / right.e22,
                left / right.e30, left / right.e31, left / right.e32
            );
        }

        public static Matrix4x3<T> operator /(Matrix4x3<T> left, Scalar<T> right)
        {
            return new Matrix4x3<T>(
                left.e00 / right, left.e01 / right, left.e02 / right,
                left.e10 / right, left.e11 / right, left.e12 / right,
                left.e20 / right, left.e21 / right, left.e22 / right,
                left.e30 / right, left.e31 / right, left.e32 / right
            );
        }

        public static Matrix4x3<T> operator -(Matrix4x3<T> m)
        {
            return new Matrix4x3<T>(
                -m.e00, -m.e01, -m.e02,
                -m.e10, -m.e11, -m.e12,
                -m.e20, -m.e21, -m.e22,
                -m.e30, -m.e31, -m.e32
            );
        }

        public static implicit operator Matrix4x3<T>(((T, T, T), (T, T, T), (T, T, T), (T, T, T)) t)
        {
            return new Matrix4x3<T>(
                t.Item1.Item1, t.Item1.Item2, t.Item1.Item3,
                t.Item2.Item1, t.Item2.Item2, t.Item2.Item3,
                t.Item3.Item1, t.Item3.Item2, t.Item3.Item3,
                t.Item4.Item1, t.Item4.Item2, t.Item4.Item3
            );
        }

        public override string ToString()
        {
            return $"Matrix4x3(" + Environment.NewLine +
                    $"\t({ e00 }, { e01 }, { e02 })," + Environment.NewLine +
                    $"\t({ e10 }, { e11 }, { e12 })," + Environment.NewLine +
                    $"\t({ e20 }, { e21 }, { e22 })," + Environment.NewLine +
                    $"\t({ e30 }, { e31 }, { e32 })" + Environment.NewLine +
                $")";
        }

        public override bool Equals(object obj)
        {
            if (obj is Matrix4x3<T> m)
                return Equals(m);

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new Matrix4x3<T>(e00, e01, e02, e10, e11, e12, e20, e21, e22, e30, e31, e32);
        }

        public bool Equals(Matrix4x3<T> other)
        {
            return e00 == other.e00 && e01 == other.e01 && e02 == other.e02 && e10 == other.e10 && e11 == other.e11 && e12 == other.e12 && e20 == other.e20 && e21 == other.e21 && e22 == other.e22 && e30 == other.e30 && e31 == other.e31 && e32 == other.e32;
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
            yield return e30;
            yield return e31;
            yield return e32;
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
            yield return e30.Value;
            yield return e31.Value;
            yield return e32.Value;
        }
    }
}