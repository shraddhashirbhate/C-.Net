using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQuery2
{
   
    class Program
    {
        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();
        static void Main1(string[] args)
        {
            AddRecs();

            /*If u are sleecting whole object then there is no need to write .SELECT*/

            var emps = lstEmp.Where(emp => emp.Basic > 11000);
            var emps2 = lstEmp.Where(emp => emp.Basic > 11000).Select(emp=>emp);
           // var emps3 = lstEmp.Where(emp => emp.Basic > 11000).Select(emp => { emp.Name, emp.Basic  });
           
            /*Will tyhe give u the same o/p*/
            var emps4 = lstEmp.Select(emp => emp).Where(emp => emp.Basic > 11000);
            var emps5 = lstEmp.Where(emp => emp.Basic > 11000).Select(emp => emp);
            //var emps6 = lstEmp.Select(emp => emp.Name).Where(emp => emp.Basic > 11000);


            foreach (var emp in emps4) {
                Console.WriteLine(emp.Name+ ", " +emp.Basic);
            }

            
            Console.ReadLine();

        }

        static void Main2(string[] args)
        {
            AddRecs();

            //var emps = lstEmp.OrderBy(emp => emp.Name).Where(emp => emp.Basic >10000);
            var emps = lstEmp.OrderByDescending(emp => emp.Name).Where(emp => emp.Basic > 10000);


            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + ", " + emp.Basic);
            }


            Console.ReadLine();

        }


        //Joins Main
        static void Main3(string[] args)
        {
            AddRecs();

            var emps = from emp in lstEmp
                       join dept in lstDept
                        on emp.DeptNo equals dept.DeptNo
                       select new { dept.DeptName, emp.Name };

            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name );
            }


            Console.ReadLine();

        }


        public static void AddRecs()
        {
            lstDept.Add(new Department { DeptNo = 10, DeptName = "SALES" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 40, DeptName = "HR" });

            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vikas", Basic = 11000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }
    }

    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }
        //public override string ToString()
        //{
        //    string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString();
        //    return s;
        //}
    }
}
