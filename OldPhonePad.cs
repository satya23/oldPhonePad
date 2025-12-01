using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePad
{
    /// <summary>
    /// Represents an old phone keypad with alphabetical letters, backspace, and send functionality.
    /// Each button can represent multiple letters, and pressing a button multiple times cycles through them.
    /// </summary>
    public static class OldPhonePadConverter
    {
        /// <summary>
        /// Maps each digit button to its corresponding letters on the old phone keypad.
        /// </summary>
        private static readonly Dictionary<char, string> KeypadMapping = new Dictionary<char, string>
        {
            { '2', "ABC" },
            { '3', "DEF" },
            { '4', "GHI" },
            { '5', "JKL" },
            { '6', "MNO" },
            { '7', "PQRS" },
            { '8', "TUV" },
            { '9', "WXYZ" }
        };

        /// <summary>
        /// Converts input from an old phone keypad into the corresponding text output.
        /// 
        /// Rules:
        /// - Each digit button cycles through its letters when pressed multiple times
        /// - A space (' ') indicates a pause, allowing the same button to be used for consecutive letters
        /// - An asterisk ('*') acts as a backspace, removing the last character
        /// - A hash ('#') indicates the end of input and triggers the send action
        /// - Any characters other than digits 2-9, space, '*' and '#' are ignored
        /// 
        /// </summary>
        /// <param name="input">The input string containing digits, spaces, asterisks, and ending with '#'</param>
        /// <returns>The decoded text output</returns>
        /// <exception cref="ArgumentNullException">Thrown when input is null</exception>
        /// <exception cref="ArgumentException">Thrown when input doesn't end with '#' or contains invalid characters</exception>
        /// 
        /// <example>
        /// <code>
        /// OldPhonePad("33#") => "E"
        /// OldPhonePad("227*#") => "B"
        /// OldPhonePad("4433555 555666#") => "HELLO"
        /// OldPhonePad("8 88777444666*664#") => "TURING"
        /// </code>
        /// </example>
        public static string OldPhonePad(string input)
        {
            // Input validation
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Input cannot be null.");
            }

            if (string.IsNullOrEmpty(input) || !input.EndsWith("#"))
            {
                throw new ArgumentException("Input must end with '#' to indicate send.", nameof(input));
            }

            // Remove the trailing '#' as it's just a terminator
            string processedInput = input.Substring(0, input.Length - 1);

            var result = new StringBuilder();
            char? currentButton = null;
            int pressCount = 0;
            int index = 0;

            while (index < processedInput.Length)
            {
                char currentChar = processedInput[index];

                // Handle backspace
                if (currentChar == '*')
                {
                    // If we have a pending button press, cancel it instead of removing from result
                    if (currentButton.HasValue)
                    {
                        // Cancel the current button press
                        currentButton = null;
                        pressCount = 0;
                    }
                    else if (result.Length > 0)
                    {
                        // No pending press, remove last character from result
                        result.Length--;
                    }
                    index++;
                    continue;
                }

                // Handle pause (space)
                if (currentChar == ' ')
                {
                    // Process any pending button presses before the pause
                    if (currentButton.HasValue)
                    {
                        result.Append(GetCharacterForButton(currentButton.Value, pressCount));
                        currentButton = null;
                        pressCount = 0;
                    }
                    index++;
                    continue;
                }

                // Handle digit buttons
                if (KeypadMapping.ContainsKey(currentChar))
                {
                    // If this is the same button as before, increment press count
                    if (currentButton == currentChar)
                    {
                        pressCount++;
                    }
                    else
                    {
                        // Different button - process the previous one first (if any)
                        if (currentButton.HasValue)
                        {
                            result.Append(GetCharacterForButton(currentButton.Value, pressCount));
                        }
                        // Start tracking the new button
                        currentButton = currentChar;
                        pressCount = 1;
                    }
                }
                else
                {
                    // Invalid character - skip it (or could throw exception)
                    // For robustness, we'll skip invalid characters
                }

                index++;
            }

            // Process any remaining button press after the loop
            if (currentButton.HasValue)
            {
                result.Append(GetCharacterForButton(currentButton.Value, pressCount));
            }

            return result.ToString();
        }

        /// <summary>
        /// Gets the character for a given button based on the number of presses.
        /// Uses modulo arithmetic to cycle through the letters on the button.
        /// </summary>
        /// <param name="button">The digit button (2-9)</param>
        /// <param name="pressCount">The number of times the button was pressed</param>
        /// <returns>The corresponding character</returns>
        private static char GetCharacterForButton(char button, int pressCount)
        {
            if (!KeypadMapping.TryGetValue(button, out string? letters) || letters == null)
            {
                throw new ArgumentException($"Invalid button: {button}", nameof(button));
            }

            // Press count is 1-indexed, so we subtract 1 to get 0-based index
            // Use modulo to cycle through letters if pressCount exceeds available letters
            int index = (pressCount - 1) % letters.Length;
            return letters[index];
        }
    }
}

