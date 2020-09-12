using Xunit;

namespace Screens.Tests
{
    public class CompassTests
    {
        [Fact]
        public void IsValidTest_WithOnlyOneStarString_returnTrue()
        {
            // Arrange
            string input = "thereaddress";

            // Act
            bool result = Compass.ContainsValidWords(input);

            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void IsValidTest_WithOnlyOneStarString_returnFalse()
        {
            // Arrange
            string input = "thereadress";

            // Act
            bool result = Compass.ContainsValidWords(input);

            // Assert
            Assert.False(result);
        }
    }
}