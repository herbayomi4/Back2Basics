using Azure.Core;
using Back2Basics.Core.DTOs.Request;
using Back2Basics.Core.Entities;
using Back2Basics.Core.Utils;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Back2Basics.API.Controllers
{
    [Route("[controller]/")]
    public class DrugController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public DrugController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        
        /// <summary>
        /// Fetch all drugs in store
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetDrugs()
        {
            return Ok(_dbContext.Inventories.ToList());
        }

        /// <summary>
        /// Fetch drug with specified Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public IActionResult GetDrugById(Guid Id)
        {
            if(AppUtils.IsValidGuid(Id))
                return BadRequest("Invalid Id!");

            //find if Id exist
            var drug = _dbContext.Inventories.FirstOrDefault(x => x.Id == Id && !x.IsDeleted);

            if (drug == null)
                return NotFound("No record found");

            return Ok(drug);
        }

        /// <summary>
        /// Creates a new record using specified name and price
        /// </summary>
        /// <returns></returns>
        [HttpPost("Create")]
        public IActionResult CreateDrugs([FromBody] CreateInventoryDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _dbContext.Inventories.Add(
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Price = request.Price,
                    CreatedAt = DateTime.UtcNow
                });

            _dbContext.SaveChanges();

            return Ok("Drug record created successfully");
        }

        /// <summary>
        /// Updates the name and/or price of a drug record usign the specified ID
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public IActionResult UpdateDrugs(Guid Id, [FromBody] CreateInventoryDTO request)
        {
            if (AppUtils.IsValidGuid(Id))
                return BadRequest("Invalid Id!");

            //find if Id exist
            var drug = _dbContext.Inventories.FirstOrDefault(x => x.Id == Id && !x.IsDeleted);

            if (drug == null)
                return NotFound("No record found");
            else
            {
                drug.Name = request.Name;
                drug.Price = request.Price;
                drug.ModifiedAt = DateTime.UtcNow;

                _dbContext.Inventories.Update(drug);

                _dbContext.SaveChanges();
            }

            return Ok("Update completed successfully");
        }

        /// <summary>
        /// Deletes a drug record using the specified ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public IActionResult DeleteDrug(Guid Id)
        {
            if (AppUtils.IsValidGuid(Id))
                return BadRequest("Invalid Id!");

            //find if Id exist
            var drug = _dbContext.Inventories.FirstOrDefault(x => x.Id == Id && !x.IsDeleted);

            if (drug == null)
                return NotFound("No record found");
            else
            {
                drug.IsDeleted = true;
                drug.DeletedAt = DateTime.UtcNow;

                _dbContext.Inventories.Update(drug);
                _dbContext.SaveChanges();
            }

            return Ok("Drug record deleted successully");
        }
    }
}
