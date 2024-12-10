using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController(IRelationalRepository<Customer> relationalRepository) : Controller
{
    [HttpPost("post")]
    public async Task<ActionResult<Customer>> Post([FromBody] Customer entry)
    {
        var createdCustomer = await relationalRepository.Post(entry);
        return Ok(createdCustomer);
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<Customer>> Get(int id)
    {
        var customer = await relationalRepository.Get(id);
        if (customer == null)
            return NotFound();
        return Ok(customer);
    }

    [HttpGet("getall")]
    public async  Task<ActionResult<IEnumerable<Customer>>> GetAll()
    {
        var customers = await relationalRepository.GetAll();
        return Ok(customers);
    }

    [HttpPut("put/{id}")]
    public async  Task<ActionResult<Customer>> Put(int id, [FromBody] Customer entry)
    {
        if (id != entry.CustomerID)
            return BadRequest();
        var existingCustomer = await relationalRepository.Get(id);
        if (existingCustomer == null)
            return NotFound();
        var updatedCustomer = await relationalRepository.Put(entry);
        return Ok(updatedCustomer);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var existingCustomer = await relationalRepository.Get(id);
        if (existingCustomer == null)
            return NotFound();

        await relationalRepository.Delete(id);
        return NoContent();
    }
}
