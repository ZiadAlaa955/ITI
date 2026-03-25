namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> myBooks = new List<Book>
            {
                new Book("978-0132350884", "Clean Code", new string[] { "Robert C. Martin" }, new DateTime(2008, 8, 1), 42.99m),

                new Book("978-0201633610", "Design Patterns", new string[] { "Erich Gamma", "Richard Helm", "Ralph Johnson", "John Vlissides" }, new DateTime(1994, 10, 31), 54.50m),

                new Book("978-1098121222", "C# 10 in a Nutshell", new string[] { "Joseph Albahari" }, new DateTime(2022, 2, 22), 65.00m)
            };

            #region User Defined Delegate Datatype
            LibraryEngine.ProcessBooks(myBooks, BookFunctions.GetTitle);
            Console.WriteLine("--------------------------------------");
            LibraryEngine.ProcessBooks(myBooks, BookFunctions.GetAuthors);
            Console.WriteLine("--------------------------------------");
            LibraryEngine.ProcessBooks(myBooks, BookFunctions.GetPrice);
            #endregion
            Console.WriteLine("=====================================");
            
            #region BCL Delegates
            LibraryEngine.ProcessBooks2(myBooks, BookFunctions.GetTitle);
            Console.WriteLine("--------------------------------------");
            LibraryEngine.ProcessBooks2(myBooks, BookFunctions.GetAuthors);
            Console.WriteLine("--------------------------------------");
            LibraryEngine.ProcessBooks2(myBooks, BookFunctions.GetPrice);
            #endregion
            Console.WriteLine("=====================================");

            #region Anonymous Method
            Func<Book, string> Fptr = delegate (Book B) { return B.ISBN; };
            LibraryEngine.ProcessBooks2(myBooks, Fptr);
            #endregion
            Console.WriteLine("=====================================");

            #region Lambda Expression
            LibraryEngine.ProcessBooks2(myBooks, myBook => myBook.PublicationDate.ToString());         
            #endregion
        }
    }
}
