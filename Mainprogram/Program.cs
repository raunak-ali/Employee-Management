using EmployeeEntity;
namespace EmployeePLs{

    public class Program  {  
    public static void Main(string[] args)
    {
      EmployeeBLL.EmployeeBLL.setlist();//

        int choice;
        do
        {
            PrintMenu();
            Console.WriteLine("Enter Choice :");
            choice = Int32.Parse(Console.ReadLine());
            //   Console.WriteLine(Directory.GetCurrentDirectory() + "");

            switch (choice)
            {
                case 1:
                    AddEmployee();
                    break;
                case 2:
                    DeleteEmployee();
                    break;
                case 3:
                    ListAllEmployees();
                    break;
                case 4:
                    SearchEmployeeByID();
                    break;
                case 5:
                    UpdateEmployee();
                    break;
                case 6:
                   // SetSerialization();
                    break;
                case 7:
                    return;
                   
                default:
                //SetSerialization();
                    break;
            }

        } while ((choice > 0 && choice < 7));



    }
    //private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    //{
    //    SetSerialization();
    //}

    private static void PrintMenu()
    {
        Console.WriteLine("\n***********Hospital Management System ***********");
        Console.WriteLine("1. Add Employee");
        Console.WriteLine("2. Delete Employee");
        Console.WriteLine("3. Get all Employee Details");
        Console.WriteLine("4. Search Employee");
        Console.WriteLine("5. Update Employee");
        Console.WriteLine("6. Serialize the  Employee Information");
        Console.WriteLine("7. Exit");


    }


    private static void AddEmployee()
    {
        try
        {
            Employee newEmployee = new Employee();
            Console.WriteLine("Enter Employee ID :");
            newEmployee.EmployeeID = Console.ReadLine();
            Console.WriteLine("Enter Employee Name :");
            newEmployee.EmployeeName = Console.ReadLine();
            Console.WriteLine("Enter PhoneNumber :");
            newEmployee.Phone = Console.ReadLine();
            bool EmployeeAdded = EmployeeBLL.EmployeeBLL.AddEmployeeBL(newEmployee);
            if (EmployeeAdded)
                Console.WriteLine("Employee Added");
            else
                Console.WriteLine("Employee not Added");
        }
        catch (HMSException.HMSException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void ListAllEmployees()
    {
        try
        {
            List<Employee> EmployeeList = EmployeeBLL.EmployeeBLL.GetAllEmployeesBL();
            if (EmployeeList != null && EmployeeList.Count > 0)
            {
                Console.WriteLine("******************************************************************************");
                Console.WriteLine("EmployeeID\t\tName\t\tPhoneNumber");
                Console.WriteLine("******************************************************************************");
                foreach (Employee Employee in EmployeeList)
                {
                    Console.WriteLine("{0}\t\t{1}\t\t{2}", Employee.EmployeeID, Employee.EmployeeName, Employee.Phone);
                }
                Console.WriteLine("******************************************************************************");

            }
            else
            {
                Console.WriteLine("No Employee Details Available");
            }
        }
        catch (HMSException.HMSException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void UpdateEmployee()
    {
        try
        {
            string updateEmployeeID;
            Console.WriteLine("Enter EmployeeID to Update Details:");
            updateEmployeeID = Console.ReadLine();
            Employee updatedEmployee = EmployeeBLL.EmployeeBLL.SearchEmployeeBL(updateEmployeeID);
            if (updatedEmployee != null)
            {
                Console.WriteLine("Update Employee Name :");
                updatedEmployee.EmployeeName = Console.ReadLine();
                Console.WriteLine("Update PhoneNumber :");
                updatedEmployee.Phone = Console.ReadLine();
                bool EmployeeUpdated = EmployeeBLL.EmployeeBLL.UpdateEmployeeBL(updatedEmployee);
                if (EmployeeUpdated)
                    Console.WriteLine("Employee Details Updated");
                else
                    Console.WriteLine("Employee Details not Updated ");
            }
            else
            {
                Console.WriteLine("No Employee Details Available");
            }


        }
        catch (HMSException.HMSException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void SearchEmployeeByID()
    {
        try
        {
            string searchEmployeeID;
            Console.WriteLine("Enter EmployeeID to Search:");
            searchEmployeeID = Console.ReadLine();
            Employee searchEmployee = EmployeeBLL.EmployeeBLL.SearchEmployeeBL(searchEmployeeID);
            if (searchEmployee != null)
            {
                Console.WriteLine("******************************************************************************");
                Console.WriteLine("EmployeeID\t\tName\t\tPhoneNumber");
                Console.WriteLine("******************************************************************************");
                Console.WriteLine("{0}\t\t{1}\t\t{2}", searchEmployee.EmployeeID, searchEmployee.EmployeeName, searchEmployee.Phone);
                Console.WriteLine("******************************************************************************");
            }
            else
            {
                Console.WriteLine("No Employee Details Available");
            }

        }
        catch (HMSException.HMSException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void DeleteEmployee()
    {
        try
        {
            string deleteEmployeeID;
            Console.WriteLine("Enter EmployeeID to Delete:");
            deleteEmployeeID = Console.ReadLine();
            bool Employeedeleted = EmployeeBLL.EmployeeBLL.DeleteEmployeeBL(deleteEmployeeID);
            if (Employeedeleted)
                Console.WriteLine("Employee Deleted");
            else
                Console.WriteLine("Employee not Deleted ");


        }
        catch (HMSException.HMSException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void SetSerialization()
    {
        EmployeeBLL.EmployeeBLL.SetSerialization();
    }



}

}
