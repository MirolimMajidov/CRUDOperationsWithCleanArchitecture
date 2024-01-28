using Application.Services;
using Domain.Entities;
using Infrastructure.Helpers;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence.Contexts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Infrastructure.Services;

public class UserService : EntityRepository<User>, IUserService
{
    public UserService(UserContext context) : base(context)
    {
    }

    public async Task<User> GetByUsernameAndPasswordAsync(string username, string password)
    {
        return await _dbSet.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);
    }

    public async Task<string> Authorize(User user)
    {
        var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Username) };
        // создаем JWT-токен
        var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

        return await Task.FromResult(accessToken);
    }
}
