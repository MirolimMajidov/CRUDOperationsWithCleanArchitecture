using Domain.Entities;

namespace Application.Services;

public interface IUserService: IBaseService<User>
{
    Task<User> GetByUsernameAndPasswordAsync(string username, string password);
    Task<string> Authorize(User user);
}
