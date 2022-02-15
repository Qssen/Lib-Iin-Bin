namespace libIinBin.Model
{
    /// <summary>
    /// Соддержит общую информацию о идентификаторе (ИИН/БИН)
    /// </summary>
    public class BaseIdentifierInformation
    {
        /// <summary>
        /// Тип идентификатора
        /// </summary>
        public IdentifierType IdentifierType { get; internal set; }
        /// <summary>
        /// Рег. номер взятый из ИИН/БИН
        /// </summary>
        public string RegistrationNumber { get; set; }
        /// <summary>
        /// Контрольная сумма
        /// </summary>
        public byte CheckSum { get; set; }
    }
}