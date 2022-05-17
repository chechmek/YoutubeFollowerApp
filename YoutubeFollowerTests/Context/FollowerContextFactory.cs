using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeFollowerTests.Context
{
    public class FollowerContextFactory
    {
        private FollowerDbContext _context;
        public FollowerContextFactory()
        {
            var options = new DbContextOptionsBuilder<FollowerDbContext>()
                .UseInMemoryDatabase("TestDb").Options;
            _context = new FollowerDbContext(options);
            _context.Database.EnsureCreated();

        }
        public FollowerDbContext CreateRealDb()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.AddRange(
                new ChannelSnippet
                {
                    Id = "UC0DSO7cuqCc0P-nMvJVspHA",
                    Name = "prodbysiqq",
                    IsStared = false,
                },
                new ChannelSnippet
                {
                    Id = "UCRbni8punxajnQgnuOjfbyg",
                    Name = "chechmek",
                    IsStared = true,
                },
                new ChannelSnippet
                {
                    Id = "UCCcprrrcbdaj14kYPjcbj9w",
                    Name = "В гостях у Гордона",
                    IsStared = false,
                });
            _context.SaveChanges();
            return _context;
        }
        public FollowerDbContext CreateEmptyDb()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.SaveChanges();
            return _context;
        }
        public FollowerDbContext CreateUnrealDb()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.Channels.AddRange(
                new ChannelSnippet
                {
                    Id = "1",
                    Name = "test1",
                    IsStared=false,
                },
                new ChannelSnippet
                {
                    Id = "2",
                    Name = "test2",
                    IsStared = true,
                });
            _context.SaveChanges();
            return _context;
        }
        public FollowerDbContext CreateDbWithoutStared()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.AddRange(
                new ChannelSnippet
                {
                    Id = "UC0DSO7cuqCc0P-nMvJVspHA",
                    Name = "prodbysiqq",
                    IsStared = false,
                },
                new ChannelSnippet
                {
                    Id = "UCRbni8punxajnQgnuOjfbyg",
                    Name = "chechmek",
                    IsStared = false,
                },
                new ChannelSnippet
                {
                    Id = "UCCcprrrcbdaj14kYPjcbj9w",
                    Name = "В гостях у Гордона",
                    IsStared = false,
                });
            _context.SaveChanges();

            return _context;
        }
    }
}