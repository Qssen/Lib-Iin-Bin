using System;

namespace libIinBin.Model
{
    /// <summary>
    /// Соддержит специфичную для БИН информацию
    /// </summary>
    public class BinInformation : BaseIdentifierInformation
    {
        /// <summary>
        /// Дата регистрации
        /// </summary>
        public DateTime RegistrationDate { get; set; }
        /// <summary>
        /// Тип регистрации (Резидент/Нерезидент)
        /// </summary>
        public OrganizationResidenceType OrganizationResidenceType { get; set; }
        /// <summary>
        /// Тип организации (Головная/Дочерняя итд)
        /// </summary>
        public OrganizationType OrganizationType { get; set; }
    }
}