using Microsoft.FSharp.Core;

namespace Examples
{
    public static class ForFSharpOption
    {
        public static void Run()
        {
            Console.WriteLine("FSharpOption");

            // Create
            FSharpOption<string>? optionNone = FSharpOption<string>.None;
            FSharpOption<string>? optionSome = FSharpOption<string>.Some("example");

            Console.WriteLine(optionNone?.ToString());
            Console.WriteLine(optionSome?.ToString());
            Console.WriteLine();
        }
    }
}
