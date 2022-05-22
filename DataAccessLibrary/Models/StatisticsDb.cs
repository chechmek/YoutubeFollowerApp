using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
        
    public class StatisticsDb
    {
        [Key]
        public DateTime Date { get; set; }
        public string ChannelId { get; set; }
        public int ViewCount { get; set; }
        public int VideosCount { get; set; }
        public int SubscriberCount { get; set; }
        //public ChannelSnippet ChannelSnippet { get; set; }
    }
}
