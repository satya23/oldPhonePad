using System;
using Xunit;

namespace OldPhonePad.Tests
{
    /// <summary>
    /// Unit tests for the OldPhonePadConverter class.
    /// </summary>
    public class OldPhonePadConverterTests
    {
        [Fact]
        public void OldPhonePad_Example1_ReturnsE()
        {
            // Arrange
            string input = "33#";

            // Act
            string result = OldPhonePadConverter.OldPhonePad(input);

            // Assert
            Assert.Equal("E", result);
        }

        [Fact]
        public void OldPhonePad_Example2_ReturnsB()
        {
            // Arrange
            string input = "227*#";

            // Act
            string result = OldPhonePadConverter.OldPhonePad(input);

            // Assert
            Assert.Equal("B", result);
        }

        [Fact]
        public void OldPhonePad_Example3_ReturnsHELLO()
        {
            // Arrange
            string input = "4433555 555666#";

            // Act
            string result = OldPhonePadConverter.OldPhonePad(input);

            // Assert
            Assert.Equal("HELLO", result);
        }

        [Fact]
        public void OldPhonePad_Example4_ReturnsTURING()
        {
            // Arrange
            string input = "8 88777444666*664#";

            // Act
            string result = OldPhonePadConverter.OldPhonePad(input);

            // Assert
            Assert.Equal("TURING", result);
        }

        [Fact]
        public void OldPhonePad_SinglePress_ReturnsFirstLetter()
        {
            // Arrange
            string input = "2#";

            // Act
            string result = OldPhonePadConverter.OldPhonePad(input);

            // Assert
            Assert.Equal("A", result);
        }

        [Fact]
        public void OldPhonePad_DoublePress_ReturnsSecondLetter()
        {
            // Arrange
            string input = "22#";

            // Act
            string result = OldPhonePadConverter.OldPhonePad(input);

            // Assert
            Assert.Equal("B", result);
        }

        [Fact]
        public void OldPhonePad_TriplePress_ReturnsThirdLetter()
        {
            // Arrange
            string input = "222#";

            // Act
            string result = OldPhonePadConverter.OldPhonePad(input);

            // Assert
            Assert.Equal("C", result);
        }

        [Fact]
        public void OldPhonePad_FourPresses_CyclesBackToFirst()
        {
            // Arrange
            string input = "2222#";

            // Act
            string result = OldPhonePadConverter.OldPhonePad(input);

            // Assert
            Assert.Equal("A", result); // Cycles back to first letter
        }

        [Fact]
        public void OldPhonePad_WithPause_SameButtonTwice()
        {
            // Arrange
            string input = "22 2#";

            // Act
            string result = OldPhonePadConverter.OldPhonePad(input);

            // Assert
            Assert.Equal("BA", result);
        }

        [Fact]
        public void OldPhonePad_MultipleBackspaces_RemovesCharacters()
        {
            // Arrange
            string input = "222***#";

            // Act
            string result = OldPhonePadConverter.OldPhonePad(input);

            // Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void OldPhonePad_BackspaceAtStart_NoEffect()
        {
            // Arrange
            string input = "*2#";

            // Act
            string result = OldPhonePadConverter.OldPhonePad(input);

            // Assert
            Assert.Equal("A", result);
        }

        [Fact]
        public void OldPhonePad_BackspaceCancelsPendingPress()
        {
            // Arrange
            string input = "22*#";

            // Act
            string result = OldPhonePadConverter.OldPhonePad(input);

            // Assert
            // Two presses would be 'B', but the backspace cancels the pending character before it is committed
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void OldPhonePad_InvalidCharactersAreIgnored()
        {
            // Arrange
            string input = "2X3#"; // 'X' should be ignored

            // Act
            string result = OldPhonePadConverter.OldPhonePad(input);

            // Assert
            // '2' -> A, pause due to invalid 'X' is effectively ignored, then '3' -> D
            Assert.Equal("AD", result);
        }

        [Fact]
        public void OldPhonePad_ComplexSequence_HandlesCorrectly()
        {
            // Arrange
            string input = "4433555 555666*#";

            // Act
            string result = OldPhonePadConverter.OldPhonePad(input);

            // Assert
            Assert.Equal("HELL", result); // Backspace removes the last 'O'
        }

        [Fact]
        public void OldPhonePad_Button7_FourLetters()
        {
            // Arrange
            string input = "7777#";

            // Act
            string result = OldPhonePadConverter.OldPhonePad(input);

            // Assert
            Assert.Equal("S", result);
        }

        [Fact]
        public void OldPhonePad_Button9_FourLetters()
        {
            // Arrange
            string input = "9999#";

            // Act
            string result = OldPhonePadConverter.OldPhonePad(input);

            // Assert
            Assert.Equal("Z", result);
        }

        [Fact]
        public void OldPhonePad_NullInput_ThrowsArgumentNullException()
        {
            // Arrange
            string? input = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => OldPhonePadConverter.OldPhonePad(input!));
        }

        [Fact]
        public void OldPhonePad_EmptyInput_ThrowsArgumentException()
        {
            // Arrange
            string input = "";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => OldPhonePadConverter.OldPhonePad(input));
        }

        [Fact]
        public void OldPhonePad_NoHash_ThrowsArgumentException()
        {
            // Arrange
            string input = "22";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => OldPhonePadConverter.OldPhonePad(input));
        }

        [Fact]
        public void OldPhonePad_OnlyHash_ReturnsEmpty()
        {
            // Arrange
            string input = "#";

            // Act
            string result = OldPhonePadConverter.OldPhonePad(input);

            // Assert
            Assert.Equal("", result);
        }
    }
}

