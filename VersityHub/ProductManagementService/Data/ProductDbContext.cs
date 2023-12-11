﻿using Microsoft.EntityFrameworkCore;
using ProductManagementService.Model.Products;

namespace ProductManagementService.Data
{
    public class ProductDbContext : DbContext
    {

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }


    }
}
