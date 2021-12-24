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
    public class MedicalHistoryRepository: IMedicalHistoryRepository
    {
        private readonly AplicationDbContext _context;
        public MedicalHistoryRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveMedicalHistory(MedicalHistory medicalHistory)
        {
            _context.Add(medicalHistory);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MedicalHistory>> GetMedicalHistory(int patientID)
        {
            var listMedicalHistory = await _context.medicalHistories
                .Where(x => x.PatientID == patientID)
                .ToListAsync();
            return listMedicalHistory;
        }
    }
}
