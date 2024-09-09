using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VendorApp.Models;

namespace VendorApp.Context;

public partial class VendorDbContext : DbContext
{
    public VendorDbContext()
    {
    }

    public VendorDbContext(DbContextOptions<VendorDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__vendors__3213E83FAE321A9F");

            entity.ToTable("vendors");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnnualTurnover)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("annual_turnover");
            entity.Property(e => e.CompanyName).HasColumnName("company_name");
            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.LastEdition).HasColumnName("last_edition");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.PhysicalAddress).HasColumnName("physical_address");
            entity.Property(e => e.TaxId)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_id");
            entity.Property(e => e.TradeName).HasColumnName("trade_name");
            entity.Property(e => e.WebsiteUrl).HasColumnName("website_url");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
