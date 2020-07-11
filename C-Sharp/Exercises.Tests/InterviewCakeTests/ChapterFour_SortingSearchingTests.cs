using Xunit;

namespace InterviewCake.Tests
{
    public class ChapterFour_SortingSearchingTests
    {
        [Fact]
        public void FindRoationPointTests_returnsValidIndex()
        {
            // Arrange
            int expected = 7;
            
            // Act
            var result = ChapterFour_SortingSearching.FindRotationPoint(new int[] { 16, 17, 20, 21, 30, 39, 40, 12, 13, 14 });
            
            // Assert
            Assert.Equal(result, expected);
        }

        [Fact]
        public void FindRoationPointTests_returnsNoRotation()
        {
            // Arrange
            int expected = -1;
            
            // Act
            int result = ChapterFour_SortingSearching.FindRotationPoint(new int[] { 16, 17, 20, 21, 30, 39, 40 });
            
            // Assert
            Assert.Equal(result, expected);
        }

        [Fact]
        public void FindRoationPointTests_returnsIndex()
        {
            // Arrange
            int expected = 3;
            
            // Act
            int result = ChapterFour_SortingSearching.FindRotationPoint(new int[] { 16, 17, 20, 1 });
            
            // Assert
            Assert.Equal(result, expected);
        }
    }
}