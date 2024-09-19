using DesafioGestaoLivraria.Communication.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioGestaoLivraria.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BooksController : DesafioGestaoLivrariaBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(Books), StatusCodes.Status200OK)]

    public IActionResult GetAllBooks()
    {
        var booksList = new List<Books>()
        {
            new Books { Id = 1, Author = "Thalles", Title = "Title", Price = (decimal)100.99, Stock = 10}
        };
        return Ok(booksList);
    }


    [HttpPost]
    [ProducesResponseType(typeof(Books), StatusCodes.Status200OK)]

    public IActionResult CreateNewBook([FromBody] RequestBookRegisterJson request)
    {
        var booksList = new List<Books>()
        {
            new Books { Id = 1, Author = "Thalles", Title = "Title", Genre = "Fiction", Price = (decimal)100.99, Stock = 10}
        };

        var newBook = new Books()
        {
            Id = booksList.Last().Id + 1,
            Author = request.Author,
            Title = request.Title,
            Price = request.Price,
            Stock = request.Stock,
            Genre = request.Genre
        };

        booksList.Add(newBook);

        return Ok(booksList);
    }


    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(typeof(Books), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]

    public IActionResult UpdateBook([FromRoute] int id, [FromBody] RequestBookUpdateJson request)
    {
        var booksList = new List<Books>()
        {
            new Books { Id = 1, Author = "Thalles", Title = "Title", Genre = "Fiction", Price = (decimal)100.99, Stock = 10}
        };


        var updatedBookTarget = booksList.FirstOrDefault(book => book.Id == id);
        var updatedBookIndex = booksList.FindIndex(book => book.Id == id);

        if (updatedBookTarget != null)
        {
            booksList[updatedBookIndex].Title = request.Title;
            booksList[updatedBookIndex].Author = request.Author;
            booksList[updatedBookIndex].Genre = request.Genre;
            booksList[updatedBookIndex].Price = request.Price;
            booksList[updatedBookIndex].Stock = request.Stock;

        } else
        {
            return NotFound();
        }

        return Ok(booksList[updatedBookIndex]);
    }


    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(typeof(Books), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]

    public IActionResult DeleteBook([FromRoute] int id)
    {
        var booksList = new List<Books>()
        {
            new Books { Id = 1, Author = "Thalles", Title = "Title", Genre = "Fiction", Price = (decimal)100.99, Stock = 10}
        };

        var updatedBookTarget = booksList.FirstOrDefault(book => book.Id == id);
        var updatedBookIndex = booksList.FindIndex(book => book.Id == id);

        if (updatedBookTarget != null)
        {
            booksList.RemoveAt(updatedBookIndex);
        }
        else
        {
            return NotFound();
        }
        Console.WriteLine(booksList);
        return NoContent();
    }


}
