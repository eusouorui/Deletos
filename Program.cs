using Deletos.Handlers;
using Deletos.Profiles;

bool exit = false;
do
{
    var profile = ProgramHandler.Start();

    //Code to check if is Rui or Andre
    switch(profile)
    {
        case 1:
            Andre.Menu();
            break;
        case 2:
            Rui.Menu();
            break;
        default:
            Console.WriteLine("New Phone, who this?");
            break;
    }

    exit = ProgramHandler.Exit();

}while(!exit);

Console.WriteLine("Thank you, come again");
Console.ReadKey();