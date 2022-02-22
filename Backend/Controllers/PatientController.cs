using Backend.Domain.IServices;
using Backend.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Patient patient)
        {
            try
            {
                patient.UserID = 1;
                patient.Active = 1;
                patient.DateCreated = DateTime.Now;
                await _patientService.CreatePatient(patient);
                return Ok(new { message = "Patient was added correctly" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{patientID}")]
        public async Task<IActionResult> Delete(int patientID)
        {
            try
            {
                int userID = 1;
                var patient = await _patientService.SearchPatient(patientID, userID);
                if(patient == null)
                {
                    return BadRequest(new { message = "Patient not found." });
                }
                await _patientService.DeletePatient(patient);
                return Ok(new { message = "Patient successfully removed from list" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // get 
        [Route("GetListPatientsByUser")]
        [HttpGet]
        public async Task<IActionResult> GetListPatientsByUser()
        {
            try
            {
                int userID = 1;
                var listPatients = await _patientService.GetListPatientByUser(userID);
                return Ok(listPatients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("{patientID}")]
        public async Task<IActionResult> GetPatient(int patientID)
        {
            try
            {
                var patient = await _patientService.GetPatient(patientID);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetNumberOfPatients")]
        public async Task<IActionResult> GetNumberOfPatients()
        {
            try
            {
                var userId = 1;
                var total = await _patientService.GetNumberOfPatients(userId);
                return Ok(total);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("GetNumberOfMalePatients")]
        public async Task<IActionResult> GetNumberOfMalePatients()
        {
            try
            {
                var userID = 1;
                int listOfGenders = await _patientService.GetNumberOfMalePatients(userID);
                return Ok(listOfGenders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetNumberOfFemalePatients")]
        public async Task<IActionResult> GetNumberOfFemalePatients()
        {
            try
            {
                var userID = 1;
                int listOfGenders = await _patientService.GetNumberOfFemalePatients(userID);
                return Ok(listOfGenders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("SearchPatientByFirstname/{firstname}")]
        [HttpGet]
        public async Task<IActionResult> SearchPatientByFirstname(string firstname)
        {
            try
            {
                int userID = 1;
                var patient = await _patientService.SearchPatientByFirstname(firstname, userID);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("SearchPatientByLastname/{lastname}")]
        [HttpGet]
        public async Task<IActionResult> SearchPatientByLastname(string lastname)
        {
            try
            {
                int userID = 1;
                var patient = await _patientService.SearchPatientByLastname(lastname, userID);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
