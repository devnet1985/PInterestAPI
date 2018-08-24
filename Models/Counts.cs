using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PInterestClient.Models
{
  public  class Counts
    {
        [JsonProperty("pins")]
        public int Pins { get; set; }

        [JsonProperty("following")]
        public int Following { get; set; }

       [JsonProperty("followers")]
        public int Followers { get; set; }

       
        
    }
}
