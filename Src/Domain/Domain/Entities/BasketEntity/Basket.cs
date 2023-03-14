namespace Domain.Entities.BasketEntity;
public class Basket
{
    #region Properties
    public string Id { get; set; }
    #endregion

    #region Ctor
    public Basket(string id)
    {
        Id = id;
    }
    #endregion

    #region Relation
    public List<BasketItem> BasketItems { get; set; } = new();
    #endregion
}