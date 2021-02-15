using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class EwalletContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<CardAccount> CardAccounts { get; set; }

        public EwalletContext(DbContextOptions<EwalletContext> options) : base(options)
        {
        }
    }
}
