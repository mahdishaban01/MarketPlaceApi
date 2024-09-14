namespace MarketPlace.Core.Domain.Account.Users.ValueObjects;

public record UserFirstName(string Value) : BaseRecordValueObject
{
    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Value))
            throw new ArgumentException(@"نام الزامی می باشد", nameof(Value));
        if (Value.Length > 50)
            throw new ArgumentOutOfRangeException(nameof(Value), @"نام نباید بیش از 50 کارکتر باشد");
    }

    public static implicit operator string(UserFirstName objectVal) => objectVal.Value;
}
