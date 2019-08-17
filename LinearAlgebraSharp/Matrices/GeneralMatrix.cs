using LinearAlgebraSharp.Scalars;
using LinearAlgebraSharp.Vectors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinearAlgebraSharp.Matrices
{
    [Serializable]
    public struct Matrix<T> :
        IEnumerable,
        IEnumerable<Scalar<T>>,
        IEnumerable<T>,
        IMatrix<T, Matrix<T>, Vector<T>, Vector<T>>
        where T : struct
    {
        #region Fields and Properties

        public static Scalar<int> Order => 2;
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

        public Scalar<T> Trace
        {
            get
            {
                if (Dimension.x != Dimension.y) throw new Exception("The trace is only defined on square matrices.");

                Scalar<T> sum = Scalar<T>.Zero;

                for (int i = 0; i < Dimension.x; i++)
                    sum += Data[i, i];

                return sum;
            }
        }

        #endregion

        #region Static

        /// <summary>
        /// Returns an n * m matrix filled with 'filling'.
        /// </summary>
        public static Matrix<T> Fill(Vector2<int> dimensions, Scalar<T> filling)
        {
            Scalar<T>[,] data = new Scalar<T>[dimensions.x, dimensions.y];

            for (int i = 0; i < dimensions.x; i++)
                for (int j = 0; j < dimensions.y; j++)
                    data[i, j] = filling;

            return new Matrix<T>(data);
        }

        /// <summary>
        /// Returns an n * m matrix filled with zeros.
        /// </summary>
        public static Matrix<T> Zeros(Vector2<int> dimensions)
        {
            return Fill(dimensions, Scalar<T>.Zero);
        }

        /// <summary>
        /// Returns an n * n matrix filled with zeros.
        /// </summary>
        public static Matrix<T> Zeros(int dimension)
        {
            return Zeros(new Vector2<int>(dimension));
        }

        /// <summary>
        /// Returns an n * m matrix filled with ones.
        /// </summary>
        public static Matrix<T> Ones(Vector2<int> dimensions)
        {
            return Fill(dimensions, Scalar<T>.One);
        }

        /// <summary>
        /// Returns an n * n matrix filled with ones.
        /// </summary>
        public static Matrix<T> Ones(int dimension)
        {
            return Ones(new Vector2<int>(dimension));
        }

        /// <summary>
        /// Returns an n * n matrix with ones on the diagonal and zeros elsewhere.
        /// </summary>
        public static Matrix<T> Eye(Vector2<int> dimensions)
        {
            Scalar<T>[,] data = new Scalar<T>[dimensions.x, dimensions.y];
            for (int i = 0; i < dimensions.x; i++)
                for (int j = 0; j < dimensions.y; j++)
                    if (i == j)
                        data[i, j] = Scalar<T>.One;
                    else
                        data[i, j] = Scalar<T>.Zero;

            return new Matrix<T>(data);
        }

        /// <summary>
        /// Returns the n * n identity matrix.
        /// </summary>
        public static Matrix<T> Identity(int dimension)
        {
            return Eye(new Vector2<int>(dimension));
        }

        /// <summary>
        /// Returns an n * n matrix with the values of 'vec' on the diagonal and zeros elsewhere.
        /// </summary>
        public static Matrix<T> Diagonal(Vector<T> vec)
        {
            Scalar<T>[,] data = new Scalar<T>[vec.Length, vec.Length];
            for (int i = 0; i < vec.Length; i++)
                for (int j = 0; j < vec.Length; j++)
                    if (i == j)
                        data[i, j] = vec[i];
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

        public Matrix<T> ElementwiseProduct(Matrix<T> mat)
        {
            if (Dimension != mat.Dimension)
                throw new DimensionMismatchException<T, Vector2<int>, Matrix<T>>(nameof(mat), mat.Dimension, Dimension);

            Scalar<T>[,] data = new Scalar<T>[Dimension.x, Dimension.y];

            for (int i = 0; i < Dimension.x; i++)
                for (int j = 0; j < Dimension.y; j++)
                    data[i, j] = Data[i, j] * mat.Data[i, j];

            return new Matrix<T>(data);
        }

        public Matrix<T> ElementwiseQuotient(Matrix<T> mat)
        {
            if (Dimension != mat.Dimension)
                throw new DimensionMismatchException<T, Vector2<int>, Matrix<T>>(nameof(mat), mat.Dimension, Dimension);

            Scalar<T>[,] data = new Scalar<T>[Dimension.x, Dimension.y];

            for (int i = 0; i < Dimension.x; i++)
                for (int j = 0; j < Dimension.y; j++)
                    data[i, j] = Data[i, j] / mat.Data[i, j];

            return new Matrix<T>(data);
        }

        /// <summary>
        /// Returns a slice of the matrix starting at (start.x, start.y) with count.x rows and count.y columns.
        /// </summary>
        public Matrix<T> Submatrix(Vector2<int> start, Vector2<int> count)
        {
            if (start.x < 0 || start.y < 0 ||
                start.x >= Dimension.x || start.y >= Dimension.y ||
                count.x < 0 || count.y < 0)
                throw new ArgumentException("Arguments outside matrix bounds.");

            int n = Math.Min(count.x.Value, Dimension.x.Value), m = Math.Min(count.y.Value, Dimension.y.Value);
            Scalar<T>[,] data = new Scalar<T>[n, m];

            for (int i = start.x; i < n; i++)
                for (int j = start.y; j < m; j++)
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

        #region Operators

        #region Arithmetic

        public Matrix<T> Multiply(Matrix<T> mat)
        {
            if (Dimension.y != mat.Dimension.x)
                throw new DimensionMismatchException<T, Vector2<int>, Matrix<T>>(nameof(mat), mat.Dimension, Dimension);


            Scalar<T>[,] data = new Scalar<T>[Dimension.x, mat.Dimension.y];

            for (int i = 0; i < Dimension.x; i++)
                for (int j = 0; j < mat.Dimension.y; j++)
                    for (int k = 0; k < Dimension.y; k++)
                        data[i, j] = Data[i, k] * mat.Data[k, j];

            return new Matrix<T>(data);
        }

        public static Matrix<T> operator *(Matrix<T> left, Matrix<T> right)
        {
            return left.Multiply(right);
        }

        public Vector<T> MultiplyLeft(Vector<T> vec)
        {
            if (Dimension.y != vec.Dimension) throw new ArgumentException("Incompatible dimensions.");

            Scalar<T>[] data = new Scalar<T>[Dimension.x];
            int i = 0, j = 0;
            for (i = 0, data[i] = Scalar<T>.Zero; i < Dimension.x; i++)
                for (j = 0; j < vec.Dimension; j++)
                    data[i] += Data[i, j] * vec[j];

            return new Vector<T>(data);
        }

        public Vector<T> MultiplyRight(Vector<T> vec)
        {
            if (Dimension.x != vec.Dimension) throw new ArgumentException("Incompatible dimensions.");

            Scalar<T>[] data = new Scalar<T>[Dimension.y];
            int i = 0, j = 0;
            for (i = 0, data[i] = Scalar<T>.Zero; i < vec.Dimension; i++)
                for (j = 0; j < Dimension.y; j++)
                    data[i] += Data[i, j] * vec[i];

            return new Vector<T>(data);
        }

        public static Vector<T> operator *(Matrix<T> left, Vector<T> right)
        {
            return left.MultiplyLeft(right);
        }

        public static Vector<T> operator *(Vector<T> left, Matrix<T> right)
        {
            return right.MultiplyRight(left);
        }

        public Matrix<T> Add(Matrix<T> mat)
        {
            if (Dimension != mat.Dimension) throw new DimensionMismatchException<T, Vector2<int>, Matrix<T>>(nameof(mat), mat.Dimension, Dimension);

            Scalar<T>[,] data = new Scalar<T>[Dimension.x, Dimension.y];

            for (int i = 0; i < Dimension.x; i++)
                for (int j = 0; j < Dimension.y; j++)
                    data[i, j] = Data[i, j] + mat.Data[i, j];

            return new Matrix<T>(data);
        }

        public static Matrix<T> operator +(Matrix<T> left, Matrix<T> right)
        {
            return left.Add(right);
        }

        public Matrix<T> Substract(Matrix<T> mat)
        {
            if (Dimension != mat.Dimension) throw new DimensionMismatchException<T, Vector2<int>, Matrix<T>>(nameof(mat), mat.Dimension, Dimension);

            Scalar<T>[,] data = new Scalar<T>[Dimension.x, Dimension.y];

            for (int i = 0; i < Dimension.x; i++)
                for (int j = 0; j < Dimension.y; j++)
                    data[i, j] = Data[i, j] - mat.Data[i, j];

            return new Matrix<T>(data);
        }

        public static Matrix<T> operator -(Matrix<T> left, Matrix<T> right)
        {
            return left.Substract(right);
        }

        public Matrix<T> Multiply(Scalar<T> s)
        {
            Scalar<T>[,] data = new Scalar<T>[Dimension.x, Dimension.y];

            for (int i = 0; i < Dimension.x; i++)
                for (int j = 0; j < Dimension.y; j++)
                    data[i, j] = Data[i, j] * s;

            return new Matrix<T>(data);
        }

        public static Matrix<T> operator *(Scalar<T> left, Matrix<T> right)
        {
            return right.Multiply(left);
        }

        public static Matrix<T> operator *(Matrix<T> left, Scalar<T> right)
        {
            return left.Multiply(right);
        }

        public Matrix<T> DivideLeft(Scalar<T> s)
        {
            Scalar<T>[,] data = new Scalar<T>[Dimension.x, Dimension.y];

            for (int i = 0; i < Dimension.x; i++)
                for (int j = 0; j < Dimension.y; j++)
                    data[i, j] = Data[i, j] / s;

            return new Matrix<T>(data);
        }

        public static Matrix<T> operator /(Matrix<T> left, Scalar<T> right)
        {
            return left.DivideLeft(right);
        }

        public Matrix<T> DivideRight(Scalar<T> s)
        {
            Scalar<T>[,] data = new Scalar<T>[Dimension.x, Dimension.y];

            for (int i = 0; i < Dimension.x; i++)
                for (int j = 0; j < Dimension.y; j++)
                    data[i, j] = s / Data[i, j];

            return new Matrix<T>(data);
        }

        public static Matrix<T> operator /(Scalar<T> left, Matrix<T> right)
        {
            return right.DivideRight(left);
        }

        public Matrix<T> Reciprocal()
        {
            Scalar<T>[,] data = new Scalar<T>[Dimension.x, Dimension.y];

            for (int i = 0; i < Dimension.x; i++)
                for (int j = 0; j < Dimension.y; j++)
                    data[i, j] = Scalar<T>.One / Data[i, j];

            return new Matrix<T>(data);
        }

        public Matrix<T> Negate()
        {
            Scalar<T>[,] data = new Scalar<T>[Dimension.x, Dimension.y];

            for (int i = 0; i < Dimension.x; i++)
                for (int j = 0; j < Dimension.y; j++)
                    data[i, j] = -Data[i, j];

            return new Matrix<T>(data);
        }

        public static Matrix<T> operator -(Matrix<T> m)
        {
            return m.Negate();
        }

        #endregion

        #region Structure

        /// <summary>
        /// Augments two matrices left to right.
        /// </summary>
        public Matrix<T> Augment(Matrix<T> right)
        {
            if (Dimension.x != right.Dimension.x) throw new ArgumentException("Incompatible dimensions.");

            Scalar<T>[,] data = new Scalar<T>[Dimension.x, Dimension.y + right.Dimension.y];

            for (int i = 0; i < Dimension.x; i++)
            {
                for (int j = 0; j < Dimension.y; j++)
                    data[i, j] = Data[i, j];
                for (int j = 0; j < right.Dimension.y; j++)
                    data[i, j + Dimension.y] = right[i, j];
            }

            return new Matrix<T>(data);
        }

        /// <summary>
        /// Augments two matrices left to right.
        /// </summary>
        public static Matrix<T> operator |(Matrix<T> left, Matrix<T> right)
        {
            return left.Augment(right);
        }

        /// <summary>
        /// Concatenates two matrices top to bottom.
        /// </summary>
        public Matrix<T> Concatenate(Matrix<T> right)
        {
            if (Dimension.y != right.Dimension.y) throw new ArgumentException("Incompatible dimensions.");

            Scalar<T>[,] data = new Scalar<T>[Dimension.x + right.Dimension.x, Dimension.y];

            for (int i = 0; i < Dimension.x; i++)
                for (int j = 0; j < Dimension.y; j++)
                    data[i, j] = Data[i, j];

            for (int i = 0; i < right.Dimension.x; i++)
                for (int j = 0; j < right.Dimension.y; j++)
                    data[i + Dimension.x, j] = right[i, j];

            return new Matrix<T>(data);
        }

        /// <summary>
        /// Concatenates two matrices top to bottom.
        /// </summary>
        public static Matrix<T> operator ^(Matrix<T> left, Matrix<T> right)
        {
            return left.Concatenate(right);
        }

        #endregion

        #region Identity

        public static bool operator ==(Matrix<T> left, Matrix<T> right)
        {
            if (left.Dimension != right.Dimension) throw new DimensionMismatchException<T, Vector2<int>, Matrix<T>>(nameof(right), right.Dimension, left.Dimension);

            for (int i = 0; i < left.Dimension.x; i++)
                for (int j = 0; j < left.Dimension.y; j++)
                    if (left[i, j] != right[i, j])
                        return false;

            return true;
        }

        public static bool operator !=(Matrix<T> left, Matrix<T> right)
        {
            if (left.Dimension != right.Dimension) throw new DimensionMismatchException<T, Vector2<int>, Matrix<T>>(nameof(right), right.Dimension, left.Dimension);

            for (int i = 0; i < left.Dimension.x; i++)
                for (int j = 0; j < left.Dimension.y; j++)
                    if (left[i, j] != right[i, j])
                        return true;

            return false;
        }

        #endregion

        #endregion

        //TODO: move this to its own class
        //#region Transformations

        //public static Matrix<T> Scaling(int dimension, T scalingFactor)
        //{
        //    Scalar<T>[,] scalars = new Scalar<T>[dimension, dimension];
        //    Scalar<T> scalingScalar = new Scalar<T>(scalingFactor);

        //    for (int i = 0; i < dimension; i++)
        //        for (int j = 0; j < dimension; j++)
        //            if (i == j) scalars[i, j] = scalingScalar;
        //            else scalars[i, j] = Scalar<T>.Zero;

        //    return new Matrix<T>(scalars);
        //}

        //public static Matrix<T> Stretching(int dimension, int stretchingAxis, T stretchingFactor)
        //{
        //    Scalar<T>[,] scalars = new Scalar<T>[dimension, dimension];
        //    Scalar<T> stretchingScalar = new Scalar<T>(stretchingFactor);

        //    for (int i = 0; i < dimension; i++)
        //        for (int j = 0; j < dimension; j++)
        //            if (i == j)
        //                if (i == stretchingAxis) scalars[i, j] = stretchingScalar;
        //                else scalars[i, j] = Scalar<T>.One;
        //            else scalars[i, j] = Scalar<T>.Zero;

        //    return new Matrix<T>(scalars);
        //}

        //public static Matrix<T> Squeezing(int dimension, int squeezingAxis, T squeezingFactor)
        //{
        //    Scalar<T>[,] scalars = new Scalar<T>[dimension, dimension];
        //    Scalar<T> squeezingScalar = new Scalar<T>(squeezingFactor);
        //    Scalar<T> squeezingScalarToPower = ScalarMath<T>.Pow(squeezingScalar, dimension - 1);
        //    Scalar<T> squeezingReciprocal = squeezingScalar.Reciprocal();

        //    for (int i = 0; i < dimension; i++)
        //        for (int j = 0; j < dimension; j++)
        //            if (i == j)
        //                if (i == squeezingAxis) scalars[i, j] = squeezingScalarToPower;
        //                else scalars[i, j] = squeezingReciprocal;
        //            else scalars[i, j] = Scalar<T>.Zero;

        //    return new Matrix<T>(scalars);
        //}

        //#endregion

        #region Interface Implementations

        public object Clone()
        {
            return new Matrix<T>((Scalar<T>[,])Data.Clone());
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
            int hash = 1;

            for (int i = 0; i < Dimension.x; i++)
                for (int j = 0; j < Dimension.y; j++)
                    hash = hash * 31 + Data[i, j].GetHashCode();

            return hash;
        }

        #endregion
    }
}
