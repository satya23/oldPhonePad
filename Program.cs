using System;

namespace OldPhonePad
{
    /// <summary>
    /// Console application to demonstrate the OldPhonePadConverter functionality.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Command line argument mode - output only the result
            if (args.Length > 0)
            {
                // Treat all arguments as part of the input, joined by spaces.
                // This allows unquoted inputs that contain spaces (e.g. 4433555 555666#).
                string rawInput = string.Join(" ", args);

                try
                {
                    string result = OldPhonePadConverter.OldPhonePad(rawInput);
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Environment.Exit(1);
                }
                return;
            }

            // Interactive mode - show header and test cases
            Console.WriteLine("Old Phone Pad Converter");
            Console.WriteLine("======================\n");

            // Test cases from the problem statement
            var testCases = new[]
            {
                ("33#", "E"),
                ("227*#", "B"),
                ("4433555 555666#", "HELLO"),
                ("8 88777444666*664#", "TURING")
            };

            Console.WriteLine("Running test cases:\n");

            foreach (var (input, expected) in testCases)
            {
                try
                {
                    string result = OldPhonePadConverter.OldPhonePad(input);
                    string status = result == expected ? "✓" : "✗";
                    
                    Console.WriteLine($"{status} Input: {input}");
                    Console.WriteLine($"  Expected: {expected}");
                    Console.WriteLine($"  Got:      {result}");
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"✗ Input: {input}");
                    Console.WriteLine($"  Error: {ex.Message}");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Enter interactive mode (type 'exit' to quit):\n");
            
            while (true)
            {
                Console.Write("Input: ");
                string? input = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(input) || input.ToLower() == "exit")
                {
                    break;
                }

                try
                {
                    string result = OldPhonePadConverter.OldPhonePad(input);
                    Console.WriteLine($"Output: {result}\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}\n");
                }
            }
        }
    }
}

