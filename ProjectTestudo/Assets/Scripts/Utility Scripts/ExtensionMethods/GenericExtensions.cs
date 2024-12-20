using System;
using UnityEngine;

public static class GenericExtensions
{

    public static bool IsSubclassOf<T, TBase>(this T obj) where T : TBase
    {
        return obj is TBase;
    }

    public static string GetTypeName<T>(this T obj)
    {
        return typeof(T).Name;
    }

    public static bool IsInterface<T>(this T obj)
    {
        return typeof(T).IsInterface;
    }

    public static bool IsOfType<T>(this object obj)
    {
        return obj is T;
    }

    public static bool IsNull<T>(this T obj)
    {
        return obj == null;
    }

    public static bool IsNotNull<T>(this T obj)
    {
        return obj != null;
    }

    public static bool IsNullOrEmpty<T>(this T obj)
    {
        return obj == null || obj.Equals("");
    }

    public static bool IsEmpty<T>(this IEnumerable<T> collection)
    {
        return collection == null || !collection.Any();
    }

    public static void RemoveAll<T>(this List<T> collection, Func<T, bool> predicate)
    {
        collection.RemoveAll(new Predicate<T>(predicate));
    }

    public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            collection.Add(item);
        }
    }

    public static T GetRandom<T>(this IList<T> collection)
    {
        Random random = new Random();
        return collection[random.Next(collection.Count)];
    }

    public static bool AnyMatch<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        return collection.Any(predicate);
    }


    public static T Clone<T>(this T obj)
    {
        var serializedObj = JsonUtility.ToJson(obj);
        return JsonUtility.FromJson<T>(serializedObj);
    }

    public static void SafeInvoke<T>(this T obj, Action<T> action)
    {
        if (obj != null)
        {
            action(obj);
        }
    }

    public static bool IsEqualTo<T>(this T obj, T otherObj)
    {
        return obj.Equals(otherObj);
    }

    public static void SortBy<T>(this List<T> list, Func<T, T, int> comparison)
    {
        list.Sort(new Comparison<T>(comparison));
    }

    public static IEnumerable<T> OrderByKey<T, TKey>(this IEnumerable<T> collection, Func<T, TKey> keySelector)
    {
        return collection.OrderBy(keySelector);
    }

    public static IEnumerable<T> OrderByDescendingKey<T, TKey>(this IEnumerable<T> collection, Func<T, TKey> keySelector)
    {
        return collection.OrderByDescending(keySelector);
    }

    public static bool IsSortedBy<T, TKey>(this IEnumerable<T> collection, Func<T, TKey> keySelector)
    {
        var previousValue = default(TKey);
        foreach (var item in collection)
        {
            var currentValue = keySelector(item);
            if (Comparer<TKey>.Default.Compare(previousValue, currentValue) > 0)
            {
                return false;
            }
            previousValue = currentValue;
        }
        return true;
    }

    public static T MinBy<T, TKey>(this IEnumerable<T> collection, Func<T, TKey> keySelector) where TKey : IComparable
    {
        return collection.OrderBy(keySelector).FirstOrDefault();
    }

    public static T MaxBy<T, TKey>(this IEnumerable<T> collection, Func<T, TKey> keySelector) where TKey : IComparable
    {
        return collection.OrderByDescending(keySelector).FirstOrDefault();
    }

    public static TResult SumBy<T, TResult>(this IEnumerable<T> collection, Func<T, TResult> selector)
    {
        dynamic sum = 0;
        foreach (var item in collection)
        {
            sum += selector(item);
        }
        return sum;
    }

    public static TResult AverageBy<T, TResult>(this IEnumerable<T> collection, Func<T, TResult> selector)
    {
        dynamic sum = 0;
        dynamic count = 0;
        foreach (var item in collection)
        {
            sum += selector(item);
            count++;
        }
        return sum / count;
    }


    public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> collection, Func<T, TKey> keySelector)
    {
        return collection.GroupBy(keySelector).Select(group => group.First());
    }

    public static IEnumerable<T> ReverseCollection<T>(this IEnumerable<T> collection)
    {
        return collection.Reverse();
    }

    public static Dictionary<TKey, T> ToDictionaryByKey<T, TKey>(this IEnumerable<T> collection, Func<T, TKey> keySelector)
    {
        return collection.ToDictionary(keySelector);
    }

    public static void AddOrUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
    {
        dictionary[key] = value;
    }

    public static IEnumerable<T> RemoveDuplicatesBy<T, TKey>(this IEnumerable<T> collection, Func<T, TKey> selector)
    {
        var seenKeys = new HashSet<TKey>();
        foreach (var item in collection)
        {
            if (seenKeys.Add(selector(item)))
            {
                yield return item;
            }
        }
    }

    public static void Shuffle<T>(this IList<T> collection)
    {
        Random rng = new Random();
        int n = collection.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = collection[k];
            collection[k] = collection[n];
            collection[n] = value;
        }
    }

    public static OrderedDictionary ToOrderedDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> collection)
    {
        var orderedDict = new OrderedDictionary();
        foreach (var kvp in collection)
        {
            orderedDict.Add(kvp.Key, kvp.Value);
        }
        return orderedDict;
    }

    public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        foreach (var item in collection)
        {
            action(item);
        }
    }


    public static IEnumerable<T> Merge<T>(this IEnumerable<T> first, IEnumerable<T> second)
    {
        return first.Concat(second);
    }

    public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> collection, int chunkSize)
    {
        for (int i = 0; i < collection.Count(); i += chunkSize)
        {
            yield return collection.Skip(i).Take(chunkSize);
        }
    }

    public static IEnumerable<T> RemoveDuplicatesByKey<T, TKey>(this IEnumerable<T> collection, Func<T, TKey> keySelector)
    {
        var seen = new HashSet<TKey>();
        foreach (var item in collection)
        {
            if (seen.Add(keySelector(item)))
            {
                yield return item;
            }
        }
    }

    public static T MostFrequent<T>(this IEnumerable<T> collection)
    {
        return collection
            .GroupBy(x => x)
            .OrderByDescending(g => g.Count())
            .FirstOrDefault()?.Key;
    }

    public static bool ContainsAll<T>(this IEnumerable<T> collection, IEnumerable<T> other)
    {
        return other.All(collection.Contains);
    }

    public static bool ContainsAny<T>(this IEnumerable<T> collection, IEnumerable<T> other)
    {
        return collection.Intersect(other).Any();
    }

    public static T NthSmallest<T>(this IEnumerable<T> collection, int n) where T : IComparable<T>
    {
        return collection.OrderBy(x => x).ElementAt(n - 1);
    }

    public static T NthLargest<T>(this IEnumerable<T> collection, int n) where T : IComparable<T>
    {
        return collection.OrderByDescending(x => x).ElementAt(n - 1);
    }

    public static bool AreEqual<T>(this T obj, T otherObj)
    {
        return EqualityComparer<T>.Default.Equals(obj, otherObj);
    }

    public static T FindGreaterOrEqual<T>(this IEnumerable<T> collection, T value) where T : IComparable<T>
    {
        return collection.FirstOrDefault(x => x.CompareTo(value) >= 0);
    }

    public static IEnumerable<string> ToUpperCase(this IEnumerable<string> collection)
    {
        return collection.Select(s => s.ToUpper());
    }

    public static IEnumerable<string> ToLowerCase(this IEnumerable<string> collection)
    {
        return collection.Select(s => s.ToLower());
    }

    public static string ToSeparatedString(this IEnumerable<string> collection, string separator = ", ")
    {
        return string.Join(separator, collection);
    }

    public static string ToJson<T>(this T obj)
    {
        return JsonUtility.ToJson(obj);
    }

    public static T FromJson<T>(this string json)
    {
        return JsonUtility.FromJson<T>(json);
    }

    public static IEnumerable<char> ToCharacters(this IEnumerable<string> collection)
    {
        return collection.SelectMany(s => s.ToCharArray());
    }

    public static bool ContainsSequence<T>(this IEnumerable<T> collection, IEnumerable<T> sequence)
    {
        return collection.Zip(sequence, (x, y) => x.Equals(y)).All(b => b);
    }

    public static void WaitUntil<T>(this T obj, Func<T, bool> condition, Action<T> action)
    {
        while (!condition(obj))
        {
            // Wait for the condition to be met
        }
        action(obj);
    }

    public static bool IsUnique<T>(this IEnumerable<T> collection)
    {
        return collection.Count() == collection.Distinct().Count();
    }

    public static T MinItem<T>(this IEnumerable<T> collection) where T : IComparable<T>
    {
        return collection.Min();
    }

    public static T MaxItem<T>(this IEnumerable<T> collection) where T : IComparable<T>
    {
        return collection.Max();
    }

    public static T RandomItem<T>(this IEnumerable<T> collection)
    {
        Random random = new Random();
        return collection.ElementAt(random.Next(collection.Count()));
    }

    public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        return collection.Where(predicate);
    }

    public static IEnumerable<T> ReverseCollection<T>(this IEnumerable<T> collection)
    {
        return collection.Reverse();
    }

    public static IEnumerable<T> RandomElements<T>(this IEnumerable<T> collection, int count)
    {
        Random rand = new Random();
        return collection.OrderBy(x => rand.Next()).Take(count);
    }

    public static IEnumerable<T> TakeEveryNth<T>(this IEnumerable<T> collection, int n)
    {
        return collection.Where((item, index) => index % n == 0);
    }

    public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
    {
        return collection == null || !collection.Any();
    }

    public static string ToConcatenatedString(this IEnumerable<string> collection, string separator = ", ")
    {
        return string.Join(separator, collection);
    }

    public static bool AnyNotEqual<T>(this IEnumerable<T> collection, T value)
    {
        return collection.Any(item => !EqualityComparer<T>.Default.Equals(item, value));
    }

    public static void AddIfNotExists<T>(this ICollection<T> collection, T item)
    {
        if (!collection.Contains(item))
        {
            collection.Add(item);
        }
    }

    public static (IEnumerable<T> True, IEnumerable<T> False) Split<T>(this IEnumerable<T> collection, Func<T, bool> condition)
    {
        var trueCollection = collection.Where(condition);
        var falseCollection = collection.Where(item => !condition(item));
        return (trueCollection, falseCollection);
    }




}
