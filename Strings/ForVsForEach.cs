namespace Deletos.Strings
{
    public static class ForVsForeach
    {
        public static void Main()
        {
            var myString = "  !This string contains spaces  .";
            Console.WriteLine(myString.Contains(" "));

            decimal start = DateTime.Now.Ticks;
            WriteStringWithoutSpaces(myString, true);
            decimal firstCycle = DateTime.Now.Ticks;

            Console.WriteLine($"Took {(firstCycle - start)/1000} ms");

            start = DateTime.Now.Ticks;
            WriteStringWithoutSpaces(myString, false);
            decimal secondCycle = DateTime.Now.Ticks;

            Console.WriteLine($"Took {(secondCycle - start)/1000} ms");
        }

        private static void WriteStringWithoutSpaces(string stringToTrim, bool useForEach)
        {
            if (useForEach)
            {
                Console.WriteLine("\nUsing foreach loop:");
                foreach (var c in stringToTrim)
                {
                    if (c != ' ')
                    {
                        Console.Write(c);
                    }
                    else
                    {
                        Console.Write("_");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nUsing for loop:");
                for(int i = 0; i < stringToTrim.Length; i++)
                {
                    char currentChar = stringToTrim[i];
                    if(currentChar != ' ')
                    {
                        Console.Write(currentChar);
                    }
                    else
                    {
                        Console.Write("_");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}