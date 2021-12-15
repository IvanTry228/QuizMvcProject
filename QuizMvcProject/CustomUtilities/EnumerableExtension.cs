using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetExtra.CustomUtilities
{
    public static class EnumerableExtension
    {
        private const int oneCount = 1;

        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return source.Count() == 0;
        }

        public static T GetRandomItem<T>(this IList<T> source)
        {
            if (source.IsEmpty())
                return default;

            int indexRandomed = GetRandomInt(0, source.Count());
            T selectItem = source[indexRandomed]; 

            return selectItem;
        }

        public static T GetRandomItem<T>(this IEnumerable<T> source)
        {
            if (source.IsEmpty())
                return default;

            int toSkip = GetRandomInt(0, source.Count());
            T selectItem = source.Skip(toSkip).Take(oneCount).First();

            return selectItem;
        }

        private static int GetRandomInt(int _min, int _max) //inclusive / exclusive //for EnumerableExtension
        {
            Random rand = new Random();
            return rand.Next(_min, _max);
        }

        //stack over flow solution:
        public static T PickRandom<T>(this IEnumerable<T> source)
        {
            return source.PickRandom(oneCount).Single();
        }

        public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count)
        {
            return source.Shuffle().Take(count);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(x => Guid.NewGuid());
        }
    }
}
