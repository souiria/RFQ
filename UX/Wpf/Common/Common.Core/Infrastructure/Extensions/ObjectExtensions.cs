using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common.Core.Infrastructure.Extensions
{
    public static class ObjectExtensions
    {
        #region IEnumerable

        /// <summary>
        /// Get if duplicate value exists on field or not
        /// </summary>
        /// <typeparam name="T">Type of Object</typeparam>
        /// <typeparam name="TKey">Type of Field</typeparam>
        /// <param name="source">Source Collection</param>
        /// <param name="keySelector">Delegate of Fields</param>
        /// <returns>True/False on condition</returns>
        public static bool HasDuplicateOnFields<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
        {
            return source.GroupBy(keySelector).Where(it => it.Count() > 1).Count() > 0;
        }

        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> list, int chunkSize)
        {
            if (chunkSize <= 0)
            {
                throw new ArgumentException("chunkSize must be greater than 0.");
            }

            while (list.Any())
            {
                yield return list.Take(chunkSize);
                list = list.Skip(chunkSize);
            }
        }

        #endregion
        /// <summary>
        /// Returns the hex value in the first index of the guid as a value between 0-15
        /// </summary>
        /// <param name="id">The Guid</param>
        /// <returns>The hex value in the first index of the guid as a value between 0-15</returns>
        public static long ToPartitionKey(this Guid id)
        {
            return int.Parse(id.ToString().First().ToString(), System.Globalization.NumberStyles.HexNumber);
        }

        /// <summary>
        /// Returns the hex value in the second index of the guid
        /// </summary>
        /// <param name="id">The Guid</param>
        /// <returns>The hex value in the second index of the guid</returns>
        public static string ToDictionaryKey(this Guid id)
        {
            return id.ToString()[1].ToString().ToLower();
        }

        /// <summary>
        /// Splits an array into several smaller arrays.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to split.</param>
        /// <param name="size">The size of the smaller arrays.</param>
        /// <returns>An array containing smaller arrays.</returns>
        public static IEnumerable<IEnumerable<T>> Split<T>(this T[] array, int size)
        {
            for (var i = 0; i < (float)array.Length / size; i++)
            {
                yield return array.Skip(i * size).Take(size);
            }
        }

        public static void AddOrUpdate<TKey, TValue>(this Dictionary<TKey, List<TValue>> d, TKey key, TValue value)
        {
            if (d.ContainsKey(key))
                d[key].Add(value);
            else
                d.Add(key, new List<TValue> { value });
        }
        public static string SetFilterValue(this object obj)
        {
            if (obj != null)
            {
                if (obj.GetType() == typeof(string))
                    return $"\"{ obj.ToString() }\"";
                else
                    return obj.ToString();
            }
            else
                return null;
        }
        public static string AppendTimeStamp(this string fileName)
        {
            return string.Concat(
                Path.GetFileNameWithoutExtension(fileName),
                DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                Path.GetExtension(fileName)
                );
        }
    }
}
