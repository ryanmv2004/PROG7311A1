using Microsoft.EntityFrameworkCore;
using PROG7311.Models;
using System;

namespace PROG7311.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
