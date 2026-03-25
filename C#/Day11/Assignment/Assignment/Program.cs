using System.Collections;
using static D11.ListGenerators;
namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Restriction Operators
            //===========================================================
            //LINQ - Restriction Operators
            //===========================================================

            //1. Find all products that are out of stock.
            Console.WriteLine("==================================================");
            Console.WriteLine("All products that are out of stock");
            Console.WriteLine("==================================================");
            var Result = ProductList.Where(p => p.UnitsInStock == 0);
            foreach (var item in Result)
                Console.WriteLine(item);

            //2. Find all products that are in stock and cost more than 3.00 per unit.
            Console.WriteLine("==================================================");
            Console.WriteLine("All products that are in stock and cost more than 3");
            Console.WriteLine("==================================================");
            Result =  ProductList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);
            foreach (var item in Result)
                Console.WriteLine(item);

            //3. Returns digits whose name is shorter than their value.
            Console.WriteLine("==================================================");
            Console.WriteLine("Digits whose name is shorter than their value");
            Console.WriteLine("==================================================");
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var Result2 = Arr.Where((name, value) => name.Length < value);
            foreach (var item in Result2)
                Console.WriteLine(item);
            #endregion

            #region Element Operators
            //===========================================================
            //LINQ - Element Operators
            //===========================================================

            //1. Get first Product out of Stock 
            Console.WriteLine("==================================================");
            Console.WriteLine("First Product out of Stock");
            Console.WriteLine("==================================================");
            var Result3 =  ProductList.First(p => p.UnitsInStock == 0);
            Console.WriteLine(Result3);

            //2. Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            Console.WriteLine("==================================================");
            Console.WriteLine("First product whose Price > 1000");
            Console.WriteLine("==================================================");
            var Result4 =  ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
            Console.WriteLine(Result4);

            //3. Retrieve the second number greater than 5 
            int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var Result5 = Arr2.Where(item => item > 5).Skip(1).First();
            Console.WriteLine("==================================================");
            Console.WriteLine("The second number greater than 5");
            Console.WriteLine("==================================================");
            Console.WriteLine(Result5);
            #endregion

            #region Ordering Operators
            //======================================================
            //LINQ - Ordering Operators
            //======================================================
            //1. Sort a list of products by name
            var Result6 =  ProductList.OrderBy(p => p.ProductName);
            Console.WriteLine("==================================================");
            Console.WriteLine("Sort a list of products by name");
            Console.WriteLine("==================================================");
            foreach (var item in Result6)
                Console.WriteLine(item);


            //2. Uses a custom comparer to do a case-insensitive sort of the words in an array.
            Console.WriteLine("==================================================");
            Console.WriteLine("Sort by case senstive");
            Console.WriteLine("==================================================");
            string[] Arr3 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var caseInsensitiveSort = Arr3.OrderBy(word => word, StringComparer.OrdinalIgnoreCase);
            foreach (var word in caseInsensitiveSort)
                Console.WriteLine(word);

            //3.Sort a list of products by units in stock from highest to lowest.
            Console.WriteLine("==================================================");
            Console.WriteLine("Sort by units in stoack descending");
            Console.WriteLine("==================================================");
            var Result7 =  ProductList.OrderByDescending(p => p.UnitPrice);
            foreach (var item in Result7)
                Console.WriteLine(item);

            //4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
            Console.WriteLine("==================================================");
            Console.WriteLine("Sort first by length of their name, and then alphabetically by the name itself");
            Console.WriteLine("==================================================");
            string[] Arr4 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var Result8 = Arr4.OrderBy(name => name.Length).ThenBy(name => name);
            foreach (var item in Result8)
                Console.WriteLine(item);

            //5. Sort first by word length and then by a case-insensitive sort of the words in an array.
            Console.WriteLine("==================================================");
            Console.WriteLine("Sort first by word length and then by a case-insensitive sort of the words in an array");
            Console.WriteLine("==================================================");

            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var Result9 = words.OrderBy(name => name.Length).ThenBy(word => word, StringComparer.OrdinalIgnoreCase);
            foreach (var item in Result9)
                Console.WriteLine(item);

            //6. Sort a list of products, first by category, and then by unit price, from highest to lowest.
            Console.WriteLine("==================================================");
            Console.WriteLine("Sort a list of products, first by category, and then by unit price, from highest to lowest");
            Console.WriteLine("==================================================");
            var Result10 =  ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            foreach (var item in Result10)
                Console.WriteLine(item);

            //7. Sort first by word length and then by a case-insensitive descending sort of the words in an array.
            string[] Arr5 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            Console.WriteLine("==================================================");
            Console.WriteLine("Sort first by word length and then by a case-insensitive descending sort of the words in an array");
            Console.WriteLine("==================================================");
            var Result11 = Arr5.OrderBy(name => name.Length).ThenByDescending(word => word, StringComparer.OrdinalIgnoreCase);
            foreach (var item in Result11)
                Console.WriteLine(item);

            //8. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            Console.WriteLine("==================================================");
            Console.WriteLine("Sort first by word length and then by a case-insensitive descending sort of the words in an array");
            Console.WriteLine("==================================================");
            string[] Arr6 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var Result12 = Arr6.Where(word => word[1] == 'i').Reverse();
            Console.WriteLine("Digits with second letter 'i', in reverse order:");
            foreach (var item in Result12)
                Console.WriteLine(item);
            #endregion

            #region Projection Operators
            //====================================================
            //LINQ - Projection Operators
            //====================================================

            //1. Return a sequence of just the names of a list of products.
            Console.WriteLine("==================================================");
            Console.WriteLine("Sequence of the names of a list of products");
            Console.WriteLine("==================================================");
            var Result13 =  ProductList.Select(p => p.ProductName);
            foreach (var item in Result13)
                Console.WriteLine(item);

            //2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).
            Console.WriteLine("==================================================");
            Console.WriteLine("UpperCase & LowerCase versions of Words");
            Console.WriteLine("==================================================");
            string[] words2 = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var Result14 = words2.Select(word => new { upperCase = word.ToUpper(), lowerCase = word.ToLower() });
            foreach (var item in Result14)
                Console.WriteLine($"{item.upperCase}, {item.lowerCase}");

            //3. Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.
            Console.WriteLine("==================================================");
            Console.WriteLine("Name & Price");
            Console.WriteLine("==================================================");
            var Result15 =  ProductList.Select(p => new { name = p.ProductName, price = p.UnitPrice });
            foreach (var item in Result15)
                Console.WriteLine($"Name: {item.name} ==> Price: {item.price}");

            //4. Determine if the value of ints in an array match their position in the array.
            Console.WriteLine("==================================================");
            Console.WriteLine("Number: In-place?");
            Console.WriteLine("==================================================");
            int[] Arr7 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var Result16 = Arr7.Select((num, i) => new { number = num, inPlace = num == i });
            foreach (var item in Result16)
                Console.WriteLine($"{item.number}: {item.inPlace}");

            //5. Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.
            Console.WriteLine("==================================================");
            Console.WriteLine("Pairs where a < b:");
            Console.WriteLine("==================================================");
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var Result17 = from a in numbersA
                           from b in numbersB
                           where a < b
                           select new { A = a, B = b };
            foreach (var item in Result17)
                Console.WriteLine($"{item.A} is less than {item.B}");

            //6. Select all orders where the order total is less than 500.00.
            Console.WriteLine("==================================================");
            Console.WriteLine("Orders less than 500");
            Console.WriteLine("==================================================");
            var Result18 = from c in  CustomerList
                              from o in c.Orders
                              where o.Total < 500
                              select o;
            foreach(var item in Result18)
                Console.WriteLine(item);

            //7. Select all orders where the order was made in 1998 or later.
            Console.WriteLine("==================================================");
            Console.WriteLine("orders was made in 1998 or later");
            Console.WriteLine("==================================================");
            var Result19 = from c in  CustomerList
                           from o in c.Orders
                           where o.OrderDate.Year >= 1998
                           select o;
            foreach (var item in Result19)
                Console.WriteLine(item);
            #endregion
        }
    }
}
