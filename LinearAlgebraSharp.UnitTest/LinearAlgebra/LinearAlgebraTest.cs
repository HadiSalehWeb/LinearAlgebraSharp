using LinearAlgebraSharp.Scalars;
using LinearAlgebraSharp.Vectors;
using LinearAlgebraSharp.Matrices;
using LinearAlgebraSharp.Tensors;
using Xunit;

namespace LinearAlgebraSharp.UnitTest.LinearAlgebra
{
    public class LinearAlgebraTest
    {
        [Fact]
        public void TestOrder()
        {
            Assert.Equal(0, Scalar<byte>.Order.Value);
            Assert.Equal(0, Scalar<sbyte>.Order.Value);
            Assert.Equal(0, Scalar<ushort>.Order.Value);
            Assert.Equal(0, Scalar<short>.Order.Value);
            Assert.Equal(0, Scalar<uint>.Order.Value);
            Assert.Equal(0, Scalar<int>.Order.Value);
            Assert.Equal(0, Scalar<ulong>.Order.Value);
            Assert.Equal(0, Scalar<long>.Order.Value);
            Assert.Equal(0, Scalar<float>.Order.Value);
            Assert.Equal(0, Scalar<double>.Order.Value);
            Assert.Equal(0, Scalar<decimal>.Order.Value);

            Assert.Equal(1, Vector<byte>.Order.Value);
            Assert.Equal(1, Vector<sbyte>.Order.Value);
            Assert.Equal(1, Vector<ushort>.Order.Value);
            Assert.Equal(1, Vector<short>.Order.Value);
            Assert.Equal(1, Vector<uint>.Order.Value);
            Assert.Equal(1, Vector<int>.Order.Value);
            Assert.Equal(1, Vector<ulong>.Order.Value);
            Assert.Equal(1, Vector<long>.Order.Value);
            Assert.Equal(1, Vector<float>.Order.Value);
            Assert.Equal(1, Vector<double>.Order.Value);
            Assert.Equal(1, Vector<decimal>.Order.Value);

            Assert.Equal(1, Vector0<byte>.Order.Value);
            Assert.Equal(1, Vector1<byte>.Order.Value);
            Assert.Equal(1, Vector2<byte>.Order.Value);
            Assert.Equal(1, Vector3<byte>.Order.Value);
            Assert.Equal(1, Vector4<byte>.Order.Value);
            Assert.Equal(1, Vector5<byte>.Order.Value);

            Assert.Equal(1, Vector0<decimal>.Order.Value);
            Assert.Equal(1, Vector1<decimal>.Order.Value);
            Assert.Equal(1, Vector2<decimal>.Order.Value);
            Assert.Equal(1, Vector3<decimal>.Order.Value);
            Assert.Equal(1, Vector4<decimal>.Order.Value);
            Assert.Equal(1, Vector5<decimal>.Order.Value);

            Assert.Equal(2, Matrix<byte>.Order.Value);
            Assert.Equal(2, Matrix<sbyte>.Order.Value);
            Assert.Equal(2, Matrix<ushort>.Order.Value);
            Assert.Equal(2, Matrix<short>.Order.Value);
            Assert.Equal(2, Matrix<uint>.Order.Value);
            Assert.Equal(2, Matrix<int>.Order.Value);
            Assert.Equal(2, Matrix<ulong>.Order.Value);
            Assert.Equal(2, Matrix<long>.Order.Value);
            Assert.Equal(2, Matrix<float>.Order.Value);
            Assert.Equal(2, Matrix<double>.Order.Value);
            Assert.Equal(2, Matrix<decimal>.Order.Value);

            Assert.Equal(2, Matrix1x1<byte>.Order.Value);
            Assert.Equal(2, Matrix1x2<byte>.Order.Value);
            Assert.Equal(2, Matrix1x3<byte>.Order.Value);
            Assert.Equal(2, Matrix1x4<byte>.Order.Value);
            Assert.Equal(2, Matrix2x1<byte>.Order.Value);
            Assert.Equal(2, Matrix2x2<byte>.Order.Value);
            Assert.Equal(2, Matrix2x3<byte>.Order.Value);
            Assert.Equal(2, Matrix2x4<byte>.Order.Value);
            Assert.Equal(2, Matrix3x1<byte>.Order.Value);
            Assert.Equal(2, Matrix3x2<byte>.Order.Value);
            Assert.Equal(2, Matrix3x3<byte>.Order.Value);
            Assert.Equal(2, Matrix3x4<byte>.Order.Value);
            Assert.Equal(2, Matrix4x1<byte>.Order.Value);
            Assert.Equal(2, Matrix4x2<byte>.Order.Value);
            Assert.Equal(2, Matrix4x3<byte>.Order.Value);
            Assert.Equal(2, Matrix4x4<byte>.Order.Value);

            Assert.Equal(2, Matrix1x1<decimal>.Order.Value);
            Assert.Equal(2, Matrix1x2<decimal>.Order.Value);
            Assert.Equal(2, Matrix1x3<decimal>.Order.Value);
            Assert.Equal(2, Matrix1x4<decimal>.Order.Value);
            Assert.Equal(2, Matrix2x1<decimal>.Order.Value);
            Assert.Equal(2, Matrix2x2<decimal>.Order.Value);
            Assert.Equal(2, Matrix2x3<decimal>.Order.Value);
            Assert.Equal(2, Matrix2x4<decimal>.Order.Value);
            Assert.Equal(2, Matrix3x1<decimal>.Order.Value);
            Assert.Equal(2, Matrix3x2<decimal>.Order.Value);
            Assert.Equal(2, Matrix3x3<decimal>.Order.Value);
            Assert.Equal(2, Matrix3x4<decimal>.Order.Value);
            Assert.Equal(2, Matrix4x1<decimal>.Order.Value);
            Assert.Equal(2, Matrix4x2<decimal>.Order.Value);
            Assert.Equal(2, Matrix4x3<decimal>.Order.Value);
            Assert.Equal(2, Matrix4x4<decimal>.Order.Value);

            Assert.Equal(0, new Tensor<Vector0<int>, float>(new Vector0<int>()).Order.Value);
            Assert.Equal(1, new Tensor<Vector1<int>, float>(new Vector1<int>(1)).Order.Value);
            Assert.Equal(2, new Tensor<Vector2<int>, float>(new Vector2<int>(1, 1)).Order.Value);
            Assert.Equal(3, new Tensor<Vector3<int>, float>(new Vector3<int>(1, 1, 1)).Order.Value);
            Assert.Equal(4, new Tensor<Vector4<int>, float>(new Vector4<int>(1, 1, 1, 1)).Order.Value);
            Assert.Equal(5, new Tensor<Vector5<int>, float>(new Vector5<int>(1, 1, 1, 1, 1)).Order.Value);

            Assert.Equal(1, new Tensor<Vector<int>, float>(new Vector<int>(1)).Order.Value);
            Assert.Equal(2, new Tensor<Vector<int>, float>(new Vector<int>(1, 1)).Order.Value);
            Assert.Equal(3, new Tensor<Vector<int>, float>(new Vector<int>(1, 1, 1)).Order.Value);
            Assert.Equal(4, new Tensor<Vector<int>, float>(new Vector<int>(1, 1, 1, 1)).Order.Value);
            Assert.Equal(5, new Tensor<Vector<int>, float>(new Vector<int>(1, 1, 1, 1, 1)).Order.Value);
            Assert.Equal(6, new Tensor<Vector<int>, float>(new Vector<int>(1, 1, 1, 1, 1, 1)).Order.Value);
        }
    }
}
