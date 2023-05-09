using Application.Common.Enums;
using Application.Dto.Base;
using Application.Dto.User;
using Application.Enums;
using Application.IContracts.IBase;
using AutoMapper;
using Domain.Entities.IdentityEntity;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace Application.Features.User.Query.UserGetAll;
public class UserGetAllQueryHandler : IRequestHandler<UserGetAllQuery, PaginationDto<UserDto>>
{
    #region CtorAndInjection
    private readonly IMapper _mapper;
    private readonly UserManager<Domain.Entities.IdentityEntity.User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    public UserGetAllQueryHandler(IMapper mapper,UserManager<Domain.Entities.IdentityEntity.User> userManager,RoleManager<Role> roleManager)
    {
        _mapper = mapper;
        _userManager = userManager;
        _roleManager = roleManager;
    }
    #endregion

    public async Task<PaginationDto<UserDto>> Handle(UserGetAllQuery req,CancellationToken cancellationToken)
    {
        #region GetUserInRole
        if (req.RoleType != RoleType.NotImportant)
        {
            List<Domain.Entities.IdentityEntity.User> userList = new List<Domain.Entities.IdentityEntity.User>();
            IList<Domain.Entities.IdentityEntity.User> query = null;
            var name = req.RoleType.ToString();
            query = await _userManager.GetUsersInRoleAsync(_roleManager.FindByNameAsync(name).Result.Name);
            foreach (var user in query)
            {
                var ali = await _userManager
                    .Users
                    .Include(x=>x.UserPicture)
                    .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.PhoneNumber == user.PhoneNumber,cancellationToken);
                userList.Add(ali);
            }
            if (!String.IsNullOrWhiteSpace(req.SearchPhoneNumber))
                userList = userList.Where(x => x.PhoneNumber.Contains(req.SearchPhoneNumber)).ToList();
            if (!String.IsNullOrWhiteSpace(req.SearchUserName))
                userList = userList.Where(x => x.UserName.Contains(req.SearchUserName)).ToList();
            if (!String.IsNullOrWhiteSpace(req.Id))
                userList = userList.Where(x => x.Id==req.Id).ToList();
            if (req.PhoneNumberConfirmed != PhoneConfirmType.NotImportant)
                userList = userList.Where(x => x.PhoneNumberConfirmed==Boolean.Parse(req.PhoneNumberConfirmed.ToString())).ToList();
            if (req.SortType == SortType.Desc)
            {
                userList = userList.OrderByDescending(x => x.Id).ToList();
            }
            else
            {
                userList = userList.OrderBy(x => x.Id).ToList();
            }

            var count = userList.Count();
            userList = userList.Skip((req.PageIndex - 1) * req.PageSize).Take(req.PageSize).ToList();
            var data = _mapper.Map<IEnumerable<UserDto>>(userList);
            return new PaginationDto<UserDto>(req.PageIndex, req.PageSize, count, data);
        }
        #endregion
        
        #region GetUserWithoutRole
        List<Domain.Entities.IdentityEntity.User> query2 =await _userManager.Users
            .Include(x=>x.UserPicture)            
            .Include(x => x.UserRoles).ThenInclude(x => x.Role).ToListAsync(cancellationToken);
        if (!String.IsNullOrWhiteSpace(req.SearchPhoneNumber))
            query2 = query2.Where(x => x.PhoneNumber.Contains(req.SearchPhoneNumber)).ToList();
        if (!String.IsNullOrWhiteSpace(req.SearchUserName))
            query2 = query2.Where(x => x.UserName.Contains(req.SearchUserName)).ToList();
        if (!String.IsNullOrWhiteSpace(req.Id))
            query2 = query2.Where(x => x.Id==req.Id).ToList();
         if (req.PhoneNumberConfirmed != PhoneConfirmType.NotImportant)
             query2 = query2.Where(x => x.PhoneNumberConfirmed==Boolean.Parse(req.PhoneNumberConfirmed.ToString())).ToList();
        if (req.SortType == SortType.Desc)
        {
            query2 = query2.OrderByDescending(x=>x.Id).ToList();
        }
        else
        {
            query2 = query2.OrderBy(x=>x.Id).ToList();
        }
        var count2 = query2.Count();
        query2 = query2.Skip((req.PageIndex - 1) * req.PageSize).Take(req.PageSize).ToList();
        var data2 = _mapper.Map<IEnumerable<UserDto>>(query2);
        return new PaginationDto<UserDto>(req.PageIndex, req.PageSize, count2, data2);
        #endregion
    }
}