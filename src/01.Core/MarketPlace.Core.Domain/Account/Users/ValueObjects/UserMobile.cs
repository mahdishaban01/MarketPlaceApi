namespace MarketPlace.Core.Domain.Account.Users.ValueObjects;


public record UserMobile(string Value) : BaseRecordValueObject
{
    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Value))
            throw new ArgumentException(@"موبایل الزامی می باشد", nameof(Value));
        if (Value.Length > 11)
            throw new ArgumentOutOfRangeException(nameof(Value), @"موبایل نباید بیش از 11 کارکتر باشد");
        if (!NumericRegex.IsMatch(Value))
            throw new ArgumentOutOfRangeException(nameof(Value), @"برای موبایل تنها عدد مجاز است");
        if (int.TryParse(Value, out int intCode) && intCode == 0)
            throw new ArgumentOutOfRangeException(nameof(Value), @"موبایل نمیتواند برابر صفر باشد");
    }

    public static implicit operator string(UserMobile objectVal) => objectVal.Value;
}