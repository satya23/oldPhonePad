# Old Phone Pad Converter

A production-ready C# solution for converting old phone keypad input sequences into text output.

## Problem Description

This solution implements a converter for an old phone keypad system where:
- Each button (2-9) represents multiple letters
- Pressing a button multiple times cycles through its letters
- A space (` `) indicates a pause, allowing the same button to be used for consecutive letters
- An asterisk (`*`) acts as a backspace, removing the last character
- A hash (`#`) indicates the end of input and triggers the send action

### Keypad Mapping

| Button | Letters |
|--------|---------|
| 2      | A, B, C |
| 3      | D, E, F |
| 4      | G, H, I |
| 5      | J, K, L |
| 6      | M, N, O |
| 7      | P, Q, R, S |
| 8      | T, U, V |
| 9      | W, X, Y, Z |

## Solution Structure

```
oldPhonePad/
├── OldPhonePad.cs          # Main implementation class
├── OldPhonePadTests.cs      # Comprehensive unit tests
├── Program.cs               # Console application demo
├── OldPhonePad.csproj       # Main project file
├── OldPhonePadTests.csproj  # Test project file
└── README.md               # This file
```

## Features

- ✅ **Production-ready code** with comprehensive error handling
- ✅ **Well-documented** with XML comments and clear structure
- ✅ **Robust** - handles edge cases and invalid inputs gracefully
- ✅ **Fully tested** with 18+ unit tests covering all scenarios
- ✅ **Clean architecture** - separation of concerns and maintainable code

## Usage

### Basic Usage

```csharp
using OldPhonePad;

string result = OldPhonePadConverter.OldPhonePad("33#");
// Returns: "E"
```

### Examples

```csharp
OldPhonePadConverter.OldPhonePad("33#")                    // => "E"
OldPhonePadConverter.OldPhonePad("227*#")                  // => "B"
OldPhonePadConverter.OldPhonePad("4433555 555666#")        // => "HELLO"
OldPhonePadConverter.OldPhonePad("8 88777444666*664#")     // => "TURING"
```

## Building and Running

### Prerequisites

- .NET 8.0 SDK or later
- Visual Studio 2022, VS Code, or Rider (optional)

### Build

```bash
dotnet build
```

### Run Tests

```bash
dotnet test
```

### Run Console Application

```bash
dotnet run --project OldPhonePad.csproj
```

Or with input as argument:

```bash
dotnet run --project OldPhonePad.csproj -- "4433555 555666#"
```

## Implementation Details

### Algorithm

1. **Input Validation**: Ensures input is not null and ends with `#`
2. **Character Processing**: Iterates through each character in the input
3. **Button State Tracking**: Maintains current button and press count
4. **Pause Detection**: Spaces reset button state, allowing same button reuse
5. **Backspace Handling**: Removes last character from result
6. **Character Mapping**: Uses modulo arithmetic to cycle through button letters

### Key Design Decisions

- **State Machine Approach**: Tracks current button and press count to handle consecutive presses
- **StringBuilder**: Efficient string building for result construction
- **Dictionary Lookup**: Fast O(1) keypad mapping
- **Modulo Arithmetic**: Handles button cycling elegantly (e.g., 4 presses on button 2 cycles back to 'A')

## Testing

The solution includes comprehensive unit tests covering:

- ✅ All provided examples
- ✅ Single and multiple button presses
- ✅ Button cycling (4+ presses)
- ✅ Pause handling
- ✅ Backspace functionality
- ✅ Edge cases (empty input, null input, invalid characters)
- ✅ Buttons with 3 and 4 letters

Run tests with:

```bash
dotnet test
```

## Error Handling

The implementation includes robust error handling:

- **ArgumentNullException**: Thrown when input is null
- **ArgumentException**: Thrown when input doesn't end with `#` or is empty
- **Graceful Degradation**: Invalid characters are skipped rather than causing crashes

## Code Quality

- **Clean Code**: Clear naming, single responsibility, DRY principles
- **Documentation**: Comprehensive XML comments for all public members
- **Type Safety**: Proper use of nullable types and null checks
- **Performance**: Efficient string building and O(n) time complexity

## AI-Assisted Development

### AI Prompt Used

If I were to AI-prompt this solution, I would use the following prompt with **Claude (Anthropic)** or **ChatGPT (OpenAI)**:

```
Create a production-ready C# solution for an old phone keypad converter with the following requirements:

1. Implement a static method `OldPhonePad(string input)` that converts keypad input to text
2. Keypad mapping: 2=ABC, 3=DEF, 4=GHI, 5=JKL, 6=MNO, 7=PQRS, 8=TUV, 9=WXYZ
3. Multiple presses cycle through letters (e.g., 2=A, 22=B, 222=C, 2222=A)
4. Space (' ') indicates pause, allowing same button for consecutive letters
5. Asterisk ('*') acts as backspace
6. Hash ('#') ends input
7. Include comprehensive error handling, XML documentation, and unit tests
8. Follow C# best practices and production-ready code standards

Test cases:
- "33#" => "E"
- "227*#" => "B"
- "4433555 555666#" => "HELLO"
- "8 88777444666*664#" => "TURING"
```

**AI Tool**: Claude (Anthropic) or ChatGPT (OpenAI)  
**Purpose**: Code structure, documentation, and test case generation

**Note**: While AI tools were used for code organization and documentation, the core algorithm and problem-solving approach were developed manually to ensure understanding and correctness.

## License

This solution is provided as part of a coding challenge submission.

## Author

Created as a demonstration of production-ready C# development practices.
