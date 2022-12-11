namespace Deletos.Profiles;

public static class Rui
{
    #region main menu
    public static void Menu()
    {
        bool exit = false;
        int option = 0;
        var menuOptions = Enum.GetValues(typeof(MenuOptions)).Cast<MenuOptions>();
        
        do
        {
            Console.Clear();
            Console.WriteLine(DateTime.Now);
            option = SelectMenuOption();
            Console.Clear();

            switch(option)
            {
                case 1: //Strings Menu
                    Console.WriteLine("You chose option 1");
                    break;
                case 2:
                    Console.WriteLine("You chose option 2");
                    break;
                case 3:
                    Console.WriteLine("You chose option 3");
                    break;
                case 0:
                    Console.WriteLine("You chose option 0 - Exit Profile");
                    break;
                default:
                    Console.WriteLine("Option is not available");
                    break;
            }

            Console.ReadKey();
        } while(!exit);
    }

    internal static int SelectMenuOption()
    {
        Console.WriteLine("Hello Rui, What would you like to do?\n");
        
        
        foreach(var option in Enum.GetValues(typeof(MenuOptions)).Cast<MenuOptions>())
        {
            Console.WriteLine((int)option + " - " + option);
        }

        Console.WriteLine("0 - Exit Profile");

        Console.WriteLine("Your option: ");
        int.TryParse(Console.ReadLine(), out int chosenOption);

        return chosenOption;
    }
    #endregion

    #region Enums
    enum MenuOptions
    {
        Strings = 1,

    }

    enum StringMenuOptions
    {

    }
    #endregion
}