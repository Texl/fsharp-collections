using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;

namespace FSharpCollections.Examples;

public static class ForFSharpList
{
    public static void Run()
    {
        Console.WriteLine("FSharpList");

        // An immutable singly-linked list.
        
        // Each element in the list is a node containing a "head" value and a "tail" that is the rest of the list;
        // the final node is a special "empty list" node that has no head or tail.
        
        // ListModule is an F# module that contains functions for creating and manipulating lists.
        // (From C#, F# modules function identically to static classes.)
        
        // Many ListModule functions have FSharpList instance method equivalents
        
        // Create empty list
        FSharpList<int> emptyList = ListModule.Empty<int>();

        // int emptyHead = emptyList.Head; // throws

        // FSharpList<int> emptyTail = emptyList.Tail; // throws
        
        bool isEmpty = emptyList.IsEmpty; // true


        // Create single-item list
        FSharpList<int> singleItemList = ListModule.Singleton(42);
        
        // Get the single-item list's head - contingent access that returns an option
        FSharpOption<int> maybeSingleHead = ListModule.TryHead(singleItemList); // Some(42)
        
        // Get the single-item list's head - assertive access that returns the head or throws
        int singleHead = ListModule.Head(singleItemList); // 42
        
        
        // Binary tree implementation lends itself well to structural sharing
        FSharpList<int> largeList = ListModule.Initialize(1_000_000, FuncConvert.FromFunc((int ord) => ord)); // 0 to 999,999
        Console.WriteLine($"{largeList.Length:n0}");

        FSharpList<int> largerList = new FSharpList<int>(42, largeList);
        Console.WriteLine($"{largerList.Length:n0}");
        
        FSharpList<int> smallerLargeList = largeList.Tail;
        Console.WriteLine($"{smallerLargeList.Length:n0}");
        
        
        // C# / F# function interop can be a bit awkward - extension methods can help
        FSharpList<int> all = ListModule.Truncate(1_000, largeList); // 0 to 999
        (FSharpList<int> even, FSharpList<int> odd) = ListModule.Partition(FuncConvert.FromFunc<int, bool>(n => n % 2 == 0), all); // 0 to 999 evens, 0 to 999 odds
        
        
        // Choose is useful - can replace patterns like .Where(x => convertAndTest(x)).Select(x => convert(x)) in one step
        // It requires use of another F# type - Option
        FSharpList<int?> mixedNullity = ListModule.Initialize(1_000, FuncConvert.FromFunc<int, int?>(ord => ord % 2 == 0 ? ord : null)); // 0 to 999,999
        FSharpList<int> nonNulls =
            ListModule.Choose(
                FuncConvert.FromFunc<int?, FSharpOption<int>>(nullableInt => 
                    OptionModule.Map(
                        FuncConvert.FromFunc<int, int>(n => n * n),
                        OptionModule.OfNullable(nullableInt))),
                mixedNullity);
    }
}

public static class FSharpExtensions
{
    public static FSharpList<U> Choose<T, U>(this FSharpList<T> list, Func<T, FSharpOption<U>> f) =>
        ListModule.Choose(FuncConvert.FromFunc(f), list);

    public static FSharpOption<U> Map<T, U>(this FSharpOption<T> option, Func<T, U> f) =>
        OptionModule.Map(FuncConvert.FromFunc(f), option);

    public static FSharpOption<T> ToOption<T>(this T? value) where T : struct =>
        OptionModule.OfNullable(value);

    public static FSharpOption<T> ToOption<T>(this T value) where T : class =>
        OptionModule.OfObj(value);
}

public static class FSharpList
{
    public static FSharpList<T> Initialize<T>(int count, Func<int, T> f) =>
        ListModule.Initialize(count, FuncConvert.FromFunc(f));
}

public static class ForFSharpList2
{
    public static void Run()
    {
        FSharpOption<int> opt;
        
        // The last example above is very explicit and ugly, let's clean it up some
        FSharpList<int?> mixedNullity = FSharpList.Initialize(1_000, ord => ord % 2 == 0 ? (int?)ord : null); // 0 to 999,999
        FSharpList<int> nonNulls = mixedNullity.Choose(nullableInt => nullableInt.ToOption().Map(n => n * n));
    } 
    
}