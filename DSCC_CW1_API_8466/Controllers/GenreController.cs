using Microsoft.AspNetCore.Mvc;
using System;
using DSCC_CW1_API_8466.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSCC_CW1_MicroservicesAPI_8466.Models;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DSCC_CW1_API_8466.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository  _genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        // GET: api/<GenreController>
        [HttpGet]
        public IActionResult Get()
        {
            var genres = _genreRepository.GetGenres();
            return new OkObjectResult(genres);
        }

        // GET api/<GenreController>/5
        [HttpGet("{id}", Name = "GetGenre")]
        public IActionResult Get(int id)
        {
            var genre = _genreRepository.GetGenreById(id);
            return new OkObjectResult(genre);
        }

        // POST api/<GenreController>
        [HttpPost]
        public IActionResult Post([FromBody] Genre genre)
        {
            using (var scope = new TransactionScope())
            {
                _genreRepository.InsertGenre(genre);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = genre.Id }, genre);
            }
        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Genre genre)
        {
            if (genre != null)
            {
                using (var scope = new TransactionScope())
                {
                    _genreRepository.UpdateGenre(genre);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _genreRepository.DeleteGenre(id);
            return new OkResult();
        }
    }
}
