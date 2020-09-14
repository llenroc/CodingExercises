using System.Collections.Generic;
using Xunit;

namespace HackerRank.Tests
{
    public class RoadsAndLibrariesTests
    {
        [Fact]
        public void RoadsAndLibrariesTest_returnsTrue()
        {
            // Arrange
            int expected = 4;
            int n = 3;
            int c_lib = 2;
            int c_road = 1;
            int[][] cities = new int[n][];
            cities[0] = new int[] { 1, 2 };
            cities[1] = new int[] { 3, 1 };
            cities[2] = new int[] { 2, 3 };

            // Act
            long result = RoadsAndLibraries.GetRoadsAndLibraries(n, c_lib, c_road, cities);
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void RoadsAndLibrariesTest_returnsTwelve()
        {
            // Arrange
            int expected = 12;
            int n = 6;
            int c_lib = 2;
            int c_road = 5;
            int[][] cities = new int[n][];
            cities[0] = new int[] { 1, 3 };
            cities[1] = new int[] { 3, 4 };
            cities[2] = new int[] { 2, 4 };
            cities[3] = new int[] { 1, 2 };
            cities[4] = new int[] { 2, 3 };
            cities[5] = new int[] { 5, 6 };

            // Act
            long result = RoadsAndLibraries.GetRoadsAndLibraries(n, c_lib, c_road, cities);
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void RoadsAndLibrariesTest_returnsIsolatedCities()
        {
            // Arrange
            int expected = 184;
            int n = 5;
            int c_lib = 92;
            int c_road = 23;
            int[][] cities = new int[9][];
            cities[0] = new int[] { 2, 1 };
            cities[1] = new int[] { 5, 3 };
            cities[2] = new int[] { 5, 1 };
            cities[3] = new int[] { 3, 4 };
            cities[4] = new int[] { 3, 1 };
            cities[5] = new int[] { 5, 4 };
            cities[6] = new int[] { 4, 1 };
            cities[7] = new int[] { 5, 2 };
            cities[8] = new int[] { 4, 1 };

            // Act
            long result = RoadsAndLibraries.GetRoadsAndLibraries(n, c_lib, c_road, cities);
            
            // Assert
            Assert.Equal(expected, result);
        }
    }
}