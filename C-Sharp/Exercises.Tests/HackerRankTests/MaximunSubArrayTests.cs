using System.Collections.Generic;
using Xunit;

namespace HackerRank.Tests
{
    public class MaximunSubArrayTests
    {
        [Fact]
        public void GetMaximunSubArrayTest_returnsTrue()
        {
            // Arrange
            int[] expected = new int[] { 10, 11 };
            int[] input = new int[] { 2, -1, 2, 3, 4, -5 };
            
            // Act
            int[] result = MaximunSubArray.GetMaxSubarray (input);
            
            // Assert
            Assert.Equal(expected[0], result[0]);
            Assert.Equal(expected[1], result[1]);
        }
    }
}