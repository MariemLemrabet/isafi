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
    public class MedicalRecordController : ApiController
    {
        private static List<MedicalRecord> medicalRecords = new List<MedicalRecord>();

        [HttpGet]
        public IEnumerable<MedicalRecord> GetAllMedicalRecords()
        {
            return medicalRecords;
        }

        [HttpGet]
        public IHttpActionResult GetMedicalRecordById(string id)
        {
            var medicalRecord = medicalRecords.FirstOrDefault(m => m.Id == id);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            return Ok(medicalRecord);
        }

        [HttpPost]
        public IHttpActionResult CreateMedicalRecord(MedicalRecord medicalRecord)
        {
            medicalRecords.Add(medicalRecord);
            return CreatedAtRoute("DefaultApi", new { id = medicalRecord.Id }, medicalRecord);
        }

        [HttpPut]
        public IHttpActionResult UpdateMedicalRecord(string id, MedicalRecord updatedMedicalRecord)
        {
            var medicalRecord = medicalRecords.FirstOrDefault(m => m.Id == id);
            if (medicalRecord == null)
            {
                return NotFound();
            }

            // Mettre à jour les propriétés du dossier médical avec les valeurs fournies
            medicalRecord.PatientName = updatedMedicalRecord.PatientName;
            medicalRecord.DateOfBirth = updatedMedicalRecord.DateOfBirth;
            medicalRecord.BloodType = updatedMedicalRecord.BloodType;
            medicalRecord.Allergies = updatedMedicalRecord.Allergies;
            medicalRecord.Medications = updatedMedicalRecord.Medications;
            medicalRecord.Conditions = updatedMedicalRecord.Conditions;

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteMedicalRecord(string id)
        {
            var medicalRecord = medicalRecords.FirstOrDefault(m => m.Id == id);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            medicalRecords.Remove(medicalRecord);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
