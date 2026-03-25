using D11;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.X86;
using static D11.ListGenerators;
using static System.Net.Mime.MediaTypeNames;


#region LINQ - Set Operators
Console.WriteLine("========================================");
Console.WriteLine("LINQ - Set Operators");
Console.WriteLine("========================================");

//1. Find the unique Category names from Product List
var UniqueCategoryNames = ProductList.Select(p => p.Category).Distinct();
Console.WriteLine("Unique Product Names: ");
foreach(var i in UniqueCategoryNames) Console.WriteLine(i);

//2. Produce a Sequence containing the unique first letter from both product and customer names.
Console.WriteLine("=============================================");
var uniqueFirstLetter = ProductList.Select(p => p.ProductName[0]).Union(CustomerList.Select(p => p.CompanyName[0]));
Console.WriteLine("Unique First letter from productNames & CompanyName: ");
foreach (var i in uniqueFirstLetter) Console.Write($"{i} ");
Console.WriteLine();

///3. Create one sequence that contains the common first letter from both product and customer names.
Console.WriteLine("=============================================");
var CommonFirstLetter = ProductList.Select(p => p.ProductName[0]).Intersect(CustomerList.Select(p => p.CompanyName[0]));
Console.WriteLine("Common First letter from productNames & CompanyName: ");
foreach (var i in CommonFirstLetter) Console.Write($"{i} ");
Console.WriteLine();

//4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.
Console.WriteLine("=============================================");
var ExceptFirstLetter = ProductList.Select(p => p.ProductName[0]).Except(CustomerList.Select(p => p.CompanyName[0]));
Console.WriteLine("First letter in productNames & NOT in CompanyName: ");
foreach (var i in ExceptFirstLetter) Console.Write($"{i} ");
Console.WriteLine();

//5. Create one sequence that contains the last Three Characters in each names of all customers and products, including any duplicates
Console.WriteLine("=============================================");
var ConcatLastThreeLetters = ProductList.Select(p => p.ProductName[^3..]).Concat(CustomerList.Select(p => p.CompanyName[^3..]));
Console.WriteLine("Last three letters in productNames & CompanyName with duplicates: ");
foreach (var i in ConcatLastThreeLetters) Console.Write($"{i} ");
Console.WriteLine();
#endregion

#region LINQ - Aggregate Operators
Console.WriteLine("========================================");
Console.WriteLine("LINQ - Aggregate Operators");
Console.WriteLine("========================================");

//1. Uses Count to get the number of odd numbers in the array
int[] CountOddArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var CountOdd = CountOddArr.Count(i => i % 2 == 1);
Console.WriteLine($"count Odd numbers in array: {CountOdd}");

//2. Return a list of customers and how many orders each has.
Console.WriteLine("========================================");
var CustomersOrders = CustomerList.Select(c => new { customer = c.CustomerID, orderCount = c.Orders.Count()});
foreach(var i in CustomersOrders)
    Console.WriteLine($"Customer: {i.customer} has {i.orderCount} orders");

//3. Return a list of categories and how many products each has
Console.WriteLine("========================================");
var CategoriesProducts = ProductList.CountBy(p => p.Category);
foreach (var i in CategoriesProducts)
    Console.WriteLine($"Category: {i.Key} has {i.Value} orders");

//4.Get the total of the numbers in an array.
int[] NumbersArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
Console.WriteLine("========================================");
Console.WriteLine($"Total Numbers of array: {NumbersArr.Sum()}");

//5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
Console.WriteLine("========================================");
string[] DictionaryText = File.ReadAllLines("D:\\ITI\\C#\\Day12\\Assignment\\Assignment\\dictionary_english.txt");
Console.WriteLine($"Total Number of characters in dictionart : {DictionaryText.Sum(d => d.Length)}");

//6. Get the total units in stock for each product category.
Console.WriteLine("========================================");
var TotalStockUnits = ProductList.AggregateBy(p => p.Category, 0,  (total, p) => total + p.UnitsInStock);
Console.WriteLine($"Total units in stock in each category:");
foreach(var i in TotalStockUnits)
    Console.WriteLine($"category: {i.Key} has {i.Value} in stock");

