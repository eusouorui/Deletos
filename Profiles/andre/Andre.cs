namespace Deletos.Profiles.Dre;

using System.Threading;
using System.Linq;
using System.Data.SqlClient;
using Dapper;

public static class Andre
{
    public static void Menu()
    {
        bool exit = false;

        do{
            menuChoices();
            int option = getChoice();

            switch(option){
                case 0:
                    Console.WriteLine("Option not available brother.");
                    break;
                case 1:
                    Console.WriteLine("Are you sure you want to exit? \nYes -> 1\nNo -> 2\n");
                    if(getChoice() == 1)
                        exit = true;
                    askToContinue();
                    break;
                case 2:
                    //TODO Optimize it and add -> simultaneous operations
                    calculatorMenu();
                    break;
                case 3:
                    theMatrix();
                    break;
                case 4:
                    database();
                    break;
                case 5:
                    minigames();
                default:
                    Console.WriteLine("Can't you read brother?");
                    break;
            }

            

        }while(!exit);
    }

    private static void database(){
        var cs = @"Server=localhost\MSSQLSERVER;Database=carsDB;Trusted_Connection=True;";

        using var con = new SqlConnection(cs);
        con.Open();

        var cars = con.Query<Car>("SELECT * FROM cars").ToList();

        cars.ForEach(car => Console.WriteLine(car));
    }

    private static int getChoice()
    {
        int.TryParse(Console.ReadLine().Trim(), out int optionSelected);
        
        return optionSelected;
    }

    private static void menuChoices(){
        Console.Clear();
        Console.WriteLine("This is Andre.");
        Console.WriteLine("1 - Exit");
        //Calculator XPTO
        Console.WriteLine("2 - Calculator");
        //It's Morpheus being cool again
        Console.WriteLine("3 - Enter the Matrix");
        Console.WriteLine("4 - Retrieve data from small Db");
        //Enters minigames menu
        Console.WriteLine("5 - Minigames");
        Console.WriteLine("What you want?: ");
    }
    


#region Calculator
    private static void calculatorMenu()
    {
        var operations = Enum.GetValues(typeof(Operators)).Cast<Operators>().ToList();
        Console.WriteLine("Write your operation(Eg. 420*69)");
        string? calc =  Console.ReadLine();
        if(calc == null)
        {
            Console.WriteLine("U stoopid?");
            return;
        }
        
        foreach(var operation in operations)
        {
            if(calc.Contains((char)operation))
            {
                compute(operation, calc);
            }
        }

    }




    private static double compute(Operators operation, string calc)
    {
        double sum=0;
        string[] wholeOperation = calc.Split((char)operation, StringSplitOptions.RemoveEmptyEntries);
        int[] numbersToCompute = new int[wholeOperation.Length];
        
        for(int i=0;i<wholeOperation.Length;i++)
        {
            int.TryParse(wholeOperation[i], out numbersToCompute[i]);
        }

        switch(operation){
            case Operators.Add:
                sum = add(numbersToCompute);
                break;
            case Operators.Sub:
                sum = subtract(numbersToCompute);
                break;
            case Operators.Div:
                sum = divide(numbersToCompute);
                break;
            case Operators.Mul:
                sum = multiply(numbersToCompute);
                break;
        }

        Console.WriteLine(sum);
        askToContinue();
        return sum;
    }

    private static double add(int[] numbersToCompute)
    {
        double sum = 0;
        foreach(int nr in numbersToCompute)
        {
            sum += (double)nr;
        }
        return sum;
    }
    private static double subtract(int[] numbersToCompute)
    {
        double sum = numbersToCompute[0]*2;
        foreach(int nr in numbersToCompute)
        {

            sum -= (double)nr;
        }
        return sum;
    }
    private static double divide(int[] numbersToCompute)
    {
        double sum = Math.Pow(numbersToCompute[0],2);
        foreach(int nr in numbersToCompute)
        {
            sum /= (double)nr;
        }
        return sum;
    }
    private static double multiply(int[] numbersToCompute)
    {
        double sum = 1;
        foreach(int nr in numbersToCompute)
        {
            sum *= (double)nr;
        }
        return sum;
    }
#endregion

    private static void theMatrix(){
        int[,] matrix = new int[5,5];
        Random rand = new Random();
        
        for(int j=0; j <matrix.Length/5;j ++){
            for (int i = 0; i < matrix.Length/5; i++)
            {
                matrix[j,i] = 0;
            }
        }
        int ite=0;
        Console.WriteLine("!YOU ARE NOW STUCK IN THE MATRIX!");
        while(ite>=0){
            
            Console.Write((matrix[rand.Next(0,5),rand.Next(0,5)] = rand.Next(0,2))+" ");
            Thread.Sleep(100);
            if(ite%8==0)
                Console.WriteLine();
            ite++;
        }
    }

    private static void minigames(){
        Console.Clear();
        Console.WriteLine("1 - Play Minesweeper");
        Console.WriteLine("0 - Leave");
        int? option =  Int32.Parse(Console.ReadLine());
        bool exit = false;
        
        switch(option){
            case 0:
                Console.Clear();
                Console.WriteLine("0 - Leave forever? (y/n)");
                exit = Exit();
                break; 
            case 1:
                Console.Clear();
                Console.WriteLine("Playing minesweeper huh?\n");
                Thread.Sleep(750);
                
                Deletos.Minigames.Minesweeper.start();
                break;
            default:
                Console.WriteLine("Not available.");
                break;
        }
    }

    private static void askToContinue()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private enum Operators
    {
        Add = '+',
        Sub = '-',
        Div = '/',
        Mul = '*',
    }

    // roubei
    private static bool Exit()
    {
        Console.WriteLine("\nAre you sure you want to quit? Y/N\n\nResponse:");

        var response = Console.ReadLine()?.ToLower();

        return string.Equals(response, "yes", StringComparison.InvariantCultureIgnoreCase) || string.Equals(response, "y", StringComparison.InvariantCultureIgnoreCase);
    }
}