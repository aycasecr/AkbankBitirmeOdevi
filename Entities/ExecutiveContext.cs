using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Entities
{
    public class ExecutiveContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ExecutiveContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer(Configuration.GetConnectionString("MovieDBEntities"));
            options.UseSqlServer("Data Source=localhost; Database=ExecutiveDB; integrated security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Flat>().ToTable("Flat");
            modelBuilder.Entity<Notification>().ToTable("Notification");
            modelBuilder.Entity<Payment>().ToTable("Payment");
            modelBuilder.Entity<Resident>().ToTable("Resident");
            modelBuilder.Entity<Logger>().ToTable("Logger");
        }
        public DbSet<User> user { get; set; }
        public DbSet<Flat> flat { get; set; }
        public DbSet<Notification> notification { get; set; }
        public DbSet<Payment> payment { get; set; }
        public DbSet<Resident> resident { get; set; }
        public DbSet<Logger> logger { get; set; }

    }
}
