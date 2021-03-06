using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Signaler.Data.Models.assets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Signaler.Data.Mappings
{
    public class assetConfiguration : IEntityTypeConfiguration<asset>
    {
        public void Configure(EntityTypeBuilder<asset> builder)
        {
            builder.Property(p => p.name).IsRequired(true);

            //Set the source name for this entity
            builder.ToTable("asset");
        }
    }
}
