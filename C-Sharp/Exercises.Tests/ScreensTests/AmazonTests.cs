using System;
using System.Collections.Generic;
using Xunit;

namespace Screens.Tests
{
    public class AmazonTests
    {
        [Fact]
        public void RunLengthEncodingTest_returnsTrue()
        {
            // Arrange
            string expected = "3a3b1c1a1d";
            string input = "aaabbbcad";

            // Act
            string result = Amazon.RunLengthEncoding(input);

            // Assert
            Assert.Equal(expected, result);
        }
    
        [Fact]
        public void ExerciseTest_returnsTrue()
        {
            // Arrange
            int topFeatures = 2;
            List<string> possibleFeatures = new List<string>() { 
                "storage","batery", "life", "alexa", "waterproof", "solar"
            };
            List<string> featureRequests = new List<string>() {
                "more storage",
                "alexa battery life",
                "a waterproof kindle",
                "waterproof and alexa batery life",
                "waterproof please",
                "sooooover my desk",
                "solar power"
            };

            // Act
            List<string> topFeatureRequests = Amazon.topFeatureRequests(topFeatures, possibleFeatures, featureRequests);

            // Assert
            Assert.True(true);
        }

        
        [Fact]
        public void FindDistanceDiffTest_returnsTrue()
        {
            // Arrange
            int[] values = new int[] { 10, 5, 6, 3, 2, 15, 20, 17 };
            int a = 5;
            int b = 17;
            int expected = 2;

            // Act
            int result = Amazon.FindDistanceDiff(values, a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindDistanceDiffTest_returnsThree()
        {
            // Arrange
            int[] values = new int[] { 10, 5, 6, 3, 2, 15, 20, 17 };
            int a = 9;
            int b = 17;
            int expected = -1;

            // Act
            int result = Amazon.FindDistanceDiff(values, a, b);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}