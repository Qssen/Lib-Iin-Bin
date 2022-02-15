using System;
using libIinBin.Exception;
using libIinBin.Parser;
using Xunit;

namespace LibIinBin.Tests
{
    public class TestBinParser
    {
        [Theory]
        [InlineData("111111111111")]
        [InlineData("111122222222")]
        [InlineData("111133333333")]
        [InlineData("111177777777")]
        [InlineData("111188888888")]
        [InlineData("111199999999")]
        [InlineData("081144000436")]
        [InlineData("081145000436")]
        public void BinParser_Should_Throw_InvalidIdentifierException(string bin)
        {
            Assert.Throws<InvalidIdentifierException>(() =>
            {
                BinParser.GetBinInformation(bin);
            });
        }

        [Fact]
        public void BinParser_Should_Throw_FormatException()
        {
            var bin = "222222222222";

            Assert.Throws<FormatException>(() =>
            {
                BinParser.GetBinInformation(bin);
            });
        }
    }
}