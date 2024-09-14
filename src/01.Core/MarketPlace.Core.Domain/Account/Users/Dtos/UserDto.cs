namespace MarketPlace.Core.Domain.Account.Users.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public int RegisterUserType { get; set; }
        public int Gender { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public bool IsMobileActive { get; set; }
        public DateTime InsertOn { get; set; }
        public DateTime? UpdateOn { get; set; }
        public int InsertBy { get; set; }
        public int? UpdateBy { get; set; }
        public bool IsActive { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
