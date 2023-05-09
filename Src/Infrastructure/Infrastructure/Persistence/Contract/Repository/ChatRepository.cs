using Application.Dto.User;
using Application.IContracts.IRepository;
using AutoMapper;
using Domain.Entities.ChatEntity;
using Domain.Entities.IdentityEntity;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contract.Repository;

public class ChatRepository : IChatRepository
{
    #region CtorAndInjection

    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ChatRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    #endregion

    #region GroupAddAsync

    public async Task GroupAddAsync(Group group)
    {
        await _context.Groups.AddAsync(group);
        await _context.SaveChangesAsync();
    }

    #endregion

    #region GroupDeleteAsync

    public async Task GroupDeleteAsync(string groupName)
    {
        await _context.Groups.Where(x => x.Name == groupName).ExecuteDeleteAsync();
    }

    #endregion

    #region ConnectionAddAsync

    public async Task ConnectionAddAsync(Connection connection)
    {
        await _context.Connections.AddAsync(connection);
        await _context.SaveChangesAsync();
    }

    #endregion

    #region GroupExistAsync

    public async Task<bool> GroupExistAsync(string groupName)
    {
        return await _context.Groups.AnyAsync(x => x.Name == groupName);
    }

    #endregion

    #region ConnectionExistAsync

    public async Task<bool> ConnectionExistAsync(string connectionId)
    {
        return await _context.Connections.AnyAsync(x => x.ConnectionId == connectionId);
    }

    #endregion

    #region GroupGetAllAsync

    public async Task<List<Group>> GroupGetAllAsync(string halfGroupName)
    {
        return await _context.Groups.Where(x => x.Name.Contains(halfGroupName))
            
            .ToListAsync();
    }

    #endregion

    #region GroupGetAsync

    public Task<Group> GroupGetAsync(string groupName)
    {
        return _context.Groups.FirstOrDefaultAsync(x => x.Name == groupName);
    }

    #endregion

    #region ConnectionDeleteInGroup

    public async Task ConnectionDeleteInGroup(string connectionId)
    {
        await _context.Connections.Where(x => x.ConnectionId == connectionId).ExecuteDeleteAsync();
        await _context.SaveChangesAsync();
    }

    #endregion

    #region UserInGroupsGet

    public async Task<List<UserDto>> UserInGroupsGet(string askerPhoneNumber)
    {
      var users=await  _context.Groups
          .Where(x => x.Name.Contains(askerPhoneNumber)).Select(x => x.Asker).ToListAsync();

      return _mapper.Map<List<User>,List<UserDto>>(users);
    }

    #endregion
    public async Task<bool> UserInGroup(string groupName, List<string> chatConnections)
    {
        var exist = false;
        var groupConnections = await 
            _context.Connections.Where(x => x.Group.Name == groupName)
                .Select(x=>x.ConnectionId).ToListAsync();

        chatConnections?.ForEach(x =>
        {
           if(groupConnections.Contains(x))exist=true;
        });
        return exist;
    }

}