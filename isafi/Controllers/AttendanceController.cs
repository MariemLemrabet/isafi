using isafi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace isafi.Controllers
{
    public class AttendanceController : ApiController
    {
        private static List<Attendance> attendanceList = new List<Attendance>();

        [HttpGet]
        public IEnumerable<Attendance> GetAllAttendance()
        {
            return attendanceList;
        }

        [HttpGet]
        public IHttpActionResult GetAttendanceById(string id)
        {
            var attendance = attendanceList.FirstOrDefault(a => a.Id == id);
            if (attendance == null)
            {
                return NotFound();
            }
            return Ok(attendance);
        }

        [HttpPost]
        public IHttpActionResult CreateAttendance(Attendance attendance)
        {
            attendanceList.Add(attendance);
            return CreatedAtRoute("DefaultApi", new { id = attendance.Id }, attendance);
        }

        [HttpPut]
        public IHttpActionResult UpdateAttendance(string id, Attendance updatedAttendance)
        {
            var attendance = attendanceList.FirstOrDefault(a => a.Id == id);
            if (attendance == null)
            {
                return NotFound();
            }

            // Mettre à jour les propriétés de la présence avec les valeurs fournies
            attendance.ClockIn = updatedAttendance.ClockIn;
            attendance.ClockOut = updatedAttendance.ClockOut;
            attendance.Duration = updatedAttendance.Duration;
            attendance.IdUser = updatedAttendance.IdUser;
            attendance.Status = updatedAttendance.Status;
            attendance.NameUser = updatedAttendance.NameUser;
            attendance.PhoneUser = updatedAttendance.PhoneUser;
            attendance.Position = updatedAttendance.Position;

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteAttendance(string id)
        {
            var attendance = attendanceList.FirstOrDefault(a => a.Id == id);
            if (attendance == null)
            {
                return NotFound();
            }
            attendanceList.Remove(attendance);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
