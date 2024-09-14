namespace MarketPlace.Core.Domain.Account.Users.ValueObjects;

public record class UserIsMobileActive(bool Value) : BaseRecordValueObject
{
    protected override void Validate() { }

    public static implicit operator bool(UserIsMobileActive objectVal) => objectVal.Value;
}
