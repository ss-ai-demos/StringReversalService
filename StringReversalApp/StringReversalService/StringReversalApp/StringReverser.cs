using System;

#nullable enable

public class StringReverser
{
    public string Reverse(object input)
    {
        if (input == null)
        {
            return string.Empty;
        }
        string strInput = input.ToString() ?? string.Empty;
        if (string.IsNullOrEmpty(strInput))
        {
            return strInput;
        }
        int len = strInput.Length;
        char[] result = new char[len];
        for (int i = 0, j = len - 1; i < len; i++, j--)
        {
            result[i] = strInput[j];
        }
        return new string(result);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("String Reversal Service");
        Console.WriteLine("======================");
        
        var reverser = new StringReverser();
        
        // Test with command line arguments if provided
        if (args.Length > 0)
        {
            foreach (string arg in args)
            {
                string reversed = reverser.Reverse(arg);
                Console.WriteLine($"Original: {arg}");
                Console.WriteLine($"Reversed: {reversed}");
                Console.WriteLine();
            }
        }
        else
        {
            // Interactive mode
            Console.WriteLine("Enter strings to reverse (type 'exit' to quit, 'demo' for a quick demo):");
            
            while (true)
            {
                Console.Write("Input: ");
                string? input = Console.ReadLine();
                
                if (string.IsNullOrEmpty(input) || input.ToLower() == "exit")
                {
                    break;
                }
                
                if (input.ToLower() == "demo" || input.ToLower() == "async")
                {
                    Console.WriteLine("Demo - reversing 'Hello Demo World!'");
                    string demoResult = reverser.Reverse("Hello Demo World!");
                    Console.WriteLine($"Result: {demoResult}");
                    Console.WriteLine();
                    continue;
                }
                
                string result = reverser.Reverse(input);
                Console.WriteLine($"Reversed: {result}");
                Console.WriteLine();
            }
        }
        
        Console.WriteLine("Thank you for using String Reversal Service!");
    }
}