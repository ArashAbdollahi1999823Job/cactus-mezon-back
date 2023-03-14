namespace Domain.Entities.IdentityEntity;

public class Address:BaseEntity.BaseEntity
{
    #region Properties
    public string State { get; set; }
    public string City { get; set; }
    public string FullAddress { get; set; }
    public string PostalCode { get; set; }
    #endregion

    #region MyRegion
    public User User { get; set; }
    public string UserId { get; set; }
    #endregion
}