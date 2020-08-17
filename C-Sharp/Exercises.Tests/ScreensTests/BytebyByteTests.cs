using System;
using Xunit;

namespace Screens.Tests
{
    public class BytebyByteTests
    {
        [Fact]
        public void KnapsackTest_returnsMaxValue()
        {
            // Arrange
            int expected = 22;
            Item[] items = new [] {
                new Item(1, 6),
                new Item(2, 10),
                new Item(3, 12)
            };

            // Act
            int result = BytebyByte.Knapsack(items, expected);

            // Assert
            Assert.Equal(expected, result);
        }

                [Fact]
        public void KnapsackTest_withUnsortedItemsReturnsMaxValue()
        {
            // Arrange
            int expected = 22;
            Item[] items = new [] {
                new Item(3, 12),
                new Item(1, 6),
                new Item(2, 10)
            };

            // Act
            int result = BytebyByte.Knapsack(items, expected);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetBigestSquareSubmatrixTest_returnsMax()
        {
            // Arrange
            int[][] matrix = new [] {
                new [] {0,1,1,0},
                new [] {1,1,1,1},
                new [] {1,1,1,1},
                new [] {1,1,1,0}
            };
            int expected = 3;
            
            // Act
            int result = BytebyByte.GetBigestSquareSubmatrix(matrix);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetBigestSquareSubmatrixTest_returnsOne()
        {
            // Arrange
            int[][] matrix = new [] {
                new [] {0,1,1,0},
                new [] {1,0,1,1},
                new [] {0,1,0,1},
                new [] {1,1,0,0}
            };
            int expected = 1;
            
            // Act
            int result = BytebyByte.GetBigestSquareSubmatrix(matrix);

            // Assert
            Assert.Equal(expected, result);
        }

                [Fact]
        public void GetBigestSquareSubmatrixTest_returnsZero()
        {
            // Arrange
            int[][] matrix = new [] {
                new [] {0,0},
                new [] {0,0}
            };
            int expected = 0;
            
            // Act
            int result = BytebyByte.GetBigestSquareSubmatrix(matrix);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}