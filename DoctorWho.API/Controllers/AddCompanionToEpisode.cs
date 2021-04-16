using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorWho.DB.Repositories;
using DoctorWho.API.Models.Dto;
using AutoMapper;
using DoctorWho.DB.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using DoctorWho.DB;
using System.Net;

namespace DoctorWho.API.Controllers
{
    [ApiController]
    [Route("api/Epsiode")]
    public class AddCompanionToEpisode : ControllerBase
    {
        private readonly ITblEpsiodeCompanionRep _epsiodeRep;
        private readonly IMapper _mapper;
        public AddCompanionToEpisode(ITblEpsiodeCompanionRep EpRepository, IMapper mapper)
        {
            _epsiodeRep= EpRepository ??
                throw new ArgumentNullException(nameof(EpRepository));
            _mapper = mapper ??
               throw new ArgumentNullException(nameof(mapper));

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TblEpisodeCompanion>> GetEps(int id)
        {
            try
            {
                var result = await _epsiodeRep.GetEps(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<TblEpisodeCompanion>>
    Createepsiode([FromBody] TblEpisodeCompanion epsiode)
        {
            try
            {
                if (epsiode == null)
                    return BadRequest();

                var createdauthor = await _epsiodeRep.AddEps(epsiode);

                return CreatedAtAction(nameof(GetEps),
                    new { id = createdauthor.EpisodeId }, createdauthor);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

    }
}
