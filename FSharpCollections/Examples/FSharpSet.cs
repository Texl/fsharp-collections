using Microsoft.FSharp.Collections;

namespace Examples
{
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
}
