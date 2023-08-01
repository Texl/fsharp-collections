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
        
        // var twoLits = ListModule.Partition()
        

        Console.WriteLine(emptyList);
        Console.WriteLine();
    }
}
