namespace Deletos.Handlers
{
    public static class ProgramHandler
    {
        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Deletos.\n\n\n");
        }

        public static bool Pause(bool askToLeave = false)
        {
            if(askToLeave)
            {
                return Exit();
            }

            Console.ReadKey();
            Console.WriteLine();

            return false;
        }

        private static bool Exit()
        {
            bool? option = null;

            List<string> responseOptions = new List<string> {"yes", "no", "y", "n"};

            while(option == null)
            {
                Console.WriteLine("\n\nDo you wish to abort the program? (Yes/No)");

                string response = Console.ReadLine()?.ToLower() ?? string.Empty;

                if(!string.IsNullOrEmpty(response))
                {
                    if(responseOptions.Any(s => string.Equals(s, response)))
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Option not available");
                    }
                }
            }

            return (bool)option;
        }
    }
}