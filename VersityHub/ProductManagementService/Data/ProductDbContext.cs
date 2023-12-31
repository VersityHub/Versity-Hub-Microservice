﻿using Microsoft.EntityFrameworkCore;
using ProductManagementService.Model.Products;

namespace ProductManagementService.Data
{
    public class PMDbContext : DbContext
    {

        public PMDbContext(DbContextOptions<PMDbContext> options)
            : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }


    }
}
