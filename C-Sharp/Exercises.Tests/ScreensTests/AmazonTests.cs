using System;
using Xunit;

namespace Screens.Tests
{
    public class AmazonTests
    {
        [Fact]
        public void RunLengthEncodingTest_returnsTrue()
        {
            // Arrange
            string expected = "3a3b1c1a1d";
            string input = "aaabbbcad";

            // Act
            string result = Amazon.RunLengthEncoding(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}