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
    public class EmergySOSController : ApiController
    {
        private static List<EmergySOS> emergySOSList = new List<EmergySOS>();

        [HttpGet]
        public IEnumerable<EmergySOS> GetAllEmergySOS()
        {
            return emergySOSList;
        }

        [HttpGet]
        public IHttpActionResult GetEmergySOSById(string id)
        {
            var emergySOS = emergySOSList.FirstOrDefault(e => e.Id == id);
            if (emergySOS == null)
            {
                return NotFound();
            }
            return Ok(emergySOS);
        }

        [HttpPost]
        public IHttpActionResult CreateEmergySOS(EmergySOS emergySOS)
        {
            emergySOSList.Add(emergySOS);
            return CreatedAtRoute("DefaultApi", new { id = emergySOS.Id }, emergySOS);
        }

        [HttpPut]
        public IHttpActionResult UpdateEmergySOS(string id, EmergySOS updatedEmergySOS)
        {
            var emergySOS = emergySOSList.FirstOrDefault(e => e.Id == id);
            if (emergySOS == null)
            {
                return NotFound();
            }

            // Mettre à jour les propriétés de l'urgence SOS avec les valeurs fournies
            emergySOS.CreateBy = updatedEmergySOS.CreateBy;
            emergySOS.PhoneNumber = updatedEmergySOS.PhoneNumber;
            emergySOS.NamePatient = updatedEmergySOS.NamePatient;
            emergySOS.Address = updatedEmergySOS.Address;

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmergySOS(string id)
        {
            var emergySOS = emergySOSList.FirstOrDefault(e => e.Id == id);
            if (emergySOS == null)
            {
                return NotFound();
            }
            emergySOSList.Remove(emergySOS);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
