namespace libIinBin.Model
{
    /// <summary>
    /// Тип регистрации организации
    /// </summary>
    public enum OrganizationResidenceType : byte
    {
        /// <summary>
        /// 4 — для юридических лиц-резидентов;
        /// </summary>
        Resident = 4,
        /// <summary>
        /// 5 — для юридических лиц-нерезидентов;
        /// </summary>
        NotResident = 5,
        /// <summary>
        /// 6 — для ИП(С);
        /// </summary>
        IpS = 6
    }
}