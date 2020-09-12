using System;
using Xunit;

namespace HackerRank.Tests
{
    public class AbsolutePermutationTets
    {
        [Fact]
        public void GetAbsolutePermutation_returnsCorrectElements()
        {
            // Arrange
            int n = 3;
            int k = 0;
            int expected = 3;

            // Act
            int[] result = AbsolutePermutation.GetAbsolutePermutation(n, k);

            // Assert
            Assert.Equal(expected, result.Length);
        }

                [Fact]
        public void GetAbsolutePermutation_returnsTrue()
        {
            // Arrange
            int n = 2;
            int k = 1;

            // Act
            int[] result = AbsolutePermutation.GetAbsolutePermutation(n, k);

            // Assert
            Assert.NotNull(result);
        }
    }
}