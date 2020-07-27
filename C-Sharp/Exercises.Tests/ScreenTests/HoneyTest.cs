using System;
using Xunit;

namespace Screen.Tests
{
    public class HoneyTests
    {
        [Fact]
        public void IsValidTest_WithOnlyOneStarString_returnTrue()
        {
            // Arrange
            string input = "*";

            // Act
            bool result = Honey.IsValid(input);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsValidTest_WithOnlyOneBracketString_returnFalse()
        {
            // Arrange
            string input = "[";

            // Act
            bool result = Honey.IsValid(input);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidTest_WithEmptyString_returnTrue()
        {
            // Arrange
            string input = "";

            // Act
            bool result = Honey.IsValid(input);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsValidTest_returnTrue()
        {
            // Arrange
            string input = "[[*]*";

            // Act
            bool result = Honey.IsValid(input);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsValidTest_returnFalse()
        {
            // Arrange
            string input = "[[**[[]";

            // Act
            bool result = Honey.IsValid(input);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidTest_isTrue()
        {
            // Arrange
            string input = "[[_]]";

            // Act
            bool result = Honey.IsValid(input.ToCharArray());

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsValidTest_isFalse()
        {
            // Arrange
            string input = "[[__[[]";

            // Act
            bool result = Honey.IsValid(input.ToCharArray());

            // Assert
            Assert.False(result);
        }
    }
}
