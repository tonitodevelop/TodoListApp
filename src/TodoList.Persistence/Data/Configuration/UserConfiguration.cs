using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Entities;

namespace Todo.Persistence.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired();

            builder.Property(u => u.UserName)
                .IsRequired();
            builder.HasIndex(u => u.UserName)
                .IsUnique();

            builder.Property(u => u.Password)

                .IsRequired();

            builder.HasMany(u => u.TodoLists)
                .WithOne(l => l.User)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
