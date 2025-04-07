using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduction to LINQ - Language Intergrated Query:");

            /*
             * Types of LINQ:
             * Obects in Memory (Collections) = Linq to Objects
             * Databaes = Linq to Entity
             * XML = Linq to XML
             * ADO.NET Data Bsets = Linq to Data sets
             */
            //Retrive the Collection of Books
            var books = new BookRepository().GetBooks();

            //1. Retrive Books < 10 - The Old Fashioned Way.
            var cheapBooks = new List<Book>();
            foreach (var book in books)
            {
                if (book.Price < 10)
                {
                    cheapBooks.Add(book);
                }
            }

            //2. The LINQ Way - Need to Revise Extention Methods
            Console.WriteLine("My First LINQ Command: Filtering Cheapbooks");
            var moarCheapBooks = books.Where(b => b.Price < 10); //Where uses a Predicate(Search Condition) Lambda

            foreach (var book in moarCheapBooks)
            {
                Console.WriteLine(book.Title + " $" + book.Price);
            }

            //3. What makes LINQ Powerful is chaining Commands
            Console.WriteLine("\nChaining LINQ Commands: Filteting Cheapbooks & Order Descending Titles");
            var sortedBooks = books.OrderBy(b => b.Title).OrderBy(b => b.Title);

            foreach (var book in sortedBooks)
            {
                Console.WriteLine(book.Title + " $" + book.Price);
            }

            //4. LINQ Extension Method -  Select can select particular properties from a Collection
            //A General Convention when Using LINQ and Lambdas, is to break each One into its own line, more readable.
            Console.WriteLine("\nUsing SELECT to access/convert Properties from Objects.");
            var bookTitles = books.
                OrderBy(b => b.Title)
                .OrderBy(b => b.Title)
                .Select(b => b.Title);//Selecting the Title(String)

            foreach (var book in bookTitles)
            {
                Console.WriteLine(book);//Just Printing what the Book Object Currently is, to show conversion from Book Object to String.
            }

            //5. LINQ Query Operators - Specific LINQ Operators to do the same job as above.
            //These Keywords essentially use the same extension methods as above, but provide ease of use.
            //For more complex queries, it is better to use the Extension Methods as there is not enough keywords to cover all the same functionality
            var cheapoBooks = from b in books
                              where b.Price < 10
                              orderby b.Title
                              select b.Title;

            //.6 Single V Where
            //The Where Method we used before returned a collection, what if we want a single result?
            Console.WriteLine("\nLINQ Single - Find Single Object in collection with MVC in Title:");

            //var MVCBook = books.Single(b => b.Title.Contains("MVC++")); - Must be certain ONLY ONE Exists, or will get exception
            var MVCBook = books.SingleOrDefault(b => b.Title.Contains("MVC++")); //Safer Method
            Console.WriteLine(MVCBook == null);//Should return Null, when No Match found.


            //7. First Method
            Console.WriteLine("\nLINQ First: First Books that matches given criteria.");
            var firstBook = books.First(b => b.Title.Contains("C#"));
            Console.WriteLine(firstBook.Title + " " + firstBook.Price);

            //8. Last Method
            Console.WriteLine("\nLINQ Last: Last Books that matches given criteria.");
            var lastBook = books.LastOrDefault(b => b.Title.Contains("C#"));
            Console.WriteLine(lastBook.Title + " " + lastBook.Price);

            //9 Skip & Take
            Console.WriteLine("\nLINQ Skip & Take: Skip 2 into the list & Take 3.");
            var skippedBooks = books.Skip(2).Take(3); //Skip 2 Into the collection & Return 3
            foreach (var book in skippedBooks)
            {
                Console.WriteLine(book.Title);
            }
            //10. Count - Max - Min
            Console.WriteLine("\nLINQ Count, Max , Min & Sum");
            var bookCount = books.Count();
            var max = books.Max(b => b.Price);
            var min = books.Min(b => b.Price);
            var sum = books.Sum(b => b.Price);
            Console.WriteLine("Count {0} - Max {1} - Min {2} - Sum {3}", bookCount, max, min, sum);

            //Summary - The Beauty of LINQ is these methods will not change if you are working with XML, Entity or Datasets
            //books.Where();
            //books.Single();
            //books.SingleOrDefault();
            //books.Average();

            Console.ReadKey();
        }
    }
}
