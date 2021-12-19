using Backend.Domain.IRepositories;
using Backend.Domain.Models;
using Backend.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Persistence.Repositories
{
    public class PatientRepository: IPatientRepository
    {
        private readonly AplicationDbContext _context;
        public PatientRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreatePatient(Patient patient)
        {
            _context.Add(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePatient(Patient patient)
        {
            patient.Active = 0;
            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<string>> GetListOfGender(int userID)
        {
            var listPatients = await _context.Patients
                .Where(x => x.Active == 1 && x.UserID == userID)
                                .Select(o => new Patient
                                {
                                    Id = o.Id,
                                    Gender = o.Gender
                                })
                .ToListAsync();
            var genders = new List<string>();
            foreach (var patient in listPatients)
            {
                genders.Add(patient.Gender);
            }
            return genders;
        }

        public async Task<List<Patient>> GetListPatientByUser(int userID)
        {
            var listPatients = await _context.Patients
                .Where(x => x.Active == 1 && x.UserID == userID)
                .ToListAsync();
            return listPatients;       
        }

        public async Task<int> GetNumberOfPatients(int userID)
        {
            //.FromSqlRaw("select TOTAL = sum(x.Active) from Patients x group by(x.UserID)")
            var numberOfPatients = await _context.Patients
                .Where(x => x.Active == 1 && x.UserID == userID)
                .ToListAsync();
            return numberOfPatients.Count;
        }

        public async Task<Patient> GetPatient(int patientID)
        {
            var patient = await _context.Patients
                .Where(x => x.Id == patientID && x.Active == 1)
                .Include(x => x.medicalHistories)
                .FirstOrDefaultAsync();
            return patient;
        }

        public async Task<Patient> SearchPatient(int patientID, int userID)
        {
            var patient = await _context.Patients
                .Where(x => x.Id == patientID && x.UserID == userID && x.Active == 1)
                .FirstOrDefaultAsync();
            return patient;
        }

        public async Task<Patient> SearchPatientByFirstname(string firstname, int userID)
        {
            var patient = await _context.Patients
                .Where(x => x.UserID == userID && x.Active == 1 && x.Firstname == firstname)
                .FirstOrDefaultAsync();
            return patient;
        }

        public async Task<Patient> SearchPatientByLastname(string lastname, int userID)
        {
            var patient = await _context.Patients
                .Where(x => x.UserID == userID && x.Active == 1 && x.Lastname == lastname)
                .FirstOrDefaultAsync();
            return patient;
        }
        //select sum(x.Active) from Patients x
    }
}
