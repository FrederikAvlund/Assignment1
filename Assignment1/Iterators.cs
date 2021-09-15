using System;
using System.Collections.Generic;

namespace Assignment1
{
    public static class Iterators
    {

        public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items)
        {
            foreach (var item in items)
            {
                foreach (var specific in item)
                {
                    yield return specific;
                }
            }
        }

        public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate)
        {
            foreach (var item in items)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
        //Method to initialize the Predicate<T>
        public static bool Even(int i)
        {
            return i % 2 == 0;
        }
    }
}
