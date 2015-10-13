namespace Task09.CreateBooksDB
{
    using System;

    public class Book
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime? PusblishDate { get; set; }

        public int ISBN { get; set; }
    }
}
