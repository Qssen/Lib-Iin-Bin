using System;
using System.Globalization;
using libIinBin.Exception;
using libIinBin.Model;

namespace libIinBin.Parser
{
    internal static class BinParser
    {
        private const int OrganizationResidenceTypeIndex = 4;
        private const int OrganizationTypeIndex = 5;
        private const string BinRegistrationDateFormat = "yyMM";

        internal static BinInformation GetBinInformation(string identifier)
        {
            var result = new BinInformation();

            //yyMM
            var dtStr = identifier.Substring(0, 4);
            
            result.RegistrationDate = DateTime.ParseExact(dtStr, BinRegistrationDateFormat, CultureInfo.CurrentCulture);

            var residenceTypeValue = (byte)char.GetNumericValue(identifier, OrganizationResidenceTypeIndex);
            result.OrganizationResidenceType = (OrganizationResidenceType) residenceTypeValue;

            if (result.OrganizationResidenceType < OrganizationResidenceType.Resident 
                || result.OrganizationResidenceType > OrganizationResidenceType.IpS)
                throw new InvalidIdentifierException($"Error at index - {OrganizationResidenceTypeIndex}. Value can not be less than 4 or greater than 6");
            
            var organizationTypeValue = (byte)char.GetNumericValue(identifier, OrganizationTypeIndex);
            result.OrganizationType = (OrganizationType)organizationTypeValue;

            if(result.OrganizationType > OrganizationType.PeasantFarm)
                throw new InvalidIdentifierException($"Error at index - {OrganizationTypeIndex}. Value can not greater than 3");

            result.RegistrationNumber = identifier[6..10];

            result.CheckSum = (byte)char.GetNumericValue(identifier, 11);
            
            return result;
        }
    }
}