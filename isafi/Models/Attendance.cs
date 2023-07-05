using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace isafi.Models
{
    public class Attendance
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("clockIn")]
        public DateTime ClockIn { get; set; }

        [JsonProperty("clockOut")]
        public DateTime ClockOut { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("idUser")]
        public string IdUser { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("nameUser")]
        public string NameUser { get; set; }

        [JsonProperty("phoneUser")]
        public string PhoneUser { get; set; }

        [JsonProperty("position")]
        public Dictionary<string, double> Position { get; set; }

        public Attendance()
        {
        }

        public Attendance(string id, DateTime clockIn, DateTime clockOut, string duration, string idUser,
            bool status, string nameUser, string phoneUser, Dictionary<string, double> position)
        {
            Id = id;
            ClockIn = clockIn;
            ClockOut = clockOut;
            Duration = duration;
            IdUser = idUser;
            Status = status;
            NameUser = nameUser;
            PhoneUser = phoneUser;
            Position = position;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Attendance FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Attendance>(json);
        }
    }

    public class AttendanceList
    {
        [JsonProperty("attendanceList")]
        public List<Attendance> AttendanceListData { get; set; }

        public AttendanceList()
        {
            AttendanceListData = new List<Attendance>();
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static AttendanceList FromJson(string json)
        {
            return JsonConvert.DeserializeObject<AttendanceList>(json);
        }
    }
}
