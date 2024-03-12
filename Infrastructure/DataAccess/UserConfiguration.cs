using Domain.Entities;
using Domain.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ValidateNullArgument(nameof(builder));

        builder.ToTable(nameof(User));
        
        builder.HasKey(user => user.Id);
        builder.HasIndex(user => user.Email).IsUnique();
        builder.Property(user => user.Email).IsRequired();
        builder.Property(user => user.Name).IsRequired();
        builder.Property(user => user.Password).IsRequired();
        builder.Property(user => user.Salt).IsRequired();
    }
}
