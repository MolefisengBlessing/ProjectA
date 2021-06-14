using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Bookstore.Core
{
    public class DBClient : IDBClient
    {
        private readonly IMongoCollection<Book> _books;

        public DBClient(IOptions<BookstoreDBConfig> bookstoreDBConfig)
        {
            var client = new MongoClient(bookstoreDBConfig.Value.Connection_String);
            var database = client.GetDatabase(bookstoreDBConfig.Value.Database_Name);
            _books = database.GetCollection<Book>(bookstoreDBConfig.Value.Books_Collection_Name);
        }

        public IMongoCollection<Book> GetBooksCollection()
        {
            return _books;
        }
    }
}
