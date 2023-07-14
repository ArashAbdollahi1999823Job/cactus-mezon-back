using Application.IContracts.IRepository;
using Domain.Entities.IdentityEntity;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contract.Repository;

public class UserVerifyRepository:IUserVerifyRepository
{
    #region CtorAndInjection
    private readonly ApplicationDbContext _context;
    public UserVerifyRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    #endregion
    
    public async Task<bool> UserVerifyAdd(UserVerify userVerify)
    {
       await _context.UserVerifies.AddAsync(userVerify);
       var check = await _context.SaveChangesAsync();
       return check > 0;
    }

    public async Task<bool> UserVerifyDelete(string phoneNumber)
    {
       var check= await _context.UserVerifies.Where(x => x.PhoneNumber == phoneNumber).ExecuteDeleteAsync();
       return check > 0;
    }
    public async Task<UserVerify> UserVerifyGet(string phoneNumber)
    {
      var userVerifies=  await _context.UserVerifies.Where(x => x.PhoneNumber == phoneNumber).OrderBy(x=>x.CreationDate).ToListAsync();
      var userVerifiesLast = userVerifies.LastOrDefault();
      var userVerifiesExceptLast = userVerifies.Except(new List<UserVerify>(){userVerifiesLast}).ToList();
      _context.UserVerifies.RemoveRange(userVerifiesExceptLast);
      var check = await _context.SaveChangesAsync();
      return userVerifies.LastOrDefault();
    }
}