namespace libIinBin.Model
{
    /// <summary>
    /// Тип организации (Головной офис, филиал итд)
    /// </summary>
    public enum OrganizationType : byte
    {
        /// <summary>
        /// Признак - Головного подразделения юридического лица или ИП(С);
        /// </summary>
        MainOffice,
        /// <summary>
        /// Признак - филиала юридического лица или ИП(С);
        /// </summary>
        Branch,
        /// <summary>
        /// Признак - представительства юридического лица или ИП(С);
        /// </summary>
        RepresentativeOffice,
        /// <summary>
        /// крестьянское (фермерское) хозяйство, осуществляющее деятельность на основе совместного предпринимательства;
        /// </summary>
        PeasantFarm
    }
}