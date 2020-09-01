using System.Collections.Generic;
using Xunit;

namespace Screens.Tests
{
    public class UtilTests
    {
        [Fact]
        public void GetWordsCombos_returnsTrue()
        {
            // Arrange
            List<string> input = new List<string>() {
                "because",
                "can",
                "do",
                "must",
                "we",
                "what"
            };

            // Act
            var result = input.GetWordsCombos();

            foreach (var item in result)
            {
                foreach (var w in item)
                {
                    System.Console.Write(w);
                }
                System.Console.WriteLine();
            }

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetWordsPermutationsTests_returnsTrue()
        {
            // Arrange
            List<string> input = new List<string>() {
                "1",
                "2",
                "3",
                "4"
            };

            // Act
            var result = input.GetWordsPermutations();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetCombosTests_returnsCombos()
        {
            // Arrange
            string input = "1234";

            // Act
            var result = input.GetCombos();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetPermutationsTests_returnsPerms()
        {
            // Arrange
            string input = "test";
            
            // Act
            var result = input.GetPermutations();
            
            // Assert
            Assert.NotNull(result);
        }
    }
}