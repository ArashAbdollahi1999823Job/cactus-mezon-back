using Application.Dto.Favorite;
using Application.Dto.Product;
using MediatR;

namespace Application.Features.Favorite.Query.FavoriteGetAll;

public class FavoriteGetAllQuery:FavoriteSearchDto,IRequest<List<ProductDto>>
{
    
}