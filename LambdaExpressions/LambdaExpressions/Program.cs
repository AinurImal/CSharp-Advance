using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLambdaExpression
{
    //Lambda Expression is an anonymous method
    //[1]No access modifier
    //[2]No name
    //[3]No return statement
    class Program
    {
        static void Main(string[] args)
        {
            // args => expression //args go to expression
            // () => ... no args
            // (x, y) => ...

            //--Example 1
            Func<int, int> square = number => number * number;
            Console.WriteLine(square(5));

            //--Example 2
            const int factor = 5;
            Func<int, int> multiplier = n => n * factor;
            Console.WriteLine(multiplier(10));

            //--Example of Predicate
            var books = new BookRepository().GetBooks();
            var cheapBooks = books.FindAll(IsCheaperThan10Dollars);

            foreach (var book in cheapBooks)
            {
                Console.WriteLine(book.Title);
            }

            //--Example to use Lambda instead of Predicate
            var lBooks = new BookRepository().GetBooks();
            var lCheapBooks = lBooks.FindAll(book => book.Price < 10);

            foreach (var book in lCheapBooks)
            {
                Console.WriteLine(book.Title);
            }
        }

        //Example of a Predicate (It is a delegate of type Predicate)
        //Predicate is a method that gets an object of Book, and give true/false based on the given condition
        static bool IsCheaperThan10Dollars(Book book)
        {
            return book.Price < 10;
        }
    }
}