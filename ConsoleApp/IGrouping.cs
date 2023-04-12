using System.Collections.Generic;

namespace ConsoleApp
{
    internal interface IGrouping<out TKey, out TElement> : IEnumerable<TElement>
    {
        TKey Key { get; }
    }
}