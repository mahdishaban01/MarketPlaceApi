namespace MarketPlace.Core.Domain.Account.Users.ValueObjects;

public record UserLastName(string Value) : BaseRecordValueObject
{
    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Value))
            throw new ArgumentException(@"نام خانوادگی الزامی می باشد", nameof(Value));
        if (Value.Length > 50)
            throw new ArgumentOutOfRangeException(nameof(Value), @"نام خانوادگی نباید بیش از 50 کارکتر باشد");
    }

    public static implicit operator string(UserLastName objectVal) => objectVal.Value;
}
