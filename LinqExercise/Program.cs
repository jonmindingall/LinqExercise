using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            var sum = numbers.Sum();
            var average = numbers.Average();
            Console.WriteLine($"The sum of the numbers is {sum}.");
            Console.WriteLine($"The average of the numbers is {average}.");
            Console.WriteLine("______________");


            

            //Order numbers in ascending order and decsending order. Print each to console.
            var ascendNumbers = numbers.OrderBy(num => num);
            foreach (var num in ascendNumbers)
            {
                Console.WriteLine(num);
            }
            
            Console.WriteLine("_____________");
            var descendNumbers = numbers.OrderByDescending(x => x);
            foreach (var x in descendNumbers)
            {
                Console.WriteLine(x);
            }

            //Print to the console only the numbers greater than 6
            Console.WriteLine("_____________");
            var greaterThanSix = numbers.Where(num => num > 6);
            foreach (var thing in greaterThanSix)
            {
                Console.WriteLine(thing);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("_________");
            foreach (var item in descendNumbers.Take(4))    
            {
                Console.WriteLine(item);
            }



            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("___________");
            numbers[4] = 43;
            var descendingNumbers = numbers.OrderByDescending(x => x);
            foreach (var x in descendingNumbers)
            {
                Console.WriteLine(x);
            }

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var filtered = employees.Where(person => person.FirstName.StartsWith('C') ||
                                                     person.FirstName.StartsWith('S'));
            filtered.OrderBy(person => person.FirstName);
            foreach (var item in filtered)
            {
                Console.WriteLine(item.FullName);
            }
            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("________");
            var overTwentySix = employees.Where(person => person.Age > 26)
                .OrderBy(person => person.Age).ThenBy(person => person.FirstName);

            foreach (var item in overTwentySix)
            {
                Console.WriteLine($"{item.Age},  {item.FullName}");
            }


            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine("__________");
            var ageOfEmployee = employees.Where(ageP => ageP.YearsOfExperience <= 10 && ageP.Age > 35);
            var sumOfYOE = ageOfEmployee.Sum(ageP => ageP.YearsOfExperience);
            var avgOfYOE = ageOfEmployee.Average(ageP => ageP.YearsOfExperience);
            Console.WriteLine($"Sum: {sumOfYOE} ; Average: {avgOfYOE}");

            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Jon", "Mindingall", 43, 1)).ToList();
            var orderedNewEmployees = employees.OrderBy(x => x.LastName);
            foreach (var item in orderedNewEmployees)
            {
                Console.WriteLine(item.LastName);
            }
            
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
