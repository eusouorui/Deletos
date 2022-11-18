namespace Deletos.Strings;

public class CheckBlankSpaces
{
    private string _ErrorMessage;
    private bool _CheckMiddleSpaces;

    public CheckBlankSpaces(string errorMessage, bool checkMiddleSpaces)
    {
        this._ErrorMessage = errorMessage;
        this._CheckMiddleSpaces = checkMiddleSpaces;
    }

    ///<summary>
    ///<returns> Returns true if is valid, false if is not</returns>
    ///</summary>
    internal (bool, string) Validate(string attribute)
    {
        if(_CheckMiddleSpaces)
        {
            return ((!attribute.Contains(" "), _ErrorMessage));
        }
        else
        {
            return ((string.Equals(attribute, attribute.Trim()), _ErrorMessage));
        }
    }
}