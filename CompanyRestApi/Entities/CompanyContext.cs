using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CompanyRestApi.Entities
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base (options)
        {
            //Database.EnsureCreated();
            Database.Migrate();
        }
        public DbSet<Company> companies { get; set; }
        public DbSet<Technology> technologies { get; set; }
    }
}
