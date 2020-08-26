using System;
using System.Collections.Generic;
using Xunit;

namespace Screens.Tests
{
    public class SquareTests
    {
        [Fact]
        public void BuildDicTest_returnsTrue()
        {
            // Arrange
            string[] input1 = new string[] { "a" };
            int[] input2 = new int[] { 1 };

            // Act
            Dictionary<String, Object> result = Square.BuildDic(input1, input2);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void BuildDicTest_returnsValidResult()
        {
            // Arrange
            string[] input1 = new string[] { "a.b", "c.d.e" };
            int[] input2 = new int[] { 1, 2 };

            // Act
            Dictionary<String, Object> result = Square.BuildDic(input1, input2);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void BuildDicTest_returnsNotNullResult()
        {
            // Arrange
            string[] input1 = new string[] { "a", "c" };
            int[] input2 = new int[] { 1, 2 };

            // Act
            Dictionary<String, Object> result = Square.BuildDic(input1, input2);

            // Assert
            Assert.NotNull(result);
        }
    }
}