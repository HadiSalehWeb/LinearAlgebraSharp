# LinearAlgebraSharp

A linear algebra library for C#.
### Scalar\<T\>
- Before:
```csharp
static double Add(double a, double b)
{
	return a + b;
}
static int Add(int a, int b)
{
	return a + b;
}
// other numerical types
public static void Main()
{
	Console.WriteLine(Add(1, 2));
	Console.WriteLine(Add(1.0, 2.0));
}
```
- After:
```csharp
static Scalar<T> Add<T>(Scalar<T> a, Scalar<T> b)
{
	return a + b;
}
public static void Main()
{
	Console.WriteLine(Add(1, 2));
	Console.WriteLine(Add(1.0, 2.0));
}
```
- The Scalar\<T\> can represent every numerical type in C# (int, double, byte etc.)
- Equipped with implicit operators, a Scalar\<T\> can be substitute any numerical type with minimal or no changes to the code
- Optimized to take up as little memory as possible while still representing many types
- Generated from a T4 template, can be extended to represent any arbitrary struct that implements a certain set of operators
### Vectors, Matrices and Tensors
- Built on Scalars, can represent any numerical type in their components
- Support many common algebraic operations (vectors products, matrix multiplication etc.)
- Vectors and Metrices come in optimized set-sized variants (e.g. Vector3, Matrix4x4) as well as flexible variants (Vector, Matrix). Hard-coded variants can be configures by editing a T4 template
- Tensors are implemented in the computer science/machine learning definition of multi-dimensional arrays, not the linear algebraic definition
### Abstraction
- Every type implements the ITensor\<T, TDimension\> interface allowing for very general functions that can process Scalar, Vectors or Matrices of any numerical type with one implementation

For more code examples see unit tests.
