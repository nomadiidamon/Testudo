using System.Collections.Generic;
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

    public static void RemoveAll<T>(this List<T> collection, System.Func<T, bool> predicate)
    {
        collection.RemoveAll(new System.Predicate<T>(predicate));
    }

    public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            collection.Add(item);
        }
    }

    public static T Clone<T>(this T obj)
    {
        var serializedObj = JsonUtility.ToJson(obj);
        return JsonUtility.FromJson<T>(serializedObj);
    }

    public static void SafeInvoke<T>(this T obj, System.Action<T> action)
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

    public static void SortBy<T>(this List<T> list, System.Func<T, T, int> comparison)
    {
        list.Sort(new System.Comparison<T>(comparison));
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
        System.Random rng = new System.Random();
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

    public static System.Collections.Specialized.OrderedDictionary ToOrderedDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> collection)
    {
        var orderedDict = new System.Collections.Specialized.OrderedDictionary();
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

    public static bool AreEqual<T>(this T obj, T otherObj)
    {
        return EqualityComparer<T>.Default.Equals(obj, otherObj);
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


    public static void WaitUntil<T>(this T obj, Func<T, bool> condition, Action<T> action)
    {
        while (!condition(obj))
        {
            // Wait for the condition to be met
        }
        action(obj);
    }

    public static string ToConcatenatedString(this IEnumerable<string> collection, string separator = ", ")
    {
        return string.Join(separator, collection);
    }

    public static void AddIfNotExists<T>(this ICollection<T> collection, T item)
    {
        if (!collection.Contains(item))
        {
            collection.Add(item);
        }
    }




}
