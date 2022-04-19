using System.Collections.Generic;
using System.Linq;
using webapi_csharp.Modelos;

namespace webapi_csharp.Repositorios
{
    public class RPBooks
    {
        public static List<Book> _listaBooks = new List<Book>()
        {
            new Book() { Id = 1, Title = "La hojarasca" , Description = "Good one" , Author = "Gabo" },
            new Book() { Id = 2, Title = "El coronel no tiene quien le escriba" , Description = "Interesting" , Author = "Gabo" },
        };

        public IEnumerable<Book> ObtenerBooks()
        {
            return _listaBooks;
        }

        public Book ObtenerBooks(int id)
        {
            var book = _listaBooks.Where(cli => cli.Id == id);

            return book.FirstOrDefault();
        }

        public void Agregar(Book nuevoBook)
        {
            _listaBooks.Add(nuevoBook);
        }

        public void UpdateBook(Book uBook, int id)
        {
            var book = _listaBooks.Where(cli => cli.Id == id);

            var update = book.FirstOrDefault();

            update.Id = id;
            update.Author = uBook.Author;
            update.Description = uBook.Description;
            update.Title = uBook.Title;
        }

        public void DeleteBook(int id)
        {
            _listaBooks.RemoveAll(cli => cli.Id == id);
        }
    }
}
