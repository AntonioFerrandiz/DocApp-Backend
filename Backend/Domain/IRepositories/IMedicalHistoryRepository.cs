using Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.IRepositories
{
    public interface IMedicalHistoryRepository
    {
        Task SaveMedicalHistory(MedicalHistory medicalHistory);
        Task<List<MedicalHistory>> GetMedicalHistory(int patientID);
    }
}
