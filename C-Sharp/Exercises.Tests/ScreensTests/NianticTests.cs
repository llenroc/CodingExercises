using System;
using Xunit;

namespace Screens.Tests
{
    public class NianticTests
    {
        [Fact]
        public void GetSumTest_returnsValidResult()
        {
            // Arrange
            int expected = 27; // 1*1 + 4*2 + 6*3 = 27

            // [1,[4,[6]]]
            NestedValue multipleInts = new NestedValue();
            multipleInts.Add(new NestedValue(6));

            NestedValue multipleIntegers = new NestedValue();
            multipleIntegers.Add(new NestedValue(4));
            multipleIntegers.Add(multipleInts);

            NestedValue input = new NestedValue();
            input.Add(new NestedValue(1));
            input.Add(multipleIntegers);

            // Act
            int result = Niantic.GetSum(input, 0);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetSumTest_returnsResult()
        {
            // Arrange
            int expected = 10; // (1+1)*2 + 2 * 1 + (1+1)*2 = 10

            // [[1,1],2,[1,1]]
            NestedValue multipleIntegers = new NestedValue();
            multipleIntegers.Add(new NestedValue(1));
            multipleIntegers.Add(new NestedValue(1));

            NestedValue multipleInts = new NestedValue();
            multipleInts.Add(new NestedValue(1));
            multipleInts.Add(new NestedValue(1));

            NestedValue input = new NestedValue();
            input.Add(multipleIntegers);
            input.Add(new NestedValue(2));
            input.Add(multipleInts);

            // Act
            int result = Niantic.GetSum(input, 0);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
