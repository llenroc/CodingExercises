using Xunit;

namespace HackerRank.Tests
{
    public class RectangularPlotTets
    {
        [Fact]
        public void GetMaxPerimeterTests()
        {
            // Arrange
            int expected = 1;
            string[] input = new string[] {
                ".x",
                "x."
           };

            // Act
            int result = RectangularPlot.GetMaxPerimeter(input);
            
            // Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void GetMaxPerimeter()
        {
            // Arrange
            int expected = 20;
            string[] input = new string[] {
                ".....",
                ".x.x.",
                ".....",
                ".....",
           };

            // Act
            int result = RectangularPlot.GetMaxPerimeter(input);
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetMaxPerimeter_restursValidNumber()
        {
            // Arrange
            int expected = 16;
            string[] input = new string[] {
                "....x",
                ".....",
                ".....",
                "x.x..",
                ".....",
                ".x...",
                "...x."
           };

            // Act
            int result = RectangularPlot.GetMaxPerimeter(input);
            
            // Assert
            Assert.Equal(expected, result);
        }
    }
}