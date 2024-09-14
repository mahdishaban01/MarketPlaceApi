namespace MarketPlace.Core.Domain.Account.Users.ValueObjects;

public record UserPassword(string Value) : BaseRecordValueObject
{
    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Value))
            throw new ArgumentException(@"کلمه عبور الزامی می باشد", nameof(Value));
        if (Value.Length > 150)
            throw new ArgumentOutOfRangeException(nameof(Value), @"کلمه عبور نباید بیش از 150 کارکتر باشد");
    }

    public static implicit operator string(UserPassword objectVal)
    {
        return objectVal.Value;
    }
}