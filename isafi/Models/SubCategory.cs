using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace isafi.Models
{
    public class SubCategory
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public SubCategory(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static SubCategory FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SubCategory>(json);
        }
    }
}