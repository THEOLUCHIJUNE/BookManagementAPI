using System.Collections.Generic;
using BookManagementAPI.Models;

namespace BookManagementAPI.Interface
{
    public interface IManagementService
    {
        List<Book> GetAllBooks();

        Book GetOneBook(int id);

        Book AddBook(Book model);

        Book UpdatePutBook(int id, Book model);

        Book UpdatePatchBook(int id, Book model);

        Book DeleteBook(int id);
    }
}