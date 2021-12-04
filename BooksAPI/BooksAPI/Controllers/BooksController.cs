
using BooksAPI.Models;
using BooksAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public readonly IBookRepository _bookrepository;
        public BooksController(IBookRepository bookrepository)
        {
            _bookrepository = bookrepository;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookrepository.GetAllBooks();
            if(books==null)
            {
                return NotFound();
            }
            return Ok(books);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBookById(int Id)
        {
            var books = await _bookrepository.GetBookById(Id);
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }
        [HttpPost("")]
        public async Task<IActionResult> UpdateBookRecord([FromBody] Book bookmodel)
        {
            var result = await _bookrepository.AddBookAsync(bookmodel);
            if(result<1)
            {
                return NotFound("result is : "+result);
            }
            else
            {
                return CreatedAtAction(nameof(GetBookById), new { id = result, Controllers = "books" },result);
            }
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateBookRecord([FromQuery] int id, [FromBody] Book bookmodel)
        {

            await _bookrepository.UpdateBookAsync(id, bookmodel);
            return Ok();
               
         

        }
        

    }
}
