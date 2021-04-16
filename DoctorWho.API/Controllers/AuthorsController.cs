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
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ITblAuthorRep _AuthorRep;
        private readonly IMapper _mapper;

        public AuthorsController(ITblAuthorRep AuthorRepository, IMapper mapper)
        {
            _AuthorRep = AuthorRepository ??
                throw new ArgumentNullException(nameof(AuthorRepository));
            _mapper = mapper ??
               throw new ArgumentNullException(nameof(mapper));

        }
        /* [HttpGet()]
         public IActionResult GetAuthors()
         {
             var authorsFromRepo = _AuthorRep.GetAuthors();
             var authors = new List<AuthorDto>();
             foreach(var author in authorsFromRepo)
             {
                 authors.Add(new AuthorDto()
                 {
                     AuthorId = author.AuthorId,
                     AuthorName = author.AuthorName
                 });


             }
             return Ok(authors);
         }*/
        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors()
        {
            var authorsFromRepo = _AuthorRep.GetAuthors();
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
        }

        /*[HttpGet("{authorId}", Name = "GetAuthor")]
        public IActionResult GetAuthor(int authorId)
        {
            var authorFromRepo = _AuthorRep.GetAuthor(authorId);

            if (authorFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AuthorDto>(authorFromRepo));
        }*/

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TblAuthor>> GetAuthorss(int id)
        {
            try
            {
                var result = await _AuthorRep.GetAuthorss(id);

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
        public async Task<ActionResult<TblAuthor>>
    CreateEmployee([FromBody] TblAuthor author)
        {
            try
            {
                if (author == null)
                    return BadRequest();

                var createdauthor = await _AuthorRep.AddAuthors(author);

                return CreatedAtAction(nameof(GetAuthorss),
                    new { id = createdauthor.AuthorId }, createdauthor);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new author record");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<TblAuthor>> UpdateEmployee(int id, TblAuthor author)
        {
            try
            {
                if (id != author.AuthorId)
                    return BadRequest("Author ID mismatch");

                var authorToUpdate = await _AuthorRep.GetAuthorss(id);

                if (authorToUpdate == null)
                    return NotFound($"Author with Id = {id} not found");

                return await _AuthorRep.Update_Author(author);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }


    }
}


