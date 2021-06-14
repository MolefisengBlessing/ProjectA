using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Core
{
    public interface IDBClient
    {
        IMongoCollection<Book> GetBooksCollection();
    }
}
