using System;
using System.Collections.Generic;
using System.Text;

namespace LinearAlgebra.Base
{
    public interface ITensor<in T, TThis> :
        ICloneable,
        IEquatable<TThis>,
        IComparable,
        IComparable<T>,
        IComparable<TThis>
        where T : struct, IComparable
        where TThis : ITensor<T, TThis>
    {
    }
}
