﻿using ECommerceAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistance
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ECommerceAPIDBContext>
    {
        public ECommerceAPIDBContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ECommerceAPIDBContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
