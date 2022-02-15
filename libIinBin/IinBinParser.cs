using System;
using System.Text.RegularExpressions;
using libIinBin.Exception;
using libIinBin.Model;
using libIinBin.Parser;

namespace libIinBin
{
    public static class IinBinParser
    {
       private static readonly Regex IinAndBinRegex = new("^\\d{12}$");

       private const byte PersonOrOrganizationFlagIndex = 4;
       private const byte OrganizationFlagMinValue = 4;

       public static IdentifierValidationResult Validate(string iinOrBin)
       {
           if (iinOrBin == null)
               throw new ArgumentNullException($"Param {nameof(iinOrBin)} can not be null");
           
           if (!IinAndBinRegex.IsMatch(iinOrBin))
               throw new InvalidIdentifierException(
                   $"Param {nameof(iinOrBin)} must be 12 chars long and only contains digits");

           var personOrOrganizationFlag = (byte)Char.GetNumericValue(iinOrBin, PersonOrOrganizationFlagIndex);

          

           BaseIdentifierInformation identifierInformation;
           IdentifierType identifierType = IdentifierType.Bin;
           
           var isOrganization = personOrOrganizationFlag >= OrganizationFlagMinValue;
           if (isOrganization)
           {
               identifierInformation = BinParser.GetBinInformation(iinOrBin);
           }
           else
           {
               identifierInformation = IinParser.GetIinInformation(iinOrBin);
               identifierType = IdentifierType.Iin;
           }

           identifierInformation.IdentifierType = identifierType;

           IdentifierValidationResult result =
               new IdentifierValidationResult(iinOrBin, identifierInformation, identifierType)
               {
                   IsValidIdentifier = true
               };

           return result;
       }
    }
}
