using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PInterestClient.Models
{
    public class IUserPin
    {

        [JsonProperty("id")]
        string Id { get; set; }

        [JsonProperty("url")]
        string Url { get; set; }

        [JsonProperty("created_at")]
        DateTime CreatedAt { get; set; }

        [JsonProperty("note")]
        string Note { get; set; }


        [JsonProperty("board")]
        IBoard Board { get; set; }

        [JsonProperty("counts")]
        IPinCounts Counts { get; set; }

  
        [JsonProperty("link")]
        string Link { get; set; }

        [JsonProperty("original_link")]
        string OriginalLink { get; set; }

        [JsonProperty("color")]
        string Color { get; set; }

        [JsonProperty("media")]
        IDictionary<string, string> Media { get; set; }

        [JsonProperty("attribution")]
        IDictionary<string, dynamic> Attribution { get; set; }

        [JsonProperty("metadata")]
        IDictionary<string, dynamic> Metadata { get; set; }

        [JsonProperty("creator")]
        Creator creator { get; set; }

    }
}
