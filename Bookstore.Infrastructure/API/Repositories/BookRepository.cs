using API.Contexts;
using Bookstore.Core.Interfaces;
using Bookstore.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace API.Repositories;

public class BookRepository : IRelationalRepository<Book>
{
    private readonly RelationalDbContext _context;
    public BookRepository(RelationalDbContext context)
    {
        _context = context;
    }
    public async Task<Book> Post(Book entry)
    {
       await _context.Books.AddAsync(entry);
       await _context.SaveChangesAsync();
        return entry;
    }

    public async Task<Book> Get(int id)
    {
       var book = await _context.Books.FindAsync(id);
       return book;
    }

    public async Task<IEnumerable<Book>> GetAll()
    {
        var books = await _context.Books.ToListAsync();
        return books;
    }

    public async Task<Book> Put(Book entry)
    {
        _context.Update(entry);
        await _context.SaveChangesAsync();
        return entry;
    }

    public async Task Delete(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
            throw new KeyNotFoundException($"Book with ID {id} not found.");
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }
}
