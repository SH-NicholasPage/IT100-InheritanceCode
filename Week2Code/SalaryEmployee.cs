using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Week2Code
{
    internal class SalaryEmployee : Employee
    {
        public double YearlyPay { get; private set; }

        //Default constructor. Does nothing, but does allow construction of a SalaryEmployee
        //  without arguments.
        public SalaryEmployee() { }

        //Non-default constructor (takes parameters and has a call to its base class' constructor)
        public SalaryEmployee(int employeeNum, String name, String position, double yearlyPay)
            : base(employeeNum, name, position)// <--- the call to the base constructor
        {
            YearlyPay = yearlyPay;
        }

        //This method is overriding the DescribeSelf() method that exists in its parent.
        //If an instance of SalaryEmployee calls DescribeSelf(), this method will execute
        //  instead of the one in its parent.
        public override void DescribeSelf()
        {
            Console.WriteLine($"This is salary employee {EmployeeNum}. Their yearly pay is {YearlyPay}");
        }
    }
}
