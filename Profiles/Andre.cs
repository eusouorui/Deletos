namespace Deletos.Profiles;

using System.Threading;
using System.Linq;
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
                    Console.WriteLine("Are you sure you want to exit? \nYes ->1\nNo -> 2\n");
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
                default:
                    Console.WriteLine("Can't you read brother?");
                    break;
            }

        }while(!exit);
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
        Console.WriteLine("What you want?: ");
    }
    

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
}