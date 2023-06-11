using System;
using ApiAds.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAds.DAL.Configurations;

public class AdsConfigurations : IEntityTypeConfiguration<Ad>
{
    public void Configure(EntityTypeBuilder<Ad> builder)
    {
        builder.HasKey(x => x.Gid);
        builder.Property(x => x.Name).HasMaxLength(15);
        builder.Property(x => x.PhotoLink).HasMaxLength(15);
    }
}

