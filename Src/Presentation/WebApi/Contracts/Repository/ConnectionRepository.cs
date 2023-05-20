using Application.Common.Messages;
using Domain.Entities.ChatEntity;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using WebApi.Contracts.IRepository;
namespace WebApi.Contracts.Repository;
public class ConnectionRepository:IConnectionRepository
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    public ConnectionRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    #endregion

    #region ConnectionAddAsync
    public async Task<bool> ConnectionAddAsync(Connection connection)
    {
        await _context.Connections.AddAsync(connection);
        var check = await _context.SaveChangesAsync();
        if (check > 0) return true;
        throw new BadRequestEntityException(ApplicationMessages.ConnectionFailedAdd);
    }
    #endregion

    #region ConnectionDeleteAsync
    public async Task<bool> ConnectionDeleteAsync(string? connectionId)
    {
        var exist = await ConnectionExistAsync(connectionId);
        if (exist)
        {
            var check =  await _context.Connections.Where(x => x.ConnectionId == connectionId).ExecuteDeleteAsync();
            if (check > 0) return true;
        }
        else
        {
            return false;
        }
        throw new BadRequestEntityException(ApplicationMessages.ConnectionFailedDelete);
    }
    #endregion
    
    #region ConnectionExistAsync
    public async Task<bool> ConnectionExistAsync(string connectionId)
    {
        return await _context.Connections.AnyAsync(x => x.ConnectionId == connectionId);
    }
    #endregion

    #region UserInGroup
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
    #endregion
}