namespace Deletos.Strings
{
    public static class Invert
    {
        public static string Main(string stringToInvert = "this is a very cool string")
        {
            //run validators

            return InvertString(stringToInvert ?? string.Empty);
        }

        private static string InvertString(string stringToInvert)
        {
            string invertedString = string.Empty;

            for(int i =  stringToInvert.Length-1; i >= 0; i--)
            {
                invertedString += stringToInvert[i];
            }

            return invertedString;
        }
    }
}