using MarketPlace.Core.Domain.Account.Users.Enums;

namespace MarketPlace.Core.Domain.Account.Users.Events;

public class UserUpdated : IEvent
{
    public int Id { get; set; }
    public required Gender Gender { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Mobile { get; set; }
    public required string MobileActiveCode { get; set; }
    public required bool IsMobileActive { get; set; }
    public required bool IsActive { get; set; }
    public required int UpdateBy { get; set; }
}
