using Application.Common.Messages;
using Application.Dto.Brand;
using Application.Dto.Product;
using Application.Features.Product.Command.ProductAdd;
using Application.IContracts.IRepository;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Brand.Command.BrandAdd;

public class BrandAddCommandHandler : IRequestHandler<BrandAddCommand, bool>
{
    #region CtorAndInjection
    private readonly IBrandRepository _brandRepository;
    public BrandAddCommandHandler(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }
    #endregion

    public async Task<bool> Handle(BrandAddCommand req, CancellationToken cancellationToken)
    {
        var brandAddDto = new BrandAddDto(req.Name, req.Description, req.MetaDescription, req.Summary);
      return  await _brandRepository.BrandAddAsync(brandAddDto, cancellationToken);
      throw new BadRequestEntityException(ApplicationMessages.BrandAddFailedOnHandle);
    }
}