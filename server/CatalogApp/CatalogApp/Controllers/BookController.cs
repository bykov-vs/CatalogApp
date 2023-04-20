using System.Collections;
using CatalogApp.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CatalogApp.Controllers;

public class BookController : Controller
{
    private ApplicationContext db;

    public BookController(ApplicationContext context)
    {
        db = context;
    }
    
    [HttpPost("addBook")]
    public void addBook([FromBody]Book book)
    {
        db.Books.Add(book);
        db.SaveChanges();
    }

    [HttpGet("getBooks")]
    public List<Book> getBooks()
    {
        return db.Books.ToList();
    }
    
    [HttpGet("getBooksByFilters")]
    public List<Book> getBooksByFilters(String[] publishers, String[] genres)
    {
        Console.Out.WriteLine(publishers.Length);
        Console.Out.WriteLine(genres.Length);
        var books = db.Books.ToList();
        List<Book> result = new List<Book>();
        for (int i = 0; i < books.Count; i++)
        {
            if (publishers.Length != 0)
            {
                if (genres.Length != 0)
                {
                    if (publishers.Contains(books[i].publisher) && genres.Contains(books[i].genre))
                    {
                        result.Add(books[i]);
                    }
                }
                else
                {
                    if (publishers.Contains(books[i].publisher))
                    {
                        result.Add(books[i]);
                    }
                }
            }
            else
            {
                if (genres.Contains(books[i].genre))
                {
                    result.Add(books[i]);
                }
            }
            
        }
        return result;
    }
    
    [HttpGet("getBooksByName")]
    public List<Book> getBooksByName(string name)
    {
        var books = db.Books.ToList();
        var result = new List<Book>();
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].name.StartsWith(name))
            {
                result.Add(books[i]);
            }
        }

        return result;
    }
}