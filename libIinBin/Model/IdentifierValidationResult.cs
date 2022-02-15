namespace libIinBin.Model
{
    /// <summary>
    /// Результат валидации ИИН-а или БИН-а
    /// </summary>
    public class IdentifierValidationResult
    {
        /// <summary>
        /// Сам проверяемый идентификатор
        /// </summary>
        public string Identifier { get; internal set; }
        /// <summary>
        /// Флаг - валидности идентификатора
        /// </summary>
        public bool IsValidIdentifier { get; internal set; }
        /// <summary>
        /// Тип идентификатора
        /// </summary>
        public IdentifierType IdentifierType { get; internal set; }

        /// <summary>
        /// Базовая информация о идентификаторе
        /// </summary>
        public BaseIdentifierInformation BaseIdentifierInformation { get; internal set; }
        /// <summary>
        /// Соддержит специфичную для ИИН информацию
        /// </summary>
        public IinInformation IinInformation { get; private set; }
        /// <summary>
        /// Соддержит специфичную для БИН информацию
        /// </summary>
        public BinInformation BinInformation { get; private set; }

        public IdentifierValidationResult(string identifier, 
            BaseIdentifierInformation baseIdentifier,
            IdentifierType identifierType)
        {
            Identifier = identifier;
            BaseIdentifierInformation = baseIdentifier;
            IdentifierType = identifierType;

            IinInformation = BaseIdentifierInformation as IinInformation;
            BinInformation = BaseIdentifierInformation as BinInformation;
        }
    }
}
