using MarketPlace.Core.Domain.Account.Users.Enums;

namespace MarketPlace.Core.Domain.Account.Users.Events;

public class UserPasswordUpdated : IEvent
{
    public int Id { get; set; }
    public required string Password { get; set; }
    public required int UpdateBy { get; set; }
}
