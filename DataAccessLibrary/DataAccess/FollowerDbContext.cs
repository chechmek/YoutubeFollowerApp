using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLibrary.DataAccess
{
    public class FollowerDbContext : DbContext
    {
        public FollowerDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<ChannelSnippet> Channels { get; set; }
    }
}
