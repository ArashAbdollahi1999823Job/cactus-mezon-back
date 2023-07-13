using Application.Common.Enums;
using Application.Common.Messages;
using Application.Dto.Base;
using Application.Dto.Chat.Group;
using Application.Dto.Favorite;
using Application.Dto.Store;
using Application.Dto.User;
using Application.Dto.UserPicture;
using Application.Enums;
using Application.IContracts.IRepository;
using Application.IContracts.IServices;
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
    private readonly IGroupRepository _groupRepository;
    private readonly IStoreRepository _storeRepository;
    private readonly IFavoriteRepository _favoriteRepository;
    private readonly IUserPictureRepository _userPictureRepository;
    private readonly IFileUploader _fileUploader;
    public UserRepository(ApplicationDbContext context, IMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager, IGroupRepository groupRepository, IStoreRepository storeRepository, IFavoriteRepository favoriteRepository, IUserPictureRepository userPictureRepository, IFileUploader fileUploader)
    {
        _context = context;
        _mapper = mapper;
        _userManager = userManager;
        _roleManager = roleManager;
        _groupRepository = groupRepository;
        _storeRepository = storeRepository;
        _favoriteRepository = favoriteRepository;
        _userPictureRepository = userPictureRepository;
        _fileUploader = fileUploader;
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
    
    #region UserDeleteAsync
    public async Task<bool> UserDeleteAsync(string id, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) throw new NotFoundEntityException(ApplicationMessages.UserNotFound);
        
        #region groupDelete
        var userGroups =
            await _groupRepository.GroupGetAllAsync(new GroupSearchDto(user.PhoneNumber, HasMessageType.NotImportant));
        #endregion
        
        #region StoreDelete
        var storeSearchDto = new StoreSearchDto(new Guid("00000000-0000-0000-0000-000000000000"), 1, 1000, null, null,
            null, ActiveType.NotImportant, id, SortType.Desc,null);
        var userStore = _storeRepository.StoreGetAllAsync(storeSearchDto, cancellationToken).Result.Data
            .FirstOrDefault();
        if (userStore!=null)
        {
            var storeEditDto = new StoreEditDto(userStore.Id, userStore.Name, userStore.Address, userStore.PhoneNumber,
                userStore.MobileNumber, userStore.Description, null, userStore.IsActive,userStore.Slug);
            var check = await _storeRepository.StoreEditAsync(storeEditDto, cancellationToken);
        }
        #endregion

        #region FavoriteDelete
        var favoriteSearchDto = new FavoriteSearchDto(id);
        var favoriteDto = await _favoriteRepository.FavoriteGetAllAsync(favoriteSearchDto, cancellationToken);
        if (favoriteDto.Count > 0)
        {
            favoriteDto.ForEach(x =>
            {
                _favoriteRepository.FavoriteDeleteAsync(new FavoriteDeleteDto(id, x.Id), cancellationToken);
            });
        }
        #endregion

        #region UserPictureDelete
        var userPictureDto = await _userPictureRepository.UserPictureGetAllAsync(new UserPictureSearchDto(new Guid("00000000-0000-0000-0000-000000000000"), id), cancellationToken);
        if (userPictureDto != null)
        {
            _fileUploader.Delete(userPictureDto.PictureUrl);
            await _userPictureRepository.UserPictureDeleteAsync(userPictureDto.Id, cancellationToken);
        }
        #endregion
        
        var result = await _userManager.DeleteAsync(user);
        if (result.Succeeded)
        {
            return true;
        }
        throw new BadRequestEntityException(ApplicationMessages.UserDeleteFailed);
    }
    #endregion
}