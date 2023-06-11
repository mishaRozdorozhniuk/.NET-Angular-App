using System;
using ApiAds.Models;
using Microsoft.EntityFrameworkCore;
 
namespace ApiAds.DAL;

public class AdsContext : DbContext
{
    public DbSet<Ad> Ad { get; set; }

    public AdsContext(DbContextOptions<AdsContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
        => builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
}

