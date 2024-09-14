using MarketPlace.Core.Domain.Account.Users.Dtos;
using MarketPlace.Core.Domain.Account.Users.Queries;

namespace MarketPlace.Core.Domain.Account.Users.QueryServices;

public interface IUserQueryService
{
    Task<QueryResult<List<UserDto>>> UserDtos(GetAllUsersQuery getAllUsersQuery);
}
