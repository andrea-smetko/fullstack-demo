using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public partial class InvestmentmgmtContext : DbContext
{
    public InvestmentmgmtContext()
    {
    }

    public InvestmentmgmtContext(DbContextOptions<InvestmentmgmtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AssetClass> AssetClasses { get; set; }

    public virtual DbSet<Commitment> Commitments { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Investor> Investors { get; set; }

    public virtual DbSet<InvestorType> InvestorTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=../database/investmentmgmt.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssetClass>(entity =>
        {
            entity.ToTable("ASSET_CLASS");
        });

        modelBuilder.Entity<Commitment>(entity =>
        {
            entity.ToTable("COMMITMENT");

            entity.HasOne(d => d.CommitmentAssetClass).WithMany(p => p.Commitments).HasForeignKey(d => d.CommitmentAssetClassId);

            entity.HasOne(d => d.Investor).WithMany(p => p.Commitments)
                .HasForeignKey(d => d.InvestorId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("COUNTRY");
        });

        modelBuilder.Entity<Investor>(entity =>
        {
            entity.ToTable("INVESTOR");

            entity.Property(e => e.DateAdded).HasColumnType("DATE");
            entity.Property(e => e.DateLastUpdated).HasColumnType("DATE");

            entity.HasOne(d => d.InvestorCountry).WithMany(p => p.Investors).HasForeignKey(d => d.InvestorCountryId);

            entity.HasOne(d => d.InvestorType).WithMany(p => p.Investors).HasForeignKey(d => d.InvestorTypeId);
        });

        modelBuilder.Entity<InvestorType>(entity =>
        {
            entity.ToTable("INVESTOR_TYPE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
