using Domain.Entities;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class SQLObjectConfiguration : IEntityTypeConfiguration<SQLObject>
{
    public void Configure(EntityTypeBuilder<SQLObject> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion<SQLObjectId.EfCoreValueConverter>();
    }
}

