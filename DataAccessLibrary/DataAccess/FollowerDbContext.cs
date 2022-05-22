using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLibrary.DataAccess
{
    public class FollowerDbContext : DbContext
    {
        public FollowerDbContext(DbContextOptions options) : base(options)
        {

            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<ChannelSnippet> Channels { get; set; }
        public DbSet<StatisticsDb> Statistic { get; set; }
    }
}
