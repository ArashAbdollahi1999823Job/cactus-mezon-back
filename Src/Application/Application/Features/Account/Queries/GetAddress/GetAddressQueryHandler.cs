#region UsingAndNamespace

using Application.Common.AutoMapping;
using Application.Common.Messages;
using Application.Dto.IdentityDto;
using Application.IContracts.IServices;
using AutoMapper;
using Domain.Entities.IdentityEntity;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Account.Queries.GetAddress;

#endregion

public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, AddressDto>
{
    #region CtorAndInjection

    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;
    private readonly UserManager<Domain.Entities.IdentityEntity.User> _userManager;

    public GetAddressQueryHandler(ICurrentUserService currentUserService, IMapper mapper, UserManager<Domain.Entities.IdentityEntity.User> userManager)
    {
        _currentUserService = currentUserService;
        _mapper = mapper;
        _userManager = userManager;
    }

    #endregion

    public async Task<AddressDto> Handle(GetAddressQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == _currentUserService.Id);
        if (user == null) throw new NotFoundEntityException(ApplicationMessages.UserNotFound);


        return _mapper.Map<AddressDto>(user.Address);
    }
}