using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using isafi.Models;

namespace isafi.Controllers
{
    public class UserController : ApiController
    {
        private static List<UserModel> users = new List<UserModel>
        {
            // Ajoutez les utilisateurs ici
            new UserModel
            {
                Id = "1",
                Email = "user1@example.com",
                Password = "password1",
                FullName = "User 1",
                PhoneNumber = "1234567891",
                Role = UserModel.UserRole.User,
                Token = "token1",
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                MedicalRecord = new MedicalRecord
                {
                    Id = "1",
                    PatientName = "Patient 1",
                    DateOfBirth = DateTime.Parse("1990-01-01"),
                    BloodType = "A+",
                    Allergies = new List<string> { "Allergy 1", "Allergy 2" },
                    Medications = new List<string> { "Medication 1", "Medication 2" },
                    Conditions = new List<string> { "Condition 1", "Condition 2" }
                }
            },
            // Ajoutez d'autres utilisateurs ici
             new UserModel
            {
                Id = "2",
                Email = "user1@example.com",
                Password = "password1",
                FullName = "User 2",
                PhoneNumber = "1234567891",
                Role = UserModel.UserRole.User,
                Token = "token1",
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                MedicalRecord = new MedicalRecord
                {
                    Id = "2",
                    PatientName = "Patient 2",
                    DateOfBirth = DateTime.Parse("1990-01-01"),
                    BloodType = "A+",
                    Allergies = new List<string> { "Allergy 1", "Allergy 2" },
                    Medications = new List<string> { "Medication 1", "Medication 2" },
                    Conditions = new List<string> { "Condition 1", "Condition 2" }
                }
            },
        };

        [HttpGet]
        public IEnumerable<UserModel> GetAllUsers()
        {
            return users;
        }

        [HttpGet]
        public IHttpActionResult GetUserById(string id)
        {
            var user = users.FirstOrDefault(u =>  u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IHttpActionResult CreateUser(UserModel user)
        {
            users.Add(user);
            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        [HttpPut]
        public IHttpActionResult UpdateUser(string id, UserModel updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            // Mettre à jour les propriétés de l'utilisateur avec les valeurs fournies
            user.Email = updatedUser.Email;
            user.Password = updatedUser.Password;
            user.FullName = updatedUser.FullName;
            user.PhoneNumber = updatedUser.PhoneNumber;
            user.Role = updatedUser.Role;
            user.Token = updatedUser.Token;
            user.UpdateAt = DateTime.Now;
            user.MedicalRecord = updatedUser.MedicalRecord;

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteUser(string id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            users.Remove(user);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
