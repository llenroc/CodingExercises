using Xunit;

namespace HackerRank.Tests
{
    public class GetLongestSubsequenceTests
    {
        [Fact]
        public void GetLongestSubsequenceTests_returnsLongestPossibleSubsequence()
        {
            // Arrange
            string s1 = "perez";
            string s2 = "mendez";
            string expected = "eez";

            // Act
            var result = LongestSubsequence.GetLongestSubsequence(s1, s2);
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetLongestSubsequenceTests_returnsLongestSubsequence()
        {
            // Arrange
            string s1 = "ABCBDAB";
            string s2 = "BDCABA";
            string expected = "BCBA";

            // Act
            var result = LongestSubsequence.GetLongestSubsequence(s1, s2);
            
            // Assert
            Assert.Equal(expected, result);
        }
    }
}