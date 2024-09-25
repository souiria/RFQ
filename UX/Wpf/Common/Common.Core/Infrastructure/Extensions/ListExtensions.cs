using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common.Core.Infrastructure.Extensions
{
    public static class ListExtensions
    {
        public static List<T> CloneList<T>(this List<T> oldList)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, oldList);
            stream.Position = 0;
            return (List<T>)formatter.Deserialize(stream);
        }

        public static Tuple<List<TSource>, List<TSource>> SplitWhere<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            var splitSource = new Tuple<List<TSource>, List<TSource>>(new List<TSource>(), new List<TSource>());

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    splitSource.Item1.Add(item);
                }
                else
                {
                    splitSource.Item2.Add(item);
                }
            }

            return splitSource;
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// Returns the only element of a sequence, or a default value if the sequence is empty or contains more than one element.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TSource SingleOrDefaultSafe<TSource>(this IEnumerable<TSource> source)
        {
            switch (source)
            {
                case null:
                    throw new ArgumentNullException(nameof(source));

                case IList<TSource> sourceList:
                    // ReSharper disable once SwitchStatementMissingSomeCases
                    switch (sourceList.Count)
                    {
                        case 1:
                            return sourceList[0];
                    }

                    break;

                default:
                {
                    using (var enumerator = source.GetEnumerator())
                    {
                        if (!enumerator.MoveNext())
                            return default;

                        var current = enumerator.Current;

                        if (!enumerator.MoveNext())
                            return current;
                    }

                    break;
                }
            }

            return default;
        }

        /// <summary>
        /// Disposes a collection of any objects that implement <see cref="IDisposable"/>.
        /// </summary>
        /// <param name="collection">The source collection.</param>
        public static void DisposeAll(this IEnumerable collection)
        {
            foreach (var obj in collection.OfType<IDisposable>())
            {
                obj.Dispose();
            }
        }
    }
}
