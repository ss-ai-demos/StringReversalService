using System;
using System.Threading.Tasks;

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

    public async Task<string> ReverseAsync(object input)
    {
        return await Task.Run(() =>
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
        });
    }

    public static async Task Main(string[] args)
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
            Console.WriteLine("Enter strings to reverse (type 'exit' to quit, 'async' for async demo):");
            
            while (true)
            {
                Console.Write("Input: ");
                string? input = Console.ReadLine();
                
                if (string.IsNullOrEmpty(input) || input.ToLower() == "exit")
                {
                    break;
                }
                
                if (input.ToLower() == "async")
                {
                    Console.WriteLine("Async demo - reversing 'Hello Async World!'");
                    string asyncResult = await reverser.ReverseAsync("Hello Async World!");
                    Console.WriteLine($"Async Result: {asyncResult}");
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