using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController(IRelationalRepository<Book> bookRepository) : Controller
{
    [HttpPost("post")]
    public async Task<ActionResult<Book>> Post([FromBody] Book entry)
    {
        var createdBook = await bookRepository.Post(entry);
        return Ok(createdBook);
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<Book>> Get(int id)
    {
        var book = await bookRepository.Get(id);

        if (book == null)
            return NotFound();

        return Ok(book);
    }

    [HttpGet("getall")]
    public ActionResult<IEnumerable<Book>> GetAll()
    {
        var books = bookRepository.GetAll();
        return Ok(books);
    }

    [HttpPut("put/{id}")]
    public async Task<ActionResult<Book>> Put(int id, [FromBody] Book entry)
    {
        if (id != entry.BookID)
            return BadRequest();

        var existingBook = await bookRepository.Get(id);
        if (existingBook == null)
            return NotFound();

        var updatedBook = await bookRepository.Put(entry);
        return Ok(updatedBook);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var existingBook = await bookRepository.Get(id);
        if (existingBook == null)
            return NotFound();

        await bookRepository.Delete(id);
        return NoContent();
    }
}
