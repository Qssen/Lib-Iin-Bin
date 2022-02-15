using System;
using System.Globalization;
using libIinBin.Exception;
using libIinBin.Model;

namespace libIinBin.Parser
{
    internal static class IinParser
    {
        private const int PersonSexIndex = 6;
        private const string IinRegistrationDateFormat = "yyMMdd";
        internal static IinInformation GetIinInformation(string identifier)
        {
            var result = new IinInformation();

            //yyMMdd
            var dtStr = identifier.Substring(0, 6);

            result.BirthDate = DateTime.ParseExact(dtStr, IinRegistrationDateFormat, CultureInfo.CurrentCulture);

            var sexValue = (byte)char.GetNumericValue(identifier, PersonSexIndex);

            if (sexValue > 6)
                throw new InvalidIdentifierException($"Error at index - {PersonSexIndex}. Value can not be greater than 6");

            if (sexValue != 1 && sexValue % 2 == 0)
                result.Sex = Sex.Female;

            result.RegistrationNumber = identifier[7..10];

            result.CheckSum = (byte) char.GetNumericValue(identifier, 11);
            
            return result;
        }
    }
}