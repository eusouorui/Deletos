using Deletos.Handlers;
using Deletos.Strings;

bool exit = false;
do
{
    ProgramHandler.Start();

    List<CheckBlankSpaces> blankSpacesCheckerList = new List<CheckBlankSpaces>();

    blankSpacesCheckerList.Add(new CheckBlankSpaces("There are spaces before or after the name.", false));
    blankSpacesCheckerList.Add(new CheckBlankSpaces("There must not be spaces in the name.", true));

    string stringToValidate = "Validate this string";

    foreach(CheckBlankSpaces item in blankSpacesCheckerList)
    {
        (bool, string) result = item.Validate(stringToValidate);

        if(result.Item1)
        {
            Console.WriteLine($"The string: \"{stringToValidate}\" is valid");
        }
        else
        {
            Console.WriteLine(result.Item2);
        }
    }

    ProgramHandler.Pause(true);
}while(!exit);