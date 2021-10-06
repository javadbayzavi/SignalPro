using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Signaler.Data.Models.assets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Signaler.Data.Mappings
{
    public class assetmarketConfiguration : IEntityTypeConfiguration<assetmarket>
    {
        public void Configure(EntityTypeBuilder<assetmarket> builder)
        {
            //Set the source name for this entity
            builder.ToTable("assetmarket");
        }
    }
}
