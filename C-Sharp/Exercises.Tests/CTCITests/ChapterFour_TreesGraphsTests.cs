using Xunit;

namespace CTCI.Tests
{
    public class CreateBSTFromArrayTests
    {
        [Fact]
        public void CreateBSTFromArrayTests_returnsBST()
        {
            // Arrange
            int[] input = new int[] { 3, 5, 6, 9, 10 };

            // Act
            var result = ChapterFour_TreesGraphs.CreateBSTFromArray(input);
            
            // Assert
            Assert.Equal(result.Root.L.Data, 5);
            Assert.Equal(result.Root.Data, 6);
            Assert.Equal(result.Root.R.Data, 9);
        }

        [Fact]
        public void CreateBSTFromArrayTests_returnsComplexBST()
        {
            // Arrange
            int[] input = new int[] { 0, 3, 4, 5, 6, 9, 10, 25, 30, 99 };

            // Act
            var result = ChapterFour_TreesGraphs.CreateBSTFromArray(input);
            
            // Assert
            Assert.Equal(result.Root.L.Data, 4);
            Assert.Equal(result.Root.Data, 9);
            Assert.Equal(result.Root.R.Data, 25);
        }
    }
}