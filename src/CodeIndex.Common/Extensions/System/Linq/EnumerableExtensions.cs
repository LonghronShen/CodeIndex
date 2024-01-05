using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Linq
{
    public static class EnumerableExtensions
    {
#if NETSTANDARD2_0 || NET461
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> self)
        {
            return new HashSet<T>(self);
        }
#endif
    }
}