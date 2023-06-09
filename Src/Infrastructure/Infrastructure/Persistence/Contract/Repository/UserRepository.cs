using Application.Common.Enums;
using Application.Common.Messages;
using Application.Dto.Base;
using Application.Dto.User;
using Application.Enums;
using Application.IContracts.IRepository;
using AutoMapper;
using Domain.Entities.IdentityEntity;
using Domain.Enums;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Contract.Repository;
public class UserRepository:IUserRepository
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    public UserRepository(ApplicationDbContext context, IMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        _context = context;
        _mapper = mapper;
        _userManager = userManager;
        _roleManager = roleManager;
    }
    #endregion

    #region ExistUserByPhoneNumberAsync
    public async Task<bool> ExistUserByPhoneNumberAsync(string phoneNumber,CancellationToken cancellationToken)
    {
        var check = await _context.Users.AsNoTracking().AnyAsync(x => x.PhoneNumber == phoneNumber, cancellationToken);
        if (!check) throw new NotFoundEntityException(ApplicationMessages.UserNotFound);
        return true;
    }
    #endregion
    
        #region UserGetAllAsync
    public async Task<PaginationDto<UserDto>> UserGetAllAsync(UserSearchDto userSearchDto, CancellationToken cancellationToken)
    {
              #region GetUserInRole
        if (userSearchDto.RoleType != RoleType.NotImportant)
        {
            List<User> userList = new List<User>();
            IList<User> query = null;
            var name = userSearchDto.RoleType.ToString();
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
            if (!String.IsNullOrWhiteSpace(userSearchDto.SearchPhoneNumber))
                userList = userList.Where(x => x.PhoneNumber.Contains(userSearchDto.SearchPhoneNumber)).ToList();
            if (!String.IsNullOrWhiteSpace(userSearchDto.SearchUserName))
                userList = userList.Where(x => x.UserName.Contains(userSearchDto.SearchUserName)).ToList();
            if (!String.IsNullOrWhiteSpace(userSearchDto.Id))
                userList = userList.Where(x => x.Id==userSearchDto.Id).ToList();
            if (userSearchDto.PhoneNumberConfirmed != PhoneConfirmType.NotImportant)
                userList = userList.Where(x => x.PhoneNumberConfirmed==Boolean.Parse(userSearchDto.PhoneNumberConfirmed.ToString())).ToList();
            if (userSearchDto.SortType == SortType.Desc)
            {
                userList = userList.OrderByDescending(x => x.Id).ToList();
            }
            else
            {
                userList = userList.OrderBy(x => x.Id).ToList();
            }

            var count = userList.Count();
            userList = userList.Skip((userSearchDto.PageIndex - 1) * userSearchDto.PageSize).Take(userSearchDto.PageSize).ToList();
            var data = _mapper.Map<IEnumerable<UserDto>>(userList);
            return new PaginationDto<UserDto>(userSearchDto.PageIndex, userSearchDto.PageSize, count, data);
        }
        #endregion
        
        #region GetUserWithoutRole
        List<User> query2 =await _userManager.Users
            .Include(x=>x.UserPicture)            
            .Include(x => x.UserRoles).ThenInclude(x => x.Role).ToListAsync(cancellationToken);
        if (!String.IsNullOrWhiteSpace(userSearchDto.SearchPhoneNumber))
            query2 = query2.Where(x => x.PhoneNumber.Contains(userSearchDto.SearchPhoneNumber)).ToList();
        if (!String.IsNullOrWhiteSpace(userSearchDto.SearchUserName))
            query2 = query2.Where(x => x.UserName.Contains(userSearchDto.SearchUserName)).ToList();
        if (!String.IsNullOrWhiteSpace(userSearchDto.Id))
            query2 = query2.Where(x => x.Id==userSearchDto.Id).ToList();
         if (userSearchDto.PhoneNumberConfirmed != PhoneConfirmType.NotImportant)
             query2 = query2.Where(x => x.PhoneNumberConfirmed==Boolean.Parse(userSearchDto.PhoneNumberConfirmed.ToString())).ToList();
        if (userSearchDto.SortType == SortType.Desc)
        {
            query2 = query2.OrderByDescending(x=>x.Id).ToList();
        }
        else
        {
            query2 = query2.OrderBy(x=>x.Id).ToList();
        }
        var count2 = query2.Count();
        query2 = query2.Skip((userSearchDto.PageIndex - 1) * userSearchDto.PageSize).Take(userSearchDto.PageSize).ToList();
        var data2 = _mapper.Map<IEnumerable<UserDto>>(query2);
        return new PaginationDto<UserDto>(userSearchDto.PageIndex, userSearchDto.PageSize, count2, data2);
        #endregion
    }
    #endregion
}