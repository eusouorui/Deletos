namespace Deletos.Handlers
{
    using Deletos.Enums;
    public static class ProgramHandler
    {
        public static int Start()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Deletos.\n\n\n");
            
            return SelectProfile();
        }

        public static void Pause(bool askToLeave = false)
        {
            Console.ReadKey();
            Console.WriteLine();
        }

        //TODO rever isto
        public static bool Exit()
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

        private static int SelectProfile()
        {
            Console.WriteLine("Please select your profile:");
            
            var profiles = new List<Profile> 
            {
                //TODO get a better way of doing this
                Profile.Andre,
                Profile.Rui,
            };

            foreach(var profile in profiles)
            {
                Console.WriteLine((int)profile + " - " + profile);
            }

            int.TryParse(Console.ReadLine(), out int chosenProfile);

            //TODO make validations
            return chosenProfile;
        } 
    }
}