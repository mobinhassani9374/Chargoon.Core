using Chargoon.DomainModels.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chargoon.DataLayer.Mapper
{
    public class UserMapper : BaseMapper<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            var prop=

            // PhoneNumber
            builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(100);
            builder.HasIndex(c => c.PhoneNumber).IsUnique(true);

            //SerialNumber
            builder.Property(c => c.SerialNumber).IsRequired().HasMaxLength(100);

            //FullName
            builder.Property(c => c.FullName).HasMaxLength(10000);
        }
    }
}
