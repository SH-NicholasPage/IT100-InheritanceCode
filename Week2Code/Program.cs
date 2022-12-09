using System.Runtime.InteropServices;

namespace Week2Code
{
    public class Program
    {
        public static void Main()
        {
            new Program().Run();
        }

        private void Run()
        {
            //Instantiate an Employee object
            Employee emp1 = new Employee();
            //Instantiate n SalaryEmployee object
            SalaryEmployee salEmp1 = new SalaryEmployee();
            //Instantiate a CommissionEmployee object
            CommissionEmployee comEmp1 = new CommissionEmployee();

            IdentifyType(emp1);
            Console.WriteLine("----------");
            IdentifyType(salEmp1);
            Console.WriteLine("----------");
            IdentifyType(comEmp1);
            Console.WriteLine("----------");

            Employee salEmp2 = new SalaryEmployee();
            Employee comEmp2 = new CommissionEmployee();
            //SalaryEmployee emp2 = new Employee();//INVALID
            //CommissionEmployee emp2 = new Employee();//INVALID

            IdentifyType(salEmp2);
            Console.WriteLine("----------");
            IdentifyType(comEmp2);
            Console.WriteLine("----------");

            //We are able to put Employees AND anything that inherits Employee into this list
            List<Employee> myEmployees = GenerateRandomEmployees();
            for(int i = 0; i < Math.Min(10, myEmployees.Count); i++)
            {
                Console.WriteLine($"Identifying employee {i + 1}/{Math.Min(10, myEmployees.Count)}");
                IdentifyType(myEmployees[i]);
                Console.WriteLine("----------");
            }

            GiveCommissionEmployeesRaises(myEmployees);

            //If DescribeSelf() is overloaded, it will call the overridden method
            emp1.DescribeSelf();
            salEmp1.DescribeSelf();
            comEmp1.DescribeSelf();

            foreach(Employee emp in myEmployees)
            {
                //Due to late-binding, the DescribeSelf() that is called will be the overridden one
                //  that belongs to the class. I.e. if SalaryEmployee is emp and SalaryEmployee is overriding,
                //  then DescribeSelf() will call the method instance that exists in the SalaryEmployee class.

                emp.DescribeSelf();
            }
        }

        private List<Employee> GenerateRandomEmployees()
        {
            int numToGenerate = Random.Shared.Next(5, 33);
            List<Employee> myEmpList = new List<Employee>();//A list that can hold Employees

            while(numToGenerate-- > 0)
            {
                //Generate a number between 0 and 2 and case it to a byte
                byte empToGenerate = (byte)Random.Shared.Next(0, 3);

                switch(empToGenerate)
                {
                    case 0://Normal Employee
                        myEmpList.Add(new Employee());
                        break;
                    case 1://Salary Employee
                        myEmpList.Add(new SalaryEmployee());
                        break;
                    case 2://Commission Employee
                        myEmpList.Add(new CommissionEmployee());
                        break;
                }
            }

            return myEmpList;
        }

        private void IdentifyType(Object obj)
        {
            //Is the object passed in an Employee?
            if(obj.GetType() == typeof(Employee))//Yes
            {
                Console.WriteLine(obj.GetType() + " is an Employee");
            }
            else//No
            {
                Console.WriteLine(obj.GetType() + " is not an Employee");
            }

            //Is the object passed in a SalaryEmployee?
            if (obj.GetType() == typeof(SalaryEmployee))//Yes
            {
                Console.WriteLine(obj.GetType() + " is a SalaryEmployee");
            }
            else//No
            {
                Console.WriteLine(obj.GetType() + " is not a SalaryEmployee");
            }

            //Is the object passed in a CommissionEmployee?
            if (obj.GetType() == typeof(CommissionEmployee))//Yes
            {
                Console.WriteLine(obj.GetType() + " is a CommissionEmployee");
            }
            else//No
            {
                Console.WriteLine(obj.GetType() + " is not a CommissionEmployee");
            }
        }

        private void GiveCommissionEmployeesRaises(List<Employee> employees)
        {
            //Iterate through the entire list of Employees
            foreach(Employee emp in employees)
            {
                //Is the Employee a CommissionEmployee?
                if(emp.GetType() == typeof(CommissionEmployee))
                {
                    //Cast the Employee object (emp) to a CommissionEmployee. We have to do this if we want
                    //  access to the fields and methods in CommissionEmployee. However,  we can only do
                    //  this cast if we are sure that emp is actually a CommissionEmployee (hence the check
                    //  above), otherwise it will throw an exception.
                    CommissionEmployee comEmp = (CommissionEmployee)emp;
                    comEmp.IncreaseCommissionRate(0.05f);
                    Console.WriteLine("Employee " + comEmp.EmployeeNum + " received a raise!");
                }
            }
        }
    }
}