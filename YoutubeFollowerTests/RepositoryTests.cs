using DataAccessLibrary.Models;
using System;
using Xunit;
using YoutubeFollower.Exceptions;
using YoutubeFollower.Repository;
using YoutubeFollowerTests.Context;

namespace YoutubeFollowerTests
{
    public class RepositoryTests
    {
        private FollowerContextFactory _contextFactory { get; set; }
        private FollowerRepository _repository { get; set; }
        public RepositoryTests()
        {
            _contextFactory = new FollowerContextFactory();
        }
        [Fact]
        public void GetStaredChannel_ActualStaredChannel()
        {
            var context = _contextFactory.CreateRealDb();
            _repository = new FollowerRepository(context);
            var expected = new ChannelSnippet
            {
                Id = "UCRbni8punxajnQgnuOjfbyg",
                Name = "chechmek",
                IsStared = true,
            };
            
            var actual = _repository.GetStaredChannel();

            Assert.NotNull(actual);
            Assert.True(actual.IsStared);
            Assert.Equal(actual.Name, expected.Name);
        }
        [Fact]
        public void GetStarredChannel_FirstChannel()
        {
            var context = _contextFactory.CreateDbWithoutStared();
            _repository = new FollowerRepository(context);
            var expected = new ChannelSnippet
            {
                Id = "UC0DSO7cuqCc0P-nMvJVspHA",
                Name = "prodbysiqq",
                IsStared = false,
            };

            var actual = _repository.GetStaredChannel();

            Assert.NotNull(actual);
            Assert.False(actual.IsStared);
            Assert.Equal(actual.Name, expected.Name);
        }
        [Fact]
        public void GetStarredChannel_Fail()
        {
            var context = _contextFactory.CreateEmptyDb();
            _repository = new FollowerRepository(context);

            Assert.Throws<ChannelNotExistsException>(() =>
            {
                _repository.GetStaredChannel();
            });
        }
    }
}
