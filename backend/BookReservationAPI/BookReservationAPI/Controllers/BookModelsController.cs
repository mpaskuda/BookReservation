using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookReservationAPI.DatabaseContext;
using BookReservationAPI.Models;
using BookReservationAPI.Repository;

namespace BookReservationAPI.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookModelsController : ControllerBase
    {
        private readonly IBookRepository<BookModel> _dataRepository;
        public BookModelsController(IBookRepository<BookModel> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/BookModel
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<BookModel> books = _dataRepository.GetAll();
            return Ok(books);
        }
        // GET: api/BookModel/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            BookModel book = _dataRepository.Get(id);
            if (book == null)
            {
                return NotFound("The BookModel record couldn't be found.");
            }
            return Ok(book);
        }
        // POST: api/BookModel
        [HttpPost]
        public IActionResult Post([FromBody] BookModel book)
        {
            if (book == null)
            {
                return BadRequest("BookModel is null.");
            }
            _dataRepository.Add(book);
            return CreatedAtRoute(
                  "Get",
                  
                  book);
        }
        // PUT: api/BookModel/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BookModel book)
        {
            if (book == null)
            {
                return BadRequest("BookModel is null.");
            }
            BookModel bookToUpdate = _dataRepository.Get(id);
            if (bookToUpdate == null)
            {
                return NotFound("The BookModel record couldn't be found.");
            }
            _dataRepository.Update(bookToUpdate, book);
            return NoContent();
        }
        // DELETE: api/BookModel/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            BookModel book = _dataRepository.Get(id);
            if (book == null)
            {
                return NotFound("The BookModel record couldn't be found.");
            }
            _dataRepository.Delete(book);
            return NoContent();
        }
    }
}
