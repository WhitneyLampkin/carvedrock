using CarvedRock.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.API.Data
{
    public class CarvedRockDbContext : DbContext
    {
        public CarvedRockDbContext(DbContextOptions<CarvedRockDbContext> options)
            : base(options)
        {
                
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
    }
}
