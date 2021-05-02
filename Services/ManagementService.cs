using System;
using BookManagementAPI.Interface;
using BookManagementAPI.Models;
using System.Collections.Generic;
using System.Linq;
using BookManagementAPI.DatabaseContext;

namespace BookManagementAPI.Service
{
    public class ManagementService : IManagementService
    {
        private readonly ApplicationDbContext _context;
        public ManagementService(
            ApplicationDbContext context
        )

        {
            _context = context;
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }
        public Book GetOneBook(int id)
        {
            return _context.Books.FirstOrDefault(PID => PID.Id == id);
        }
        public Book AddBook(Book model)
        {
            if(model is null) throw new ArgumentNullException(message: "Book cannot be null", null);

            var book = new Book
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Genre = model.Genre,
                Author = model.Author,
                DateAdded = DateTime.Now,
                PublisherId = model.PublisherId

            };

            //do a research on AddRange before submission
            _context.Books.Add(book);
            _context.SaveChanges();

            return book;
                
        }

        public Book UpdatePutBook(int id, Book model)
        {
            var book = GetOneBook(id);
            

            if (book is null) throw new ArgumentOutOfRangeException(message: "Book cannot be null", null);
            
            
            book.Title = model.Title;
            book.Description = model.Description;
            book.Genre = model.Genre;
            book.Author = model.Author;
            

            _context.Books.Update(book);
            _context.SaveChanges();

            return book;
                
        }

        public Book UpdatePatchBook(int id, Book model)
        {
            var book = GetOneBook(id);

            if (book is null) throw new ArgumentOutOfRangeException(message: "No book with this Id found", null);

            if (!string.IsNullOrWhiteSpace(model.Title))
            {
                book.Title = model.Title;
            }

            if (!string.IsNullOrWhiteSpace(model.Description))
            {
                book.Description = model.Description;
            }

            if (!string.IsNullOrWhiteSpace(model.Genre))
            {
                book.Genre = model.Genre;
            }

            if (!string.IsNullOrWhiteSpace(model.Author))
            {
                book.Author = model.Author;
            }

            _context.Books.Update(book);
            _context.SaveChanges();

            return book;
                
        }

        public Book DeleteBook(int id)
        {
            var book = GetOneBook(id);
            
            if (book is null) throw new ArgumentOutOfRangeException(message: "Book cannot be null", null);

            _context.Books.Remove(book);
            _context.SaveChanges();

            return book;
                
        }
    }
}