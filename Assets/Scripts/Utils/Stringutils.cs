using System;
using System.Text.RegularExpressions;

public class Stringutils
{
    private static readonly Regex regex = new Regex(@"^\d+$");
    public static bool isNumeric(string str)
    {
        if ( regex.IsMatch(str) )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
