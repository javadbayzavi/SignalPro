using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Signaler.Data.Models.assets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Signaler.Data.Mappings
{
    public class exhangeConfiguration : IEntityTypeConfiguration<exchange>
    {
        public void Configure(EntityTypeBuilder<exchange> builder)
        {
            //Set the source name for this entity
            builder.ToTable("exchage");
        }
    }
}
