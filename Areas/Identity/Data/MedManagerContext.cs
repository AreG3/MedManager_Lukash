using MedManager.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedManager.Data;

public class MedManagerContext : IdentityDbContext<MedManagerUser>
{
    public MedManagerContext(DbContextOptions<MedManagerContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}

class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<MedManagerUser>
{
    public void Configure(EntityTypeBuilder<MedManagerUser> builder)
    {
        builder.Property(u => u.Nick).HasMaxLength(50);
    }
}