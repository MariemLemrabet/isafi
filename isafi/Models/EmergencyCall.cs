using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace isafi.Models
{
    public class EmergencyCall
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("patientName")]
        public string PatientName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("status")]
        public EmergencyStatus Status { get; set; }

        [JsonProperty("createAt")]
        public DateTime CreateAt { get; set; }

        [JsonProperty("isByCall")]
        public bool IsByCall { get; set; }

        [JsonProperty("addBy")]
        public Enum AddBy { get; set; }

        [JsonProperty("createBy")]
        public string CreateBy { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("sex")]
        public string Sex { get; set; }

        [JsonProperty("patientType")]
        public string PatientType { get; set; }

        [JsonProperty("patientCount")]
        public int PatientCount { get; set; }

        [JsonProperty("emergencyAccidentType")]
        public AccidentType EmergencyAccidentType { get; set; }

        [JsonProperty("subCategoryId")]
        public string SubCategoryId { get; set; }

        [JsonProperty("userRole")]
        public UserModel.UserRole UserRole { get; set; }

        public enum EmergencyStatus
        {
            [Display(Name = "Pending")]
            PENDING,

            [Display(Name = "In Progress")]
            IN_PROGRESS,

            [Display(Name = "Completed")]
            COMPLETED,

            [Display(Name = "Cancelled")]
            CANCELLED,

            [Display(Name = "Rejected")]
            REJECTED
        }

        public enum AccidentType
        {
            [Display(Name = "Accidents")]
            ACCIDENTS,

            [Display(Name = "Maladies")]
            MALADIES,

            [Display(Name = "Femmes et Maternité")]
            FEMMES_ET_MATERNITE,

            [Display(Name = "Toxicité")]
            TOXICITE
        }
    }
}