using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using aspnetcore.Controllers.Resources;
using aspnetcore.Interfaces;
using aspnetcore.Interfaces.Repositories;
using aspnetcore.models;
using aspnetcore.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore.Controllers
{
    [Route("/api/vehical")]
    public class VehicalController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IVehicalRepository vehicalRepository;

        public VehicalController(IUnitOfWork unitOfWork, IMapper mapper, IVehicalRepository vehicalRepository)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.vehicalRepository = vehicalRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateVehical([FromBody] SaveVehicalResource vehicalResource)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var vehical = mapper.Map<SaveVehicalResource, Vehical>(vehicalResource);
            vehical.LastUpdated = DateTime.Now;
            vehicalRepository.Add(vehical);
            await unitOfWork.CompleteAsync();

            vehical = await vehicalRepository.GetVehical(vehical.Id);
            var result = mapper.Map<Vehical, VehicalResource>(vehical);
            return Ok(result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehical(int id, [FromBody] SaveVehicalResource vehicalResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehical = await vehicalRepository.GetVehicalWithFeature(id);
            if (vehical == null)
            {
                return NotFound();
            }
            mapper.Map<SaveVehicalResource, Vehical>(vehicalResource, vehical);
            vehical.LastUpdated = DateTime.Now;


            await unitOfWork.CompleteAsync();

            vehical = await vehicalRepository.GetVehical(vehical.Id);
            var result = mapper.Map<Vehical, VehicalResource>(vehical);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehical(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehical = await vehicalRepository.GetVehical(id, false);
            if (vehical == null)
            {
                return NotFound();
            }
            vehicalRepository.Remove(vehical);
            await unitOfWork.CompleteAsync();
            return Ok(id);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehical(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehical = await vehicalRepository.GetVehical(id);
            if (vehical == null)
            {
                return NotFound();
            }

            var vResource = mapper.Map<Vehical, VehicalResource>(vehical);
            return Ok(vResource);

        }
        [HttpGet]
        public async Task<IEnumerable<VehicalResource>> GetVehicals(FilterResource filter)
        {
            mapper.Map<FilterResource, Filter>(filter);
            var vehicals = await vehicalRepository.GetVehicles();
            return mapper.Map<IEnumerable<Vehical>, IEnumerable<VehicalResource>>(vehicals);
        }
    }
}
