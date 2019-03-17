using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LinearAlgebra.Vectors;
using LinearAlgebra.Scalars;

namespace LinearAlgebra.UnitTest.Vectors
{
    [TestClass]
    public class VectorTest
    {
        [TestMethod]
        public void TestInitialization()
        {
            Vector1<double> v1 = new Vector1<double>(2.0);
            Vector2<double> v2 = new Vector2<double>(2.0, 4.0);
            Vector3<double> v3 = new Vector3<double>(2.0, 4.0, 6.0);
            Vector4<double> v4 = new Vector4<double>(2.0, 4.0, 6.0, 8.0);
            Vector5<double> v5 = new Vector5<double>(2.0, 4.0, 6.0, 8.0, 10.0);

            Assert.AreEqual(2.0, v1.x.Value);
            Assert.AreEqual(2.0, v2.x.Value);
            Assert.AreEqual(2.0, v3.x.Value);
            Assert.AreEqual(2.0, v4.x.Value);
            Assert.AreEqual(2.0, v5.v0.Value);
            Assert.AreEqual(4.0, v2.y.Value);
            Assert.AreEqual(4.0, v3.y.Value);
            Assert.AreEqual(4.0, v4.y.Value);
            Assert.AreEqual(4.0, v5.v1.Value);
            Assert.AreEqual(6.0, v3.z.Value);
            Assert.AreEqual(6.0, v4.z.Value);
            Assert.AreEqual(6.0, v5.v2.Value);
            Assert.AreEqual(8.0, v4.w.Value);
            Assert.AreEqual(8.0, v5.v3.Value);
            Assert.AreEqual(10.0, v5.v4.Value);
        }

        [TestMethod]
        public void TestImplicitInitialization()
        {
            Vector1<double> v1 = (2.0);
            Vector2<double> v2 = (2.0, 4.0);
            Vector3<double> v3 = (2.0, 4.0, 6.0);
            Vector4<double> v4 = (2.0, 4.0, 6.0, 8.0);
            Vector5<double> v5 = (2.0, 4.0, 6.0, 8.0, 10.0);

            Assert.AreEqual(2.0, v1.x.Value);
            Assert.AreEqual(2.0, v2.x.Value);
            Assert.AreEqual(2.0, v3.x.Value);
            Assert.AreEqual(2.0, v4.x.Value);
            Assert.AreEqual(2.0, v5.v0.Value);
            Assert.AreEqual(4.0, v2.y.Value);
            Assert.AreEqual(4.0, v3.y.Value);
            Assert.AreEqual(4.0, v4.y.Value);
            Assert.AreEqual(4.0, v5.v1.Value);
            Assert.AreEqual(6.0, v3.z.Value);
            Assert.AreEqual(6.0, v4.z.Value);
            Assert.AreEqual(6.0, v5.v2.Value);
            Assert.AreEqual(8.0, v4.w.Value);
            Assert.AreEqual(8.0, v5.v3.Value);
            Assert.AreEqual(10.0, v5.v4.Value);
        }

