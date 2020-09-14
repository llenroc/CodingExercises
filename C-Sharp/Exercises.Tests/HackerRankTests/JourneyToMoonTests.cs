using System.Collections.Generic;
using Xunit;

namespace HackerRank.Tests
{
    public class JourneyToMoonTests
    {
        [Fact]
        public void GetPasswordCrackerTest_returnsTrue()
        {
            // Arrange
            int expected = 6;
            int[][] astronaut = new int[3][];
            astronaut[0] = new int[] { 0, 1 };
            astronaut[1] = new int[] { 2, 3 };
            astronaut[2] = new int[] { 0, 4 };
            int n = 5;

            // Act
            int result = JourneyToMoon.GetJourneyToMoonCombo(n, astronaut);
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetPasswordCrackerTest_returnsPairs()
        {
            // Arrange
            int expected = 5;
            int[][] astronaut = new int[1][];
            astronaut[0] = new int[] { 0, 2 };
            int n = 4;

            // Act
            int result = JourneyToMoon.GetJourneyToMoonCombo(n, astronaut);
            
            // Assert
            Assert.Equal(expected, result);
        }
    }
}