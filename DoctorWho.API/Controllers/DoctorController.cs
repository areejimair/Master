using AutoMapper;
using DoctorWho.API.Models.Dto;
using DoctorWho.DB.Models;
using DoctorWho.DB.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.API.Controllers
{
    [Route("api/Doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ITblDoctorRep _DoctorRep;
        private readonly IMapper _mapper;

        public DoctorController(ITblDoctorRep DoctorRepository, IMapper mapper)
        {
            _DoctorRep = DoctorRepository ??
                throw new ArgumentNullException(nameof(DoctorRepository));
            _mapper = mapper ??
               throw new ArgumentNullException(nameof(mapper));

        }
        [HttpGet]
        public async Task<ActionResult> GetDoctors()
        {
            try
            {
                return Ok(await _DoctorRep.GetDoctors());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}",Name ="GetDoctor")]
        public async Task<ActionResult<TblDoctor>> GetEmployee(int id)
        {
            try
            {
                var result = await _DoctorRep.GetDoctor(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public ActionResult<DoctorDto> CreateAuthor(int id,DoctorforCreation doctor)
        {
            var doctorEntity = _mapper.Map<DoctorWho.DB.Models.TblDoctor>(doctor);
            _DoctorRep.AddDoctor(id,doctorEntity);
            _DoctorRep.Save();

            var doctorToReturn = _mapper.Map<DoctorDto>(doctorEntity);
            return CreatedAtRoute("GetDoctor",
                new { doctorId = doctorToReturn.DoctorId },
                doctorToReturn);
        }


        [HttpDelete("{DoctorId}")]
        public ActionResult DeleteAuthor(int doctorId)
        {
            var Doctor = _DoctorRep.Get_Doctor(doctorId);

            if (Doctor == null)
            {
                return NotFound();
            }

            _DoctorRep.DeleteDoctor(Doctor);
            _DoctorRep.Save();
            return NoContent();
        }
    }
}
