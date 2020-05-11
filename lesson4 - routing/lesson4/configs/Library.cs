using System.Collections.Generic;

namespace lesson4
{
    public class Library
    {

        public List<Book> Books { get; set; }
    }

    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
