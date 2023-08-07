using ManagementSystem.Data.EntityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Data.DbContext
{
    public class ManagementSystemDbContext : IdentityDbContext
    {
        public ManagementSystemDbContext() { }

        public ManagementSystemDbContext(DbContextOptions<ManagementSystemDbContext> options) : base(options) { }

        public virtual DbSet<UserDetails>? SystemUserDetails { get; set; }

    }
}
