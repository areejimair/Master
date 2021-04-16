using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorWho.DB.Repositories;
using AutoMapper;
using DoctorWho.DB.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using DoctorWho.DB;
using System.Net;

namespace DoctorWho.API.Controllers
{
    [ApiController]
    [Route("api/Enemy")]
    public class AddEnemyToEpisode : ControllerBase
    {
        private readonly ITblEpsiodeEnemyRep _epsiodeRep;
        private readonly ITblEpisodeRep _epsiode_Rep;
        private readonly IMapper _mapper;
        public AddEnemyToEpisode(ITblEpsiodeEnemyRep EpRepository, ITblEpisodeRep EpsiodeRep, IMapper mapper)
        {
            _epsiodeRep = EpRepository ??
                throw new ArgumentNullException(nameof(EpRepository));
            _epsiode_Rep = EpsiodeRep ??
               throw new ArgumentNullException(nameof(EpsiodeRep));
            _mapper = mapper ??
               throw new ArgumentNullException(nameof(mapper));

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TblEpisodeEnemy>> GetEps(int id)
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
        public async Task<ActionResult<TblEpisodeEnemy>>
    Createepsiode([FromBody] TblEpisodeEnemy epsiode)
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
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TblEpisode>> GetEpsiode(int id)
        {
            try
            {
                var result = await _epsiode_Rep.GetEpsiode(id);

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
        public async Task<ActionResult<TblEpisode>>
Create_Epsiode([FromBody] TblEpisode episode)
        {
            try
            {
                if (episode == null)
                    return BadRequest();

                var createdauthor = await _epsiode_Rep.AddEpsiode(episode);

                return CreatedAtAction(nameof(GetEpsiode),
                    new { id = createdauthor.AuthorId }, createdauthor);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new author record");
            }
        }

    }
}


