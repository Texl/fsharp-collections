using Microsoft.FSharp.Collections;

namespace FSharpCollections.Examples;

public static class ForFSharpSet
{
    public static void Run()
    {
        Console.WriteLine("FSharpSet");

        // Create empty
        FSharpSet<string> set = SetModule.Empty<string>();

        Console.WriteLine(set.ToString());
        Console.WriteLine();
    }
}
