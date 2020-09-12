using System;
using Xunit;

namespace Screens.Tests
{
    public class DocusignTests
    {
        [Fact]
        public void GetRangeSumTests_returnTrue()
        {
            // Arrange
            int[][] input = new int[][] {
                new int[] { 1, 2, 3, 4 },
                new int[] { 4, 5, 6, 7 },
                new int[] { 8, 9, 0, 1 },
                new int[] { 1, 2, 3, 4 }
            };
            int expected = 3;

            // Act
            int result = Docusign.GetRangeSum(input, 2, 2, 3, 2);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetRangeSumTests_returnOne()
        {
            // Arrange
            int[][] input = new int[][] {
                new int[] { 1, 2, 3, 4 },
                new int[] { 4, 5, 6, 7 },
                new int[] { 8, 9, 0, 1 },
                new int[] { 1, 2, 3, 4 }
            };
            int expected = 1;

            // Act
            int result = Docusign.GetRangeSum(input, 0, 0, 0, 0);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetRangeSumTests_returnSixty()
        {
            // Arrange
            int[][] input = new int[][] {
                new int[] { 1, 2, 3, 4 },
                new int[] { 4, 5, 6, 7 },
                new int[] { 8, 9, 0, 1 },
                new int[] { 1, 2, 3, 4 }
            };
            int expected = 60;

            // Act
            int result = Docusign.GetRangeSum(input, 0, 0, 3, 3);

            // Assert
            Assert.Equal(expected, result);
        }


        [Fact]
        public void GetBirthday_test()
        {
            // Arrange
            int m = 8;
            int d = 4;

            // Act
            double result = Docusign.GetBirthday(m, d);

            // Assert
            Assert.True(8.04 == result);
        }
    }
}