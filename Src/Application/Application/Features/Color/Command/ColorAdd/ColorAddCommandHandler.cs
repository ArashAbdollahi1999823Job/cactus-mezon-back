using Application.Common.Messages;
using Application.Dto.Color;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Color.Command.ColorAdd;
public class ColorAddCommandHandler : IRequestHandler<ColorAddCommand, bool>
{
    #region CtorAndInjection
    private readonly IColorRepository _colorRepository;
    public ColorAddCommandHandler(IColorRepository colorRepository)
    {
        _colorRepository = colorRepository;
    }
    #endregion


    public async Task<bool> Handle(ColorAddCommand req, CancellationToken cancellationToken)
    {
  
            ColorAddDto colorAddDto = new ColorAddDto(req.Name,req.Value,req.ProductId);
            return await _colorRepository.ColorAddAsync(colorAddDto,cancellationToken);
            throw new BadRequestEntityException(ApplicationMessages.ColorFailedAddOnHandle);
    }
}