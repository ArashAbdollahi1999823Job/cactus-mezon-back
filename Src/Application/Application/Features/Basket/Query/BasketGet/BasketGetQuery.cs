using MediatR;
namespace Application.Features.Basket.Query.BasketGet;
public class BasketGetQuery :IRequest<Domain.Entities.BasketEntity.Basket>
{
    public string Id { get; set; }

    public BasketGetQuery(string id)
    {
        Id = id;
    }
}