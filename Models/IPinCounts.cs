using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PInterestClient.Models
{
  public  class IPinCounts
    {
        [JsonProperty("comments")]
        public int Comments { get; set; }

        [JsonProperty("saves")]
        public int Saves { get; set; }

       
    }
}
