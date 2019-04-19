using LinearAlgebra.Scalars;
using LinearAlgebra.Vectors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinearAlgebra.Matrices
{
    public struct Matrix<T> :
        ICloneable,
        IEquatable<Matrix<T>>,
        IEnumerable,
        IEnumerable<Scalar<T>>,
        IEnumerable<T>,
        IMatrix<T>,
        ITensor<T, Vector2<int>, Matrix<T>>
        where T : struct
    {
        #region Fields and Properties

        public Scalar<int> Rank => 2;
        public Vector2<int> Dimension { get; }
        public Scalar<T>[,] Data { get; }


        public Vector<T>[] Rows
        {
            get
            {
                Vector<T>[] rows = new Vector<T>[Dimension.x];

                for (int i = 0; i < Dimension.x; i++)
                {
                    Scalar<T>[] data = new Scalar<T>[Dimension.y];

                    for (int j = 0; j < Dimension.y; j++)
                        data[j] = Data[i, j];

                    rows[i] = new Vector<T>(data);
                }

                return rows;
            }
        }
        public Vector<T>[] Columns
        {
            get
            {
                Vector<T>[] columns = new Vector<T>[Dimension.y];

                for (int j = 0; j < Dimension.y; j++)
                {
                    Scalar<T>[] data = new Scalar<T>[Dimension.x];

                    for (int i = 0; i < Dimension.x; i++)
                        data[j] = Data[i, j];

                    columns[j] = new Vector<T>(data);
                }

                return columns;
            }
        }

        public Scalar<T> this[int i, int j] => Data[i, j];
        public Vector<T> this[int row] => Rows[row];

        #endregion

        #region Static

        public static Matrix<T> Zero(Vector2<int> dimensions)
        {
            Scalar<T>[,] data = new Scalar<T>[dimensions.x, dimensions.y];
            for (int i = 0; i < dimensions.x; i++)
                for (int j = 0; j < dimensions.y; j++)
                    data[i, j] = Scalar<T>.Zero;

            return new Matrix<T>(data);
        }
        public static Matrix<T> Zero(int dimension)
        {
            return Zero(new Vector2<int>(dimension));
        }

        public static Matrix<T> One(int dimension)
        {
            Scalar<T>[,] data = new Scalar<T>[dimension, dimension];
            for (int i = 0; i < dimension; i++)
                for (int j = 0; j < dimension; j++)
                    if (i == j)
                        data[i, j] = Scalar<T>.One;
                    else
                        data[i, j] = Scalar<T>.Zero;

            return new Matrix<T>(data);
        }

        #endregion

        #region Constructors

        public Matrix(Scalar<T>[,] data)
        {
            Dimension = new Vector2<int>(data.GetLength(0), data.GetLength(1));
            Data = data;
        }

        public Matrix(T[,] data)
        {
            Dimension = new Vector2<int>(data.GetLength(0), data.GetLength(1));
            Data = new Scalar<T>[Dimension.x, Dimension.y];

            for (int i = 0; i < Dimension.x; i++)
                for (int j = 0; j < Dimension.y; j++)
                    Data[i, j] = new Scalar<T>(data[i, j]);
        }

        #endregion

        #region Functions

        public Vector<T> Transform(Vector<T> v)
        {
            return this * v;
        }

        public Matrix<T> Transform(Matrix<T> m)
        {
            return this * m;
        }

        public Matrix<T> Submatrix(Vector2<int> start, Vector2<int> count)
        {
            if (start.x < 0 || start.y < 0 ||
                start.x >= Dimension.x || start.y >= Dimension.y ||
                count.x < 0 || count.y < 0 ||
                start.x + count.x > Dimension.x || start.y + count.y > Dimension.y)
                throw new Exception("make a message here");

            Scalar<T>[,] data = new Scalar<T>[count.x, count.y];

            for (int i = start.x; i < count.x; i++)
                for (int j = start.y; j < count.y; j++)
                    data[i - start.x, j - start.y] = Data[i, j];

            return new Matrix<T>(data);
        }

        public Matrix<T> Transpose()
        {
            Scalar<T>[,] data = new Scalar<T>[Dimension.y, Dimension.x];

            for (int i = 0; i < Dimension.x; i++)
                for (int j = 0; j < Dimension.y; j++)
                    data[j, i] = Data[i, j];

            return new Matrix<T>(data);
        }

        public TResult Aggregate<TResult>(TResult seed, Func<TResult, Scalar<T>, TResult> func)
        {
            for (int i = 0; i < Dimension.x; i++)
                for (int j = 0; j < Dimension.y; j++)
                    seed = func(seed, Data[i, j]);

            return seed;
        }

        public Matrix<TResult> Select<TResult>(Func<Scalar<T>, Scalar<TResult>> func)
            where TResult : struct
        {
            Scalar<TResult>[,] data = new Scalar<TResult>[Dimension.y, Dimension.x];

            for (int i = 0; i < Dimension.x; i++)
                for (int j = 0; j < Dimension.y; j++)
                    data[i, j] = func(Data[i, j]);

            return new Matrix<TResult>(data);
        }

        #endregion

        public static Matrix<T> operator *(Matrix<T> left, Matrix<T> right)
        {
            if (left.Dimension.y != right.Dimension.x) throw new ArgumentException("Incompatible dimensions.");

            Scalar<T>[,] data = new Scalar<T>[left.Dimension.x, right.Dimension.y];

            for (int i = 0; i < left.Dimension.x; i++)
                for (int j = 0; j < right.Dimension.y; j++)
                    for (int k = 0; k < left.Dimension.y; k++)
                        data[i, j] = left[i, k] * right[k, j];

            return new Matrix<T>(data);
        }

        public static Vector<T> operator *(Matrix<T> left, Vector<T> right)
        {
            if (left.Dimension.y != right.Dimension) throw new ArgumentException("Incompatible dimensions.");

            Scalar<T>[] data = new Scalar<T>[left.Dimension.x];
            int i = 0, j = 0;
            for (i = 0, data[i] = Scalar<T>.Zero; i < left.Dimension.x; i++)
                for (j = 0; j < right.Dimension; j++)
                    data[i] += left[i, j] * right[j];

            return new Vector<T>(data);
        }

        public static Matrix<T> operator +(Matrix<T> left, Matrix<T> right)
        {
            if (left.Dimension != right.Dimension) throw new ArgumentException("Incompatible dimensions.");

            Scalar<T>[,] data = new Scalar<T>[left.Dimension.x, left.Dimension.y];

            for (int i = 0; i < left.Dimension.x; i++)
                for (int j = 0; j < left.Dimension.y; j++)
                    data[i, j] = left[i, j] + right[i, j];

            return new Matrix<T>(data);
        }

        public static Matrix<T> operator -(Matrix<T> left, Matrix<T> right)
        {
            if (left.Dimension != right.Dimension) throw new ArgumentException("Incompatible dimensions.");

            Scalar<T>[,] data = new Scalar<T>[left.Dimension.x, left.Dimension.y];

            for (int i = 0; i < left.Dimension.x; i++)
                for (int j = 0; j < left.Dimension.y; j++)
                    data[i, j] = left[i, j] - right[i, j];

            return new Matrix<T>(data);
        }

        public static Matrix<T> operator *(Scalar<T> left, Matrix<T> right)
        {
            Scalar<T>[,] data = new Scalar<T>[right.Dimension.x, right.Dimension.y];

            for (int i = 0; i < right.Dimension.x; i++)
                for (int j = 0; j < right.Dimension.y; j++)
                    data[i, j] = left * right[i, j];

            return new Matrix<T>(data);
        }

        public static Matrix<T> operator *(Matrix<T> left, Scalar<T> right)
        {
            return right * left;
        }

        public static Matrix<T> operator /(Scalar<T> left, Matrix<T> right)
        {
            Scalar<T>[,] data = new Scalar<T>[right.Dimension.x, right.Dimension.y];

            for (int i = 0; i < right.Dimension.x; i++)
                for (int j = 0; j < right.Dimension.y; j++)
                    data[i, j] = left / right[i, j];

            return new Matrix<T>(data);
        }

        public static Matrix<T> operator /(Matrix<T> left, Scalar<T> right)
        {
            Scalar<T>[,] data = new Scalar<T>[left.Dimension.x, left.Dimension.y];

            for (int i = 0; i < left.Dimension.x; i++)
                for (int j = 0; j < left.Dimension.y; j++)
                    data[i, j] = left[i, j] / right;

            return new Matrix<T>(data);
        }

        public static Matrix<T> operator -(Matrix<T> m)
        {
            var data = new Scalar<T>[m.Dimension.x, m.Dimension.y];

            for (int i = 0; i < m.Dimension.x; i++)
                for (int j = 0; j < m.Dimension.y; j++)
                    data[i, j] = -m.Data[i, j];

            return new Matrix<T>(data);
        }

        public static Matrix<T> operator |(Matrix<T> left, Matrix<T> right)
        {
            if (left.Dimension.x != right.Dimension.x) throw new ArgumentException("Incompatible dimensions.");

            Scalar<T>[,] data = new Scalar<T>[left.Dimension.x, left.Dimension.y + right.Dimension.y];

            for (int i = 0; i < left.Dimension.x; i++)
            {
                for (int j = 0; j < left.Dimension.y; j++)
                    data[i, j] = left[i, j];
                for (int j = 0; j < right.Dimension.y; j++)
                    data[i, j + left.Dimension.y] = right[i, j];
            }

            return new Matrix<T>(data);
        }

        public object Clone()
        {
            return new Matrix<T>(Data);
        }

        public bool Equals(Matrix<T> other)
        {
            if (Dimension != other.Dimension)
                return false;

            for (int i = 0; i < Dimension.x; i++)
                for (int j = 0; j < Dimension.y; j++)
                    if (Data[i, j] != other.Data[i, j])
                        return false;

            return true;
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<Scalar<T>> IEnumerable<Scalar<T>>.GetEnumerator()
        {
            for (int i = 0; i < Dimension.x; i++)
                for (int j = 0; j < Dimension.y; j++)
                    yield return Data[i, j];
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = 0; i < Dimension.x; i++)
                for (int j = 0; j < Dimension.y; j++)
                    yield return Data[i, j].Value;
        }

        public override bool Equals(object obj)
        {
            if (obj is Matrix<T> m)
                return Equals(m);

            return false;
        }

        public override string ToString()
        {
            var res = new StringBuilder($"Matrix{ Dimension.x }x{ Dimension.y } {{");

            res.AppendLine();

            for (int i = 0; i < Dimension.x; i++)
            {
                res.Append("\t{ ");
                for (int j = 0; j < Dimension.y; j++)
                {
                    res.Append(Data[i, j].ToString());
                    if (j != Dimension.y - 1)
                        res.Append(", ");
                }
                res.AppendLine(" }");
            }

            res.Append("}");

            return res.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
