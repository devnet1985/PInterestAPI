using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PInterestClient.Models
{
  public  class User
    {

        [JsonProperty("account_type")]
        public string AccountType { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        

        [JsonProperty("counts")]
        public Counts Counts { get; set; }

        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }




    }
}
