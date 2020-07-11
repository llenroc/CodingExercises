using Xunit;

namespace InterviewCake.Tests
{
    public class ChapterSix_DynamicProgrammingTests
    {
        [Fact]
        public void GetCoinChangeWaysTests_returnsValidResult()
        {
            // Arrange
            int expected = 4;
            
            // Act
            var result = ChapterSix_DynamicProgramming.GetCoinChangeWays(new int[] { 3, 2, 1 }, 4);
            
            // Assert
            Assert.Equal(result, expected);
        }

        [Fact]
        public void GetCoinChangeWaysTests_returnsResult()
        {
            // Arrange
            int expected = 5;
            
            // Act
            var result = ChapterSix_DynamicProgramming.GetEfficientCoinChange(new int[] { 3, 2, 1, 5 }, 19);
            
            // Assert
            Assert.Equal(result, expected);
        }
    }
}