using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDataBaseContext
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


        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        public DbSet<TEntity> Set<TEntity>()
        where TEntity : class;
    }
}
