using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqSnippets
{
    public class Snippets
    {
        static public void BasicLinqExamples()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "VW A3",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat León"
            };

            // 1. SELECT * FROM cars (ALL CARS)
            var carList = from car in cars select car;
            foreach(var car in carList)
            {
                Console.WriteLine(car);
            }

            // 2. SELECT * FROM cars WHERE cars LIKE '%Audi%' (ALL Audis)
            var audiList = from car in cars where car.Contains("Audi") select car;
            foreach (var audis in audiList)
            {
                Console.WriteLine(audis);
            }
        }

        static public void BasicLinqNumbersExamples()
        {
            List<int> numbers = new List<int> { 1,2,3,4,5,6,7,8,9};

            // Each numbers multiplied by 3 and take all numers, but 9
            // Order numbers by Ascending values
            var processedList =
                numbers
                    .Select(num => num * 3)
                    .Where(num => num != 9)
                    .OrderBy(num => num);
            foreach (var number in processedList)
            {
                Console.WriteLine(number);
            }
        }

        static public void BasicLinqSearchExamples()
        {
            List<string> textList = new List<string> 
            { 
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"
            };

            // 1. Find First Element of all elements
            var firstElement = textList.First();

            // 2. First Element that is 'C'
            var cElement = textList.First(text => text == "c");

            // 3. First element that contains 'j'
            var jElement = textList.First(text => text.Contains("j"));

            // 4. First element that contains 'z' or default
            var zElement = textList.FirstOrDefault(text => text.Contains("z"));

            // 5. Last or Default Element contains 'z'
            var zLastElement = textList.LastOrDefault(text => text.Contains("z"));

            // 6. Single Values
            var singleElement = textList.Single();
            var singleDefaultElement = textList.SingleOrDefault();

            // 7.
            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEvenNumbers = { 2, 6, 0 };

            // Obtain 4 and 8
            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers);

        }

        static public void BasicLinqMultipleSelects()
        {
            // SELECT MANY
            string[] myOpinions =
            {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3",
            };

            var myOpinionsSelect = myOpinions.SelectMany(opinion => opinion.Split(","));
            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new Employee[]
                    {
                        new Employee()
                        {
                            Id = 1,
                            Name = "Marty",
                            Email = "Marty@gmail.com",
                            Salary = 30000
                        },
                        new Employee()
                        {
                            Id = 2,
                            Name = "Mauri",
                            Email = "Mauri_Maincraft@gmail.com",
                            Salary = 32000
                        },
                        new Employee()
                        {
                            Id = 3,
                            Name = "Pepe",
                            Email = "PepMaster@gmail.com",
                            Salary = 31000
                        }
                    }
                },
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 2",
                    Employees = new Employee[]
                    {
                        new Employee()
                        {
                            Id = 4,
                            Name = "Ana",
                            Email = "Ana@gmail.com",
                            Salary = 32000
                        },
                        new Employee()
                        {
                            Id = 5,
                            Name = "Maria",
                            Email = "Maria_Strike@gmail.com",
                            Salary = 35000
                        },
                        new Employee()
                        {
                            Id = 6,
                            Name = "Martha",
                            Email = "LisboaCat@gmail.com",
                            Salary = 31500
                        }
                    }
                }
            };

            // Obtain all Employees of all enterprises
            var employeesList = enterprises.SelectMany(enterprise => enterprise.Employees);

            // Know If a list is empty
            bool hasEnterprises = enterprises.Any();

            bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any());

            // All enterprises at leat has an employee with more than 10000 of salary
            bool employeeSalaryMoreThan1000 =
                enterprises.Any(enterprise =>
                    enterprise.Employees.Any(employee => employee.Salary >= 10000));
        }

        static public void BasicLinqCollections()
        {
            var firstList = new List<string> { "a", "b", "c"};
            var secondList = new List<string> { "a", "c", "d"};

            // Inner Join
            var allList = from element in firstList
                          join element2 in secondList
                          on element equals element2
                          select new { element, element2 };
            // Iner Join, other way
            var allList2 = firstList.Join(
                secondList,
                element => element,
                element2 => element2,
                (element, element2) => new { element, element2 });

            // Outter Join - Left
            var leftOutterJoin = from element in firstList
                                 join secondElement in secondList
                                 on element equals secondElement
                                 into temporalList
                                 from temporalElement in temporalList.DefaultIfEmpty()
                                 where element != temporalElement
                                 select new { Element = element };   
            
            var leftOuttterJoinSimple = from element in firstList
                                        from secondElement in secondList.Where(s=> s == element).DefaultIfEmpty()
                                        select new {Element = element, SecondElement = secondElement };

            // Outter Join - Right
            var rightOutterJoin = from secondElement in secondList
                                 join element in firstList
                                 on secondElement equals element
                                 into temporalList
                                 from temporalElement in temporalList.DefaultIfEmpty()
                                 where secondElement != temporalElement
                                 select new { Element = secondElement };

            // Union Join
            var unionList = leftOutterJoin.Union(rightOutterJoin);
        }

        static public void BasicLinqSkipTake()
        {
            var myList = new[]
            {
                1,2,3,4,5,7,8,9,10
            };

            // Skip - Saltar hasta...

            var skipTwoFirstValues = myList.Skip(2); // 3,4,5,6,7,8,9,10

            var skipLastTwoValues = myList.SkipLast(2); // 1,2,3,4,5,6,7,8

            var skipWhile = myList.SkipWhile(num => num < 4); // 4,5,6,7,8

            // Take - Tomar

            var takeTwoFirstValues = myList.Take(2); // 1,2

            var takeLastTwoValues = myList.TakeLast(2); // 9,10

            var takeWhile = myList.TakeWhile(num => num < 4); // 1,2,3

        }

        // Paging with skip & take
        static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultPerPage)
        {
            int startIndex = (pageNumber - 1) * resultPerPage;
            return collection.Skip(startIndex).Take(resultPerPage);
        }

        // Variable
        static public void BasicLinqVariable()
        {
            int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var aboutAverage = from number in numbers
                               let average = numbers.Average()
                               let nSquare = Math.Pow(number, 2)
                               where nSquare > average
                               select number;
            Console.WriteLine($"Average: {numbers.Average()}");
            foreach (var number in aboutAverage)
            {
                Console.WriteLine($"Query: Number: {number} Square: {Math.Pow(number,2)}");
            }
        }

        //Zip - Intercalar
        static public void BasicZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "one", "two", "three", "four", "five" };
            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers,(number,word) => number + "=" + word);
            // { "1 = one", "2 = two", "3 = three" ...}
        }

        // Repeat & Range
        static public void BasicRepeatRangeLinq()
        {
            // Generate collection 1 to 1000 - range
            IEnumerable<int> first1000 = Enumerable.Range(0, 1000);
            var aboveAverage = from number in first1000
                               select number;
            // Repeat value N times
            IEnumerable<string> fiveXs = Enumerable.Repeat("X", 5); // {x, x, x, x, x}

        }

        static public void studentsLinq()
        {
            var classroom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Martin",
                    Grade = 90,
                    Certified = true
                },
                new Student
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 50,
                    Certified = false
                },
                new Student
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 98,
                    Certified = true
                },
                new Student
                {
                    Id = 4,
                    Name = "Alvaro",
                    Grade = 10,
                    Certified = false
                },
                new Student
                {
                    Id = 5,
                    Name = "Pedro",
                    Grade = 50,
                    Certified = true
                }
            };

            var certifiedStudent = from student in classroom
                                   where student.Certified == true
                                   select student;

            var notCertifiedStudent = from student in classroom
                                      where student.Certified != true
                                      select student;

            var approvedStudentName = from student in classroom
                                  where student.Grade >= 50 && student.Certified
                                  select student.Name;

        }

        // All
        static public void BasicAllLinq()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            bool allSmallerThanTen = numbers.All(numbers => numbers <= 10); // true

            bool allBiggerThanTwo = numbers.All(numbers => numbers >= 2); // false

            var emptyList = new List<int>();
            bool numbersAreGreaterThan = numbers.All(numbers => numbers >= 0); // True - Aunque este vacia
        }

        // Aggregate
        static public void BasicAggregateLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Sum all numbers
            int sum = numbers.Aggregate((prevSum, current)=> prevSum + current);

            string[] words = { "Hello", "My", "Name", "Is", "Ezreal" };
            string greeting = words.Aggregate((prevGreeting, current) => prevGreeting + current);
            // "", "Hello",
            // "Hello", "My"
            // "Hello My", "Name"
            // ...

        }

        // Distinct
        static public void BasicDistinctLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 4, 3, 2, 1 };
            IEnumerable<int> distinctValues = numbers.Distinct();
        }

        // GroupBy
        static public void BasicGroupByLinq()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Only even numbers and generate two groups
            var groupNumber = numbers.GroupBy(x => x % 2 == 0);

            foreach ( var group in groupNumber)
            {
                foreach (var value in group) {
                    Console.WriteLine(value); // 1,3,5,7,9... 2,4,6,8 (first odd, second even)
                }
            }

            // Another example 
            var classroom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Martin",
                    Grade = 90,
                    Certified = true
                },
                new Student
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 50,
                    Certified = false
                },
                new Student
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 98,
                    Certified = true
                },
                new Student
                {
                    Id = 4,
                    Name = "Alvaro",
                    Grade = 10,
                    Certified = false
                },
                new Student
                {
                    Id = 5,
                    Name = "Pedro",
                    Grade = 50,
                    Certified = true
                }
            };
            var certifiedQuery = classroom.GroupBy(student => student.Certified);

            // 2 groups
            // 1.- Not Certified Students
            // 2.- Certified Students
            foreach (var group in certifiedQuery)
            {
                Console.WriteLine($"----- {group.Key} -----" );
                foreach (var value in group)
                {
                    Console.WriteLine(value.Name); // 1,3,5,7,9... 2,4,6,8 (first odd, second even)
                }
            }

        }

        static public void relationsLinq()
        {
            List<Post> posts = new List<Post>() { 
                new Post
                {
                    Id=1,
                    Title = "My First Post",
                    Content = "My First Content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 1,
                            Created = DateTime.Now,
                            Title = "My first Comment Title",
                            Content = "My first Content Comment"
                        },
                        new Comment()
                        {
                            Id = 2,
                            Created = DateTime.Now,
                            Title = "My second Comment Title",
                            Content = "My second Content Comment"
                        }
                    }
                },
                new Post
                {
                    Id=2,
                    Title = "My Second Post",
                    Content = "My Second Content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 3,
                            Created = DateTime.Now,
                            Title = "My new Comment Title",
                            Content = "My new Content Comment"
                        },
                        new Comment()
                        {
                            Id = 4,
                            Created = DateTime.Now,
                            Title = "My Other Comment Title",
                            Content = "My Other Content Comment"
                        }
                    }
                }
            };

            var commentsContent = posts.SelectMany(
                post => post.Comments,
                    (post, comment) => new {PostId = post.Id, CommentContent = comment.Content});
        }

    }
}