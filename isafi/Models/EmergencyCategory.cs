using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace isafi.Models
{
    public class EmergencyCategory
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("subCategories")]
        public List<isafi.Models.SubCategory> SubCategories { get; set; }

        public EmergencyCategory()
        {
            SubCategories = new List<isafi.Models.SubCategory>();
        }
    }

}
