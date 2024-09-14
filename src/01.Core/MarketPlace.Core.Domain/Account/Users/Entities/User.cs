using MarketPlace.Core.Domain.Account.Users.Enums;
using MarketPlace.Core.Domain.Account.Users.Events;
using MarketPlace.Core.Domain.Account.Users.ValueObjects;

namespace MarketPlace.Core.Domain.Account.Users.Entities;

public class User : BaseAggregateRoot<int>
{
    private User()
    {

    }

    public User(RegisterUserType registerUserType, Gender gender, UserFirstName firstName, UserLastName lastName,
        UserMobile mobile, UserMobileActiveCode mobileActiveCode, UserIsMobileActive isMobileActive,
        UserPassword password, int insertBy)
    {
        HandleEvent(new UserCreated
        {
            RegisterUserType = registerUserType,
            Gender = gender,
            FirstName = firstName,
            LastName = lastName,
            Mobile = mobile,
            MobileActiveCode = mobileActiveCode,
            IsMobileActive = isMobileActive,
            Password = password,
            InsertBy = insertBy
        });
    }

    public void SetUser(Gender gender, UserFirstName firstName, UserLastName lastName, UserMobile mobile,
        UserMobileActiveCode mobileActiveCode, UserIsMobileActive isMobileActive, UserPassword password,
        bool isActive, int updateBy)
    {
        HandleEvent(new UserUpdated
        {
            Id = Id,
            Gender = gender,
            FirstName = firstName,
            LastName = lastName,
            Mobile = mobile,
            MobileActiveCode = mobileActiveCode,
            IsMobileActive = isMobileActive,
            IsActive = isActive,
            UpdateBy = updateBy
        });
    }

    public void SetPassword(UserPassword password, int updateBy)
    {
        HandleEvent(new UserPasswordUpdated
        {
            Id = Id,
            Password = password,
            UpdateBy = updateBy
        });
    }

    protected override void SetStateByEvent(IEvent @event)
    {
        switch (@event)
        {
            case UserCreated e:
                RegisterUserType = e.RegisterUserType;
                Gender = e.Gender;
                FirstName = new UserFirstName(e.FirstName);
                LastName = new UserLastName(e.LastName);
                Mobile = new UserMobile(e.Mobile);
                MobileActiveCode = new UserMobileActiveCode(e.MobileActiveCode);
                IsMobileActive = new UserIsMobileActive(e.IsMobileActive);
                Password = new UserPassword(e.Password);
                InsertOn = DateTime.Now;
                InsertBy = Id;
                break;
            case UserUpdated e:
                Gender = e.Gender;
                FirstName = new UserFirstName(e.FirstName);
                LastName = new UserLastName(e.LastName);
                Mobile = new UserMobile(e.Mobile);
                MobileActiveCode = new UserMobileActiveCode(e.MobileActiveCode);
                IsMobileActive = new UserIsMobileActive(e.IsMobileActive);
                UpdateOn = DateTime.Now;
                UpdateBy = Id;
                break;
            case UserPasswordUpdated e:
                Password = new UserPassword(e.Password);
                UpdateOn = DateTime.Now;
                UpdateBy = Id;
                break;
            default:
                throw new InvalidOperationException(@"امکان اجرای عملیات درخواستی وجود ندارد");
        }
    }

    protected override void ValidateInvariants() { }

    #region Fields

    public RegisterUserType RegisterUserType { get; protected set; }
    public Gender Gender { get; protected set; }
    public UserFirstName FirstName { get; protected set; } = null!;
    public UserLastName LastName { get; protected set; } = null!;
    public UserMobile Mobile { get; protected set; } = null!;
    public UserMobileActiveCode MobileActiveCode { get; protected set; } = null!;
    public UserIsMobileActive IsMobileActive { get; protected set; } = null!;
    public UserPassword Password { get; protected set; } = null!;

    #endregion
}
