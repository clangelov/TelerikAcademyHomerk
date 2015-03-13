class StringsInC
{
    /*
     * A string is a sequence of characters stored in a certain address in memory. Or something like a char array. And in .NET Framework each character has a serial number from the Unicode table
     * 
     * 
     * The string class has an important feature – the character sequences stored in a variable of the class are never changing (immutable). After being assigned once, the content of the variable does not change directly – if we try to change the value, it will be saved to a new location in the dynamic memory and the variable will point to it
     * 
     * .ToLower() - makes all letters lowercase
     * .ToUpper() - makes all letters uppercase
     * .IndexOf() - gives the starting index of a char or string
     * .LastIndexOf() gives the last starting index of a char or string
     * .Substring(startIndex, length) -  extracts a substring from a string, which is located between startIndex and (startIndex + length – 1) inclusively
     * .Split(new char[] {','}) - splits the strign by a given char symbol to be used with:
     * +StringSplitOptions.RemoveEmptyEntries = removes all "";
     * .Equals() - compare strings something like ==
     * .Replace(string, string) - replaces one string with another;
     * .Trim() - Removing unnecessary characters at the beginning and at the end of a string
     */


}

