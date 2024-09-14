using System.Text.RegularExpressions;

namespace Framework.Base.RegexPatterns;

public class NumericRegex
{
    public static bool IsMatch(string input) => Regex.IsMatch(input, @"^[0-9]*$");
}   
