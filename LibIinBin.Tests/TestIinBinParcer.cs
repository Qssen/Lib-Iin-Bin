using libIinBin;
using System;
using libIinBin.Exception;
using Xunit;
using static libIinBin.Model.IdentifierType;

namespace LibIinBin.Tests
{
    public class TestIinBinParcer
    {
        [Fact]
        public void IinBinParser_Test_Should_Throw_ArgumentNullException()
        {
            //Arrange
            string iinOrBin = null;

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                IinBinParser.Validate(iinOrBin);
            });
        }

        [Theory]
        [InlineData("08114")]
        [InlineData("08114000043É")]
        public void IinBinParser_Test_Should_Throw_InvalidIdentifierException(string iinOrBin)
        {
            Assert.Throws<InvalidIdentifierException>(() =>
            {
                IinBinParser.Validate(iinOrBin);
            });
        }

        [Fact]
        public void IinBinParser_Should_Return_IdentifierType_Equals_Bin()
        {
            //Arrange
            var bin = "081140000431";
            
            //Act 
            var response = IinBinParser.Validate(bin);

            //Assert
            Assert.Equal(response.IdentifierType, Bin);
        }

        [Fact]
        public void IinBinParser_Should_Return_IdentifierType_Equals_Iin()
        {
            //Arrange
            var iin = "980906399250";

            //Act 
            var response = IinBinParser.Validate(iin);

            //Assert
            Assert.Equal(response.IdentifierType, Iin);
        }

        [Theory]
        [InlineData("984620980906")]
        [InlineData("991340026265")]
        public void IinBinParser_Should_Throw_FormatException_CauseInvalidDateTime(string iinBin)
        {
            Assert.Throws<FormatException>(() =>
            {
                IinBinParser.Validate(iinBin);
            });
        }
    }
}
