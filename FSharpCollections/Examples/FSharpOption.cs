using Microsoft.FSharp.Core;

namespace FSharpCollections.Examples;

public static class ForFSharpOption
{
    public static void Run()
    {
        Console.WriteLine("FSharpOption");

        // Create
        var optionNone = FSharpOption<string>.None;
        var optionSome = FSharpOption<string>.Some("example");
        
        Console.WriteLine(optionNone);
        Console.WriteLine(optionSome);
        Console.WriteLine();
    }
}
