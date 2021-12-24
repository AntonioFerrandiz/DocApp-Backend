using Backend.Domain.IServices;
using Backend.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalHistoryController : ControllerBase
    {
        private readonly IMedicalHistoryService _medicalHistoryService;
        public MedicalHistoryController(IMedicalHistoryService medicalHistoryService)
        {
            _medicalHistoryService = medicalHistoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MedicalHistory medicalHistory)
        {
            try
            {
                medicalHistory.DateCreated = DateTime.Now;
                await _medicalHistoryService.SaveMedicalHistory(medicalHistory);
                return Ok(new { message = "Medical history was added correctly" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetMedicalHistory/{patientID}")]
        [HttpGet]
        public async Task<IActionResult> GetMedicalHistory(int patientID)
        {
            try
            {
                var medicalHistory = await _medicalHistoryService.GetMedicalHistory(patientID);
                return Ok(medicalHistory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
