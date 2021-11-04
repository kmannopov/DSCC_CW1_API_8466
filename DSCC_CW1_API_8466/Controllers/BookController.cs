using DSCC_CW1_API_8466.Repository;
using DSCC_CW1_MicroservicesAPI_8466.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DSCC_CW1_API_8466.Controllers
{
    [Produces("application/json")]
    [Route("api/Book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        // GET: api/<BookController>
        [HttpGet]
        public IActionResult Get()
        {
            var books = _bookRepository.GetBooks();
            return new OkObjectResult(books);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}", Name ="Get")]
        public IActionResult Get(int id)
        {
            var book = _bookRepository.GetBookById(id);
            return new OkObjectResult(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            using (var scope = new TransactionScope())
            {
                _bookRepository.InsertBook(book);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
            }
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            if (book != null)
            {
                using (var scope = new TransactionScope())
                {
                    _bookRepository.UpdateBook(book);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookRepository.DeleteBook(id);
            return new OkResult();
        }
    }
}
