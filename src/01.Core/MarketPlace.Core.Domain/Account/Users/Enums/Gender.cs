using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Core.Domain.Account.Users.Enums;

public enum Gender
{
    [Display(Name = "جنسیت نامشخص")]
    UnknownGender,
    [Display(Name = "آقا")]
    Male,
    [Display(Name = "خانم")]
    Female
}
