using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user_");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever();

        builder
            .Property(x => x.Name)
            .HasMaxLength(50);

        builder
            .Property(x => x.LastName)
            .HasMaxLength(50);

        builder
            .Property(x => x.Email)
            .HasMaxLength(150);

        builder
            .Property(x => x.Password);
    }
}