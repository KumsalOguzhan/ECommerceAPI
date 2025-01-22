using ECommerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistance.Contexts
{
    public class ECommerceAPIDBContext : DbContext
    {
        public ECommerceAPIDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var data = ChangeTracker.Entries().Where(data => data.State == EntityState.Added || data.State == EntityState.Modified);
            foreach (var item in data)
            {
                if (item.State == EntityState.Added)
                {
                    item.CurrentValues["CreatedDate"] = DateTime.Now;
                }
                item.CurrentValues["UpdatedDate"] = DateTime.Now;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
