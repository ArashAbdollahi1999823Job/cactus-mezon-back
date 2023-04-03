using Application.Dto.Base;
using Application.Dto.Brand;
using Application.Dto.Product;
using Application.Dto.ProductDto;
using MediatR;

namespace Application.Features.Brand.Query.BrandGetAll;
public class BrandGetAllQuery:BrandSearchDto,IRequest<PaginationDto<BrandDto>>
{
    
}