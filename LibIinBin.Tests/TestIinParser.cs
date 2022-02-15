using System;
using libIinBin.Exception;
using libIinBin.Model;
using libIinBin.Parser;
using Xunit;
using static libIinBin.Model.Sex;

namespace LibIinBin.Tests
{
    public class TestIinParser
    {
        [Theory]
        [InlineData("980906150976", Male)]
        [InlineData("980906350976", Male)]
        [InlineData("980906550976", Male)]

        [InlineData("980906250976", Female)]
        [InlineData("980906450976", Female)]
        [InlineData("980906650976", Female)]
        public void IinParser_Should_Return_Sex(string iin, Sex sex)
        {
            var response = IinParser.GetIinInformation(iin);
           
            Assert.Equal(response.Sex, sex);
        }

        [Fact]
        public void IinParser_Should_Throw_Format_Exception()
        {
            Assert.Throws<FormatException>(() =>
            {
                IinParser.GetIinInformation("081145000436");
            });
        }

        [Fact]
        public void IinParser_Should_Throw_Format_InvalidIdentifierException()
        {
            Assert.Throws<InvalidIdentifierException>(() =>
            {
                IinParser.GetIinInformation("980906750333");
            });
        }
    }
}
