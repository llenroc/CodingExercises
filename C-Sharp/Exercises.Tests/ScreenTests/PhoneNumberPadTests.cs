using System;
using Xunit;

namespace Screen.Tests
{
    public class PhoneNumberPadTests
    {
        [Fact]
        public void GetAllComboTests_returnsCobinations()
        {
            // Arrange
            var input = new int[] {2,4,5};
            
            // Act
            var result = PhoneNumberPad.GetAllCombos(input);

            // Assert
            Assert.Equal(27, result.Count); 
        }
    }
}