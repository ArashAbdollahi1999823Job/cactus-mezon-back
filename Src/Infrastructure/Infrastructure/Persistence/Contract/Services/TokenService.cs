#region UsingAndNamespace

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.IContracts.IServices;
using Domain.Entities.IdentityEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Infrastructure.Persistence.Contract.Services;
#endregion
public class TokenService:ITokenService
{
    #region UsingAndNamespace
    private readonly IConfiguration _configuration;
    private readonly UserManager<User> _userManager;
    private readonly SymmetricSecurityKey _symmetricSecurityKey;
    public TokenService( UserManager<User> userManager, IConfiguration configuration)
    {
       
        _userManager = userManager;
        _configuration = configuration;
        _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfiguration:Key"] ?? string.Empty));
    }
    #endregion
    
    public async Task<string> CreateToken(User user)
    {
        if (user.PhoneNumber == null) return null;
        //create claims
        var claims = new List<Claim>
        {
            new("Username", user.UserName ?? ""),
            new("Id", user.Id ?? ""),
            new("PhoneNumber", user.PhoneNumber ?? ""),
            /*new("PhoneNumber", user.PhoneNumber ?? ""),*/
        };
        //add role to claims
        var roles = await _userManager.GetRolesAsync(user);
        if(roles!=null&& roles.Any())claims.AddRange(roles.Select(x=>new Claim(ClaimTypes.Role,x)));
        //create cred
        var cred = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);
        //create desc
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Issuer = _configuration["JwtConfiguration:Issuer"],
            Audience = _configuration["JwtConfiguration:Audience"],
            IssuedAt = DateTime.Now,
            Expires = DateTime.UtcNow.AddDays(10),
            SigningCredentials = cred,
            Subject = new ClaimsIdentity(claims)
        };
        //create token
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return await  Task.Run(()=>tokenHandler.WriteToken(token)).ConfigureAwait(false);

    }
}