using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeFollower.Models;

namespace YoutubeFollowerTests
{
    public static class TestData
    {
        public static Channel ChechmekChannel
        {
            get
            {
                return new Channel
                {
                    Id = "UCRbni8punxajnQgnuOjfbyg",
                    Title = "chechmek",
                    
                };
            }
        }
        public static string ChannelId { get; set; } = "UCRbni8punxajnQgnuOjfbyg";
        public static string ChannelIdWithoutContent { get; set; } = "UC87mLwjzs12oabpAxrGgunA";
        public static string GordonChannelId { get; set; } = "UCZIFo5MmrUJS5JbLOxgnHuQ";
    }
}
