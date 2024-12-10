using API.Contexts;
using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class OrderRepository : IRelationalRepository<Order>
{
    private readonly RelationalDbContext db;

    public OrderRepository(RelationalDbContext context)
    {
        db = context;
    }

    public async Task<Order> Post(Order entry)
    {
        await db.Orders.AddAsync(entry);
        await db.SaveChangesAsync();
        return entry;
    }

    public async Task<Order> Get(int id)
    {
        var order = await db.Orders.FindAsync(id);
        return order;
    }

    public async Task<IEnumerable<Order>> GetAll()
    {
        var orders = await db.Orders.ToListAsync();
        return orders;
    }

    public async Task<Order> Put(Order entry)
    {
        db.Orders.Update(entry);
        await db.SaveChangesAsync();
        return entry;
    }

    public async Task Delete(int id)
    {
        var order = await db.Orders.FindAsync(id);
        if (order == null)
            throw new KeyNotFoundException($"Order with ID {id} not found.");

        db.Orders.Remove(order);
        await db.SaveChangesAsync();
    }
}
