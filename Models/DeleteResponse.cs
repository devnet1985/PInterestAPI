using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace PInterestClient.Models
{
   public class DeleteResponse
    {
       
            [JsonProperty("message")]
          public  string message { get; set; }

            [JsonProperty("type")]
        public string type { get; set; }

            [JsonProperty("data")]
        public string data { get; set; }


      
    }
}
