using Application.Common.Messages;
using Application.Dto.Brand;
using Application.Dto.Product;
using Application.Features.Product.Command.ProductEdit;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;
namespace Application.Features.Brand.Command.BrandEdit;
public class BrandEditCommandHandler:IRequestHandler<BrandEditCommand,bool>
{
    #region CtorAndInjection
    private readonly IBrandRepository _brandRepository;
    public BrandEditCommandHandler(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }
    #endregion
    public async Task<bool> Handle(BrandEditCommand req, CancellationToken cancellationToken)
    {
        var check =await _brandRepository.BrandExistAsync(req.Id,cancellationToken);
        if (check)
        {
            var brandEditDto = new BrandEditDto(req.Id,req.Name, req.Description, req.MetaDescription,req.Summary);
            return await _brandRepository.BrandEditAsync(brandEditDto, cancellationToken);
        }

        throw new BadRequestEntityException(ApplicationMessages.BrandEditFailedOnHandle);
    }
}