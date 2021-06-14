using Bookstore.Core;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Bookstore.WebApi
{

    public class BookServices : IBookServices
    {
        private readonly IMongoCollection<Book> _books;

        public BookServices(IDBClient dBClient)
        {
            _books = (IMongoCollection<Book>)dBClient.GetBooksCollection();
        }

        public Book AddBook(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void DeleteBook(string id)
        {
            _books.DeleteOne(book => book.Id == id);
        }

        public Book GetBook(string id) => _books.Find(book => book.Id == id).First();

        public List<Book> GetBooks()
        {
            return _books.Find(book => true).ToList();
        }

        public Book UpdateBook(Book book)
        {
            GetBook(book.Id);
            _books.ReplaceOne(b => b.Id == book.Id, book);
            return book;
        }
    }
}
