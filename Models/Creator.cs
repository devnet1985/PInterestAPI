using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PInterestClient.Models
{
    public class Creator
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

     
        [JsonProperty("id")]
        public string ID { get; set; }
    }
}
