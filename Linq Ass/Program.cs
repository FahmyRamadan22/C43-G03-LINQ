using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static Assignment.ListGenerator;
namespace Assignment
{
    public class WordsComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
            return Sort(x!) == Sort(y!);
        }

        public int GetHashCode([DisallowNull] string obj)
        {
            return Sort(obj).GetHashCode();
        }

        private string Sort(string word)
        {
            char[] arr = word.ToCharArray();
            Array.Sort(arr);
            return new string(arr);
        }
    }
    internal class Program
    {

        public static void PrintEnumerable<T>(IEnumerable<T> list)
        {
            foreach (var item in list)
                Console.WriteLine(item);

            Console.WriteLine("====================================================================================");
            Console.WriteLine();
        }
        internal class ProgramBase
        {
            public static void PrintCollection<T>(IEnumerable<T> collection)
            {
                foreach (var item in collection)
                    Console.WriteLine(item);

                Console.WriteLine();
            }

            static void Main(string[] args, int v)
            {


                #region LINQ - Restriction Operators

                #region 1. Find all products that are out of stock.

                // 1. Fluent Syntax
                var OutOfStockProducts = ProductList.Where(P => P.UnitsInStock == 0);

                // 2. Query Syntax

                OutOfStockProducts = from P in ProductList
                                     where P.UnitsInStock == 0
                                     select P;

                PrintCollection(OutOfStockProducts);




                #endregion

                #region 2. Find all products that are in stock and cost more than 3.00 per unit.


                //// 1. By Fluent Syntax
                //var specifiedCostProducts = ProductList.Where((P) => P.UnitsInStock > 0 && P.UnitPrice > 3.00M);


                //// 2. By Query Syntax

                //specifiedCostProducts = from product in ProductList
                //                        where product.UnitsInStock > 0 && product.UnitPrice > 3.00M
                //                        select product;


                //PrintCollection(specifiedCostProducts);




                #endregion

                #region 3. Returns digits whose name is shorter than their value.

                string[] Arr = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

                // 1. Fluent Syntax
                // 1.1. Indexed Where
                var ShorterDigits = Arr.Where((number, index) => number.Length < index);
                // 1.2. Array.IndexOf() method
                ShorterDigits = Arr.Where(number => number.Length < Array.IndexOf(Arr, number));

                // 2. Query Syntax

                ShorterDigits = from number in Arr
                                where number.Length < Array.IndexOf(Arr, number)
                                select number;


                //PrintCollection(ShorterDigits);


                #endregion
                #endregion

                #region LINQ - Ordering Operators

                #region 1. Sort a list of products by name

                // Stable Sorting Algorithm: If two elements are equal, their order will be preserved as they were in the original sequence.
                // OrderBy is stable algorithm.

                // 1.Fluent Syntax

                var OrderedByNameProducts = ProductList.OrderBy(P => P.ProductName);


                // 2. Query Syntax

                OrderedByNameProducts = from P in ProductList
                                        orderby P.ProductName
                                        select P;

                //PrintCollection(OrderedByNameProducts);


                #endregion

                #region 2. Uses a custom comparer to do a case-insensitive sort of the words in an array.

                IEnumerable<string> Words = ["aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"];


                // 1. Fluent Syntax

                //var sortedWords = Words.OrderBy(word => word, new StringInCaseSensitiveComparer());
                var sortedWords = Words.OrderBy(word => word, StringComparer.OrdinalIgnoreCase);

                //PrintCollection(sortedWords);





                #endregion

                #region 3. Sort a list of products by units in stock from highest to lowest.

                // 1. Fluent Syntax

                var OrderedByUnitsInStockProducts = ProductList.OrderByDescending(P => P.UnitsInStock);

                // 2. Query Syntax

                OrderedByUnitsInStockProducts = from product in ProductList
                                                orderby product.UnitsInStock descending
                                                select product;


                //PrintCollection(OrderedByUnitsInStockProducts);


                #endregion

                #region 4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.

                Arr = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

                // 1. Fluent Syntax

                var SortedNumbers = Arr.OrderBy(number => number.Length)
                                       .ThenBy(number => number);


                // 2. Query Syntax

                SortedNumbers = from number in Arr
                                orderby number.Length, number
                                select number;


                //PrintCollection(SortedNumbers);

                #endregion

                #region 5. Sort first by word length and then by a case-insensitive sort of the words in an array.

                string[] Arr02 = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

                // 1. Fluent Syntax

                var SortedWords = Arr02.OrderBy(number => number.Length)
                                     .ThenBy(number => number, StringComparer.OrdinalIgnoreCase);


                SortedWords = Arr02.OrderBy(number => number.Length)
                                     .ThenBy(number => number, new StringInCaseSensitiveComparer());


                //PrintCollection(SortedWords);




                #endregion

                #region 6.Sort a list of products, first by category, and then by unit price, from highest to lowest.

                // 1.Fluent Syntax

                var sortedByCategoryAscAndPriceDesc = ProductList.OrderBy(P => P.Category)
                                                                 .ThenByDescending(P => P.UnitPrice);

                // 2. Query Syntax

                sortedByCategoryAscAndPriceDesc = from P in ProductList
                                                  orderby P.Category, P.UnitPrice descending
                                                  select P;


                //PrintCollection(sortedByCategoryAscAndPriceDesc);


                #endregion

                #region 7. Sort first by word length and then by a case-insensitive descending sort of the words in an array.

                IEnumerable<string> Fruits = ["aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"];

                // 1. Fluent Syntax

                var sortedFruits = Fruits.OrderBy(word => word.Length)
                                          .ThenByDescending(word => word, StringComparer.OrdinalIgnoreCase);

                sortedFruits = Fruits.OrderBy(word => word.Length)
                                          .ThenByDescending(word => word, new StringInCaseSensitiveComparer());

                //PrintCollection(sortedFruits);


                #endregion

                #region 8. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.

                Arr = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

                // 1. Fluent Syntax

                var reversedNumbersWithILetter = Arr.Where(number => number[1] == 'i')
                                                    .Reverse();


                // 2. Query Syntax

                reversedNumbersWithILetter = (from number in Arr
                                              where number[1] == 'i'
                                              select number).Reverse();

                //PrintCollection(reversedNumbersWithILetter);




                #endregion

                #endregion

                #region LINQ – Transformation Operators

                #region 1. Return a sequence of just the names of a list of products.

                // 1. Fluent Syntax

                var productNames = ProductList.Select(P => P.ProductName);

                // 2. Query Syntax

                productNames = from p in ProductList
                               select p.ProductName;

                //PrintCollection(productNames);

                #endregion

                #region 2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).

                string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

                // 1. Fluent Syntax
                var upperLowerWords = words.Select(word => new { LowerVersion = word.ToLower(), UpperVersion = word.ToUpper() });

                // 2. Query Syntax

                upperLowerWords = from word in words
                                  select new { LowerVersion = word.ToLower(), UpperVersion = word.ToUpper() };


                //PrintCollection(upperLowerWords);



                #endregion

                #region 3. Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.

                // 1.Fluent Syntax

                var productsBrief = ProductList.Select(P => new { Name = P.ProductName, Price = P.UnitPrice, P.UnitsInStock });

                // 2. Query Syntax

                productsBrief = from product in ProductList
                                select new { Name = product.ProductName, Price = product.UnitPrice, product.UnitsInStock };


                //PrintCollection(productsBrief);


                #endregion

                #region 4. Determine if the value of ints in an array match their position in the array.
                int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

                // 1.Fluent Syntax

                var matchedNumbers = numbers.Select((number, index) => $"{number}: {number == index}");

                // 2.Query Syntax

                matchedNumbers = from number in numbers
                                 select $"{number}: {number == Array.IndexOf(numbers, number)}";

                //PrintCollection(matchedNumbers);


                #endregion

                #region 5. Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.

                int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 }; /*(A,B)*/
                int[] numbersB = { 1, 3, 5, 7, 8 };

                // 1. Fluent Syntax

                var pairs = numbersA.SelectMany(numberA => numbersB, (numberA, numberB) => new { numberA, numberB })
                                    .Where(pair => pair.numberA < pair.numberB)
                                    .Select(pair => $"{pair.numberA} is less than {pair.numberB}");

                // 2. Query Syntax

                pairs = from numberA in numbersA
                        from numberB in numbersB
                        where numberA < numberB
                        select $"{numberA} is less than {numberB}";

                //PrintCollection(pairs);






                #endregion

                #region 6. Select all orders where the order total is less than 500.00.

                // 1. Fluent Syntax

                var OrderesLessThan500 = CustomerList.SelectMany(C => C.Orders)
                                                     .Where(order => order.Total < 500);

                // 2. Query Syntax

                OrderesLessThan500 = from Customer in CustomerList
                                     from Order in Customer.Orders
                                     where Order.Total < 500
                                     select Order;

                //PrintCollection(OrderesLessThan500);

                #endregion

                #region 7. Select all orders where the order was made in 1998 or later.
                // 1.Fluent Syntax

                var OrdersIn1998OrLater = CustomerList.SelectMany(C => C.Orders)
                                                      .Where(Order => Order.OrderDate.Year >= 1998);


                // 2.Query Syntax

                OrdersIn1998OrLater = from Customer in CustomerList
                                      from Order in Customer.Orders
                                      where Order.OrderDate.Year >= 1998
                                      select Order;

                PrintCollection(OrdersIn1998OrLater);

                #endregion

                #endregion

                #region Element Operators

                #region Question 01
                //// 1. Get first Product out of Stock 

                //var FirstProductOutOfStock = ProductList.FirstOrDefault(P => P.UnitsInStock == 0);
                ////Console.WriteLine(FirstProductOutOfStock);


                #endregion

                #region Question 02

                // 2. Return the first product whose Price > 1000, unless there is no match, in which case null is returned.

                //var FirstProductMoreThan1000 = ProductList.FirstOrDefault(P => P.UnitPrice > 1000);

                ////Console.WriteLine(FirstProductMoreThan1000);

                //var sortedProducts = ProductList.OrderByDescending(P => P.UnitPrice);

                //PrintEnumerable(sortedProducts);

                #endregion

                #region Question 03

                // 3. Retrieve the second number greater than 5

                int[] Arr01 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

                var SecondNumberGreaterThan5 = Arr01.Where(n => n >5)
                                                  .ElementAtOrDefault(1);


                //Console.WriteLine(SecondNumberGreaterThan5);




                #endregion



                #endregion

                #region Aggregate Operators

                #region Question 01

                //// 1. Uses Count to get the number of odd numbers in the array
                //Arr01 = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

                //var OddCount = Arr01.Count(n => n % 2 != 0);

                //Console.WriteLine(OddCount);




                #endregion

                #region Question 02

                //// 2. Return a list of customers and how many orders each has.

                //var customerListWithOrderCount = CustomerList.Select(Customer => new { Customer.CustomerName, OrderCount = Customer.Orders.Count() });
                ////PrintEnumerable(customerListWithOrderCount);



                #endregion

                #region Question 03
                // 3. Return a list of categories and how many products each has
                //var ProductsPerCtegory = ProductList.GroupBy(P => P.Category, (Category, group) => new { Category, Count = group.Count() });
                ////PrintEnumerable(ProductsPerCtegory);


                #endregion

                #region Question 04
                //// 4. Get the total of the numbers in an array.
                //Arr01 = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

                //var Total = Arr01.Sum();
                ////Console.WriteLine(Total);


                #endregion

                #region Question 05
                // 5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

                //var TotalCharCount = Words.Aggregate(0, (total, word) => total + word.Length);

                //TotalCharCount = Words.Sum(word => word.Length);

                //Console.WriteLine($"Total Characters count: {TotalCharCount}");


                #endregion

                #region Question 06
                // 6. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

                //// b is the shortest word in the dictionary

                //var shortestLength = Words.Min(word => word.Length);
                ////Console.WriteLine(shortestLength);


                #endregion

                #region Question 07
                // 7. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
                //var longestWord = Words.Max(word => word.Length);
                ////Console.WriteLine(longestWord);

                #endregion

                #region Question 08
                // 8. Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

                //var AverageLength = Words.Average(Word => Word.Length);
                ////Console.WriteLine(AverageLength);

                #endregion

                #region Question 09
                //  9. Get the total units in stock for each product category.

                //var UnitsInStockPerCategory = ProductList.GroupBy(P => P.Category, (Category, Products) => new { Category, TotalUnitsInStock = Products.Sum(P => P.UnitsInStock) });
                ////PrintEnumerable(UnitsInStockPerCategory);


                #endregion

                #region Question 10
                // 10. Get the cheapest price among each category's products.

                //var CheepestPricePerCategory = ProductList.GroupBy(P => P.Category, (Category, Products) => new { Category, CheepestPrice = Products.Min(Product => Product.UnitPrice) });
                ////PrintEnumerable(CheepestPricePerCategory);


                #endregion

                #region Question 11
                // 11. Get the products with the cheapest price in each category (Use Let)

                //var CheepestProductPerCategory = from p in ProductList
                //                                 group p by p.Category
                //                                 into CategoryGroup
                //                                 let cheepestProduct = CategoryGroup.MinBy(CategoryGroup => CategoryGroup.UnitPrice)
                //                                 select new { Category = CategoryGroup.Key, CheepestProduct = cheepestProduct };

                ////PrintEnumerable(CheepestProductPerCategory);




                #endregion

                #region Question 12
                //// 12. Get the most expensive price among each category's products.

                //var MostExpensivePricePerCategory = ProductList.GroupBy(P => P.Category, (Category, Products) => new { Category, MostExpensivePrice = Products.Max(Product => Product.UnitPrice) });
                ////PrintEnumerable(MostExpensivePricePerCategory);


                #endregion

                #region Question 13
                // 13. Get the most expensive product in each category.

                //var MostExpnesiveProductPerCategory = from p in ProductList
                //                                      group p by p.Category
                //                                into CategoryGroup
                //                                      let MostExpensiveProduct = CategoryGroup.MaxBy(CategoryGroup => CategoryGroup.UnitPrice)
                //                                      select new { Category = CategoryGroup.Key, MostExpensiveProduct };

                ////PrintEnumerable(MostExpnesiveProductPerCategory);


                #endregion

                #region Question 14
                // 14. Get the average price of each category's products.

                //var AveragePricePerCategory = ProductList.GroupBy(P => P.Category, (Category, Products) => new { Category, AveragePrice = Products.Average(Product => Product.UnitPrice) });
                ////PrintEnumerable(AveragePricePerCategory);



                #endregion

                #endregion

                #region Set Operators

                #region Question 01

                // 1. Find the unique Category names from Product List

                //var UniqueCategoryNames = ProductList.Select(P => P.Category)
                //                                     .Distinct();

                ////PrintEnumerable(UniqueCategoryNames);

                #endregion

                #region Question 02

                //// 2. Produce a Sequence containing the unique first letter from both product and customer names

                //var UniqueFirstLetters = ProductList.Select(P => P.ProductName[0])
                //                                    .Union(CustomerList.Select(C => C.CustomerName[0]));

                ////PrintEnumerable(UniqueFirstLetters);




                #endregion

                #region Question 03
                // 3. Create one sequence that contains the common first letter from both product and customer names.

                //var CommonFirstLetters = ProductList.Select(P => P.ProductName[0])
                //                                   .Intersect(CustomerList.Select(C => C.CustomerName[0]));

                ////PrintEnumerable(CommonFirstLetters);


                #endregion

                #region Question 04
                // 4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.

                //var ProductNotCustomerLetter = ProductList.Select(P => P.ProductName[0])
                //                                   .Except(CustomerList.Select(C => C.CustomerName[0]));

                ////PrintEnumerable(ProductNotCustomerLetter);


                #endregion

                #region Question 05

                //// 5. Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates


                //// 1 2 3 4 5 
                //var LastThreeChars = ProductList.Select(P => P.ProductName[^3..])
                //                     .Concat(CustomerList.Select(C => C.CustomerName[^3..]));

                //PrintEnumerable(LastThreeChars);



                #endregion

                #endregion

                #region Partitioning Operators

                #region Question 01
                // 1. Get the first 3 orders from customers in Washington

                //var WAFirstThreeOrders = CustomerList.Where(C => C.Region == "WA")
                //                                     .SelectMany(C => C.Orders)
                //                                     .Take(3);

                ////PrintEnumerable(WAFirstThreeOrders);



                #endregion

                #region Question 02
                // 2. Get all but the first 2 orders from customers in Washington.

                //var WACustomersOrders = CustomerList.Where(C => C.Region == "WA")
                //                                    .SelectMany(C => C.Orders)
                //                                    .Skip(2);


                //PrintEnumerable(WACustomersOrders);

                #endregion

                #region Question 03
                // 3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.
                //int[] numbers01 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

                //var output = numbers01.TakeWhile((number, index) => number >= index);

                ////PrintEnumerable(output);

                #endregion

                #region Question 04

                //// 4. Get the elements of the array starting from the first element divisible by 3.
                //numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

                //var output02 = numbers.SkipWhile(number => number % 3 != 0);

                ////PrintEnumerable(output02);

                #endregion

                #region Question 05

                //  5. Get the elements of the array starting from the first element less than its position.
                //numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

                //var output03 = numbers.SkipWhile((number, index) => number >= index);
                ////PrintEnumerable(output03);

                #endregion


                #endregion

                #region Quantifiers

                #region Question 01

                // 1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.

                //Console.WriteLine(Words.Any(Word => Word.Contains("ei")));


                #endregion

                #region Question 02

                // 2. Return a grouped a list of products only for categories that have at least one product that is out of stock.

                //var products = ProductList.GroupBy(P => P.Category)
                //                          .Where(group => group.Any(P => P.UnitsInStock == 0));

                //foreach(var group in products)
                //    Console.WriteLine($"Category: {group.Key}\n...{string.Join("\n...", group)}\n");



                #endregion

                #region Question 03

                // 3. Return a grouped a list of products only for categories that have all of their products in stock.

                //var products02 = ProductList.GroupBy(P => P.Category)
                //                        .Where(group => group.All(P => P.UnitsInStock > 0));

                //foreach (var group in products02)
                //    Console.WriteLine($"Category: {group.Key}\n...{string.Join("\n...", group)}\n");





                #endregion

                #endregion


                #region Grouping Operators

                #region Question 01

                // 1. Use group by to partition a list of numbers by their remainder when divided by 5
                //List<int> nums = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15];

                //// Fluent Syntax
                //var groupedByRemainder = nums.GroupBy(n => n % 5, (remainder, numbers) => new { remainder, numbers });

                //// Query Syntax
                //groupedByRemainder = from number in nums
                //                     group number by number % 5
                //                     into remainderGroup
                //                     select new { remainder = remainderGroup.Key, numbers = (IEnumerable<int>)remainderGroup };

                //foreach( var group in groupedByRemainder)
                //    Console.WriteLine($"Numbers with a remainder of {group.remainder} when divided by 5: {string.Join(", " , group.numbers)}");

                #endregion

                #region Question 02
                // 2. Uses group by to partition a list of words by their first letter. Use dictionary_english.txt for Input

                // FLuent Syntax
                //var wordGroupedByFirstLetter = Words.GroupBy(word => word[0], (firstLetter, words) => new { FirstLetter = firstLetter, Words = words });


                //// Query Syntax
                //wordGroupedByFirstLetter = from word in Words
                //                           group word by word[0]
                //                           into FirstLetterGroup
                //                           select new { FirstLetter = FirstLetterGroup.Key, Words = (IEnumerable<string>)FirstLetterGroup };

                //foreach (var group in wordGroupedByFirstLetter)
                //    Console.WriteLine($"Words starting with letter {group.FirstLetter}: {string.Join("\n" , group.Words)}");

                #endregion

                #region Question 03
                // 3. Use Group By with a custom comparer that matches words that are consists of the same Characters Together
                //string[] Arr0 = { "from", "salt", "earn", " last", "near", "form" };

                ////var string01 = "from";
                ////var string02 = "form";

                ////char[] arr01 = string01.ToCharArray();
                ////char[] arr02 = string02.ToCharArray();

                ////Array.Sort(arr01);
                ////Array.Sort(arr02);

                ////Console.WriteLine(arr01);
                ////Console.WriteLine(arr02);

                //var groupedWords = Arr0.GroupBy(word => word.Trim(), (word, words) => new { Word = word, Matches = words }, new WordsComparer());

                ////foreach (var group in groupedWords)
                //    Console.WriteLine($"Anagrams of {group.Word}: {string.Join(", " , group.Matches)}");


                #endregion


                #endregion






            }
        }
    }
}