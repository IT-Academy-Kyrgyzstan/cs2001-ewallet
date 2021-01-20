using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class EwalletContext : DbContext
    {
        private readonly string _connectionString;
        
        public EwalletContext(string connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
            => builder.UseSqlServer(_connectionString);
    }
}
