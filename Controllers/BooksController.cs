using Microsoft.AspNetCore.Mvc;
using webapi_csharp.Modelos;
using webapi_csharp.Repositorios;

namespace webapi_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            RPBooks rpBook = new RPBooks();
            return Ok(rpBook.ObtenerBooks());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            RPBooks rpBook = new RPBooks();

            var BookRet = rpBook.ObtenerBooks(id);

            if (BookRet == null)
            {
                var nf = NotFound("El libro " + id.ToString() + " no existe.");
                return nf;
            }

            return Ok(BookRet);
        }

        [HttpPost]
        public IActionResult AgregarBook(Book nuevoBook)
        {
            RPBooks BooksCli = new RPBooks();
            
            var BookRet = BooksCli.ObtenerBooks(nuevoBook.Id);

            if (BookRet == null)
            {
                BooksCli.Agregar(nuevoBook);
                return CreatedAtAction(nameof(AgregarBook), nuevoBook);
            }
            else
            {
                var nf = BadRequest("El libro " + nuevoBook.Id.ToString() + " ya existe.");
                return nf;
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(Book nuevoBook, int Id)
        {
            RPBooks rpBook = new RPBooks();

            var BookRet = rpBook.ObtenerBooks(Id);

            if (BookRet == null)
            {
                var nf = NotFound("El libro " + Id.ToString() + " no existe.");
                return nf;
            }

            rpBook.UpdateBook(nuevoBook, Id);

            return Ok(rpBook.ObtenerBooks(Id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            RPBooks rpCli = new RPBooks();

            var cliRet = rpCli.ObtenerBooks(id);

            if (cliRet == null)
            {
                var nf = NotFound("El libro " + id.ToString() + " no existe.");
                return nf;
            }

            rpCli.DeleteBook(id);

            return Ok(rpCli.ObtenerBooks());
        }
    }
}