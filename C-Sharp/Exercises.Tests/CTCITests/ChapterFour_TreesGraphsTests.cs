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
            BinarySearchTree result = ChapterFour_TreesGraphs.CreateBSTFromArray(input);
            
            // Assert
            Assert.Equal(result.Root.L.Data, input[1]);
            Assert.Equal(result.Root.Data, input[2]);
            Assert.Equal(result.Root.R.Data, input[3]);
        }

        [Fact]
        public void CreateBSTFromArrayTests_returnsComplexBST()
        {
            // Arrange
            int[] input = new int[] { 0, 3, 4, 5, 6, 9, 10, 25, 30, 99 };

            // Act
            BinarySearchTree result = ChapterFour_TreesGraphs.CreateBSTFromArray(input);
            
            // Assert
            Assert.Equal(result.Root.L.Data, input[2]);
            Assert.Equal(result.Root.Data, input[5]);
            Assert.Equal(result.Root.R.Data, input[7]);
        }
    }
}