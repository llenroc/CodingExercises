using Xunit;

namespace InterviewCake.Tests
{
    public class ChapterOne_ArraysTests
    {
        [Fact]
        public void IsFirstComeFirstSeredTests_returnsFalse()
        {
            // Arrange & Act
            var result = ChapterOne_Arrays.IsFirstComeFirstServed(new int[] {1, 3, 5}, new int[] {2, 4, 6}, new int[] {1, 2, 4, 6, 5, 3});
            
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsFirstComeFirstSeredTests_returnsTrue()
        {
            // Arrange & Act
            var result = ChapterOne_Arrays.IsFirstComeFirstServed(new int[] {17, 8, 24}, new int[] {12, 19, 2}, new int[] {17, 8, 12, 19, 24, 2});
            
            // Assert
            Assert.True(result);
        }
    }
}
