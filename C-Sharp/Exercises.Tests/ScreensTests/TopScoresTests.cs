using System;
using Xunit;

namespace Screens.Tests
{
    public class TopScoresTests
    {
        // TODO: Fix test case due to Singletone, meantime run the test independently
        [Fact]
        public void InstanceTests_returnsSingletonInstance()
        {
            // Arrange
            int[] input = new int[] {1};
            TopScores result = TopScores.Instance;
            result.Insert(input);
            
            // Act
            TopScores r = TopScores.Instance;

            // Assert
            Assert.Equal(r.Scores.Length, result.Scores.Length); 
        }

        // TODO: Fix test case due to Singletone, meantime run the test independently
        [Fact]
        public void InsertTests_returnsTopScoresSorted()
        {
            // Arrange
            int[] input = new int[] {12, 5, 2, 98 ,24, 7, 5, 65, 0, 1, 100, 99};
            TopScores result = TopScores.Instance;
            int expected = 10;
            
            // Act
            result.Insert(input);

            // Assert
            Assert.Equal(expected, result.Scores.Length); 
        }

        [Fact]
        public void DeleteTests_returnsTopScoresWihAvailableSpots()
        {
            // Arrange
            int expected = 6;
            
            int[] input = new int[] {12, 5, 2, 98 ,24, 7, 5, 65, 0, 1, 100, 99};

            // Delete 5 from TopScores and 1 from AdditionalScores
            int[] toDelete = new int[] {98 ,24, 7, 5, 65, 0}; 
            
            TopScores result = TopScores.Instance;
            result.Insert(input);
            
            // Act
            result.Delete(toDelete);

            // Assert
            Assert.Equal(expected, result.Scores.Length); 
        }
    }
}
