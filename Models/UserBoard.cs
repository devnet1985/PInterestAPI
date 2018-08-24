using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PInterestClient.Models
{
 public   class UserBoard
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("creator")]
        public Creator creator { get; set; }

        [JsonProperty("privacy")]
        public string Privacy { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

 
        [JsonProperty("counts")]
        public IBoardCount Count { get; set; }

        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
        
    }
}
