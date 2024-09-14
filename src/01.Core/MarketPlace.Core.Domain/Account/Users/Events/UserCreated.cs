using MarketPlace.Core.Domain.Account.Users.Enums;

namespace MarketPlace.Core.Domain.Account.Users.Events;

public class UserCreated : IEvent
{
    public required RegisterUserType RegisterUserType { get; set; }
    public required Gender Gender { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Mobile { get; set; }
    public required string MobileActiveCode { get; set; }
    public required bool IsMobileActive { get; set; }
    public required string Password { get; set; }
    public required int InsertBy { get; set; }
}
