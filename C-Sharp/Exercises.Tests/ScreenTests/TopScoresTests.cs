using System;
using Xunit;

namespace Screen.Tests
{
    public class TopScoresTests
    {
        [Fact]
        public void InstanceTests_returnsSingletonInstance()
        {
            // Arrange
            var input = new int[] {1};
            var result = TopScores.Instance;
            result.Insert(input);
            
            // Act
            var r = TopScores.Instance;

            // Assert
            Assert.Equal(r.Scores.Length, result.Scores.Length); 
        }

        [Fact]
        public void InsertTests_returnsTopScoresSorted()
        {
            // Arrange
            var input = new int[] {12, 5, 2, 98 ,24, 7, 5, 65, 0, 1, 100, 99};
            var result = TopScores.Instance;
            var expected = 10;
            
            // Act
            result.Insert(input);

            // Assert
            Assert.Equal(expected, result.Scores.Length); 
        }

                [Fact]
        public void DeleteTests_returnsTopScoresWihAvailableSpots()
        {
            // Arrange
            var expected = 6;
            
            var input = new int[] {12, 5, 2, 98 ,24, 7, 5, 65, 0, 1, 100, 99};

            // Delete 5 from TopScores and 1 from AdditionalScores
            var toDelete = new int[] {98 ,24, 7, 5, 65, 0}; 
            
            var result = TopScores.Instance;
            result.Insert(input);
            
            // Act
            result.Delete(toDelete);

            // Assert
            Assert.Equal(expected, result.Scores.Length); 
        }
    }
}
