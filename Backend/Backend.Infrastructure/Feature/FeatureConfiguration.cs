using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Feature;

public class FeatureConfiguration: IEntityTypeConfiguration<Domain.Feature.Feature>    
{
    public void Configure(EntityTypeBuilder<Domain.Feature.Feature> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
    }
}