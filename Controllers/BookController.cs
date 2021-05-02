using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookManagementAPI.Interface;
using BookManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementAPI.Controllers
{
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IManagementService _repo;

        public BookController(
            IManagementService repo
        )
        {
            _repo = repo;
        }

        [HttpGet("/book")]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var books = _repo.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("/book/{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = _repo.GetOneBook(id);
            return Ok(book);
        }
        

        [HttpPost("/book")]
        public ActionResult<Book> Post(Book model)
        {
            try
            {
                var book = _repo.AddBook(model);
                return new CreatedResult("/book/", new {Id = book.Id, message="Book Added Successfully"});
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message});
            }
        }

        [HttpPatch("/book/{id}")]
        public ActionResult<Book> Patch(int id, Book model)
        {
            try
            {
                var book = _repo.UpdatePatchBook(id, model);
                return new OkObjectResult(new { message = "Book Detail Updated successfully", id});
            }
            catch (Exception e)
            {
                return BadRequest(new {message = e.Message});
            }
        }

        [HttpPut("/book/{id}")]
        public ActionResult<Book> Put(int id, Book model)
        {
            try
            {
                var book = _repo.UpdatePutBook(id, model);
                return new OkObjectResult(new {message = "Book Details Updated successfully", id });
            }
            catch (Exception e)
            {
                return BadRequest(new {message = e.Message});
            }
        }

        [HttpDelete("/book/{id}")]
        public ActionResult<Book> Delete(int id)
        {
            try
            {
                var book = _repo.DeleteBook(id);
                return new OkObjectResult(new {message = "Book Deleted successfully", id });
            }
            catch (Exception e)
            {
                return BadRequest(new {message = e.Message});
            }
        }
    }
}