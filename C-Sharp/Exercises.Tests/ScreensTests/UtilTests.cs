using Xunit;

namespace Screens.Tests
{
    public class UtilTests
    {
        [Fact]
        public void GetCombosTests_returnsCombos()
        {
            // Arrange
            string input = "test";

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