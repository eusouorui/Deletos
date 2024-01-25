namespace Deletos.Minigames;

using System.Threading;
using System.Linq;

public static class Minesweeper{


    public static void start(){
        bool exit = false;
        bool gameOver = false;
        Console.Clear();
        Console.WriteLine("Welcome to Minesweeper!\n");

        do{
            int option = startMenu();

            switch(option){
                case 1:
                    startEasyGame();
                    break;
                case 2:
                    startNormalGame();
                    break;
                case 3:
                    startHardGame();
                    break;
                case 0:
                    exit = Exit();
                    break;
                default:
                    Console.WriteLine("No option available");
                    break;
                
            }
        }while(!exit);           
    }

    private static int startMenu(){
        Console.WriteLine("1 - Easy");
        Console.WriteLine("2 - Normal");
        Console.WriteLine("3 - Hard");
        Console.WriteLine("0 - Exit");
        return Int32.Parse(Console.ReadLine());
    }


    private static void startEasyGame(){
        Console.WriteLine("Easy???");
        int x = 10;
        int y = 8;
        int[ , ] easyMap = new int [x, y];
        int bombs = 10;
        showMap(x,y);
        placeBombs(bombs, x,y);


    }

    private static void startNormalGame(){
        Console.WriteLine("Nice.");
        int[ , ] x = new int [18, 14];
        int bombs = 40;
    }

    private static void startHardGame(){
        Console.WriteLine("Playa!");
        int[ , ] x = new int [24, 20];
        int bombs = 99;


    }

    private static void showMap(int x, int y){
        for(int i=0;i<=x;i++){
            for(int j=0;j<=y;j++){
                Console.Write("*\t");
            }
            Console.WriteLine("*");
        }
    }

    private static void placeBombs(int bombs, int x, int y){
        Random rnd = new Random();
        //initializes map with game size
        int [ , ] bombMap = new int [x,y];
        int a,b;
        
        //for every bomb it generates an x and y to place a bomb (1)
        for(int i=0;i<bombs;i++){
            a = rnd.Next(x);
            b = rnd.Next(y);
            bombMap[a,b] = 1;
        }
        
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Console.Write(bombMap[i,j] + "\t");
            }
            Console.WriteLine();
        }
    }






    // roubei
    private static bool Exit()
    {
        Console.WriteLine("\nAre you sure you want to quit? Y/N\n\nResponse:");

        var response = Console.ReadLine()?.ToLower();

        return string.Equals(response, "yes", StringComparison.InvariantCultureIgnoreCase) || string.Equals(response, "y", StringComparison.InvariantCultureIgnoreCase);
    }
}