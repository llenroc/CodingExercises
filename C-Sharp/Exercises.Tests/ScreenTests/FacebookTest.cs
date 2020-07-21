using Xunit;

namespace Screen.Tests
{
    public class FacebookTests
    {
        [Fact]
        public void GetMinString_returnsString()
        {
            // Arrange
            string s = "baaacbccac";
            string chars = "cba";

            // Act
            var result = Facebook.GetMinString(s, chars);

            // Assert
            Assert.Equal(3, result.Length);
        }
    }
}