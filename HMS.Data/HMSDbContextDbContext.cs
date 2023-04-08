using HMS.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HMS.Data
{
    public class HMSDbContext : IdentityDbContext<User>
    {
        public HMSDbContext(DbContextOptions<HMSDbContext> options)
            : base(options)
        {
        }
    }
}