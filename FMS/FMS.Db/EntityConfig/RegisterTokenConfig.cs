using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Db.EntityConfig
{
    internal class RegisterTokenConfig : IEntityTypeConfiguration<RegisterToken>
    {
        public void Configure(EntityTypeBuilder<RegisterToken> builder)
        {
            builder.ToTable("RegisterTokens", "dbo");
            builder.HasKey(e => e.TokenId);
            builder.Property(e => e.TokenId).HasDefaultValueSql("newid()");
            builder.Property(e => e.TokenValue).HasMaxLength(150);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
        }
    }
}
