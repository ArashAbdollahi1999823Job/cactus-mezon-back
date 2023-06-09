using Application.Common.Messages;
using Application.Dto.Chat.Group;
using Application.Enums;
using Application.IContracts.IRepository;
using AutoMapper;
using Domain.Entities.ChatEntity;
using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using WebApi.Contracts.IRepository;

namespace WebApi.Contracts.Repository;
public class GroupRepository:IGroupRepository
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GroupRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    #endregion

    #region GroupGetAllAsync
    public async Task<List<GroupDto>> GroupGetAllAsync(GroupSearchDto groupSearchDto)
    {
        var query = _context.Groups.Include(x=>x.Asker).Include(x=>x.Responder).AsQueryable();
        if (!string.IsNullOrEmpty(groupSearchDto.Name)) query = query.Where(x => x.Name.Contains(groupSearchDto.Name));
        if (groupSearchDto.HasMessage != 0)
        {
            query = groupSearchDto.HasMessage switch
            {
                HasMessageType.HaveMessage => query.Where(x => x.Messages.Count > 0),
                HasMessageType.DontHaveMessage => query.Where(x => x.Messages.Count == 0),
                _ => query
            };
        }
        var groups =await query.ToListAsync();
        return _mapper.Map<List<Group>, List<GroupDto>>(groups);
    }
    #endregion

    #region GroupAddAsync
    public async Task<GroupDto> GroupAddAsync(GroupAddDto groupAddDto)
    {
        var group = new Group(groupAddDto.Name, groupAddDto.ResponderId, groupAddDto.AskerId);
        await _context.Groups.AddAsync(group);
        var check = await _context.SaveChangesAsync();
        if (check > 0)
        {
            var groupSearchDto = new GroupSearchDto(groupAddDto.Name,HasMessageType.NotImportant);
            var groupDtos =await GroupGetAllAsync(groupSearchDto);
            return groupDtos.First() ;
        }
        throw new BadRequestEntityException(ApplicationMessages.GroupFailedAdd);
    }
    #endregion
    
    #region GroupExistAsync
    public async Task<bool> GroupExistAsync(string groupName)
    {
        return await _context.Groups.AnyAsync(x => x.Name == groupName);
    }
    #endregion

    #region GroupDeleteAsync
    public async Task<bool> GroupDeleteAsync(string groupName)
    {
      var check=await  _context.Groups.Where(x => x.Name == groupName).ExecuteDeleteAsync();
      if (check > 0) return true;
      throw new BadRequestEntityException(ApplicationMessages.GroupFailedDelete);
    }
    #endregion
}