using Xunit;

namespace InterviewCake.Tests
{
    public class ChapterTwo_HashtablesTests
    {
        [Fact]
        public void SortScoresTests_retursScores()
        {
            // Arrange & Act
            var result = ChapterTwo_Hashtables.SortScores(new int[] {37, 89, 41, 65, 91, 53}, 100);
            
            // Assert
            Assert.True(result[0] == 91);
            Assert.True(result[result.Length - 1] == 37);
        }
    }
}