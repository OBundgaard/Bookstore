using API.Repositories;
using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController(INoSQLRepository<Author> authorRepository) : Controller
{
    [HttpPost("post")]
    public async Task<ActionResult<Author>> Post([FromBody] Author entry)
    {
        var createdAuthor = await authorRepository.Post(entry);
        return Ok(createdAuthor);
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<Author>> Get(int id)
    {
        var author = await authorRepository.Get(id.ToString());

        if (author == null)
            return NotFound();

        return Ok(author);
    }

    [HttpGet("getall")]
    public async Task<ActionResult<IEnumerable<Author>>> GetAll()
    {
        var authors = await authorRepository.GetAll();
        return Ok(authors);
    }

    [HttpPut("put/{id}")]
    public async Task<ActionResult<Author>> Put(int id, [FromBody] Author entry)
    {
        if (id != entry.AuthorID)
            return BadRequest();

        var existingAuthor = await authorRepository.Get(id.ToString());
        if (existingAuthor == null)
            return NotFound();

        var updatedAuthor = await authorRepository.Put(entry);
        return Ok(updatedAuthor);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var existingAuthor = await authorRepository.Get(id.ToString());
        if (existingAuthor == null)
            return NotFound();

        await authorRepository.Delete(id.ToString());
        return NoContent();
    }
}
