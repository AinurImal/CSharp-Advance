using System;

namespace Generics
{
    public class Book
    {
        // Assuming Book class has some properties
        public string Title { get; set; }
        public string Author { get; set; }
    }

    public class BookList
    {
        private List<Book> books = new List<Book>();

        public void Add(Book book)
        {
            books.Add(book);
        }

        public Book this[int index]
        {
            get { return books[index]; }
        }
    }

    public class GenericDictionary<TKey, TValue>
    {
        public void Add(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }
    }

    public class GenericList<T>
    {
        public void Add(T value)
        {
            throw new NotImplementedException();
        }

        public T this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }
}
