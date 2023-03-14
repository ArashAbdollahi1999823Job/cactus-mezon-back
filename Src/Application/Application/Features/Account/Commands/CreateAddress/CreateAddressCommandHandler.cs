#region UsingAndNamespace

using Application.Common.Messages;
using Application.Dto.IdentityDto;
using Application.IContracts.IBase;
using Application.IContracts.IServices;
using AutoMapper;
using Domain.Entities.IdentityEntity;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Account.Commands.CreateAddress;
#endregion
public class CreateAddressCommandHandler:IRequestHandler<CreateAddressCommand,AddressDto>
{
    #region CtorAndInjection
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;
    private readonly UserManager<Domain.Entities.IdentityEntity.User> _userManager;
    public CreateAddressCommandHandler(IUnitOfWork uow, IMapper mapper, ICurrentUserService currentUserService, UserManager<Domain.Entities.IdentityEntity.User> userManager)
    {
        _uow = uow;
        _mapper = mapper;
        _currentUserService = currentUserService;
        _userManager = userManager;
    }
    #endregion
    public async Task<AddressDto> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        //set userid user
        var userId = _currentUserService.Id;
        var user = await _userManager.Users.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == userId);
        //check exist user
        if (user == null) throw new NotFoundEntityException(ApplicationMessages.UserNotFound);
        //check exist address
        if (user.Address!=null)
        {
            //remove old address
            var oldAddress =await _uow.Context.Set<Address>().FirstOrDefaultAsync(x => x.UserId == userId);
            _uow.Context.Set<Address>().Remove(oldAddress);
            
            //create new address
            var newAddress = _mapper.Map<Address>(request);
            user.Address = newAddress;

            var checkUpdateUser = await _userManager.UpdateAsync(user);
            if (!checkUpdateUser.Succeeded) throw new BadRequestEntityException();

            return _mapper.Map<AddressDto>(newAddress);

        }
        var newAddress2 = _mapper.Map<Address>(request);
        user.Address = newAddress2;

        var checkUpdateUser2 = await _userManager.UpdateAsync(user);
        if (!checkUpdateUser2.Succeeded) throw new BadRequestEntityException();

        return _mapper.Map<AddressDto>(newAddress2);
    }
}