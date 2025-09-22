using System;

public class StringReverser
{
    public string Reverse(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}