using Application.Common.Messages;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;
namespace Application.Features.Color.Command.ColorDelete;
public class ColorCommandHandler:IRequestHandler<ColorDeleteCommand,bool>
{
    #region CtorAndInjection
    private readonly IColorRepository _colorRepository;
    public ColorCommandHandler(IColorRepository colorRepository)
    {
        _colorRepository = colorRepository;
    }
    #endregion
    public async Task<bool> Handle(ColorDeleteCommand req, CancellationToken cancellationToken)
    {
        var color =await _colorRepository.ColorExistAsync(req.Id, cancellationToken);

        if (color)
        {
           return await _colorRepository.ColorDeleteAsync(req.Id,cancellationToken);
        }
        throw new BadRequestEntityException(ApplicationMessages.ColorFailedDeleteOnHandle);
    }
}