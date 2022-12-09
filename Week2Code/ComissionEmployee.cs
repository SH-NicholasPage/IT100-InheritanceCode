using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Code
{
    public class CommissionEmployee : Employee
    {
        public double HourlyPay { get; private set; }
        public float CommissionRate { get; private set; } = 0.1f;

        //Default constructor. Does nothing, but does allow construction of a SalaryEmployee
        //  without arguments.
        public CommissionEmployee() { }

        //Non-default constructor (takes parameters and has a call to its base class' constructor)
        public CommissionEmployee(int employeeNum, String name, String position, double hourlyPay, float commissionRate)
            : base(employeeNum, name, position)// <--- the call to the base constructor
        {
            HourlyPay = hourlyPay;
            CommissionRate = commissionRate;
        }

        //This method is overriding the DescribeSelf() method that exists in its parent.
        //If an instance of CommissionEmployee calls DescribeSelf(), this method will execute
        //  instead of the one in its parent.
        public override void DescribeSelf()
        {
            Console.WriteLine($"This is commission employee {EmployeeNum}. Their commission is {CommissionRate * 100}%");
        }

        //Instance method
        public void IncreaseCommissionRate(float increaseAmount)
        {
            CommissionRate += increaseAmount;
        }
    }
}
