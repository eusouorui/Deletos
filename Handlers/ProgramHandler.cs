namespace Deletos.Handlers
{
    public static class ProgramHandler
    {
        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Deletos.\n\n\n");
        }

        public static void Pause(
                            string pauseMessage = "\n\nDeletos was paused. Press any key to continue: ",
                            bool showPauseMessage = true)
        {
            Console.Write(pauseMessage);
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}