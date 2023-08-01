using Microsoft.FSharp.Collections;

namespace FSharpCollections.Examples;

public static class ForFSharpMap
{
    public static void Run()
    {
        Console.WriteLine("FSharpMap");

        // An immutable key-value map based on binary trees..
        
        // Create empty
        FSharpMap<string, int> map = MapModule.Empty<string, int>();

        Console.WriteLine(map);
        Console.WriteLine();
    }
}
