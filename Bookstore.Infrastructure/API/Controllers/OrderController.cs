using API.Repositories;
using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController(IRelationalRepository<Order> orderRepository) : Controller
{
    [HttpPost("post")]
    public async Task<ActionResult<Order>> Post([FromBody] Order entry)
    {
        var createdOrder = await orderRepository.Post(entry);
        return Ok(createdOrder);
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<Order>> Get(int id)
    {
        var order = await orderRepository.Get(id);

        if (order == null)
            return NotFound();

        return Ok(order);
    }

    [HttpGet("getall")]
    public async Task<ActionResult<IEnumerable<Order>>> GetAll()
    {
        var orders = await orderRepository.GetAll();
        return Ok(orders);
    }

    [HttpPut("put/{id}")]
    public async Task<ActionResult<Order>> Put(int id, [FromBody] Order entry)
    {
        if (id != entry.OrderID)
            return BadRequest();

        var existingOrder = await orderRepository.Get(id);
        if (existingOrder == null)
            return NotFound();

        var updatedOrder = await orderRepository.Put(entry);
        return Ok(updatedOrder);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var existingOrder = await orderRepository.Get(id);
        if (existingOrder == null)
            return NotFound();

        await orderRepository.Delete(id);
        return NoContent();
    }
}
