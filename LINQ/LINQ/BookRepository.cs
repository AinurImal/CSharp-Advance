﻿using System.Collections.Generic;

namespace LINQ
{
    public class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book() {Title = "ADO.Net step by Step", Price = 5},
                new Book() {Title = "ASP.NET Web API", Price = 12},
                new Book() {Title = "C# Advanced Topics", Price = 7},
                new Book() {Title = "ASP.NET MVC", Price = 9.99},
                new Book() {Title = "C# Intermediate", Price = 9}
            };
        }
    }
}
