using Microsoft.FSharp.Collections;

namespace Examples
{
    public static class ForFSharpList
    {
        public static void Run()
        {
            Console.WriteLine("FSharpList");

            // Create empty
            FSharpList<string> list = ListModule.Empty<string>();

            Console.WriteLine(list.ToString());
            Console.WriteLine();
        }
    }
}
