using Backend.Domain.IRepositories;
using Backend.Domain.IServices;
using Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class MedicalHistoryService : IMedicalHistoryService
    {
        private readonly IMedicalHistoryRepository _medicalHistoryRepository;
        public MedicalHistoryService(IMedicalHistoryRepository medicalHistoryRepository)
        {
            _medicalHistoryRepository = medicalHistoryRepository;
        }

        public async Task<List<MedicalHistory>> GetMedicalHistory(int patientID)
        {
            return await _medicalHistoryRepository.GetMedicalHistory(patientID);
        }

        public async Task SaveMedicalHistory(MedicalHistory medicalHistory)
        {
            await _medicalHistoryRepository.SaveMedicalHistory(medicalHistory);
        }
    }
}
