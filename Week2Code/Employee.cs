using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Code
{
    public class Employee
    {
        //The properties that any classes that inherit Employee will get
        public int EmployeeNum { get; }
        public String Name { get; private set; }
        public String Position { get; private set; }

        //Default constructor (generates default values)
        public Employee() 
        {
            EmployeeNum = Random.Shared.Next(0, Int32.MaxValue);
            Name = "Unknown";
            Position = "not defined";
        }

        //Non-default constructor
        public Employee(int employeeNum, string name, string position)
        {
            EmployeeNum = employeeNum;
            Name = name;
            Position = position;
        }

        //A method that can be overridden by a derived class
        //Method types that can be overridden: virtual, abstract, override
        public virtual void DescribeSelf()
        {
            //String interpolated WriteLine
            Console.WriteLine($"This is employee {EmployeeNum}. Their name is {Name} and position is {Position}.");
        }
    }
}
