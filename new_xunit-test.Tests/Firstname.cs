using System;
using ValidateTheNameModelBinding.Models;  
using Xunit;

namespace new_xunit_test.Tests
{
    public class FirstnameTests
    {
        [Theory]
        [InlineData("Anna")]
        [InlineData("John")]
        [InlineData("Sofie")]
        public void Constructor_ValidFirstname_DoesNotThrow(string validName)
        {
            var exception = Record.Exception(() => new Firstname(validName));
            Assert.Null(exception);  
        }

        [Theory]
        [InlineData("")]
        [InlineData("A")]
        [InlineData("ThisNameIsWayTooLongToBeValidBecauseItIsOverTwentyCharacters")]
        [InlineData("Name123")]
        [InlineData("Name!@#")]
        public void Constructor_InvalidFirstname_ThrowsArgumentException(string invalidName)
        {
            Assert.Throws<ArgumentException>(() => new Firstname(invalidName));
        }
    }
}
