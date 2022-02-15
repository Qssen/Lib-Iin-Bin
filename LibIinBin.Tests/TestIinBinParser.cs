using libIinBin;
using System;
using libIinBin.Exception;
using libIinBin.Model;
using Xunit;
using static libIinBin.Model.IdentifierType;

namespace LibIinBin.Tests
{
    public class TestIinBinParser
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
        public void IinBinParser_Should_Return_IdentifierType_Equals_Type_Bin()
        {
            //Arrange
            var bin = "081140000431";

            //Act 
            var response = IinBinParser.Validate(bin);

            //Assert
            Assert.IsType<BinInformation>(response.BaseIdentifierInformation);
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

        [Fact]
        public void IinBinParser_Should_Return_IdentifierType_Equals_Type_Iin()
        {
            //Arrange
            var iin = "980906399250";

            //Act 
            var response = IinBinParser.Validate(iin);

            //Assert
            Assert.IsType<IinInformation>(response.BaseIdentifierInformation);
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

        [Theory]
        [InlineData("980906350976")]
        [InlineData("850413402609")]
        [InlineData("780605402865")]
        [InlineData("660221402774")]

        [InlineData("081140000436")]
        [InlineData("000140002217")]
        [InlineData("020540003431")]
        [InlineData("991140001226")]
        public void IinBinParser_Should_ReturnBaseIdentifierInformation(string iinOrBin)
        {
            var response = IinBinParser.Validate(iinOrBin);

            Assert.NotNull(response.BaseIdentifierInformation);
        }

        [Theory]
        [InlineData("980906350976")]
        [InlineData("850413402609")]
        [InlineData("780605402865")]
        [InlineData("660221402774")]
        public void IinBinParser_Should_ReturnIinIdentifierInformation(string iinOrBin)
        {
            var response = IinBinParser.Validate(iinOrBin);

            Assert.NotNull(response.IinInformation);
        }

        [Theory]
        [InlineData("081140000436")]
        [InlineData("000140002217")]
        [InlineData("020540003431")]
        [InlineData("991140001226")]
        public void IinBinParser_Should_ReturnBinIdentifierInformation(string iinOrBin)
        {
            var response = IinBinParser.Validate(iinOrBin);

            Assert.NotNull(response.BinInformation);
        }
    }
}
