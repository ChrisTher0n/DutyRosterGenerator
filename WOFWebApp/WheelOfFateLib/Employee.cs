using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFateLib
{
    public class EmployeeContainer: IEnumerable
    {
        private List<Employee> listOfEmployees;
        private List<String> defaultNamesList = new List<string>() { "Beth", "Bell", "Margot", "Darell", "Claudine", "Ian", "Argelia", "Ernie", "Tatiana", "Cynthia" };
        private int nextEmployeeNum = 1; //Start employee numbers at 1
        Random myRndGen = new Random(); //Will re-use this so make it class variable

        #region Public methods
        /// <summary>
        /// Default constuctor. Initialises a default list of 10 employees
        /// </summary>
        public EmployeeContainer()
        {
            listOfEmployees = new List<Employee>();
            InitDefaultList();
        }

        /// <summary>
        /// Returns a random Employee from listOfEmployees
        /// </summary>
        /// <returns>Employee</returns>
        public Employee GetRandomEmployee()
        {
            Employee retEng;

            int rndIndex = myRndGen.Next(listOfEmployees.Count);
            retEng = listOfEmployees[rndIndex];

            return retEng;
        }

        public void UpdateShiftCount(int empNum)
        {
            listOfEmployees.Where(emp => emp.EmployeeNum == empNum).First().ShiftsWorked++;
        }

        /// <summary>
        /// Public Enumerator
        /// </summary>
        /// <returns>IEnumertor for EmployeeContainer</returns>
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)listOfEmployees).GetEnumerator();
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Private method to initialize default list of 10 employees
        /// </summary>
        private void InitDefaultList()
        {
            foreach (String name in defaultNamesList)
            {
                AddEmployee(name);
            }
        }

        /// <summary>
        /// Method to add entry to back of list of employees
        /// Next Employee number will automatically be used
        /// </summary>
        /// <param name="_name">Name of employee to add</param>
        private void AddEmployee(string name)
        {
            Employee toAdd = new Employee(name, nextEmployeeNum++);
            listOfEmployees.Add(toAdd);
        }
        #endregion

    }

    public class Employee
    {
        //Private class variables
        private string name;
        private int employeeNum;
        private int shiftsWorked;

        //Public attributes
        public string Name => name;
        public int EmployeeNum => employeeNum;
        public int ShiftsWorked
        {
            get => shiftsWorked;
            set => shiftsWorked = value;
        }

        /// <summary>
        /// Employee public constructor
        /// </summary>
        /// <param name="empName">Employee name</param>
        /// <param name="empNum">Unique employee number</param>
        public Employee(string empName,int empNum)
        {
            name = empName;
            employeeNum = empNum;
            shiftsWorked = 0;
        }
    }
}
