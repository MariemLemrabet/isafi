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
    public class EmergencyCallController : ApiController
    {
        private static List<EmergencyCall> emergencyCalls = new List<EmergencyCall>();

        [HttpGet]
        public IEnumerable<EmergencyCall> GetAllEmergencyCalls()
        {
            return emergencyCalls;
        }

        [HttpGet]
        public IHttpActionResult GetEmergencyCallById(string id)
        {
            var emergencyCall = emergencyCalls.FirstOrDefault(e => e.Id == id);
            if (emergencyCall == null)
            {
                return NotFound();
            }
            return Ok(emergencyCall);
        }

        [HttpPost]
        public IHttpActionResult CreateEmergencyCall(EmergencyCall emergencyCall)
        {
            emergencyCalls.Add(emergencyCall);
            return CreatedAtRoute("DefaultApi", new { id = emergencyCall.Id }, emergencyCall);
        }

        [HttpPut]
        public IHttpActionResult UpdateEmergencyCall(string id, EmergencyCall updatedEmergencyCall)
        {
            var emergencyCall = emergencyCalls.FirstOrDefault(e => e.Id == id);
            if (emergencyCall == null)
            {
                return NotFound();
            }

            // Mettre à jour les propriétés de l'appel d'urgence avec les valeurs fournies
            emergencyCall.PatientName = updatedEmergencyCall.PatientName;
            emergencyCall.Description = updatedEmergencyCall.Description;
            emergencyCall.Status = updatedEmergencyCall.Status;
            emergencyCall.CreateAt = updatedEmergencyCall.CreateAt;
            emergencyCall.IsByCall = updatedEmergencyCall.IsByCall;
            emergencyCall.AddBy = updatedEmergencyCall.AddBy;
            emergencyCall.CreateBy = updatedEmergencyCall.CreateBy;
            emergencyCall.PhoneNumber = updatedEmergencyCall.PhoneNumber;
            emergencyCall.Address = updatedEmergencyCall.Address;
            emergencyCall.Sex = updatedEmergencyCall.Sex;
            emergencyCall.PatientType = updatedEmergencyCall.PatientType;
            emergencyCall.PatientCount = updatedEmergencyCall.PatientCount;
            emergencyCall.EmergencyAccidentType = updatedEmergencyCall.EmergencyAccidentType;
            emergencyCall.SubCategoryId = updatedEmergencyCall.SubCategoryId;
            emergencyCall.UserRole = updatedEmergencyCall.UserRole;

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmergencyCall(string id)
        {
            var emergencyCall = emergencyCalls.FirstOrDefault(e => e.Id == id);
            if (emergencyCall == null)
            {
                return NotFound();
            }
            emergencyCalls.Remove(emergencyCall);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