//7. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
Console.WriteLine("========================================");
var shortestWord = DictionaryText.Min(d => d.Length);
Console.WriteLine($"Length of Shortest Word: {shortestWord}");

//8. Get the cheapest price among each category's products
Console.WriteLine("========================================");
var CheapestPrice = ProductList.GroupBy(p => p.Category).Select(P => new { categoryname = P.Key, cheapestPrice = P.Min(p => p.UnitPrice) });
foreach(var i in CheapestPrice)
    Console.WriteLine($"Category: {i.categoryname} : {i.cheapestPrice:C}");

//9. Get the products with the cheapest price in each category (Use Let)
Console.WriteLine("========================================");
var LetCheapestPrice = from p in ProductList
                       group p by p.Category into groupCategory
                       let cheapestPrice = groupCategory.Min(g => g.UnitPrice)
                       select new { categoryname = groupCategory.Key, cheapestPrice = groupCategory.Where(p => p.UnitPrice == cheapestPrice) };
foreach (var i in CheapestPrice)
    Console.WriteLine($"Category: {i.categoryname} : {i.cheapestPrice:C}");

//10. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
Console.WriteLine("========================================");
var LongestWord = DictionaryText.Max(d => d.Length);
Console.WriteLine($"Length of Longest Word: {LongestWord}");

//11. Get the most expensive price among each category's products.
Console.WriteLine("========================================");
var HighstPrice = ProductList.GroupBy(p => p.Category).Select(P => new { categoryname = P.Key, cheapestPrice = P.Max(p => p.UnitPrice) });
foreach (var i in HighstPrice)
    Console.WriteLine($"Category: {i.categoryname} : {i.cheapestPrice:C}");

//12. Get the products with the most expensive price in each category.
Console.WriteLine("========================================");
var LetHighestPrice = from p in ListGenerators.ProductList
                      group p by p.Category into groupCategory
                      let highestPrice = groupCategory.Max(g => g.UnitPrice)
                      select new
                      {
                          CategoryName = groupCategory.Key,
                          Products = groupCategory.Where(p => p.UnitPrice == highestPrice)
                      };
foreach (var category in LetHighestPrice)
{
    Console.Write($"Category: {category.CategoryName} : ");
    foreach (var product in category.Products)
        Console.WriteLine($"{product.ProductName} : {product.UnitPrice:C}");
}

//13. Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
var AvgWordsLength = DictionaryText.Average(d => d.Length);
Console.WriteLine("========================================");
Console.WriteLine($"Average length of words: {(Int32)AvgWordsLength}");

//14. Get the average price of each category's products.
var AvgPrices = ProductList.GroupBy(pg => pg.Category).Select(p => new { categoryName = p.Key, avg = p.Average(ap => ap.UnitPrice) });
Console.WriteLine("========================================");
Console.WriteLine($"Average Prices of In categories: ");
foreach(var i in AvgPrices)
    Console.WriteLine($"Category: {i.categoryName} : {(Int32)i.avg}");
#endregion

#region LINQ - Partitioning Operators
Console.WriteLine("===============================================");
Console.WriteLine("LINQ - Partitioning Operators");
Console.WriteLine("===============================================");

//1. Get the first 3 orders from customers in Washington
var First3Orders = CustomerList.Where(c => c.Region == "WA").SelectMany(c => c.Orders).Take(3);
Console.WriteLine("First 3 orders in Washington: ");
foreach(var i in First3Orders)
    Console.WriteLine(i);

//2. Get all but the first 2 orders from customers in Washington.
Console.WriteLine("===============================================");
var SkipFirst2Orders = CustomerList.Where(c => c.Region == "WA").SelectMany(c => c.Orders).Skip(2);
Console.WriteLine("Skip First 2 orders in Washington: ");
foreach (var i in SkipFirst2Orders)
    Console.WriteLine(i);

//3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.
int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
Console.WriteLine("===============================================");
var numbersResult = numbers.TakeWhile((n, i) => n >= i);
Console.WriteLine("Elements until number less than position: ");
foreach (var i in numbersResult)
    Console.WriteLine(i);

