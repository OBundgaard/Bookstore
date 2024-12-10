using API.Contexts;
using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class CustomerRepository : IRelationalRepository<Customer>
{
    private readonly RelationalDbContext _context;
    public async Task<Customer> Post(Customer entry)
    {
        await _context.Customers.AddAsync(entry);
        await _context.SaveChangesAsync();
        return entry;
    }

    public async Task<Customer> Get(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        return customer;
    }

    public async Task<IEnumerable<Customer>> GetAll()
    {
        var customer = await _context.Customers.ToListAsync();
        return customer;
    }

    public async Task<Customer> Put(Customer entry)
    {
        _context.Update(entry);
        await _context.SaveChangesAsync();
        return entry;
    }

    public async Task Delete(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
            throw new KeyNotFoundException($"Customer with ID {id} not found.");
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }
}
