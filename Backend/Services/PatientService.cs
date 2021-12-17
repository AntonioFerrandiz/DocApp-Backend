using Backend.Domain.IRepositories;
using Backend.Domain.IServices;
using Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task CreatePatient(Patient patient)
        {
            await _patientRepository.CreatePatient(patient);
        }

        public async Task DeletePatient(Patient patient)
        {
            await _patientRepository.DeletePatient(patient);
        }

        public async Task<List<Patient>> GetListPatientByUser(int userID)
        {
            return await _patientRepository.GetListPatientByUser(userID);
        }

        public async Task<Patient> GetPatient(int patientID)
        {
            return await _patientRepository.GetPatient(patientID);
        }

        public async Task<Patient> SearchPatient(int patientID, int userID)
        {
            return await _patientRepository.SearchPatient(patientID, userID);
        }

        public async Task<Patient> SearchPatientByFirstname(string firstname, int userID)
        {
            return await _patientRepository.SearchPatientByFirstname(firstname, userID);
        }

        public async Task<Patient> SearchPatientByLastname(string lastname, int userID)
        {
            return await _patientRepository.SearchPatientByLastname(lastname, userID);
        }
    }
}
