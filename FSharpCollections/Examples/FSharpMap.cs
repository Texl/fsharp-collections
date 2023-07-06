using Microsoft.FSharp.Collections;

namespace Examples
{
    public static class ForFSharpMap
    {
        public static void Run()
        {
            Console.WriteLine("FSharpMap");

            // Create empty
            FSharpMap<string, int> map = MapModule.Empty<string, int>();

            Console.WriteLine(map.ToString());
            Console.WriteLine();
        }
    }
}
