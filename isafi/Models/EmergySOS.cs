using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace isafi.Models
{
    public class EmergySOS
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createBy")]
        public string CreateBy { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("namePatient")]
        public string NamePatient { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        public EmergySOS(string id, string createBy, string phoneNumber, string namePatient, Address address)
        {
            Id = id;
            CreateBy = createBy;
            PhoneNumber = phoneNumber;
            NamePatient = namePatient;
            Address = address;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static EmergySOS FromJson(string json)
        {
            return JsonConvert.DeserializeObject<EmergySOS>(json);
        }
    }

    public class EmergySOSListContainer
    {
        [JsonProperty("emergySOSList")]
        public List<EmergySOS> EmergySOSList { get; set; }

        public EmergySOSListContainer(List<EmergySOS> emergySOSList)
        {
            EmergySOSList = emergySOSList;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static EmergySOSListContainer FromJson(string json)
        {
            return JsonConvert.DeserializeObject<EmergySOSListContainer>(json);
        }
    }
}