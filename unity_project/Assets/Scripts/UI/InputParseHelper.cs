
public static class InputParseHelper
{
    /// <summary>
    /// joins arguments from [start] to [end]
    /// </summary>
    /// <param name="arguments">the argument array</param>
    /// <param name="start">the index to start from</param>
    /// <param name="end">the index to end in, if 0 or less, it's used as a backwards index</param>
    /// <returns>a string with all arguments from indexes start to end separated by white spaces</returns>
    public static string JoinArguments(string[] arguments, int start = 1, int end = 0)
    {
        string ret = string.Empty;

        if (end < 1) end += arguments.Length - 1;

        if (arguments.Length > start && arguments.Length > end && start <= end)
        {
            ret = arguments[start];

            for (int i = start + 1; i <= end; i++)
            {
                ret += " " + arguments[i];
            }
        }

        return ret;
    }

    /// <summary>
    /// this is useful to parse inputs that have to contain a name and might contain a number at the end
    /// </summary>
    /// <param name="arguments">entire input</param>
    /// <param name="text">the text part</param>
    /// <param name="number">the number at the end of the input if exists, defaultNumber otherwise</param>
    /// <param name="defaultNumber">to be returned in number if there was no number on arguments</param>
    /// <returns>true if the input is valid</returns>
    public static bool ParseTextAndNumberArgs(string[] arguments, out string text, out int number, int defaultNumber = 1)
    {
        string lastArg = arguments[arguments.Length - 1];
        text = string.Empty;

        if (arguments.Length < 2)
        {
            number = defaultNumber;
            return false;
        }

        //is lastArg a number?
        if (int.TryParse(lastArg, out number))
        {
            if (arguments.Length < 3)
            {
                number = defaultNumber;
                return false;
            }

            text = InputParseHelper.JoinArguments(arguments, end: -1);
        }
        else
        {

            number = defaultNumber;
            text = InputParseHelper.JoinArguments(arguments);
        }

        return true;
    }
}
