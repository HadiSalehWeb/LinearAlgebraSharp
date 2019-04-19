using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinearAlgebra.Matrices;

namespace LinearAlgebra.UnitTest.Matrices
{
    [TestClass]
    public class GeneralMatrixTest
    {
        [TestMethod]
        public void TestTranspose()
        {
            Matrix<int> m1 = new Matrix<int>(new int[,] {
                { 1, 2, 3 },
                { 4, 5, 6 }
            }), m2 = new Matrix<int>(new int[,] {
                { 1, 2 },
                { 3, 4 },
                { 5, 6 }
            }), m3 = new Matrix<int>(new int[,] {
                { 1, 2 }
            }), m4 = new Matrix<int>(new int[,] {
                { 1, 2 },
                { 3, 4 }
            });

            Assert.AreEqual(new Matrix<int>(new int[,] {
                { 1, 4 },
                { 2, 5 },
                { 3, 6 }
            }), m1.Transpose());
            Assert.AreEqual(new Matrix<int>(new int[,] {
                { 1, 3, 5 },
                { 2, 4, 6 }
            }), m2.Transpose());
            Assert.AreEqual(new Matrix<int>(new int[,] {
                { 1 },
                { 2 }
            }), m3.Transpose());
            Assert.AreEqual(new Matrix<int>(new int[,] {
                { 1, 3 },
                { 2, 4 }
            }), m4.Transpose());
        }

        [TestMethod]
        public void TestDoubleTranspose()
        {
            Matrix<int> m1 = new Matrix<int>(new int[,] {
                { 1, 2, 3 },
                { 4, 5, 6 }
            }), m2 = new Matrix<int>(new int[,] {
                { 1, 2 },
                { 3, 4 },
                { 5, 6 }
            }), m3 = new Matrix<int>(new int[,] {
                { 1, 2 }
            }), m4 = new Matrix<int>(new int[,] {
                { 1, 2 },
                { 3, 4 }
            });

            Assert.AreEqual(m1, m1.Transpose().Transpose());
            Assert.AreEqual(m2, m2.Transpose().Transpose());
            Assert.AreEqual(m3, m3.Transpose().Transpose());
            Assert.AreEqual(m4, m4.Transpose().Transpose());
        }

        [TestMethod]
        public void TestMatrixAugmentation()
        {
            Matrix<int> m1 = new Matrix<int>(new int[,] {
                { 1, 2, 3 },
                { 4, 5, 6 }
            }), m2 = new Matrix<int>(new int[,] {
                { 1, 2 },
                { 3, 4 }
            }), m3 = new Matrix<int>(new int[,] {
                { 1 },
                { 2 }
            });

            Assert.AreEqual(m1 | m2, new Matrix<int>(new int[,] {
                { 1, 2, 3, 1, 2 },
                { 4, 5, 6, 3, 4 }
            }));
            Assert.AreEqual(m1 | m3, new Matrix<int>(new int[,] {
                { 1, 2, 3, 1 },
                { 4, 5, 6, 2 }
            }));
            Assert.AreEqual(m2 | m3, new Matrix<int>(new int[,] {
                { 1, 2, 1 },
                { 3, 4, 2 }
            }));
        }
    }
}
