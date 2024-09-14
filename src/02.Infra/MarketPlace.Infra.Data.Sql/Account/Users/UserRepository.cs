using MarketPlace.Core.Domain.Account.Users.Entities;
using MarketPlace.Core.Domain.Account.Users.Repositories;
using MarketPlace.Infra.Data.Sql.Common;

namespace MarketPlace.Infra.Data.Sql.Account.Users;

public class UserRepository(MarketPlaceDbContext context) : IUserRepository
{
    public Task Add(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Exists(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetWithId(int id)
    {
        throw new NotImplementedException();
    }

    public void Remove(int id)
    {
        throw new NotImplementedException();
    }
}
