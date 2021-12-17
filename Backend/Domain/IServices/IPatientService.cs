using Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.IServices
{
    public interface IPatientService
    {
        Task CreatePatient(Patient patient);
        Task<List<Patient>> GetListPatientByUser(int userID);
        Task<Patient> GetPatient(int patientID);
        Task<Patient> SearchPatient(int patientID, int userID);
        Task<Patient> SearchPatientByFirstname(string firstname, int userID);
        Task<Patient> SearchPatientByLastname(string lastname, int userID);
        Task DeletePatient(Patient patient);
    }
}
