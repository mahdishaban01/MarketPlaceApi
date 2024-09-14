using MarketPlace.Core.Domain.Account.Users.Entities;
using MarketPlace.Core.Domain.Account.Users.ValueObjects;

namespace MarketPlace.Infra.Data.Sql.Account.Users;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        //Id
        builder.HasKey(b => b.Id);

        //FirstName
        builder.Property(c => c.FirstName).HasConversion(c => c.Value, d => new UserFirstName(d));
        builder.Property(b => b.FirstName).HasMaxLength(50).IsRequired();

        //LastName
        builder.Property(c => c.LastName).HasConversion(c => c.Value, d => new UserLastName(d));
        builder.Property(b => b.LastName).HasMaxLength(50).IsRequired();

        //Mobile
        builder.Property(c => c.Mobile).HasConversion(c => c.Value, d => new UserMobile(d));
        builder.Property(b => b.Mobile).HasMaxLength(11).IsRequired();

        //MobileActiveCode
        builder.Property(c => c.MobileActiveCode).HasConversion(c => c.Value, d => new UserMobileActiveCode(d));
        builder.Property(b => b.MobileActiveCode).HasMaxLength(150).IsRequired();

        //IsMobileActive
        builder.Property(c => c.IsMobileActive).HasConversion(c => c.Value, d => new UserIsMobileActive(d));
        builder.Property(b => b.IsMobileActive).IsRequired();

        //Password
        builder.Property(c => c.Password).HasConversion(c => c.Value, d => new UserPassword(d));
        builder.Property(b => b.Password).HasMaxLength(150).IsRequired();

        //InsertedOn
        builder.Property(x => x.InsertOn).HasColumnType("datetime");
        //UpdateOn
        builder.Property(x => x.UpdateOn).HasColumnType("datetime");
        //RowVersion
        builder.Property(x => x.RowVersion).IsRowVersion();
    }
}
