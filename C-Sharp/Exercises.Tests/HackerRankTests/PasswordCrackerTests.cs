using System.Collections.Generic;
using Xunit;

namespace HackerRank.Tests
{
    public class PasswordCrackerTests
    {
        [Fact]
        public void GetPasswordCrackerTest_returnsTrue()
        {
            // Arrange
            string expected = "we do what we must because we can";
            List<string> passwords = new List<string>() {
                "because",
                "can",
                "do",
                "must",
                "we",
                "what"
            };
            string intent = "wedowhatwemustbecausewecan";

            // Act
            string result = PasswordCracker.GetPasswordCracker(passwords, intent);
            
            // Assert
            Assert.Equal(expected, result);
        }
    }
}