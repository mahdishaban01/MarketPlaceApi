using MarketPlace.Core.Domain.Account.Users.Entities;

namespace MarketPlace.Core.Domain.Account.Users.Repositories;

public interface IUserRepository
{
    Task Add(User user);
    Task<User?> GetWithId(int id);
    Task<bool> Exists(int id);
    void Remove(int id);
}
