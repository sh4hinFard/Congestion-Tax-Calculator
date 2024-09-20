using FardTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FardTest.Dbcontext
{
    public class CongestionTaxDbContext : DbContext
    {
        public DbSet<TaxRule> TaxRules { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Configure the context to use SQL Server
                optionsBuilder.UseSqlServer("Data Source=.;Integrated Security=True;initial catalog=TestDB;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxRule>().HasData(
                new TaxRule { Id = 1, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(6, 29, 59), Amount = 8, Year = 2013, City = "Gothenburg" },
                new TaxRule { Id = 2, StartTime = new TimeSpan(6, 30, 0), EndTime = new TimeSpan(6, 59, 59), Amount = 13, Year = 2013, City = "Gothenburg" },
                new TaxRule { Id = 3, StartTime = new TimeSpan(7, 0, 0), EndTime = new TimeSpan(7, 59, 59), Amount = 18, Year = 2013, City = "Gothenburg" },
                new TaxRule { Id = 4, StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(8, 29, 59), Amount = 13, Year = 2013, City = "Gothenburg" },
                new TaxRule { Id = 5, StartTime = new TimeSpan(8, 30, 0), EndTime = new TimeSpan(14, 59, 59), Amount = 8, Year = 2013, City = "Gothenburg" },
                new TaxRule { Id = 6, StartTime = new TimeSpan(15, 0, 0), EndTime = new TimeSpan(15, 29, 59), Amount = 13, Year = 2013, City = "Gothenburg" },
                new TaxRule { Id = 7, StartTime = new TimeSpan(15, 30, 0), EndTime = new TimeSpan(16, 59, 59), Amount = 18, Year = 2013, City = "Gothenburg" },
                new TaxRule { Id = 8, StartTime = new TimeSpan(17, 0, 0), EndTime = new TimeSpan(17, 59, 59), Amount = 13, Year = 2013, City = "Gothenburg" },
                new TaxRule { Id = 9, StartTime = new TimeSpan(18, 0, 0), EndTime = new TimeSpan(18, 29, 59), Amount = 8, Year = 2013, City = "Gothenburg" },
                new TaxRule { Id = 10, StartTime = new TimeSpan(18, 30, 0), EndTime = new TimeSpan(5, 59, 59), Amount = 0, Year = 2013, City = "Gothenburg" }
            );

            base.OnModelCreating(modelBuilder);
        }

    }

}
