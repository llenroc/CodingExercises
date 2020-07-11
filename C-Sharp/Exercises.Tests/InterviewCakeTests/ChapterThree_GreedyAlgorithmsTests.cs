using Xunit;

namespace InterviewCake.Tests
{
    public class ChapterThree_GreedyAlgorithmsTests
    {
        [Fact]
        public void GetHighestProduct_returnsHighest()
        {
            // Arrange
            int expected = 5000;

            // Act
            int result = ChapterThree_GreedyAlgorithms.GetHighestProduct(new int[]{ 1, 10, -5, 1, -100 });

            // Assert
            Assert.Equal(result, expected); // (10 * -5 * -100)
        }
    }
}