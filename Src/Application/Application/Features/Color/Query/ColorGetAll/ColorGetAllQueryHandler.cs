using Application.Dto.Color;
using Application.IContracts.IRepository;
using MediatR;

namespace Application.Features.Color.Query.ColorGetAll;
public class ColorGetAllQueryHandler:IRequestHandler<ColorGetAllQuery,List<ColorDto>>
{
    #region CtorAndInjection
    private readonly IColorRepository _colorRepository;
    public ColorGetAllQueryHandler(IColorRepository colorRepository)
    {
        _colorRepository = colorRepository;
    }
    #endregion
    public async Task<List<ColorDto>> Handle(ColorGetAllQuery req, CancellationToken cancellationToken)
    {
        ColorSearchDto colorSearchDto = new ColorSearchDto(req.Id, req.ProductId);
        return await _colorRepository.ColorGetAllAsync(colorSearchDto, cancellationToken);
    }
}