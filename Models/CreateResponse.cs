using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace PInterestClient.Models
{
  public  class CreateResponse
    {
        [JsonProperty("message")]
        public string message { get; set; }

        [JsonProperty("StatusCode")]
        public int StatusCode { get; set; }

        [JsonProperty("data")]
        public string data { get; set; }

        [JsonProperty("StatusDescription")]
        public string StatusDescription { get; set; }

        
    }
}