        [TestMethod]
        public void TestStatics()
        {
            Assert.AreEqual(new Vector1<double>(0.0), Vector1<double>.zero);
            Assert.AreEqual(new Vector1<double>(1.0), Vector1<double>.one);
            Assert.AreEqual(new Vector1<double>(1.0), Vector1<double>.right);
            Assert.AreEqual(new Vector1<double>(-1.0), Vector1<double>.left);

            Assert.AreEqual(new Vector2<double>(0.0, 0.0), Vector2<double>.zero);
            Assert.AreEqual(new Vector2<double>(1.0, 1.0), Vector2<double>.one);
            Assert.AreEqual(new Vector2<double>(1.0, 0.0), Vector2<double>.right);
            Assert.AreEqual(new Vector2<double>(-1.0, 0.0), Vector2<double>.left);
            Assert.AreEqual(new Vector2<double>(0.0, 1.0), Vector2<double>.up);
            Assert.AreEqual(new Vector2<double>(0.0, -1.0), Vector2<double>.down);

            Assert.AreEqual(new Vector3<double>(0.0, 0.0, 0.0), Vector3<double>.zero);
            Assert.AreEqual(new Vector3<double>(1.0, 1.0, 1.0), Vector3<double>.one);
            Assert.AreEqual(new Vector3<double>(1.0, 0.0, 0.0), Vector3<double>.right);
            Assert.AreEqual(new Vector3<double>(-1.0, 0.0, 0.0), Vector3<double>.left);
            Assert.AreEqual(new Vector3<double>(0.0, 1.0, 0.0), Vector3<double>.up);
            Assert.AreEqual(new Vector3<double>(0.0, -1.0, 0.0), Vector3<double>.down);
            Assert.AreEqual(new Vector3<double>(0.0, 0.0, 1.0), Vector3<double>.forward);
            Assert.AreEqual(new Vector3<double>(0.0, 0.0, -1.0), Vector3<double>.backward);

            Assert.AreEqual(new Vector4<double>(0.0, 0.0, 0.0, 0.0), Vector4<double>.zero);
            Assert.AreEqual(new Vector4<double>(1.0, 1.0, 1.0, 1.0), Vector4<double>.one);
            Assert.AreEqual(new Vector4<double>(1.0, 0.0, 0.0, 0.0), Vector4<double>.right);
            Assert.AreEqual(new Vector4<double>(-1.0, 0.0, 0.0, 0.0), Vector4<double>.left);
            Assert.AreEqual(new Vector4<double>(0.0, 1.0, 0.0, 0.0), Vector4<double>.up);
            Assert.AreEqual(new Vector4<double>(0.0, -1.0, 0.0, 0.0), Vector4<double>.down);
            Assert.AreEqual(new Vector4<double>(0.0, 0.0, 1.0, 0.0), Vector4<double>.forward);
            Assert.AreEqual(new Vector4<double>(0.0, 0.0, -1.0, 0.0), Vector4<double>.backward);
            Assert.AreEqual(new Vector4<double>(0.0, 0.0, 0.0, 1.0), Vector4<double>.ana);
            Assert.AreEqual(new Vector4<double>(0.0, 0.0, 0.0, -1.0), Vector4<double>.kata);

            Assert.AreEqual(new Vector5<double>(0.0, 0.0, 0.0, 0.0, 0.0), Vector5<double>.zero);
            Assert.AreEqual(new Vector5<double>(1.0, 1.0, 1.0, 1.0, 1.0), Vector5<double>.one);
        }

        [TestMethod]
        public void TestOperations()
        {
            Vector2<double> v1 = (2.0, 3.14), v2 = (1.0, 2.5);
            Scalar<double> s = 3;

            Assert.AreEqual(new Vector2<double>(2.0 + 1.0, 3.14 + 2.5), v1 + v2);
            Assert.AreEqual(new Vector2<double>(2.0 - 1.0, 3.14 - 2.5), v1 - v2);
            Assert.AreEqual(new Vector2<double>(2.0 * 3.0, 3.14 * 3.0), s * v1);
            Assert.AreEqual(new Vector2<double>(2.0 / 3.0, 3.14 / 3.0), v1 / s);
            Assert.AreEqual(false, v1 == v2);
            Assert.AreEqual(true, v1 != v2);
        }

        [TestMethod]
        public void TestScale()
        {
            Vector2<int> v1 = (1, 2), v2 = (3, 4);

            Assert.AreEqual(new Vector2<int>(1 * 3, 2 * 4), v1.Scale(v2));
        }

        [TestMethod]
        public void TestDot()
        {
            Vector2<int> v1 = (1, 2), v2 = (3, 4);

            Assert.AreEqual(1 * 3 + 2 * 4, v1.Dot(v2).Value);
        }

        [TestMethod]
        public void TestMagnitude()
        {
            Vector2<double> v1 = (3.0, 4.0);

            Assert.AreEqual(3.0 * 3.0 + 4.0 * 4.0, v1.SqrMagnitude.Value);
            Assert.AreEqual(Math.Sqrt(3.0 * 3.0 + 4.0 * 4.0), v1.Magnitude.Value);
            Assert.AreEqual(v1 / Math.Sqrt(3.0 * 3.0 + 4.0 * 4.0), v1.Normalized);
        }
    }
}
