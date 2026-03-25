using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    public class Book
    {
        #region Properties
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }
        #endregion

        #region Constructor
        public Book(string _ISBN, string _Title, string[] _Authors, DateTime _PublicationDate, decimal _Price)
        {
            ISBN = _ISBN;
            Title = _Title;
            Authors = _Authors;
            PublicationDate = _PublicationDate;
            Price = _Price;
        }
        #endregion

        #region ToString override
        public override string ToString() 
            => $"ISBN: {ISBN}\nTitle: {Title} \nAuthors: {string.Join(",", Authors)}\nPublication Date:{PublicationDate}\nPrice: {Price} ";
        #endregion
    }
    public class BookFunctions
    {
        public static string GetTitle(Book B) => B.Title;
        public static string GetAuthors(Book B) => string.Join(",",B.Authors);
        public static string GetPrice(Book B) => B.Price.ToString("C");
    }

    #region User Defined Delegate Datatype
    public delegate string MyDelegate(Book B);

    public class LibraryEngine
    {
        public static void ProcessBooks(List<Book> bList, MyDelegate fPtr)
        {
            foreach (Book B in bList)
                Console.WriteLine(fPtr(B));
        }
    #endregion

        public static void ProcessBooks2(List<Book> bList, Func<Book, string> fPtr)
        {
            foreach (Book B in bList)
                Console.WriteLine(fPtr(B));
        }
    }
}
