namespace Deletos.Profiles;

public static class Rui
{
    #region Menus

    #region Main menu
    
    public static void Menu()
    {
        var exit = false;
        var option = 0;

        do
        {
            option = SelectMenuOption();

            switch (option)
            {
                case 1:
                    StringMenu();
                    break;
                case 2:
                    Console.WriteLine("You chose option 2");
                    break;
                case 3:
                    Console.WriteLine("You chose option 3");
                    break;
                case 0:
                    Console.WriteLine("You chose option 0 - Exit Profile");
                    exit = Exit();
                    break;
                default:
                    Console.WriteLine("Option is not available");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("Press enter to continue...");
                Console.ReadKey();
            }

        } while (!exit);
    }

    private static int SelectMenuOption()
    {
        Console.Clear();
        Console.WriteLine(DateTime.Now);
        Console.WriteLine("Hello Rui, What would you like to do?\n");
        var options = Enum.GetValues(typeof(MenuOptions)).Cast<MenuOptions>().ToList();
        
        foreach (int option in options)
        {
            Console.WriteLine(option + " - " + option);
        }
        Console.WriteLine("0 - Exit Profile");

        Console.WriteLine("Your option: ");
        int.TryParse(Console.ReadLine(), out var chosenOption);

        return chosenOption;
    }
    #endregion

    #region String Menu

    private static void StringMenu()
    {
        Console.Clear();
        Console.WriteLine(DateTime.Now);
        Console.WriteLine("Hello Rui, What would you like to do?\n");

        var exit = false;
        var option = 0;

        do
        {
            option = SelectStringMenuOption();

            switch(option)
            {
                case 1:
                    break;
                case 0:
                    Console.WriteLine("You chose option 0 - Exit Strings Menu");
                    exit = Exit();
                    break;
                default:
                    break;
            }

            if(!exit)
            {
                Console.WriteLine("Press enter to continue...");
                Console.ReadKey();
            }

        }while (!exit);
    }

    private static int SelectStringMenuOption()
    {
        Console.Clear();
        Console.WriteLine(DateTime.Now);
        Console.WriteLine("Hello Rui, What would you like to do?\nStrings Menu\n");
        var stringOptions = Enum.GetValues(typeof(StringMenuOptions)).Cast<StringMenuOptions>().ToList();

        foreach(int option in stringOptions)
        {
            Console.WriteLine(option + " - " + option);
        }
        Console.WriteLine("0 - Exit Strings Menu");

        Console.WriteLine("Your option: ");
        int.TryParse(Console.ReadLine(), out var chosenOption);

        return chosenOption;
    }
    #endregion

    #endregion

    #region Enums
    enum MenuOptions
    {
        Strings = 1,
    }

    enum StringMenuOptions
    {
        InvertString = 1,
    }
    #endregion

    private static bool Exit()
    {
        Console.WriteLine("\nAre you sure you want to quit? Y/N\n\nResponse:");

        var response = Console.ReadLine()?.ToLower();

        return string.Equals(response, "yes", StringComparison.InvariantCultureIgnoreCase) || string.Equals(response, "y", StringComparison.InvariantCultureIgnoreCase);
    }
}