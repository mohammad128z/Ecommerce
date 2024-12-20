﻿using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts.EF_Core
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesLine> SalesLine { get; set; }
        public DbSet<SalesLineInSeller> SalesLineInSeller { get; set; }
        public DbSet<SalesLineInProduct> SalesLineInProduct { get; set; }
        public DbSet<DetailPreInvoice> DetailPreInvoice { get; set; }
        public DbSet<PreInvoiceHeader> PreInvoiceHeader { get; set; }


        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<SalesLineInProduct>().HasKey(e => new { e.SalesLineId, e.ProductId });

            modelBuilder.Entity<DetailPreInvoice>()
                .HasOne(dpi => dpi.PreInvoiceHeader)
                .WithOne(pih => pih.DetailPreInvoice)
                .HasForeignKey<DetailPreInvoice>(dpi => dpi.PreInvoiceHeaderId);

            modelBuilder.Entity<SalesLineInSeller>()
            .HasOne(e => e.PreInvoiceHeader)
            .WithOne(e => e.SalesLineInSeller)
            .HasForeignKey<SalesLineInSeller>(up => up.PreInvoiceHeaderId);

            modelBuilder.Entity<SalesLineInSeller>()
                .HasOne(sc => sc.SalesLine)
                .WithMany(s => s.SalesLineInSellers)
                .HasForeignKey(sc => sc.SalesLineId);

            modelBuilder.Entity<SalesLineInSeller>()
                .HasOne(sc => sc.Seller)
                .WithMany(c => c.SalesLineInSellers)
                .HasForeignKey(sc => sc.SellerId);
        }

    }
}
