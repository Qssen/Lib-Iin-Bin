using System;

namespace libIinBin.Model
{
    /// <summary>
    /// Соддержит специфичную для ИИН информацию
    /// </summary>
    public class IinInformation : BaseIdentifierInformation
    {
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public Sex Sex { get; set; }
    }
}