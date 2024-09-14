namespace MarketPlace.Core.Domain.Account.Users.ValueObjects;

public record UserMobileActiveCode(string Value) : BaseRecordValueObject
{
    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Value))
            throw new ArgumentException(@"کد فعالسازی موبایل الزامی می باشد", nameof(Value));
        if (Value.Length > 150)
            throw new ArgumentOutOfRangeException(nameof(Value), @"کد فعالسازی موبایل نباید بیش از 150 کارکتر باشد");
    }

    public static implicit operator string(UserMobileActiveCode objectVal) => objectVal.Value;
}
