using System;
using System.Collections;
using System.Collections.Generic;

// namespace ConsoleApp
// {
//     public class OnlyEvenEnumerables : IEnumerable<int>
//     {
//         private readonly IEnumerable<int> _objects;

//         public OnlyEvenEnumerables(IEnumerable<int> objects)
//         {
//             _objects = objects;
//         }

//         public class OnlyEvenEnumerator : IEnumerator<int>
//         {
//             private readonly IEnumerator<int> _enumerator;

//             public OnlyEvenEnumerator(IEnumerator<int> enumerator)
//             {
//                 _enumerator = enumerator;
//             }

//             public int Current {get; private set;}

//             object IEnumerator.Current => Current;

//             public void Dispose()
//             {
//                 _enumerator.Dispose();
//             }

//             public bool MoveNext()
//             {
//                 while(_enumerator.MoveNext())
//                 {
//                     if(_enumerator.Current % 2 == 0)
//                     {
//                         Current = _enumerator.Current;
//                         return true;
//                     }
//                 }
//                 return false;
//             }

//             public void Reset()
//             {
//                 _enumerator.Reset();
//             }
//         }

//         public IEnumerator<int> GetEnumerator()
//         {
//             return _objects.GetEnumerator();
//         }

//         IEnumerator IEnumerable.GetEnumerator()
//         {
//             return GetEnumerator();
//         }
//     }
//     class Program
//      {
//         static void Main(string[] args)
//         {
//             foreach (int item in new OnlyEvenEnumerables(new[] {1, 2, 3, 4, 5, 6}))
//             {
//                 Console.WriteLine(item);
//             }
//         }
//     }
// }


//MORE BETTER SOLUTION

namespace ConsoleApp
{
    public class BetterOnlyEvenEnumerables : IEnumerable<int>
    {
        private readonly IEnumerable<int> _collection;

        public BetterOnlyEvenEnumerables(IEnumerable<int> collection)
        {
            _collection = collection;
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (int item in _collection)
            {
                if( item % 2 == 0 )
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new BetterOnlyEvenEnumerables(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10});

            foreach (int item in numbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}