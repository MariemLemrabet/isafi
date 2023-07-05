using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace isafi.Models
{
    public class Address
    {
        [JsonProperty("address")]
        public string AddressLine { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        public Address(string address, double latitude, double longitude)
        {
            AddressLine = address;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Address FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Address>(json);
        }
    }
}
