﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Wow.Models;

namespace Wow.Context;

public partial class KlimBaseContext : DbContext
{
    public KlimBaseContext()
    {
    }

    public KlimBaseContext(DbContextOptions<KlimBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductSale> ProductSales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=89.110.53.87:5522; Database=klim_base; Username=klim; Password=nissan");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("newtable_1_pk");

            entity.ToTable("manufacturers", "Demo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Manufacturersname)
                .HasColumnType("character varying")
                .HasColumnName("manufacturersname");
            entity.Property(e => e.Startupdate).HasColumnName("startupdate");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pk");

            entity.ToTable("products", "Demo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Image)
                .HasColumnType("character varying")
                .HasColumnName("image");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasColumnType("character varying")
                .HasColumnName("product_name");
        });

        modelBuilder.Entity<ProductSale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("newtable_pk");

            entity.ToTable("productSale", "Demo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Countofproduct).HasColumnName("countofproduct");
            entity.Property(e => e.Dateofsale).HasColumnName("dateofsale");
            entity.Property(e => e.Man).HasColumnName("man");
            entity.Property(e => e.Product).HasColumnName("product");
            entity.Property(e => e.Timeofsale).HasColumnName("timeofsale");

            entity.HasOne(d => d.ManNavigation).WithMany(p => p.ProductSales)
                .HasForeignKey(d => d.Man)
                .HasConstraintName("productsale_manufacturers_fk");

            entity.HasOne(d => d.ProductNavigation).WithMany(p => p.ProductSales)
                .HasForeignKey(d => d.Product)
                .HasConstraintName("productsale_products_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