//4. Get the elements of the array starting from the first element divisible by 3.
int[] numbers2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
Console.WriteLine("===============================================");
var numbersResult2 = numbers.SkipWhile(n => n % 3 != 0);
Console.WriteLine("Elements Divisible by 3: ");
foreach (var i in numbersResult2)
    Console.WriteLine(i);

//5. Get the elements of the array starting from the first element less than its position.
int[] numbers3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
Console.WriteLine("===============================================");
var numbersResult3 = numbers.SkipWhile((n, i) => n >= i);
Console.WriteLine("Elements starting from number less than position: ");
foreach (var i in numbersResult3)
    Console.WriteLine(i);

#endregion

#region LINQ - Quantifiers
Console.WriteLine("===============================================");
Console.WriteLine("LINQ - Quantifiers");
Console.WriteLine("===============================================");

//1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.
var AnyEI = DictionaryText.Any(d => d.Contains("ei"));
Console.WriteLine($"is any word contains \"ei\" : {AnyEI}");

//2. Return a grouped a list of products only for categories that have at least one product that is out of stock.
Console.WriteLine("===============================================");
var OutOfStockList = ProductList.GroupBy(p => p.Category).Where(g => g.Any(p => p.UnitsInStock == 0));
foreach (var categoryGroup in OutOfStockList)
{
    Console.Write($"Category: {categoryGroup.Key}");
    foreach (var product in categoryGroup)
    {
        string stockStatus = product.UnitsInStock == 0 ? "OUT OF STOCK" : product.UnitsInStock.ToString();
        Console.WriteLine($"{product.ProductName} (Stock: {stockStatus})");
    }
}

//3. Return a grouped a list of products only for categories that have all of their products in stock.
Console.WriteLine("===============================================");
var AllInStockList = ProductList.GroupBy(p => p.Category).Where(g => g.All(p => p.UnitsInStock > 0));
foreach (var categoryGroup in AllInStockList)
{
    Console.Write($"Category: {categoryGroup.Key}");
    foreach (var product in categoryGroup)
    {
        Console.WriteLine($"{product.ProductName} (Stock: {product.UnitsInStock})");
    }
}
#endregion

#region LINQ - Grouping Operators
Console.WriteLine("===============================================");
Console.WriteLine("LINQ - Grouping Operators");
Console.WriteLine("===============================================");

//1. Use group by to partition a list of numbers by their remainder when divided by 5
int[] numbers4 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
var DividedBy5 = numbers4.GroupBy(n => n % 5);
foreach (var group in DividedBy5)
{
    Console.WriteLine($"Numbers with a remainder of {group.Key} when divided by 5:");
    foreach (var number in group)
        Console.WriteLine(number);
}

//2. Uses group by to partition a list of words by their first letter (Use dictionary_english.txt for Input)
var GroupWords = DictionaryText.GroupBy(d => d[0]);
Console.WriteLine("===============================================");
Console.WriteLine("Group words by first letter:");
foreach (var i in GroupWords)
{
    Console.WriteLine($"\nLetter: {i.Key}");
    foreach(var j in i.Take(5))
        Console.Write($"{j}  ");
}

//3. Consider this Array as an Input 
string[] Arr = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };
//Use Group By with a custom comparer that matches words that are consists of the same Characters Together
Console.WriteLine("========================================");
var matchedWords = Arr.GroupBy(w => w, new AnagramComparer());
foreach (var group in matchedWords)
{
    Console.WriteLine("...");
    foreach (var word in group)
    {
        Console.WriteLine(word.Trim());
    }
}

public class AnagramComparer : IEqualityComparer<string>
{
    public bool Equals(string x, string y)
    {
        string sortedX = string.Concat(x.Trim().OrderBy(c => c));
        string sortedY = string.Concat(y.Trim().OrderBy(c => c));

        return sortedX == sortedY;
    }

    public int GetHashCode(string obj)
    {
        string sortedObj = string.Concat(obj.Trim().OrderBy(c => c));
        return sortedObj.GetHashCode();
    }
}
#endregion