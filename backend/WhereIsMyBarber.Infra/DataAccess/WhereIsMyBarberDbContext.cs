using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhereIsMyBarber.Domain.Entities;

namespace WhereIsMyBarber.Infra.DataAccess
{
    public class WhereIsMyBarberDbContext : DbContext
    {
        public WhereIsMyBarberDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WhereIsMyBarberDbContext).Assembly);
        }
    }
}