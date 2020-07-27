using Xunit;

namespace HackerRank.Tests
{
    public class ThePowerSumTests
    {
        [Fact]
        public void PowerSumTests_returnsPossibleCandidates()
        {
            // Arrange
            int expected = 1;

            // Act
            var result = ThePowerSum.PowerSum(100, 3);
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void PowerSumTests_returnsCandidates()
        {
            // Arrange
            int expected = 3;

            // Act
            var result = ThePowerSum.PowerSum(100, 2);
            
            // Assert
            Assert.Equal(expected, result);
        }
    }
}