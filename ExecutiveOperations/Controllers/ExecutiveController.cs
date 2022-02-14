using DAL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExecutiveOperations.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExecutiveController : ControllerBase
    {
        ExecutiveContext executiveDbOperations;
        ExecutiveRepository repository;

        public ExecutiveController()
        {
            executiveDbOperations = new ExecutiveContext();
            repository = new ExecutiveRepository();
        }
        /// <summary>
        /// Insert Registration
        /// </summary>
        /// <response code="200">result successfuly</response>
        /// <response code="404">Registration not inserted</response>

        [HttpPost("/CreateRegistration")]
        public async Task<IActionResult> CreateRegistration(Resident resident)
        {
            try
            {
                //resository'den ekleme methoduna istekte bulunuluyor.
                repository.InsertResident(resident);
                return Ok("Başarı ile Eklendi.");
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
        /// <summary>
        /// Update Resident
        /// </summary>
        /// <response code="200">result successfuly</response>
        /// <response code="404">movie not updated</response>
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateResident(int Id, Resident resident)
        {
            try
            {
                //resository'den güncelleme methoduna istekte bulunuluyor.
                repository.UpdateResident(resident);
                return Ok("Başarı İle Güncellendi.");
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
        /// <summary>
        /// Delete Resident
        /// </summary>
        /// <response code="200">result successfuly</response>
        /// <response code="404">resident not deleted</response>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteResident(int Id)
        {

            try
            {
                repository.DeleteResident(Id);
                return Ok("Başarılı bir şekilde silindi.");
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        /// <summary>
        /// Get Resident By ResidentId
        /// </summary>
        /// <response code="200">result successfuly</response>
        /// <response code="404">movie not found</response>
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetResident(int Id)
        {
            try
            {
                var resident = repository.ResidentSelectById(Id);
                if (resident != null)
                {
                    return Ok(resident);
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        /// <summary>
        /// Get All Resident
        /// </summary>
        /// <response code="200">result successfuly</response>
        /// <response code="404">resident not found</response>
        /// 
       
        [HttpGet("/GetAllResident")]
        public async Task<IActionResult> GetAllResident()
        {
            try
            {
                List<Resident> residents = new List<Resident>();
                residents = repository.SelectAllResidents();
                if (residents != null)
                    return Ok(residents);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        /// <summary>
        /// Get All Flats
        /// </summary>
        /// <response code="200">result successfuly</response>
        /// <response code="404">flats not found</response>
        /// 

        [HttpGet]
        public async Task<IActionResult> GetAllFlat()
        {
            try
            {
                List<Flat> flats = new List<Flat>();
                flats = repository.SelectAllFlats();
                if (flats != null)
                    return Ok(flats);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

        }

        /// <summary>
        /// Delete Flat
        /// </summary>
        /// <response code="200">result successfuly</response>
        /// <response code="404">flat not deleted</response>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteFlat(int Id)
        {

            try
            {
                repository.DeleteFlat(Id);
                return Ok("Başarılı bir şekilde silindi.");
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        /// <summary>
        /// Update Flat
        /// </summary>
        /// <response code="200">result successfuly</response>
        /// <response code="404">flat not updated</response>
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateFlat(int Id, Flat flat)
        {
            try
            {
                //resository'den güncelleme methoduna istekte bulunuluyor.
                repository.UpdateFlat(flat);
                return Ok("Başarı İle Güncellendi.");
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

    }
}
